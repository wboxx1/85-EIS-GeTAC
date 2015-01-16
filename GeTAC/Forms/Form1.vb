Imports System.IO
Imports System.Environment
Imports SharpKml.Dom
Imports SharpKml.Base
Imports SharpKml.Engine
Imports GeTAC.FormValues
Imports GeTAC.GeTAC_Controller


Public Class formGeTAC
    Private mFormValues As FormValues
    Private mFormValuesFileName As String
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
       
        'Set up look and feel of window
        ApplicationLookAndFeel.UseTheme(Me)

        'Instanciate all local variables
        LocalVariableInstanciate()
        
        'Import form values
        ImportFormValues()

        'Populate Values to form
        PopulatFormValues()

        'Calculate Cache Size

        'Calculate Points and Time Required


    End Sub

    Private Sub LocalVariableInstanciate()
        mFormValues = New FormValues()
        mFormValuesFileName = New String("")
    End Sub

    Private Sub ImportFormValues()
        mFormValuesFileName = GeTAC_Controller.GetFormValuesFileName()
        mFormValues = GeTAC_Controller.DeserializeFormValuesXML(mFormValuesFileName)
    End Sub

    Private Sub PopulatFormValues()
        GeTAC_Controller.FillMainForm(Me, mFormValues)
    End Sub
    Sub runTest()
        Dim cmd, DefM As String
        Dim ClkPointLon, ClkPointLat As Double

        DefM = "TEST"
        ClkPointLat = 49.42164
        ClkPointLon = 7.60656

        cmd = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "UTF-8" & Chr(34) & "?>" & vbCrLf
        cmd &= "<kml xmlns=" & Chr(34) & "http://earth.google.com/kml/2.1" & Chr(34) & ">" & vbCrLf
        cmd &= "<Placemark>" & vbCrLf
        cmd &= "<name>Clickpoint</name>" & vbCrLf
        cmd &= "<description>" & DefM & "</description>" & vbCrLf
        cmd &= "<Point>" & vbCrLf
        cmd &= "<coordinates>" & ClkPointLon.ToString & "," & ClkPointLat.ToString & ",2000</coordinates>" & vbCrLf
        cmd &= "</Point>" & vbCrLf
        cmd &= "</Placemark>" & vbCrLf
        cmd &= "</kml>"
        Dim m_FileName As String = ""
        Try
            ' Return the path and name of a newly created Temporary
            '   file.
            m_FileName = Path.GetTempFileName()
            ' Create a FileInfo object to manipulate properties of 
            '   the created temporary file
            Dim myFileInfo As New FileInfo(m_FileName)
            ' Use the FileInfo object to set the Attribute property of this
            '   file to Temporary.
            myFileInfo.Attributes = FileAttributes.Temporary
            myFileInfo.Delete()
            m_FileName = m_FileName.Replace(myFileInfo.Extension, ".kml")
        Catch exc As Exception
            ' Warn the user if there is a problem
            MessageBox.Show("Unable to create a TEMP file or set its attributes.", "Google Earth Viewer", MessageBoxButtons.OK)
            Exit Sub
        End Try

        Dim st As Stream = File.Open(m_FileName, FileMode.Create, FileAccess.ReadWrite, FileShare.None)
        Dim sw As New StreamWriter(st)
        sw.AutoFlush = True
        sw.Write(cmd)
        sw.Close()
        st.Dispose()

        System.Diagnostics.Process.Start(m_FileName)
    End Sub

    Sub test2()
        Dim kml As kml
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

        kml = New kml()
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

        coordinateCollection1 = New CoordinateCollection()
        point1.Coordinate = New Vector(49.69398, 7.312933, 0)
        point2.Coordinate = New Vector(49.69398, 8.0796, 0)
        point3.Coordinate = New Vector(49.27732, 8.0796, 0)
        point4.Coordinate = New Vector(49.27732, 7.312933, 0)
        coordinateCollection1.Add(point1.Coordinate)
        coordinateCollection1.Add(point2.Coordinate)
        coordinateCollection1.Add(point3.Coordinate)
        coordinateCollection1.Add(point4.Coordinate)
        coordinateCollection1.Add(point1.Coordinate)
        linestring1.Coordinates = coordinateCollection1
        linestring1.altitudeMode = AltitudeMode.ClampToGround
        linestring1.Tessellate = True
        style1.Line = New LineStyle
        style1.Line.Color = New Color32(255, 0, 255, 255)
        style1.Line.Width = 3
        placemark1.AddStyle(style1)
        placemark1.Geometry = linestring1

        coordinateCollection2 = New CoordinateCollection()
        point1.Coordinate = New Vector(49.68148, 7.900436, 0)
        point2.Coordinate = New Vector(49.68148, 7.925436, 0)
        point3.Coordinate = New Vector(49.70649, 7.925436, 0)
        point4.Coordinate = New Vector(49.70649, 7.900436, 0)
        coordinateCollection2.Add(point1.Coordinate)
        coordinateCollection2.Add(point2.Coordinate)
        coordinateCollection2.Add(point3.Coordinate)
        coordinateCollection2.Add(point4.Coordinate)
        coordinateCollection2.Add(point1.Coordinate)
        linestring2.Coordinates = coordinateCollection2
        linestring2.altitudeMode = AltitudeMode.ClampToGround
        linestring2.Tessellate = True
        style2.Line = New LineStyle
        style2.Line.Color = New Color32(255, 0, 255, 0)
        style2.Line.Width = 3
        placemark2.AddStyle(style2)
        placemark2.Geometry = linestring2


        point.Coordinate = New Vector(49.69398, 7.312933)
        point.Extrude = True
        style3.Icon = New IconStyle
        style3.Icon.Icon = New IconStyle.IconLink(New Uri("http://maps.google.com/mapfiles/kml/shapes/donut.png"))
        style3.Icon.Scale = 0.75
        placemark3.Geometry = point
        placemark3.Visibility = True
        placemark3.AddStyle(style3)


        folder.Name = "MyHarvester"
        folder.AddFeature(placemark1)
        folder.AddFeature(placemark2)
        folder.AddFeature(placemark3)


        kml.Feature = folder

        Dim serializer As Serializer
        serializer = New Serializer()
        serializer.Serialize(kml)

        Dim appData As String = GetFolderPath(SpecialFolder.ApplicationData)
        Directory.CreateDirectory(appData & "\GeTAC")

        Dim writer As StreamWriter = New StreamWriter("C:\\Users\Boxx\AppData\Roaming\GeTAC\newKMLTest.kml")
        writer.Write(serializer.Xml)
        writer.Close()

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        test2()
    End Sub


    Private Sub txtBxLabelLat_MouseClick(sender As Object, e As MouseEventArgs) Handles txtBxLabelLat.MouseDown
        grpBxScanArea.Focus()
        Me.Refresh()
        Select Case txtBxLabelLat.Text
            Case "N"
                txtBxLabelLat.Text = "S"
            Case "S"
                txtBxLabelLat.Text = "N"
        End Select
    End Sub

    Private Sub txtBxLabelLon_MouseClick(sender As Object, e As MouseEventArgs) Handles txtBxLabelLon.MouseDown
        grpBxScanArea.Focus()
        Me.Refresh()
        Select Case txtBxLabelLon.Text
            Case "E"
                txtBxLabelLon.Text = "W"
            Case "W"
                txtBxLabelLon.Text = "E"
        End Select
    End Sub

    Private Sub txtBoxLabelLatScanArea_MouseDown(sender As Object, e As MouseEventArgs) Handles txtBoxLabelLatScanArea.MouseDown
        grpBxScanArea.Focus()
        Me.Refresh()
        Select Case txtBoxLabelLatScanArea.Text
            Case "N"
                txtBoxLabelLatScanArea.Text = "S"
            Case "S"
                txtBoxLabelLatScanArea.Text = "N"
        End Select
    End Sub

    Private Sub txtBoxLabelLonScanArea_MouseDown(sender As Object, e As MouseEventArgs) Handles txtBoxLabelLonScanArea.MouseDown
        grpBxScanArea.Focus()
        Me.Refresh()
        Select Case txtBoxLabelLonScanArea.Text
            Case "E"
                txtBoxLabelLonScanArea.Text = "W"
            Case "W"
                txtBoxLabelLonScanArea.Text = "E"
        End Select
    End Sub

    Private Sub TextBoxLabel1_MouseClick(sender As Object, e As MouseEventArgs)

    End Sub

    
    Private Sub trkBarStep_Scroll(sender As Object, e As EventArgs) Handles trkBarStep.Scroll
        Dim min = CDbl(trkBarStep.Value * 0.5)
        Me.lblStep.Text = min & " Min"
    End Sub

    Private Sub trkBarDwell_Scroll(sender As Object, e As EventArgs) Handles trkBarDwell.Scroll
        Dim sec = CDbl(trkBarDwell.Value / 10)
        Me.lblDwell.Text = sec & " Sec"
    End Sub

    Private Sub trkBarRange_Scroll(sender As Object, e As EventArgs) Handles trkBarRange.Scroll
        Dim km = LinearToLog.ConvertLinearToLog(trkBarRange.Value)
        Me.lblRange.Text = km / 1000 & " km"
    End Sub

    
    Private Sub trkBarTilt_Scroll(sender As Object, e As EventArgs) Handles trkBarTilt.Scroll
        Me.lblTilt.Text = trkBarTilt.Value & " Deg"
    End Sub

    Private Sub trkBarHeading_Scroll(sender As Object, e As EventArgs) Handles trkBarHeading.Scroll
        Me.lblHeading.Text = trkBarHeading.Value & " Deg"
    End Sub

    Private Sub formGeTAC_FormClosing(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        GeTAC_Controller.SerializeFormValuesXML(mFormValuesFileName, mFormValues)
        'Dim serializer As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(FormValues))
        'Dim writer As StreamWriter = New StreamWriter(GeTAC_Controller.GetFormValuesFileName)
        'serializer.Serialize(writer, mFormValues)
    End Sub

    Private Sub upDwn_ValueChanged(sender As Object, e As EventArgs) Handles upDwnDegLat.ValueChanged, upDwnDegLatScanArea.ValueChanged, _
                                                                                   upDwnDegLon.ValueChanged, upDwnDegLonScanArea.ValueChanged, _
                                                                                   upDwnMinLat.ValueChanged, upDwnMinLatScanArea.ValueChanged, _
                                                                                   upDwnMinLon.ValueChanged, upDwnMinLonScanArea.ValueChanged

        If sender.Equals(Me.upDwnDegLat) Then mFormValues.StartPointLatDegree = upDwnDegLat.Value
        If sender.Equals(Me.upDwnDegLatScanArea) Then mFormValues.ScanAreaLatDegree = upDwnDegLatScanArea.Value
        If sender.Equals(Me.upDwnDegLon) Then mFormValues.StartPointLonDegree = upDwnDegLon.Value
        If sender.Equals(Me.upDwnDegLonScanArea) Then mFormValues.ScanAreaLonDegree = upDwnDegLonScanArea.Value
        If sender.Equals(Me.upDwnMinLat) Then mFormValues.StartPointLatMinute = upDwnMinLat.Value
        If sender.Equals(Me.upDwnMinLatScanArea) Then mFormValues.ScanAreaLatMinute = upDwnMinLatScanArea.Value
        If sender.Equals(Me.upDwnMinLon) Then mFormValues.StartPointLonMinute = upDwnMinLon.Value
        If sender.Equals(Me.upDwnMinLonScanArea) Then mFormValues.ScanAreaLonMinute = upDwnMinLonScanArea.Value
    End Sub

    Private Sub trkBar_ValueChanged(sender As Object, e As EventArgs) Handles trkBarStep.ValueChanged, trkBarDwell.ValueChanged, _
                                                                                  trkBarHeading.ValueChanged, trkBarRange.ValueChanged, _
                                                                                  trkBarTilt.ValueChanged
        If mFormValues IsNot Nothing Then
            If sender.Equals(Me.trkBarStep) Then mFormValues.ScanStep = trkBarStep.Value
            If sender.Equals(Me.trkBarDwell) Then mFormValues.Dwell = trkBarDwell.Value
            If sender.Equals(Me.trkBarHeading) Then mFormValues.Heading = trkBarHeading.Value
            If sender.Equals(Me.trkBarRange) Then mFormValues.Range = trkBarRange.Value
            If sender.Equals(Me.trkBarTilt) Then mFormValues.Tilt = trkBarTilt.Value
        End If
    End Sub

    Private Sub txtBxLabel_TextChanged(sender As Object, e As EventArgs) Handles txtBxLabelLat.TextChanged, txtBxLabelLon.TextChanged, _
                                                                                    txtBoxLabelLatScanArea.TextChanged, txtBoxLabelLonScanArea.TextChanged
        If mFormValues IsNot Nothing Then
            If sender.Equals(Me.txtBxLabelLat) Then
                Select Case txtBxLabelLat.Text
                    Case "N"
                        mFormValues.StartPointLatDirection = LATDirection.N
                    Case "S"
                        mFormValues.StartPointLatDirection = LATDirection.N
                End Select
            ElseIf sender.Equals(Me.txtBxLabelLon) Then
                Select Case txtBxLabelLon.Text
                    Case "E"
                        mFormValues.StartPointLonDirection = LONDirection.E
                    Case "W"
                        mFormValues.StartPointLonDirection = LONDirection.W
                End Select
            ElseIf sender.Equals(Me.txtBoxLabelLonScanArea) Then
                Select Case txtBoxLabelLonScanArea.Text
                    Case "E"
                        mFormValues.ScanAreaLonDirection = LONDirection.E
                    Case "W"
                        mFormValues.ScanAreaLonDirection = LONDirection.W
                End Select
            ElseIf sender.Equals(Me.txtBoxLabelLatScanArea) Then
                Select Case txtBoxLabelLatScanArea.Text
                    Case "N"
                        mFormValues.ScanAreaLatDirection = LATDirection.N
                    Case "S"
                        mFormValues.ScanAreaLatDirection = LATDirection.S
                End Select
            End If
        End If
    End Sub
End Class
