Imports System.IO
Imports System.Xml.Serialization
Imports GeTAC.FormValues
Imports GeTAC.formGeTAC

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

    Shared latDirection As String() = {"N", "S"}
    Shared lonDirection As String() = {"E", "W"}
End Class
