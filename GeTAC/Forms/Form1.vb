Imports System.IO
Imports System.Environment
Imports SharpKml.Dom
Imports SharpKml.Base
Imports SharpKml.Engine
Imports GeTAC.FormValues
Imports GeTAC.GeTAC_Controller
Imports System.Runtime.InteropServices
Imports NLog

Public Class formGeTAC

    Private log As Logger = LogManager.GetCurrentClassLogger
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
    Private mScreenShotIsEnabled As Boolean
    Private mScreenShotLocation As String

    Public LatitudePoints As Integer
    Public LongitudePoints As Integer
    Public ScanTooLarge As Boolean
    Public PointsWarning As Boolean


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Threading.Thread.Sleep(2000)
        log.Trace("Initialize Components Complete.")
        ' Add any initialization after the InitializeComponent() call.

        'Set up look and feel of window
        log.Trace("Applying Look and Feel.")
        ApplicationLookAndFeel.UseTheme(Me)
        log.Trace("Complete.")

        'Instanciate all local variables
        log.Trace("Instanciating Local Variables.")
        LocalVariableInstanciate()
        log.Trace("Complete.")

        'Import form values
        log.Trace("Import Form Values.")
        ImportFormValues()
        log.Trace("Complete.")

        'Populate Values to form
        log.Trace("Populate Form with Values.")
        PopulatFormValues()
        log.Trace("Complete.")

        'Check for on top
        log.Trace("Check for on top.")
        CheckForOnTop()
        log.Trace("Complete.")

        'Check for Google Earth
        log.Trace("Check Registry for Google Earth")
        CheckForGoogleEarth()
        log.Trace("Complete.")

        'Get Cache Location
        log.Trace("Calculate Cache Size.")
        CalculateCacheLocation()
        log.Trace("Complete.")

        'Create KML
        log.Trace("Creating Initial KML.")
        CreateKML()
        log.Trace("Complete.")

        'Calculate Points 
        log.Trace("Calculating LAT/LON Points.")
        CalculatePoints()
        log.Trace("Complete.")

        'Set Time Variable
        log.Trace("Setting Time Variable.")
        SetTimeVariable()
        log.Trace("Complete.")

        'Calculate Time
        log.Trace("Calculating Time.")
        CalculateTime()
        log.Trace("Complete.")

        'Start Cache reader
        log.Trace("Starting Cache Reader Thread.")
        Me.bckGrndCacheRead.RunWorkerAsync()
        log.Trace("Complete.")

        'Signal finished initialization
        mIsInitialized = True
        log.Trace("Form Initialization Complete.")

    End Sub

    Private Sub CalculateTime()
        If mIsInitialized Then log.Trace("Starting sub 'CalculateTime()'.")
        If Not ScanTooLarge Then
            mScanHour = CalculateHour(mDwellTime * LatitudePoints * LongitudePoints)
            mScanMinute = CalculateMinute(mDwellTime * LatitudePoints * LongitudePoints)
            mScanSecond = CalculateSecond(mDwellTime * LatitudePoints * LongitudePoints)
            Me.lblTimeRequired.Text = mScanHour.ToString("00") & "h " & mScanMinute.ToString("00") & "m " & mScanSecond.ToString("00") & "s"
        Else
            Me.lblTimeRequired.Text = "00h 00m 00s"
        End If
        If mIsInitialized Then log.Trace("Ending sub 'CalculateTime()'.")
    End Sub
    Private Sub SetTimeVariable()
        If mIsInitialized Then log.Trace("Starting sub 'SetTimeVariable()'.")
        mDwellTime = CDbl(Me.trkBarDwell.Value / 10)
        If mIsInitialized Then log.Trace("Ending sub 'SetTimeVariable()'.")
    End Sub
    Private Sub CalculatePoints()
        If mIsInitialized Then log.Trace("Starting sub 'CalculatePoints()'.")
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
        If mIsInitialized Then log.Trace("Ending sub 'CalculatePoints()'.")
    End Sub
    Private Sub CreateKML(Optional ByVal latMult As Integer = 0, Optional ByVal lonMult As Integer = 0)
        If mIsInitialized Then log.Trace("Starting sub 'CreateKML()'.")
        BuildKML(mFormValues, latMult, lonMult)
        OpenKML(mKMLPath)
        If mIsInitialized Then log.Trace("Ending sub 'CreateKML()'.")
    End Sub
    Private Sub CalculateCacheLocation()
        If mIsInitialized Then log.Trace("Starting sub 'CalculateCacheLocation()'.")
        mCacheLocation = getCacheLocation()
        If mIsInitialized Then log.Trace("Ending sub 'CalculateCacheLocation()'.")
    End Sub
    Private Sub CheckForGoogleEarth()
        If mIsInitialized Then log.Trace("Starting sub 'CheckForGoogleEarth()'.")
        If GoogleEarthIsInstalled() Then
            mGoogleEarthIsInstalled = True
        Else
            mGoogleEarthIsInstalled = False
            MsgBox("Google Earth Not Installed! Download Google Earth to use GeTAC!", MsgBoxStyle.MsgBoxSetForeground)
        End If
        If mIsInitialized Then log.Trace("Ending sub 'CheckForGoogleEarth()'.")
    End Sub
    Private Sub LocalVariableInstanciate()
        If mIsInitialized Then log.Trace("Starting sub 'LocalVariableInstanciate()'.")
        mFormValues = New FormValues()
        mFormValuesFileName = New String("")
        mGoogleEarthIsInstalled = False
        mCacheSizeBytes = New Long()
        mCacheSizeMegaBytes = New Long()
        mKMLPath = GetFolderPath(SpecialFolder.ApplicationData) & "\GeTAC\LinkKML.kml"
        mDwellTime = 0
        LatitudePoints = 0
        LongitudePoints = 0
        ScanTooLarge = False
        mProgramIsPaused = False
        mIsInitialized = False
        mIsCancelled = False
        PointsWarning = False
        mScreenShotIsEnabled = False
        mScreenShotLocation = txtBoxScreenShotDir.Text
        If mIsInitialized Then log.Trace("Ending sub 'LocalVariableInstanciate()'.")
    End Sub

    Private Sub ImportFormValues()
        If mIsInitialized Then log.Trace("Starting sub 'ImportFormValues()'.")
        mFormValuesFileName = GetFormValuesFileName()
        mFormValues = DeserializeFormValuesXML(mFormValuesFileName)
        If mIsInitialized Then log.Trace("Ending sub 'ImportFormValues()'.")
    End Sub

    Private Sub PopulatFormValues()
        If mIsInitialized Then log.Trace("Starting sub 'PopulateFormValues()'.")
        FillMainForm(Me, mFormValues)
        If mIsInitialized Then log.Trace("Ending sub 'PopulateFormValues()'.")
    End Sub

    Private Sub CheckForOnTop()
        If mIsInitialized Then log.Trace("Starting sub 'CheckForOnTop()'.")
        If mFormValues.OnTop = False Then
            MakeNormal()
        Else
            MakeTopMost()
        End If
        If mIsInitialized Then log.Trace("Ending sub 'CheckForOnTop()'.")
    End Sub

    Private Sub txtBxLabelLat_MouseClick(sender As Object, e As MouseEventArgs) Handles txtBxLabelLat.MouseDown
        If mIsInitialized Then log.Trace("Starting sub 'txtBxLabelLat_MouseClick()'.")
        grpBxScanArea.Focus()
        Me.Refresh()
        Select Case txtBxLabelLat.Text
            Case "N"
                txtBxLabelLat.Text = "S"
            Case "S"
                txtBxLabelLat.Text = "N"
        End Select
        If mIsInitialized Then log.Trace("Ending sub 'txtBxLabelLat_MouseClick()'.")
    End Sub

    Private Sub txtBxLabelLon_MouseClick(sender As Object, e As MouseEventArgs) Handles txtBxLabelLon.MouseDown
        If mIsInitialized Then log.Trace("Starting sub 'txtBxLabelLon_MouseClick()'.")
        grpBxScanArea.Focus()
        Me.Refresh()
        Select Case txtBxLabelLon.Text
            Case "E"
                txtBxLabelLon.Text = "W"
            Case "W"
                txtBxLabelLon.Text = "E"
        End Select
        If mIsInitialized Then log.Trace("Ending sub 'txtBxLabelLon_MouseClick()'.")
    End Sub

    Private Sub txtBoxLabelLatScanArea_MouseDown(sender As Object, e As MouseEventArgs) Handles txtBoxLabelLatScanArea.MouseDown
        If mIsInitialized Then log.Trace("Starting sub 'txtBoxLabelLatScanArea_MouseDown()'.")
        grpBxScanArea.Focus()
        Me.Refresh()
        Select Case txtBoxLabelLatScanArea.Text
            Case "N"
                txtBoxLabelLatScanArea.Text = "S"
            Case "S"
                txtBoxLabelLatScanArea.Text = "N"
        End Select
        If mIsInitialized Then log.Trace("Ending sub 'txtBoxLabelLatScanArea_MouseDown()'.")
    End Sub

    Private Sub txtBoxLabelLonScanArea_MouseDown(sender As Object, e As MouseEventArgs) Handles txtBoxLabelLonScanArea.MouseDown
        If mIsInitialized Then log.Trace("Starting sub 'txtBoxLabelLonScanArea_MouseDown()'.")
        grpBxScanArea.Focus()
        Me.Refresh()
        Select Case txtBoxLabelLonScanArea.Text
            Case "E"
                txtBoxLabelLonScanArea.Text = "W"
            Case "W"
                txtBoxLabelLonScanArea.Text = "E"
        End Select
        If mIsInitialized Then log.Trace("Ending sub 'txtBoxLabelLonScanArea_MouseDown()'.")
    End Sub

    Private Sub trkBarStep_Scroll(sender As Object, e As EventArgs) Handles trkBarStep.Scroll
        If mIsInitialized Then log.Trace("Starting sub 'trkBarStep_Scroll()'.")
        Dim min = CDbl(trkBarStep.Value * 0.5)
        Me.lblStep.Text = min & " Min"
        CalculatePoints()
        CalculateTime()
        If mIsInitialized Then log.Trace("Ending sub 'trkBarStep_Scroll()'.")
    End Sub

    Private Sub trkBarDwell_Scroll(sender As Object, e As EventArgs) Handles trkBarDwell.Scroll
        If mIsInitialized Then log.Trace("Starting sub 'trkBarDwell_Scroll()'.")
        Dim sec = CDbl(trkBarDwell.Value / 10)
        mDwellTime = sec
        Me.lblDwell.Text = sec & " Sec"

        CalculateTime()
        If mIsInitialized Then log.Trace("Ending sub 'trkBarDwell_Scroll()'.")
    End Sub

    Private Sub trkBarRange_Scroll(sender As Object, e As EventArgs) Handles trkBarRange.Scroll
        If mIsInitialized Then log.Trace("Starting sub 'trkBarRange_Scroll()'.")
        Dim km = LinearToLog.ConvertLinearToLog(trkBarRange.Value)
        Me.lblRange.Text = km / 1000 & " km"
        If mIsInitialized Then log.Trace("Ending sub 'trkBarRange_Scroll()'.")
    End Sub


    Private Sub trkBarTilt_Scroll(sender As Object, e As EventArgs) Handles trkBarTilt.Scroll
        If mIsInitialized Then log.Trace("Starting sub 'trkBarTilt_Scroll()'.")
        Me.lblTilt.Text = trkBarTilt.Value & " Deg"
        If mIsInitialized Then log.Trace("Ending sub 'trkBarTilt_Scroll()'.")
    End Sub

    Private Sub trkBarHeading_Scroll(sender As Object, e As EventArgs) Handles trkBarHeading.Scroll
        If mIsInitialized Then log.Trace("Starting sub 'trkBarHeading_Scroll()'.")
        Me.lblHeading.Text = trkBarHeading.Value & " Deg"
        If mIsInitialized Then log.Trace("Ending sub 'trkBarHeading_Scroll()'.")
    End Sub

    Private Sub formGeTAC_FormClosing(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If mIsInitialized Then log.Trace("Starting sub 'formGeTAC_FormClosing()'.")
        If mGoogleEarthIsInstalled Then
            SerializeFormValuesXML(mFormValuesFileName, mFormValues)
        End If
        If mIsInitialized Then log.Trace("Ending sub 'formGeTAC_FormClosing()'.")
        'Dim serializer As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(FormValues))
        'Dim writer As StreamWriter = New StreamWriter(GeTAC_Controller.GetFormValuesFileName)
        'serializer.Serialize(writer, mFormValues)
    End Sub

    Private Sub upDwn_ValueChanged(sender As Object, e As EventArgs) Handles upDwnDegLat.ValueChanged, upDwnDegLatScanArea.ValueChanged, _
                                                                                   upDwnDegLon.ValueChanged, upDwnDegLonScanArea.ValueChanged, _
                                                                                   upDwnMinLat.ValueChanged, upDwnMinLatScanArea.ValueChanged, _
                                                                                   upDwnMinLon.ValueChanged, upDwnMinLonScanArea.ValueChanged

        If mIsInitialized Then
            log.Trace("Starting sub 'upDwn_ValueChanged()'")
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
            log.Trace("Ending sub 'upDwn_ValueChanged()'.")
        End If
    End Sub

    Private Sub trkBar_ValueChanged(sender As Object, e As EventArgs) Handles trkBarStep.ValueChanged, trkBarDwell.ValueChanged, _
                                                                                  trkBarHeading.ValueChanged, trkBarRange.ValueChanged, _
                                                                                  trkBarTilt.ValueChanged
        If mIsInitialized Then log.Trace("Starting sub 'trkBar_ValueChanged()'.")
        If mFormValues IsNot Nothing Then
            If sender.Equals(Me.trkBarStep) Then mFormValues.ScanStep = trkBarStep.Value
            If sender.Equals(Me.trkBarDwell) Then mFormValues.Dwell = trkBarDwell.Value
            If sender.Equals(Me.trkBarHeading) Then mFormValues.Heading = trkBarHeading.Value
            If sender.Equals(Me.trkBarRange) Then mFormValues.Range = trkBarRange.Value
            If sender.Equals(Me.trkBarTilt) Then mFormValues.Tilt = trkBarTilt.Value

        End If
        If mIsInitialized Then log.Trace("Ending sub 'trkBar_ValueChanged()'.")

    End Sub

    Private Sub trkBar_MouseUp(sender As Object, e As EventArgs) Handles trkBarStep.MouseUp, trkBarDwell.MouseUp, _
                                                                                  trkBarHeading.MouseUp, trkBarRange.MouseUp, _
                                                                                  trkBarTilt.MouseUp
        If mIsInitialized Then log.Trace("Starting sub 'trkBar_MouseUp()'.")
        If mFormValues IsNot Nothing Then CreateKML()
        If mIsInitialized Then log.Trace("Ending sub 'formGeTAC_FormClosing()'.")
    End Sub

    Private Sub txtBxLabel_TextChanged(sender As Object, e As EventArgs) Handles txtBxLabelLat.TextChanged, txtBxLabelLon.TextChanged, _
                                                                                    txtBoxLabelLatScanArea.TextChanged, txtBoxLabelLonScanArea.TextChanged
        If mIsInitialized Then
            log.Trace("Starting sub 'txtBxLabel_TextChanged()'.")
            If mFormValues IsNot Nothing Then
                If sender.Equals(Me.txtBxLabelLat) Then
                    Select Case txtBxLabelLat.Text
                        Case "N"
                            mFormValues.StartPointLatDirection = LATDirection.N
                        Case "S"
                            mFormValues.StartPointLatDirection = LATDirection.S
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
            log.Trace("Ending sub 'txtBxLabel_TextChanged()'.")
        End If
    End Sub

    Private Sub chkBoxOnTop_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxOnTop.CheckedChanged
        If mIsInitialized Then log.Trace("Staring sub 'chkBoxOnTop_CheckedChanged()'.")
        If mFormValues IsNot Nothing Then mFormValues.OnTop = chkBoxOnTop.Checked
        CheckForOnTop()
        If mIsInitialized Then log.Trace("Ending sub 'chkBoxOnTop_CheckedChanged()'.")
    End Sub
    <DllImport("user32.dll", SetLastError:=True)> _
    Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As Integer) As Boolean
    End Function

    Private Const SWP_NOSIZE As Integer = &H1
    Private Const SWP_NOMOVE As Integer = &H2

    Private Shared ReadOnly HWND_TOPMOST As New IntPtr(-1)
    Private Shared ReadOnly HWND_NOTOPMOST As New IntPtr(-2)

    Public Function MakeTopMost()
        If mIsInitialized Then log.Trace("Starting function 'MakeTopMost()'.")
        SetWindowPos(Me.Handle(), HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
        If mIsInitialized Then log.Trace("Ending function 'MakeTopMost()'.")
    End Function

    Public Function MakeNormal()
        If mIsInitialized Then log.Trace("Starting function 'MakeNormal()'.")
        SetWindowPos(Me.Handle(), HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOSIZE)
        If mIsInitialized Then log.Trace("Ending function 'MakeNormal()'.")
    End Function

    Private Sub bckGrndCacheRead_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckGrndCacheRead.DoWork
        If mIsInitialized Then log.Trace("Starting sub 'bckGrndCacheRead()'.")
        Do
            mCacheSizeBytes = GetFolderSize(mCacheLocation, True)
            bckGrndCacheRead.ReportProgress(mCacheSizeBytes)
            System.Threading.Thread.Sleep(2000)
        Loop
        If mIsInitialized Then log.Trace("Ending sub 'bckGrndCacheRead()'.")
    End Sub

    Private Sub bckGrndCacheRead_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bckGrndCacheRead.ProgressChanged
        Dim bytes = e.ProgressPercentage
        mCacheSizeMegaBytes = bytes / 1048576
        Me.lblCacheSize.Text = mCacheSizeMegaBytes & " MB (" & String.Format("{0:n0}", bytes) & " bytes)"
    End Sub

    Private Sub bckGrndMoveWindow_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bckGrndMoveWindow.DoWork
        If mIsInitialized Then log.Trace("Starting sub 'bckGrndMoveWindow_DoWork()'.")
        Dim progress As Double = 0
        Dim remainder As Double = 0
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        graph = Graphics.FromImage(screenshot)
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
                    If mScreenShotIsEnabled Then
                        If Not Directory.Exists(mScreenShotLocation) Then Directory.CreateDirectory(mScreenShotLocation)
                        graph.CopyFromScreen(0, 0, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
                        screenshot.Save(mScreenShotLocation + CStr(progress) + ".jpeg", Imaging.ImageFormat.Jpeg)
                    End If
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
                    If mScreenShotIsEnabled Then
                        If Not Directory.Exists(mScreenShotLocation) Then Directory.CreateDirectory(mScreenShotLocation)
                        graph.CopyFromScreen(0, 0, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
                        screenshot.Save(mScreenShotLocation + CStr(progress) + ".jpeg", Imaging.ImageFormat.Jpeg)
                    End If
                Next
            End If

        Next
        If mIsInitialized Then log.Trace("Ending sub 'bckGrndMoveWindow_DoWork()'.")
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
        If mIsInitialized Then log.Trace("Starting sub 'btnStart_Click()'.")
        btnStart.Enabled = False
        mIsCancelled = False
        bckGrndMoveWindow.RunWorkerAsync()
        mAlarmTime = Date.Now.AddHours(mScanHour)
        mAlarmTime = mAlarmTime.AddMinutes(mScanMinute)
        mAlarmTime = mAlarmTime.AddSeconds(mScanSecond)
        Timer1.Start()
        If mIsInitialized Then log.Trace("Ending sub 'btnStart_Click()'.")
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        If mIsInitialized Then log.Trace("Starting sub 'btnStop_Click()'.")
        If bckGrndMoveWindow.WorkerSupportsCancellation Then
            mIsCancelled = True
            bckGrndMoveWindow.CancelAsync()
        End If
        btnStart.Enabled = True
        btnPause.Text = "Pause"
        btnPause.BackColor = SystemColors.ControlLight
        mProgramIsPaused = False
        Timer1.Stop()
        If mIsInitialized Then log.Trace("Ending sub 'btnStop_Click()'.")
    End Sub

    Private Sub btnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If mIsInitialized Then log.Trace("Starting sub 'btnPause_Click()'.")
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
        If mIsInitialized Then log.Trace("Ending sub 'btnPause_Click()'.")
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

    Private Sub chkBoxScreenShot_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxScreenShot.CheckedChanged
        If sender.checked = True Then
            mScreenShotIsEnabled = True
        Else
            mScreenShotIsEnabled = False
        End If
    End Sub

    Private Sub txtBoxScreenShotDir_TextChanged(sender As Object, e As EventArgs) Handles txtBoxScreenShotDir.TextChanged
        mScreenShotLocation = sender.text
    End Sub

    Private Sub chkBoxGridOn_CheckedChanged(sender As Object, e As EventArgs) Handles chkBoxGridOn.CheckedChanged
        If mIsInitialized Then log.Trace("Staring sub 'chkBoxGridOn_CheckedChanged()'.")
        If mFormValues IsNot Nothing Then mFormValues.GridOn = chkBoxGridOn.Checked
        CreateKML()
        If mIsInitialized Then log.Trace("Ending sub 'chkBoxGridOn_CheckedChanged()'.")
    End Sub

    Private Sub btnPreviewKML_Click(sender As Object, e As EventArgs) Handles btnPreviewKML.Click
        If mIsInitialized Then log.Trace("Starting sub 'btnPreviewKML_Click()'.")
        If mFormValues IsNot Nothing Then
            PreviewKML(mFormValues, LatitudePoints, LongitudePoints)
            OpenKML(mKMLPath)
        End If
        If mIsInitialized Then log.Trace("Ending sub 'btnPreviewKML_Click()'.")
    End Sub
End Class
