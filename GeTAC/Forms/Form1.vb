Imports System.IO
Imports System.Environment
Imports SharpKml.Dom
Imports SharpKml.Base
Imports SharpKml.Engine
Imports GeTAC.FormValues
Imports GeTAC.GeTAC_Controller
Imports System.Runtime.InteropServices


Public Class formGeTAC
    Private mFormValues As FormValues
    Private mFormValuesFileName As String
    Private mGoogleEarthIsInstalled As Boolean
    Private mCacheSizeBytes As Long
    Private mCacheSizeMegaBytes As Integer
    Private mKMLPath As String
    Private mDwellTime As Double
    Private mScanHour As Integer
    Private mScanMinute As Integer
    Private mScanSecond As Integer
    Private mCacheLocation As String
    Private mProgramIsPaused As Boolean
    Private mIsInitialized As Boolean
    Private mIsCancelled As Boolean
    Private mAlarmTime As Date

    Public LatitudePoints As Integer
    Public LongitudePoints As Integer
    Public ScanTooLarge As Boolean
    Public PointsWarning As Boolean


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

        'Check for on top
        CheckForOnTop()

        'Check for Google Earth
        CheckForGoogleEarth()

        'Get Cache Location
        CalculateCacheLocation()

        'Create KML
        CreateKML()

        'Calculate Points 
        CalculatePoints()

        'Set Time Variable
        SetTimeVariable()

        'Calculate Time
        CalculateTime()

        'Start Cache reader
        Me.bckGrndCacheRead.RunWorkerAsync()

        'Signal finished initialization
        mIsInitialized = True

    End Sub
   
    Private Sub CalculateTime()
        If Not ScanTooLarge Then
            mScanHour = CalculateHour(mDwellTime * LatitudePoints * LongitudePoints)
            mScanMinute = CalculateMinute(mDwellTime * LatitudePoints * LongitudePoints)
            mScanSecond = CalculateSecond(mDwellTime * LatitudePoints * LongitudePoints)
            Me.lblTimeRequired.Text = mScanHour.ToString("00") & "h " & mScanMinute.ToString("00") & "m " & mScanSecond.ToString("00") & "s"
        Else
            Me.lblTimeRequired.Text = "00h 00m 00s"
        End If
    End Sub
    Private Sub SetTimeVariable()
        mDwellTime = CDbl(Me.trkBarDwell.Value / 10)
    End Sub
    Private Sub CalculatePoints()
        CalculateScan(Me)

        If ScanTooLarge Then
            ScanOVer(Me)
        Else
            ScanOK(Me, LatitudePoints * LongitudePoints)
            If PointsWarning Then
                PointsOver(Me)
            Else
                PointsOK(Me)
            End If
        End If

        

    End Sub
    Private Sub CreateKML(Optional ByVal latMult As Integer = 0, Optional ByVal lonMult As Integer = 0)
        BuildKML(mFormValues, latMult, lonMult)
        OpenKML(mKMLPath)
    End Sub
    Private Sub CalculateCacheLocation()
        mCacheLocation = getCacheLocation()
    End Sub
    Private Sub CheckForGoogleEarth()
        If GoogleEarthIsInstalled() Then
            mGoogleEarthIsInstalled = True
        Else
            mGoogleEarthIsInstalled = False
            MsgBox("Google Earth Not Installed! Download Google Earth to use GeTAC!", MsgBoxStyle.MsgBoxSetForeground)

        End If
    End Sub
    Private Sub LocalVariableInstanciate()
        mFormValues = New FormValues()
        mFormValuesFileName = New String("")
        mGoogleEarthIsInstalled = False
        mCacheSizeBytes = New Long()
        mCacheSizeMegaBytes = New Long()
        mKMLPath = "C:\\Users\Boxx\AppData\Roaming\GeTAC\LinkKML.kml"
        mDwellTime = 0
        LatitudePoints = 0
        LongitudePoints = 0
        ScanTooLarge = False
        mProgramIsPaused = False
        mIsInitialized = False
        mIsCancelled = False
        PointsWarning = False
    End Sub

    Private Sub ImportFormValues()
        mFormValuesFileName = GetFormValuesFileName()
        mFormValues = DeserializeFormValuesXML(mFormValuesFileName)
    End Sub

    Private Sub PopulatFormValues()
        FillMainForm(Me, mFormValues)
    End Sub

    Private Sub CheckForOnTop()
        If mFormValues.OnTop = False Then
            MakeNormal()
        Else
            MakeTopMost()
        End If
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
        CalculatePoints()
        CalculateTime()
    End Sub

    Private Sub trkBarDwell_Scroll(sender As Object, e As EventArgs) Handles trkBarDwell.Scroll
        Dim sec = CDbl(trkBarDwell.Value / 10)
        mDwellTime = sec
        Me.lblDwell.Text = sec & " Sec"

        CalculateTime()
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
        If mGoogleEarthIsInstalled Then
            SerializeFormValuesXML(mFormValuesFileName, mFormValues)
        End If

        'Dim serializer As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(FormValues))
        'Dim writer As StreamWriter = New StreamWriter(GeTAC_Controller.GetFormValuesFileName)
        'serializer.Serialize(writer, mFormValues)
    End Sub

    Private Sub upDwn_ValueChanged(sender As Object, e As EventArgs) Handles upDwnDegLat.ValueChanged, upDwnDegLatScanArea.ValueChanged, _
                                                                                   upDwnDegLon.ValueChanged, upDwnDegLonScanArea.ValueChanged, _
                                                                                   upDwnMinLat.ValueChanged, upDwnMinLatScanArea.ValueChanged, _
                                                                                   upDwnMinLon.ValueChanged, upDwnMinLonScanArea.ValueChanged
        If mIsInitialized Then
            If sender.Equals(Me.upDwnDegLat) Then mFormValues.StartPointLatDegree = upDwnDegLat.Value
            If sender.Equals(Me.upDwnDegLatScanArea) Then mFormValues.ScanAreaLatDegree = upDwnDegLatScanArea.Value
            If sender.Equals(Me.upDwnDegLon) Then mFormValues.StartPointLonDegree = upDwnDegLon.Value
            If sender.Equals(Me.upDwnDegLonScanArea) Then mFormValues.ScanAreaLonDegree = upDwnDegLonScanArea.Value
            If sender.Equals(Me.upDwnMinLat) Then mFormValues.StartPointLatMinute = upDwnMinLat.Value
            If sender.Equals(Me.upDwnMinLatScanArea) Then mFormValues.ScanAreaLatMinute = upDwnMinLatScanArea.Value
            If sender.Equals(Me.upDwnMinLon) Then mFormValues.StartPointLonMinute = upDwnMinLon.Value
            If sender.Equals(Me.upDwnMinLonScanArea) Then mFormValues.ScanAreaLonMinute = upDwnMinLonScanArea.Value

            CalculatePoints()
            CreateKML()
        End If
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

    Private Sub trkBar_MouseUp(sender As Object, e As EventArgs) Handles trkBarStep.MouseUp, trkBarDwell.MouseUp, _
                                                                                  trkBarHeading.MouseUp, trkBarRange.MouseUp, _
                                                                                  trkBarTilt.MouseUp
        If mFormValues IsNot Nothing Then CreateKML()
    End Sub

    Private Sub txtBxLabel_TextChanged(sender As Object, e As EventArgs) Handles txtBxLabelLat.TextChanged, txtBxLabelLon.TextChanged, _
                                                                                    txtBoxLabelLatScanArea.TextChanged, txtBoxLabelLonScanArea.TextChanged
        If mIsInitialized Then
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
                CreateKML()
            End If
        End If
    End Sub

    Private Sub chkBoxOnTop_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxOnTop.CheckedChanged
        If mFormValues IsNot Nothing Then mFormValues.OnTop = chkBoxOnTop.Checked
        CheckForOnTop()
    End Sub
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As Integer) As Boolean
    End Function

    Private Const SWP_NOSIZE As Integer = &H1
    Private Const SWP_NOMOVE As Integer = &H2

    Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Private Shared ReadOnly HWND_NOTOPMOST As New IntPtr(-2)

    Public Function MakeTopMost()
        SetWindowPos(Me.Handle(), HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
    End Function

    Public Function MakeNormal()
        SetWindowPos(Me.Handle(), HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
    End Function

    Private Sub bckGrndCacheRead_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckGrndCacheRead.DoWork
        Do
            mCacheSizeBytes = GetFolderSize(mCacheLocation, True)
            bckGrndCacheRead.ReportProgress(mCacheSizeBytes)
            System.Threading.Thread.Sleep(2000)
        Loop
    End Sub

    Private Sub bckGrndCacheRead_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bckGrndCacheRead.ProgressChanged
        Dim bytes = e.ProgressPercentage
        mCacheSizeMegaBytes = bytes / 1048576
        Me.lblCacheSize.Text = mCacheSizeMegaBytes & " MB (" & String.Format("{0:n0}", bytes) & " bytes)"
    End Sub

    Private Sub bckGrndMoveWindow_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckGrndMoveWindow.DoWork
        Dim progress As Double = 0
        Dim remainder As Double = 0
        For i = 0 To LatitudePoints - 1
            remainder = i / 2 - Math.Floor(i / 2)
            If remainder = 0 Then
                For j = 0 To LongitudePoints - 1
                    If mProgramIsPaused Then
                        Do Until Not mProgramIsPaused
                        Loop
                    End If
                    If mIsCancelled Then Exit Sub
                    CreateKML(i, j)
                    progress += 1
                    bckGrndMoveWindow.ReportProgress(progress)
                    Threading.Thread.Sleep(mFormValues.Dwell * 100)
                Next
            Else
                For j = LongitudePoints - 1 To 0 Step -1
                    If mProgramIsPaused Then
                        Do Until Not mProgramIsPaused
                        Loop
                    End If
                    If mIsCancelled Then Exit Sub
                    CreateKML(i, j)
                    progress += 1
                    bckGrndMoveWindow.ReportProgress(progress)
                    Threading.Thread.Sleep(mFormValues.Dwell * 100)
                Next
            End If

        Next

    End Sub

    Private Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As IntPtr) As Integer
    Private Declare Function SetFocus Lib "user32.dll" (ByVal hWnd As IntPtr) As Integer

    Private Sub bckGrndMoveWindow_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bckGrndMoveWindow.ProgressChanged
        Dim progress = e.ProgressPercentage
        Me.lblOnPoint.Text = progress
        Me.ProgressBar1.Value = (progress / (LongitudePoints * LatitudePoints)) * 100
        SetForegroundWindow(Me.Handle)
        SetFocus(Me.Handle)
    End Sub
    

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        mIsCancelled = False
        bckGrndMoveWindow.RunWorkerAsync()
        mAlarmTime = Date.Now.AddHours(mScanHour)
        mAlarmTime = mAlarmTime.AddMinutes(mScanMinute)
        mAlarmTime = mAlarmTime.AddSeconds(mScanSecond)
        Timer1.Start()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If bckGrndMoveWindow.WorkerSupportsCancellation Then
            mIsCancelled = True
            bckGrndMoveWindow.CancelAsync()
        End If
        btnStart.Enabled = True
        btnPause.Text = "Pause"
        btnPause.BackColor = SystemColors.ControlLight
        mProgramIsPaused = False
        Timer1.Stop()
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        Select Case btnPause.Text
            Case "Pause"
                btnPause.Text = "Resume"
                btnPause.BackColor = Color.Yellow
                mProgramIsPaused = True
            Case "Resume"
                btnPause.Text = "Pause"
                btnPause.BackColor = SystemColors.ControlLight
                mProgramIsPaused = False
        End Select
    End Sub

    Private Sub bckGrndMoveWindow_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bckGrndMoveWindow.RunWorkerCompleted
        btnStart.Enabled = True
        Timer1.Stop()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If mProgramIsPaused Then
            mAlarmTime = mAlarmTime.AddSeconds(1)
        Else
            If mAlarmTime < Date.Now Then
                Me.Timer1.Stop()
            Else
                Dim remaining = mAlarmTime.Subtract(Date.Now)
                Me.lblTimeRemain.Text = String.Format("{0}:{1:d2}:{2:d2}", remaining.Hours, remaining.Minutes, remaining.Seconds)
            End If
        End If
    End Sub

    Private Sub SAVECACHEToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SAVECACHEToolStripMenuItem.Click
        Dim dialog As New FolderBrowserDialog
        Dim destinationPath As String = String.Empty
        Dim cachePath As String = String.Empty

        dialog.Description = "Choose folder to save cache in."

        If dialog.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
            destinationPath = dialog.SelectedPath
        End If
        cachePath = getCacheLocation()

        SaveCache(cachePath, destinationPath, Me)
    End Sub
End Class
