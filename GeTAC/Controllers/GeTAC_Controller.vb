Imports System.IO
Imports System.Xml.Serialization
Imports GeTAC.FormValues
Imports GeTAC.formGeTAC
Imports Microsoft.Win32
Imports System.Environment
Imports SharpKml.Dom
Imports SharpKml.Base
Imports SharpKml.Engine

Public Class GeTAC_Controller

    Shared Function GetFormValuesFileName() As String
        Return System.IO.Directory.GetCurrentDirectory & "\FormValues.xml"
    End Function

    Shared Function DeserializeFormValuesXML(ByVal path As String) As FormValues
        Dim serializer As XmlSerializer = New XmlSerializer(GetType(FormValues))
        Dim reader As StreamReader = New StreamReader(path)
        Dim returnObj = serializer.Deserialize(reader)
        reader.Close()
        Return returnObj
    End Function

    Shared Sub SerializeFormValuesXML(ByVal path As String, ByVal values As FormValues)
        Dim serializer As XmlSerializer = New XmlSerializer(GetType(FormValues))
        Dim writer As StreamWriter = New StreamWriter(path)
        serializer.Serialize(writer, values)
        writer.Close()
    End Sub

    Shared Sub FillMainForm(ByRef mainForm As formGeTAC, ByVal values As FormValues)
        mainForm.txtBxLabelLat.Text = If(values.StartPointLatDirection = Nothing, "N", latDirection(values.StartPointLatDirection))
        mainForm.txtBxLabelLon.Text = If(values.StartPointLonDirection = Nothing, "W", lonDirection(values.StartPointLonDirection))
        mainForm.txtBoxLabelLatScanArea.Text = If(values.ScanAreaLatDirection = Nothing, "N", latDirection(values.ScanAreaLatDirection))
        mainForm.txtBoxLabelLonScanArea.Text = If(values.ScanAreaLonDirection = Nothing, "E", lonDirection(values.ScanAreaLonDirection))
        mainForm.upDwnDegLat.Value = If(values.StartPointLatDegree = Nothing, 29, values.StartPointLatDegree)
        mainForm.upDwnDegLon.Value = If(values.StartPointLonDegree = Nothing, 88, values.StartPointLonDegree)
        mainForm.upDwnMinLat.Value = If(values.StartPointLatMinute = Nothing, 49.297, values.StartPointLatMinute)
        mainForm.upDwnMinLon.Value = If(values.StartPointLonMinute = Nothing, 52.737, values.StartPointLonMinute)
        mainForm.upDwnDegLatScanArea.Value = If(values.ScanAreaLatDegree = Nothing, 0, values.ScanAreaLatDegree)
        mainForm.upDwnDegLonScanArea.Value = If(values.ScanAreaLonDegree = Nothing, 0, values.ScanAreaLonDegree)
        mainForm.upDwnMinLatScanArea.Value = If(values.ScanAreaLatMinute = Nothing, 5, values.ScanAreaLatMinute)
        mainForm.upDwnMinLonScanArea.Value = If(values.ScanAreaLonMinute = Nothing, 5, values.ScanAreaLonMinute)
        mainForm.trkBarStep.Value = If(values.ScanStep = Nothing, 3, values.ScanStep)
        mainForm.trkBarDwell.Value = If(values.Dwell = Nothing, 100, values.Dwell)
        mainForm.trkBarHeading.Value = If(values.Heading = Nothing, 0, values.Heading)
        mainForm.trkBarRange.Value = If(values.Range = Nothing, 16, values.Range)
        mainForm.trkBarTilt.Value = If(values.Tilt = Nothing, 14, values.Tilt)
        mainForm.lblStep.Text = mainForm.trkBarStep.Value * 0.5 & " Min"
        mainForm.lblTilt.Text = mainForm.trkBarTilt.Value & " Deg"
        mainForm.lblRange.Text = LinearToLog.ConvertLinearToLog(mainForm.trkBarRange.Value) / 1000 & " km"
        mainForm.lblHeading.Text = mainForm.trkBarHeading.Value & " Deg"
        mainForm.lblDwell.Text = mainForm.trkBarDwell.Value / 10 & " Sec"
        mainForm.chkBoxAutoRange.Checked = If(values.AutoRange = Nothing, False, values.AutoRange)
        mainForm.chkBoxOnTop.Checked = If(values.OnTop = Nothing, True, values.OnTop)

    End Sub

    Shared Function GoogleEarthIsInstalled() As Boolean

        If Registry.CurrentUser.OpenSubKey("Software\Google\Google Earth Plus") Is Nothing Then
            ' Key doesn't exist
            Return False
        Else
            ' Key existed
            Return True
        End If
    End Function

    Shared Function getCacheLocation() As String
        Dim key = Registry.CurrentUser.OpenSubKey("Software\Google\Google Earth Plus")
        Dim path = key.GetValue("CachePath") & "\unified_cache_leveldb_leveldb2"
        Return path
    End Function

    Shared Function GetFolderSize(ByVal DirPath As String, Optional IncludeSubFolders As Boolean = True) As Long

        Dim lngDirSize As Long
        Dim objFileInfo As FileInfo
        Dim objDir As DirectoryInfo = New DirectoryInfo(DirPath)
        Dim objSubFolder As DirectoryInfo

        Try

            'add length of each file
            For Each objFileInfo In objDir.GetFiles()
                lngDirSize += objFileInfo.Length
            Next

            'call recursively to get sub folders
            'if you don't want this set optional
            'parameter to false 
            If IncludeSubFolders Then
                For Each objSubFolder In objDir.GetDirectories()
                    lngDirSize += GetFolderSize(objSubFolder.FullName)
                Next
            End If

        Catch Ex As Exception


        End Try

        Return lngDirSize
    End Function

    Shared Sub SaveCache(ByVal CachePath As String, ByVal DestinationPath As String, ByRef main As formGeTAC)
        Dim objFileInfo As FileInfo
        Dim objDir As DirectoryInfo = New DirectoryInfo(CachePath)

        main.Cursor = Cursors.WaitCursor
        For Each objFileInfo In objDir.GetFiles()
            Try
                objFileInfo.CopyTo(DestinationPath & "\" & objFileInfo.Name)
            Catch e As Exception
            End Try
        Next
        main.Cursor = Cursors.Default
    End Sub

    Shared Sub BuildKML(ByVal formValues As FormValues, Optional latitudeMultiplier As Integer = 0, Optional longitudeMultiplier As Integer = 0)
        Dim kml As Kml
        Dim folder As Folder
        Dim placemark1 As Placemark
        Dim placemark2 As Placemark
        Dim placemark3 As Placemark
        Dim linestring1 As LineString
        Dim linestring2 As LineString
        Dim point As Point
        Dim style1 As Style
        Dim style2 As Style
        Dim style3 As Style
        Dim coordinateCollection1 As CoordinateCollection
        Dim coordinateCollection2 As CoordinateCollection
        Dim point1 As Point
        Dim point2 As Point
        Dim point3 As Point
        Dim point4 As Point
        Dim lookAt As LookAt

        kml = New Kml()
        folder = New Folder()
        point = New Point()
        placemark1 = New Placemark()
        placemark2 = New Placemark()
        placemark3 = New Placemark()
        linestring1 = New LineString()
        linestring2 = New LineString()
        style1 = New Style()
        style2 = New Style()
        style3 = New Style()
        point1 = New Point()
        point2 = New Point()
        point3 = New Point()
        point4 = New Point()
        lookAt = New LookAt()

        coordinateCollection1 = New CoordinateCollection()
        point1.Coordinate = New Vector(DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute, formValues.StartPointLatDirection), _
                                       DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute, formValues.StartPointLonDirection), 0)
        point2.Coordinate = New Vector(DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute, formValues.StartPointLatDirection), _
                                       DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute, formValues.StartPointLonDirection) + _
                                       DecimalCoordinate(formValues.ScanAreaLonDegree, formValues.ScanAreaLonMinute, formValues.ScanAreaLonDirection), 0)
        point3.Coordinate = New Vector(DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute, formValues.StartPointLatDirection) + _
                                       DecimalCoordinate(formValues.ScanAreaLatDegree, formValues.ScanAreaLatMinute, formValues.ScanAreaLatDirection), _
                                       DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute, formValues.StartPointLonDirection) + _
                                       DecimalCoordinate(formValues.ScanAreaLonDegree, formValues.ScanAreaLonMinute, formValues.ScanAreaLonDirection), 0)
        point4.Coordinate = New Vector(DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute, formValues.StartPointLatDirection) + _
                                       DecimalCoordinate(formValues.ScanAreaLatDegree, formValues.ScanAreaLatMinute, formValues.ScanAreaLatDirection), _
                                       DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute, formValues.StartPointLonDirection), 0)
        coordinateCollection1.Add(point1.Coordinate)
        coordinateCollection1.Add(point2.Coordinate)
        coordinateCollection1.Add(point3.Coordinate)
        coordinateCollection1.Add(point4.Coordinate)
        coordinateCollection1.Add(point1.Coordinate)
        linestring1.Coordinates = coordinateCollection1
        linestring1.AltitudeMode = AltitudeMode.ClampToGround
        linestring1.Tessellate = True
        style1.Line = New LineStyle
        style1.Line.Color = New Color32(255, 0, 255, 255)
        style1.Line.Width = 3
        placemark1.AddStyle(style1)
        placemark1.Geometry = linestring1

        coordinateCollection2 = New CoordinateCollection()
        point1.Coordinate = New Vector(DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute + formValues.ScanStep / 4, formValues.StartPointLatDirection) + _
                                       latitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLatDirection), _
                                       DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute - formValues.ScanStep / 4, formValues.StartPointLonDirection) + _
                                       longitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLonDirection), 0)
        point2.Coordinate = New Vector(DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute + formValues.ScanStep / 4, formValues.StartPointLatDirection) + _
                                       latitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLatDirection), _
                                       DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute + formValues.ScanStep / 4, formValues.StartPointLonDirection) + _
                                       longitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLonDirection), 0)
        point3.Coordinate = New Vector(DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute - formValues.ScanStep / 4, formValues.StartPointLatDirection) + _
                                       latitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLatDirection), _
                                       DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute + formValues.ScanStep / 4, formValues.StartPointLonDirection) + _
                                       longitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLonDirection), 0)
        point4.Coordinate = New Vector(DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute - formValues.ScanStep / 4, formValues.StartPointLatDirection) + _
                                       latitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLatDirection), _
                                       DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute - formValues.ScanStep / 4, formValues.StartPointLonDirection) + _
                                       longitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLonDirection), 0)
        coordinateCollection2.Add(point1.Coordinate)
        coordinateCollection2.Add(point2.Coordinate)
        coordinateCollection2.Add(point3.Coordinate)
        coordinateCollection2.Add(point4.Coordinate)
        coordinateCollection2.Add(point1.Coordinate)
        linestring2.Coordinates = coordinateCollection2
        linestring2.AltitudeMode = AltitudeMode.ClampToGround
        linestring2.Tessellate = True
        style2.Line = New LineStyle
        style2.Line.Color = New Color32(255, 0, 255, 0)
        style2.Line.Width = 3
        placemark2.AddStyle(style2)
        placemark2.Geometry = linestring2


        point.Coordinate = New Vector(DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute, formValues.StartPointLatDirection) + _
                                      latitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLatDirection), _
                                      DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute, formValues.StartPointLonDirection) + _
                                      longitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLonDirection), 0)
        point.Extrude = True
        style3.Icon = New IconStyle
        style3.Icon.Icon = New IconStyle.IconLink(New Uri("http://maps.google.com/mapfiles/kml/shapes/donut.png"))
        style3.Icon.Scale = 0.75
        placemark3.Geometry = point
        placemark3.Visibility = True
        placemark3.AddStyle(style3)

        lookAt.Heading = formValues.Heading
        lookAt.Latitude = DecimalCoordinate(formValues.StartPointLatDegree, formValues.StartPointLatMinute, formValues.StartPointLatDirection) + _
                          latitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLatDirection)
        lookAt.Longitude = DecimalCoordinate(formValues.StartPointLonDegree, formValues.StartPointLonMinute, formValues.StartPointLonDirection) + _
                           longitudeMultiplier * DecimalCoordinate(0, formValues.ScanStep / 2, formValues.ScanAreaLonDirection)
        lookAt.Range = LinearToLog.ConvertLinearToLog(formValues.Range)
        lookAt.Tilt = formValues.Tilt



        folder.Name = "GeTAC"
        folder.AddFeature(placemark1)
        folder.AddFeature(placemark2)
        folder.AddFeature(placemark3)
        folder.Viewpoint = lookAt


        kml.Feature = folder

        Dim serializer As SharpKml.Base.Serializer
        serializer = New SharpKml.Base.Serializer()
        serializer.Serialize(kml)

        Dim appData As String = GetFolderPath(SpecialFolder.ApplicationData)
        If Not Directory.Exists(appData & "\GeTAC") Then Directory.CreateDirectory(appData & "\GeTAC")

        Dim writer As StreamWriter = New StreamWriter("C:\\Users\Boxx\AppData\Roaming\GeTAC\LinkKML.kml")
        writer.Write(serializer.Xml)
        writer.Close()
    End Sub

    Shared Sub OpenKML(ByVal path As String)
        Dim p As Process = Process.Start(path)
        p.WaitForInputIdle()

    End Sub

    Shared Function DecimalCoordinate(ByVal degree As Integer, ByVal minute As Double, Optional ByVal direction As LATDirection = FormValues.LATDirection.N) As Double
        Dim multiplier = If(direction = FormValues.LATDirection.N, 1, -1)
        Return multiplier * (degree + (minute / 60))
    End Function

    Shared Function DecimalCoordinate(ByVal degree As Integer, ByVal minute As Double, Optional ByVal direction As LONDirection = FormValues.LONDirection.E) As Double
        Dim multiplier = If(direction = FormValues.LONDirection.E, 1, -1)
        Return multiplier * (degree + (minute / 60))
    End Function

    Shared Sub CalculateScan(ByRef main As formGeTAC)
        Dim lat = (((main.upDwnDegLatScanArea.Value * 60) + (main.upDwnMinLatScanArea.Value)) / (main.trkBarStep.Value / 2))
        main.LatitudePoints = Math.Floor(lat) + 1

        Dim lon = (((main.upDwnDegLonScanArea.Value * 60) + (main.upDwnMinLonScanArea.Value)) / (main.trkBarStep.Value / 2))
        main.LongitudePoints = Math.Floor(lon) + 1

        main.PointsWarning = If(main.LatitudePoints * main.LongitudePoints > 600, True, False)
        main.ScanTooLarge = If(lon < 1 Or lat < 1, True, False)
    End Sub

    Shared Sub PointsOK(ByRef main As formGeTAC)
        main.txtBxColorPointsCheck.BackColor = Color.Green
    End Sub

    Shared Sub PointsOver(ByRef main As formGeTAC)
        main.txtBxColorPointsCheck.BackColor = Color.Yellow
    End Sub

    Shared Sub ScanOK(ByRef main As formGeTAC, ByVal totalPoints As Integer)
        main.lblTotalPoints.Text = "Points " & totalPoints
        main.txtBxColorPointsCheck.BackColor = Color.Green
        main.btnStart.Enabled = True
    End Sub

    Shared Sub ScanOVer(ByRef main As formGeTAC)
        main.lblTotalPoints.Text = "Points "
        main.txtBxColorPointsCheck.BackColor = Color.Red
        main.btnStart.Enabled = False
    End Sub

    Shared Function CalculateHour(ByVal seconds As Double) As Integer
        Return Math.Floor(seconds / 3600)
    End Function

    Shared Function CalculateMinute(ByVal seconds As Double) As Integer
        Dim Hour = Math.Floor(seconds / 3600)
        Dim Minute = (seconds / 3600) - Hour
        Return Math.Floor(Minute * 60)
    End Function

    Shared Function CalculateSecond(ByVal seconds As Double) As Integer
        Dim Hour = Math.Floor(seconds / 3600)
        Dim Minute = (seconds / 3600) - Hour
        Minute = Minute * 60
        Dim Sec = Minute - Math.Floor(Minute)
        Sec = Math.Floor(Sec * 60)

        Return Sec

    End Function

    Shared latDirection As String() = {"N", "S"}
    Shared lonDirection As String() = {"E", "W"}
End Class
