<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formGeTAC
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formGeTAC))
        Me.btnStart = New System.Windows.Forms.Button()
        Me.grpBxStartPoint = New System.Windows.Forms.GroupBox()
        Me.upDwnMinLon = New System.Windows.Forms.NumericUpDown()
        Me.upDwnMinLat = New System.Windows.Forms.NumericUpDown()
        Me.upDwnDegLon = New System.Windows.Forms.NumericUpDown()
        Me.upDwnDegLat = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpBxScanArea = New System.Windows.Forms.GroupBox()
        Me.upDwnMinLonScanArea = New System.Windows.Forms.NumericUpDown()
        Me.upDwnMinLatScanArea = New System.Windows.Forms.NumericUpDown()
        Me.upDwnDegLonScanArea = New System.Windows.Forms.NumericUpDown()
        Me.upDwnDegLatScanArea = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.grpBoxProgress = New System.Windows.Forms.GroupBox()
        Me.lblDwell = New System.Windows.Forms.Label()
        Me.lblStep = New System.Windows.Forms.Label()
        Me.trkBarDwell = New System.Windows.Forms.TrackBar()
        Me.trkBarStep = New System.Windows.Forms.TrackBar()
        Me.lblTotalPoints = New System.Windows.Forms.Label()
        Me.lblTimeRequired = New System.Windows.Forms.Label()
        Me.lblOnPoint = New System.Windows.Forms.Label()
        Me.lblTimeRemain = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.lblCacheSize = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.trkBarRange = New System.Windows.Forms.TrackBar()
        Me.chkBoxOnTop = New System.Windows.Forms.CheckBox()
        Me.chkBoxAutoRange = New System.Windows.Forms.CheckBox()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.lblTilt = New System.Windows.Forms.Label()
        Me.lblHeading = New System.Windows.Forms.Label()
        Me.trkBarTilt = New System.Windows.Forms.TrackBar()
        Me.trkBarHeading = New System.Windows.Forms.TrackBar()
        Me.lblRange = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.bckGrndCacheRead = New System.ComponentModel.BackgroundWorker()
        Me.bckGrndMoveWindow = New System.ComponentModel.BackgroundWorker()
        Me.bckGrndTimer = New System.ComponentModel.BackgroundWorker()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtBxColorPointsCheck = New GeTAC.TextBoxColor()
        Me.txtBoxLabelLonScanArea = New GeTAC.TextBoxLabel()
        Me.txtBoxLabelLatScanArea = New GeTAC.TextBoxLabel()
        Me.txtBxLabelLon = New GeTAC.TextBoxLabel()
        Me.txtBxLabelLat = New GeTAC.TextBoxLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FILEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HELPToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HOWTOToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ABOUTToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SAVECACHEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grpBxStartPoint.SuspendLayout()
        CType(Me.upDwnMinLon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upDwnMinLat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upDwnDegLon, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upDwnDegLat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBxScanArea.SuspendLayout()
        CType(Me.upDwnMinLonScanArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upDwnMinLatScanArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upDwnDegLonScanArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.upDwnDegLatScanArea, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpBoxProgress.SuspendLayout()
        CType(Me.trkBarDwell, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkBarStep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.trkBarRange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkBarTilt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trkBarHeading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(354, 89)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(50, 30)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'grpBxStartPoint
        '
        Me.grpBxStartPoint.Controls.Add(Me.upDwnMinLon)
        Me.grpBxStartPoint.Controls.Add(Me.upDwnMinLat)
        Me.grpBxStartPoint.Controls.Add(Me.upDwnDegLon)
        Me.grpBxStartPoint.Controls.Add(Me.txtBxLabelLon)
        Me.grpBxStartPoint.Controls.Add(Me.txtBxLabelLat)
        Me.grpBxStartPoint.Controls.Add(Me.upDwnDegLat)
        Me.grpBxStartPoint.Controls.Add(Me.Label4)
        Me.grpBxStartPoint.Controls.Add(Me.Label3)
        Me.grpBxStartPoint.Controls.Add(Me.Label2)
        Me.grpBxStartPoint.Controls.Add(Me.Label1)
        Me.grpBxStartPoint.Location = New System.Drawing.Point(12, 33)
        Me.grpBxStartPoint.Name = "grpBxStartPoint"
        Me.grpBxStartPoint.Size = New System.Drawing.Size(271, 89)
        Me.grpBxStartPoint.TabIndex = 1
        Me.grpBxStartPoint.TabStop = False
        Me.grpBxStartPoint.Text = "Start Point"
        '
        'upDwnMinLon
        '
        Me.upDwnMinLon.DecimalPlaces = 3
        Me.upDwnMinLon.Location = New System.Drawing.Point(178, 58)
        Me.upDwnMinLon.Name = "upDwnMinLon"
        Me.upDwnMinLon.Size = New System.Drawing.Size(80, 20)
        Me.upDwnMinLon.TabIndex = 10
        '
        'upDwnMinLat
        '
        Me.upDwnMinLat.DecimalPlaces = 3
        Me.upDwnMinLat.Location = New System.Drawing.Point(178, 29)
        Me.upDwnMinLat.Name = "upDwnMinLat"
        Me.upDwnMinLat.Size = New System.Drawing.Size(80, 20)
        Me.upDwnMinLat.TabIndex = 9
        '
        'upDwnDegLon
        '
        Me.upDwnDegLon.Location = New System.Drawing.Point(102, 58)
        Me.upDwnDegLon.Name = "upDwnDegLon"
        Me.upDwnDegLon.Size = New System.Drawing.Size(57, 20)
        Me.upDwnDegLon.TabIndex = 8
        Me.upDwnDegLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'upDwnDegLat
        '
        Me.upDwnDegLat.Location = New System.Drawing.Point(102, 29)
        Me.upDwnDegLat.Name = "upDwnDegLat"
        Me.upDwnDegLat.Size = New System.Drawing.Size(57, 20)
        Me.upDwnDegLat.TabIndex = 4
        Me.upDwnDegLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(175, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Minutes"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(99, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Degrees"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "LON"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "LAT"
        '
        'grpBxScanArea
        '
        Me.grpBxScanArea.Controls.Add(Me.upDwnMinLonScanArea)
        Me.grpBxScanArea.Controls.Add(Me.upDwnMinLatScanArea)
        Me.grpBxScanArea.Controls.Add(Me.upDwnDegLonScanArea)
        Me.grpBxScanArea.Controls.Add(Me.txtBoxLabelLonScanArea)
        Me.grpBxScanArea.Controls.Add(Me.txtBoxLabelLatScanArea)
        Me.grpBxScanArea.Controls.Add(Me.upDwnDegLatScanArea)
        Me.grpBxScanArea.Controls.Add(Me.Label5)
        Me.grpBxScanArea.Controls.Add(Me.Label6)
        Me.grpBxScanArea.Controls.Add(Me.Label7)
        Me.grpBxScanArea.Controls.Add(Me.Label8)
        Me.grpBxScanArea.Location = New System.Drawing.Point(288, 33)
        Me.grpBxScanArea.Name = "grpBxScanArea"
        Me.grpBxScanArea.Size = New System.Drawing.Size(271, 89)
        Me.grpBxScanArea.TabIndex = 2
        Me.grpBxScanArea.TabStop = False
        Me.grpBxScanArea.Text = "Scan Area"
        '
        'upDwnMinLonScanArea
        '
        Me.upDwnMinLonScanArea.DecimalPlaces = 3
        Me.upDwnMinLonScanArea.Location = New System.Drawing.Point(181, 57)
        Me.upDwnMinLonScanArea.Name = "upDwnMinLonScanArea"
        Me.upDwnMinLonScanArea.Size = New System.Drawing.Size(80, 20)
        Me.upDwnMinLonScanArea.TabIndex = 20
        '
        'upDwnMinLatScanArea
        '
        Me.upDwnMinLatScanArea.DecimalPlaces = 3
        Me.upDwnMinLatScanArea.Location = New System.Drawing.Point(181, 28)
        Me.upDwnMinLatScanArea.Name = "upDwnMinLatScanArea"
        Me.upDwnMinLatScanArea.Size = New System.Drawing.Size(80, 20)
        Me.upDwnMinLatScanArea.TabIndex = 19
        '
        'upDwnDegLonScanArea
        '
        Me.upDwnDegLonScanArea.Location = New System.Drawing.Point(105, 57)
        Me.upDwnDegLonScanArea.Name = "upDwnDegLonScanArea"
        Me.upDwnDegLonScanArea.Size = New System.Drawing.Size(57, 20)
        Me.upDwnDegLonScanArea.TabIndex = 18
        Me.upDwnDegLonScanArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'upDwnDegLatScanArea
        '
        Me.upDwnDegLatScanArea.Location = New System.Drawing.Point(105, 28)
        Me.upDwnDegLatScanArea.Name = "upDwnDegLatScanArea"
        Me.upDwnDegLatScanArea.Size = New System.Drawing.Size(57, 20)
        Me.upDwnDegLatScanArea.TabIndex = 15
        Me.upDwnDegLatScanArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(178, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Minutes"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(102, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Degrees"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 60)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "LON"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(27, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "LAT"
        '
        'grpBoxProgress
        '
        Me.grpBoxProgress.Controls.Add(Me.lblDwell)
        Me.grpBoxProgress.Controls.Add(Me.lblStep)
        Me.grpBoxProgress.Controls.Add(Me.trkBarDwell)
        Me.grpBoxProgress.Controls.Add(Me.trkBarStep)
        Me.grpBoxProgress.Controls.Add(Me.lblTotalPoints)
        Me.grpBoxProgress.Controls.Add(Me.lblTimeRequired)
        Me.grpBoxProgress.Controls.Add(Me.lblOnPoint)
        Me.grpBoxProgress.Controls.Add(Me.lblTimeRemain)
        Me.grpBoxProgress.Controls.Add(Me.Label17)
        Me.grpBoxProgress.Controls.Add(Me.Label16)
        Me.grpBoxProgress.Controls.Add(Me.Label15)
        Me.grpBoxProgress.Controls.Add(Me.Label10)
        Me.grpBoxProgress.Controls.Add(Me.Label13)
        Me.grpBoxProgress.Controls.Add(Me.ProgressBar1)
        Me.grpBoxProgress.Controls.Add(Me.lblCacheSize)
        Me.grpBoxProgress.Controls.Add(Me.Label11)
        Me.grpBoxProgress.Controls.Add(Me.Label12)
        Me.grpBoxProgress.Location = New System.Drawing.Point(12, 128)
        Me.grpBoxProgress.Name = "grpBoxProgress"
        Me.grpBoxProgress.Size = New System.Drawing.Size(547, 148)
        Me.grpBoxProgress.TabIndex = 8
        Me.grpBoxProgress.TabStop = False
        '
        'lblDwell
        '
        Me.lblDwell.AutoSize = True
        Me.lblDwell.Location = New System.Drawing.Point(277, 107)
        Me.lblDwell.Name = "lblDwell"
        Me.lblDwell.Size = New System.Drawing.Size(26, 13)
        Me.lblDwell.TabIndex = 22
        Me.lblDwell.Text = "Sec"
        '
        'lblStep
        '
        Me.lblStep.AutoSize = True
        Me.lblStep.Location = New System.Drawing.Point(277, 78)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(24, 13)
        Me.lblStep.TabIndex = 21
        Me.lblStep.Text = "Min"
        '
        'trkBarDwell
        '
        Me.trkBarDwell.Location = New System.Drawing.Point(59, 97)
        Me.trkBarDwell.Maximum = 300
        Me.trkBarDwell.Minimum = 20
        Me.trkBarDwell.Name = "trkBarDwell"
        Me.trkBarDwell.Size = New System.Drawing.Size(212, 45)
        Me.trkBarDwell.TabIndex = 20
        Me.trkBarDwell.TickFrequency = 10
        Me.trkBarDwell.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.trkBarDwell.Value = 20
        '
        'trkBarStep
        '
        Me.trkBarStep.Location = New System.Drawing.Point(59, 62)
        Me.trkBarStep.Maximum = 60
        Me.trkBarStep.Minimum = 1
        Me.trkBarStep.Name = "trkBarStep"
        Me.trkBarStep.Size = New System.Drawing.Size(212, 45)
        Me.trkBarStep.TabIndex = 19
        Me.trkBarStep.TickFrequency = 10
        Me.trkBarStep.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.trkBarStep.Value = 1
        '
        'lblTotalPoints
        '
        Me.lblTotalPoints.AutoSize = True
        Me.lblTotalPoints.Location = New System.Drawing.Point(457, 64)
        Me.lblTotalPoints.Name = "lblTotalPoints"
        Me.lblTotalPoints.Size = New System.Drawing.Size(41, 13)
        Me.lblTotalPoints.TabIndex = 18
        Me.lblTotalPoints.Text = "(points)"
        '
        'lblTimeRequired
        '
        Me.lblTimeRequired.AutoSize = True
        Me.lblTimeRequired.Location = New System.Drawing.Point(457, 83)
        Me.lblTimeRequired.Name = "lblTimeRequired"
        Me.lblTimeRequired.Size = New System.Drawing.Size(68, 13)
        Me.lblTimeRequired.TabIndex = 17
        Me.lblTimeRequired.Text = "00h 00m 00s"
        '
        'lblOnPoint
        '
        Me.lblOnPoint.AutoSize = True
        Me.lblOnPoint.Location = New System.Drawing.Point(457, 102)
        Me.lblOnPoint.Name = "lblOnPoint"
        Me.lblOnPoint.Size = New System.Drawing.Size(20, 13)
        Me.lblOnPoint.TabIndex = 16
        Me.lblOnPoint.Text = "(#)"
        '
        'lblTimeRemain
        '
        Me.lblTimeRemain.AutoSize = True
        Me.lblTimeRemain.Location = New System.Drawing.Point(457, 122)
        Me.lblTimeRemain.Name = "lblTimeRemain"
        Me.lblTimeRemain.Size = New System.Drawing.Size(32, 13)
        Me.lblTimeRemain.TabIndex = 15
        Me.lblTimeRemain.Text = "(time)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(351, 64)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(63, 13)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Points Total"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(351, 83)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(76, 13)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Time Required"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(351, 102)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(71, 13)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Point Number"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(351, 122)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Time Remaining"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 29)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(64, 13)
        Me.Label13.TabIndex = 9
        Me.Label13.Text = "Cache Size:"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(349, 19)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(189, 23)
        Me.ProgressBar1.TabIndex = 8
        '
        'lblCacheSize
        '
        Me.lblCacheSize.AutoSize = True
        Me.lblCacheSize.Location = New System.Drawing.Point(99, 29)
        Me.lblCacheSize.Name = "lblCacheSize"
        Me.lblCacheSize.Size = New System.Drawing.Size(31, 13)
        Me.lblCacheSize.TabIndex = 6
        Me.lblCacheSize.Text = "(size)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(19, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(33, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Dwell"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(23, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Step"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.trkBarRange)
        Me.GroupBox1.Controls.Add(Me.chkBoxOnTop)
        Me.GroupBox1.Controls.Add(Me.chkBoxAutoRange)
        Me.GroupBox1.Controls.Add(Me.txtBxColorPointsCheck)
        Me.GroupBox1.Controls.Add(Me.btnStop)
        Me.GroupBox1.Controls.Add(Me.btnPause)
        Me.GroupBox1.Controls.Add(Me.lblTilt)
        Me.GroupBox1.Controls.Add(Me.lblHeading)
        Me.GroupBox1.Controls.Add(Me.trkBarTilt)
        Me.GroupBox1.Controls.Add(Me.trkBarHeading)
        Me.GroupBox1.Controls.Add(Me.btnStart)
        Me.GroupBox1.Controls.Add(Me.lblRange)
        Me.GroupBox1.Controls.Add(Me.Label31)
        Me.GroupBox1.Controls.Add(Me.Label32)
        Me.GroupBox1.Controls.Add(Me.Label33)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 282)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 143)
        Me.GroupBox1.TabIndex = 23
        Me.GroupBox1.TabStop = False
        '
        'trkBarRange
        '
        Me.trkBarRange.Location = New System.Drawing.Point(59, 18)
        Me.trkBarRange.Maximum = 41
        Me.trkBarRange.Name = "trkBarRange"
        Me.trkBarRange.Size = New System.Drawing.Size(212, 45)
        Me.trkBarRange.TabIndex = 28
        Me.trkBarRange.TickFrequency = 10
        Me.trkBarRange.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'chkBoxOnTop
        '
        Me.chkBoxOnTop.AutoSize = True
        Me.chkBoxOnTop.Location = New System.Drawing.Point(476, 19)
        Me.chkBoxOnTop.Name = "chkBoxOnTop"
        Me.chkBoxOnTop.Size = New System.Drawing.Size(62, 17)
        Me.chkBoxOnTop.TabIndex = 27
        Me.chkBoxOnTop.Text = "On Top"
        Me.chkBoxOnTop.UseVisualStyleBackColor = True
        '
        'chkBoxAutoRange
        '
        Me.chkBoxAutoRange.AutoSize = True
        Me.chkBoxAutoRange.Location = New System.Drawing.Point(354, 19)
        Me.chkBoxAutoRange.Name = "chkBoxAutoRange"
        Me.chkBoxAutoRange.Size = New System.Drawing.Size(83, 17)
        Me.chkBoxAutoRange.TabIndex = 26
        Me.chkBoxAutoRange.Text = "Auto Range"
        Me.chkBoxAutoRange.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(488, 89)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(50, 30)
        Me.btnStop.TabIndex = 24
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnPause
        '
        Me.btnPause.Location = New System.Drawing.Point(420, 89)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(50, 30)
        Me.btnPause.TabIndex = 23
        Me.btnPause.Text = "Pause"
        Me.btnPause.UseVisualStyleBackColor = True
        '
        'lblTilt
        '
        Me.lblTilt.AutoSize = True
        Me.lblTilt.Location = New System.Drawing.Point(279, 106)
        Me.lblTilt.Name = "lblTilt"
        Me.lblTilt.Size = New System.Drawing.Size(27, 13)
        Me.lblTilt.TabIndex = 22
        Me.lblTilt.Text = "Deg"
        '
        'lblHeading
        '
        Me.lblHeading.AutoSize = True
        Me.lblHeading.Location = New System.Drawing.Point(279, 71)
        Me.lblHeading.Name = "lblHeading"
        Me.lblHeading.Size = New System.Drawing.Size(27, 13)
        Me.lblHeading.TabIndex = 21
        Me.lblHeading.Text = "Deg"
        '
        'trkBarTilt
        '
        Me.trkBarTilt.Location = New System.Drawing.Point(59, 91)
        Me.trkBarTilt.Maximum = 90
        Me.trkBarTilt.Name = "trkBarTilt"
        Me.trkBarTilt.Size = New System.Drawing.Size(212, 45)
        Me.trkBarTilt.TabIndex = 20
        Me.trkBarTilt.TickFrequency = 10
        Me.trkBarTilt.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.trkBarTilt.Value = 20
        '
        'trkBarHeading
        '
        Me.trkBarHeading.Location = New System.Drawing.Point(59, 54)
        Me.trkBarHeading.Maximum = 180
        Me.trkBarHeading.Minimum = -180
        Me.trkBarHeading.Name = "trkBarHeading"
        Me.trkBarHeading.Size = New System.Drawing.Size(212, 45)
        Me.trkBarHeading.TabIndex = 19
        Me.trkBarHeading.TickFrequency = 30
        Me.trkBarHeading.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        Me.trkBarHeading.Value = 1
        '
        'lblRange
        '
        Me.lblRange.AutoSize = True
        Me.lblRange.Location = New System.Drawing.Point(280, 32)
        Me.lblRange.Name = "lblRange"
        Me.lblRange.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblRange.Size = New System.Drawing.Size(21, 13)
        Me.lblRange.TabIndex = 10
        Me.lblRange.Text = "km"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(13, 32)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(39, 13)
        Me.Label31.TabIndex = 6
        Me.Label31.Text = "Range"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(31, 106)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(21, 13)
        Me.Label32.TabIndex = 5
        Me.Label32.Text = "Tilt"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(5, 71)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(47, 13)
        Me.Label33.TabIndex = 4
        Me.Label33.Text = "Heading"
        '
        'bckGrndCacheRead
        '
        Me.bckGrndCacheRead.WorkerReportsProgress = True
        '
        'bckGrndMoveWindow
        '
        Me.bckGrndMoveWindow.WorkerReportsProgress = True
        Me.bckGrndMoveWindow.WorkerSupportsCancellation = True
        '
        'bckGrndTimer
        '
        Me.bckGrndTimer.WorkerReportsProgress = True
        Me.bckGrndTimer.WorkerSupportsCancellation = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 0
        Me.ToolTip1.ShowAlways = True
        Me.ToolTip1.Tag = ""
        '
        'txtBxColorPointsCheck
        '
        Me.txtBxColorPointsCheck.BackColor = System.Drawing.Color.Lime
        Me.txtBxColorPointsCheck.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtBxColorPointsCheck.Location = New System.Drawing.Point(354, 63)
        Me.txtBxColorPointsCheck.Name = "txtBxColorPointsCheck"
        Me.txtBxColorPointsCheck.Size = New System.Drawing.Size(184, 20)
        Me.txtBxColorPointsCheck.TabIndex = 25
        Me.txtBxColorPointsCheck.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txtBxColorPointsCheck, "If red, your step size is too large for your scan area." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "If yellow, your points m" & _
        "ay be too high for a 2GB Cache")
        '
        'txtBoxLabelLonScanArea
        '
        Me.txtBoxLabelLonScanArea.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBoxLabelLonScanArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtBoxLabelLonScanArea.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtBoxLabelLonScanArea.Location = New System.Drawing.Point(62, 57)
        Me.txtBoxLabelLonScanArea.Name = "txtBoxLabelLonScanArea"
        Me.txtBoxLabelLonScanArea.ReadOnly = True
        Me.txtBoxLabelLonScanArea.Size = New System.Drawing.Size(25, 20)
        Me.txtBoxLabelLonScanArea.TabIndex = 17
        Me.txtBoxLabelLonScanArea.TabStop = False
        Me.txtBoxLabelLonScanArea.Text = "E"
        Me.txtBoxLabelLonScanArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBoxLabelLatScanArea
        '
        Me.txtBoxLabelLatScanArea.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBoxLabelLatScanArea.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtBoxLabelLatScanArea.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtBoxLabelLatScanArea.Location = New System.Drawing.Point(62, 28)
        Me.txtBoxLabelLatScanArea.Name = "txtBoxLabelLatScanArea"
        Me.txtBoxLabelLatScanArea.ReadOnly = True
        Me.txtBoxLabelLatScanArea.Size = New System.Drawing.Size(25, 20)
        Me.txtBoxLabelLatScanArea.TabIndex = 16
        Me.txtBoxLabelLatScanArea.TabStop = False
        Me.txtBoxLabelLatScanArea.Text = "S"
        Me.txtBoxLabelLatScanArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBxLabelLon
        '
        Me.txtBxLabelLon.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBxLabelLon.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtBxLabelLon.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtBxLabelLon.Location = New System.Drawing.Point(59, 58)
        Me.txtBxLabelLon.Name = "txtBxLabelLon"
        Me.txtBxLabelLon.ReadOnly = True
        Me.txtBxLabelLon.Size = New System.Drawing.Size(25, 20)
        Me.txtBxLabelLon.TabIndex = 7
        Me.txtBxLabelLon.TabStop = False
        Me.txtBxLabelLon.Text = "E"
        Me.txtBxLabelLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtBxLabelLat
        '
        Me.txtBxLabelLat.BackColor = System.Drawing.SystemColors.ControlLight
        Me.txtBxLabelLat.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtBxLabelLat.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.txtBxLabelLat.Location = New System.Drawing.Point(59, 29)
        Me.txtBxLabelLat.Name = "txtBxLabelLat"
        Me.txtBxLabelLat.ReadOnly = True
        Me.txtBxLabelLat.Size = New System.Drawing.Size(25, 20)
        Me.txtBxLabelLat.TabIndex = 6
        Me.txtBxLabelLat.TabStop = False
        Me.txtBxLabelLat.Text = "N"
        Me.txtBxLabelLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FILEToolStripMenuItem, Me.HELPToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(569, 24)
        Me.MenuStrip1.TabIndex = 24
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FILEToolStripMenuItem
        '
        Me.FILEToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SAVECACHEToolStripMenuItem})
        Me.FILEToolStripMenuItem.Name = "FILEToolStripMenuItem"
        Me.FILEToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.FILEToolStripMenuItem.Text = "FILE"
        '
        'HELPToolStripMenuItem
        '
        Me.HELPToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HOWTOToolStripMenuItem, Me.ABOUTToolStripMenuItem})
        Me.HELPToolStripMenuItem.Name = "HELPToolStripMenuItem"
        Me.HELPToolStripMenuItem.Size = New System.Drawing.Size(47, 20)
        Me.HELPToolStripMenuItem.Text = "HELP"
        '
        'HOWTOToolStripMenuItem
        '
        Me.HOWTOToolStripMenuItem.Name = "HOWTOToolStripMenuItem"
        Me.HOWTOToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.HOWTOToolStripMenuItem.Text = "HOW TO"
        '
        'ABOUTToolStripMenuItem
        '
        Me.ABOUTToolStripMenuItem.Name = "ABOUTToolStripMenuItem"
        Me.ABOUTToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.ABOUTToolStripMenuItem.Text = "ABOUT"
        '
        'SAVECACHEToolStripMenuItem
        '
        Me.SAVECACHEToolStripMenuItem.Name = "SAVECACHEToolStripMenuItem"
        Me.SAVECACHEToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.SAVECACHEToolStripMenuItem.Text = "SAVE CACHE"
        '
        'formGeTAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(569, 456)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.grpBoxProgress)
        Me.Controls.Add(Me.grpBxScanArea)
        Me.Controls.Add(Me.grpBxStartPoint)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "formGeTAC"
        Me.Text = "GeTAC: Google Earth Tile Acquisition Cache"
        Me.grpBxStartPoint.ResumeLayout(False)
        Me.grpBxStartPoint.PerformLayout()
        CType(Me.upDwnMinLon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upDwnMinLat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upDwnDegLon, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upDwnDegLat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBxScanArea.ResumeLayout(False)
        Me.grpBxScanArea.PerformLayout()
        CType(Me.upDwnMinLonScanArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upDwnMinLatScanArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upDwnDegLonScanArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.upDwnDegLatScanArea, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpBoxProgress.ResumeLayout(False)
        Me.grpBoxProgress.PerformLayout()
        CType(Me.trkBarDwell, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkBarStep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.trkBarRange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkBarTilt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trkBarHeading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents grpBxStartPoint As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents grpBxScanArea As System.Windows.Forms.GroupBox
    Friend WithEvents upDwnDegLat As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBxLabelLat As GeTAC.TextBoxLabel
    Friend WithEvents txtBxLabelLon As GeTAC.TextBoxLabel
    Friend WithEvents upDwnMinLon As System.Windows.Forms.NumericUpDown
    Friend WithEvents upDwnMinLat As System.Windows.Forms.NumericUpDown
    Friend WithEvents upDwnDegLon As System.Windows.Forms.NumericUpDown
    Friend WithEvents grpBoxProgress As System.Windows.Forms.GroupBox
    Friend WithEvents trkBarDwell As System.Windows.Forms.TrackBar
    Friend WithEvents trkBarStep As System.Windows.Forms.TrackBar
    Friend WithEvents lblTotalPoints As System.Windows.Forms.Label
    Friend WithEvents lblTimeRequired As System.Windows.Forms.Label
    Friend WithEvents lblOnPoint As System.Windows.Forms.Label
    Friend WithEvents lblTimeRemain As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblCacheSize As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblDwell As System.Windows.Forms.Label
    Friend WithEvents lblStep As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblTilt As System.Windows.Forms.Label
    Friend WithEvents lblHeading As System.Windows.Forms.Label
    Friend WithEvents trkBarTilt As System.Windows.Forms.TrackBar
    Friend WithEvents trkBarHeading As System.Windows.Forms.TrackBar
    Friend WithEvents lblRange As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnPause As System.Windows.Forms.Button
    Friend WithEvents trkBarRange As System.Windows.Forms.TrackBar
    Friend WithEvents chkBoxOnTop As System.Windows.Forms.CheckBox
    Friend WithEvents chkBoxAutoRange As System.Windows.Forms.CheckBox
    Friend WithEvents txtBxColorPointsCheck As GeTAC.TextBoxColor
    Friend WithEvents upDwnMinLonScanArea As System.Windows.Forms.NumericUpDown
    Friend WithEvents upDwnMinLatScanArea As System.Windows.Forms.NumericUpDown
    Friend WithEvents upDwnDegLonScanArea As System.Windows.Forms.NumericUpDown
    Friend WithEvents txtBoxLabelLonScanArea As GeTAC.TextBoxLabel
    Friend WithEvents txtBoxLabelLatScanArea As GeTAC.TextBoxLabel
    Friend WithEvents upDwnDegLatScanArea As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents bckGrndCacheRead As System.ComponentModel.BackgroundWorker
    Friend WithEvents bckGrndMoveWindow As System.ComponentModel.BackgroundWorker
    Friend WithEvents bckGrndTimer As System.ComponentModel.BackgroundWorker
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents FILEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SAVECACHEToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HELPToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HOWTOToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ABOUTToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
