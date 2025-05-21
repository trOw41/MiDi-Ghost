<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Panel1 = New Panel()
        VolumeMeter2 = New NAudio.Gui.VolumeMeter()
        VolumeMeter8 = New NAudio.Gui.VolumeMeter()
        VolumeMeter7 = New NAudio.Gui.VolumeMeter()
        VolumeMeter6 = New NAudio.Gui.VolumeMeter()
        VolumeMeter5 = New NAudio.Gui.VolumeMeter()
        VolumeMeter4 = New NAudio.Gui.VolumeMeter()
        VolumeMeter3 = New NAudio.Gui.VolumeMeter()
        VolumeMeter1 = New NAudio.Gui.VolumeMeter()
        Label7 = New Label()
        Label8 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Button3 = New Button()
        cmsMidiLearn = New ContextMenuStrip(components)
        tsmiLearnMidi = New ToolStripMenuItem()
        Fader8 = New NAudio.Gui.Fader()
        Button8 = New Button()
        Fader7 = New NAudio.Gui.Fader()
        Button5 = New Button()
        Button2 = New Button()
        Label24 = New Label()
        Label23 = New Label()
        Label22 = New Label()
        Label21 = New Label()
        Label20 = New Label()
        Label19 = New Label()
        Label18 = New Label()
        Label17 = New Label()
        Fader6 = New NAudio.Gui.Fader()
        Button7 = New Button()
        Fader5 = New NAudio.Gui.Fader()
        Button4 = New Button()
        Fader4 = New NAudio.Gui.Fader()
        Button1 = New Button()
        Fader3 = New NAudio.Gui.Fader()
        Button6 = New Button()
        Fader2 = New NAudio.Gui.Fader()
        Fader1 = New NAudio.Gui.Fader()
        Panel2 = New Panel()
        Pot6 = New NAudio.Gui.Pot()
        Pot5 = New NAudio.Gui.Pot()
        Pot4 = New NAudio.Gui.Pot()
        Pot3 = New NAudio.Gui.Pot()
        Pot2 = New NAudio.Gui.Pot()
        Pot8 = New NAudio.Gui.Pot()
        Pot7 = New NAudio.Gui.Pot()
        Label16 = New Label()
        Label15 = New Label()
        Label14 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label25 = New Label()
        Label11 = New Label()
        Label10 = New Label()
        Label9 = New Label()
        Pot1 = New NAudio.Gui.Pot()
        cboMidiInDevices = New ComboBox()
        Label26 = New Label()
        Label27 = New Label()
        BtnConnect = New Button()
        BtnDisconnect = New Button()
        lblConnectedDevice = New Label()
        cboMidiOutDevices = New ComboBox()
        Label28 = New Label()
        Label29 = New Label()
        lbxMidiAddresses = New DataGridView()
        MiDi_IN = New DataGridViewTextBoxColumn()
        MIDI_OUT = New DataGridViewTextBoxColumn()
        BindingSource1 = New BindingSource(components)
        rtbMidiLog = New RichTextBox()
        Panel1.SuspendLayout()
        cmsMidiLearn.SuspendLayout()
        Panel2.SuspendLayout()
        CType(lbxMidiAddresses, ComponentModel.ISupportInitialize).BeginInit()
        CType(BindingSource1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(VolumeMeter2)
        Panel1.Controls.Add(VolumeMeter8)
        Panel1.Controls.Add(VolumeMeter7)
        Panel1.Controls.Add(VolumeMeter6)
        Panel1.Controls.Add(VolumeMeter5)
        Panel1.Controls.Add(VolumeMeter4)
        Panel1.Controls.Add(VolumeMeter3)
        Panel1.Controls.Add(VolumeMeter1)
        Panel1.Controls.Add(Label7)
        Panel1.Controls.Add(Label8)
        Panel1.Controls.Add(Label6)
        Panel1.Controls.Add(Label5)
        Panel1.Controls.Add(Label4)
        Panel1.Controls.Add(Label3)
        Panel1.Controls.Add(Label2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Fader8)
        Panel1.Controls.Add(Button8)
        Panel1.Controls.Add(Fader7)
        Panel1.Controls.Add(Button5)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Label24)
        Panel1.Controls.Add(Label23)
        Panel1.Controls.Add(Label22)
        Panel1.Controls.Add(Label21)
        Panel1.Controls.Add(Label20)
        Panel1.Controls.Add(Label19)
        Panel1.Controls.Add(Label18)
        Panel1.Controls.Add(Label17)
        Panel1.Controls.Add(Fader6)
        Panel1.Controls.Add(Button7)
        Panel1.Controls.Add(Fader5)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Fader4)
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(Fader3)
        Panel1.Controls.Add(Button6)
        Panel1.Controls.Add(Fader2)
        Panel1.Controls.Add(Fader1)
        Panel1.Location = New Point(37, 317)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(823, 225)
        Panel1.TabIndex = 0
        ' 
        ' VolumeMeter2
        ' 
        VolumeMeter2.Amplitude = 0F
        VolumeMeter2.Location = New Point(768, 35)
        VolumeMeter2.MaxDb = 18.0F
        VolumeMeter2.MinDb = -60.0F
        VolumeMeter2.Name = "VolumeMeter2"
        VolumeMeter2.Size = New Size(22, 171)
        VolumeMeter2.TabIndex = 2
        VolumeMeter2.Text = "VolumeMeter1"
        ' 
        ' VolumeMeter8
        ' 
        VolumeMeter8.Amplitude = 0F
        VolumeMeter8.Location = New Point(47, 35)
        VolumeMeter8.MaxDb = 18.0F
        VolumeMeter8.MinDb = -60.0F
        VolumeMeter8.Name = "VolumeMeter8"
        VolumeMeter8.Size = New Size(22, 171)
        VolumeMeter8.TabIndex = 2
        VolumeMeter8.Text = "VolumeMeter1"
        ' 
        ' VolumeMeter7
        ' 
        VolumeMeter7.Amplitude = 0F
        VolumeMeter7.Location = New Point(154, 35)
        VolumeMeter7.MaxDb = 18.0F
        VolumeMeter7.MinDb = -60.0F
        VolumeMeter7.Name = "VolumeMeter7"
        VolumeMeter7.Size = New Size(22, 171)
        VolumeMeter7.TabIndex = 2
        VolumeMeter7.Text = "VolumeMeter1"
        ' 
        ' VolumeMeter6
        ' 
        VolumeMeter6.Amplitude = 0F
        VolumeMeter6.Location = New Point(257, 35)
        VolumeMeter6.MaxDb = 18.0F
        VolumeMeter6.MinDb = -60.0F
        VolumeMeter6.Name = "VolumeMeter6"
        VolumeMeter6.Size = New Size(22, 171)
        VolumeMeter6.TabIndex = 2
        VolumeMeter6.Text = "VolumeMeter1"
        ' 
        ' VolumeMeter5
        ' 
        VolumeMeter5.Amplitude = 0F
        VolumeMeter5.Location = New Point(360, 35)
        VolumeMeter5.MaxDb = 18.0F
        VolumeMeter5.MinDb = -60.0F
        VolumeMeter5.Name = "VolumeMeter5"
        VolumeMeter5.Size = New Size(22, 171)
        VolumeMeter5.TabIndex = 2
        VolumeMeter5.Text = "VolumeMeter1"
        ' 
        ' VolumeMeter4
        ' 
        VolumeMeter4.Amplitude = 0F
        VolumeMeter4.Location = New Point(463, 35)
        VolumeMeter4.MaxDb = 18.0F
        VolumeMeter4.MinDb = -60.0F
        VolumeMeter4.Name = "VolumeMeter4"
        VolumeMeter4.Size = New Size(22, 171)
        VolumeMeter4.TabIndex = 2
        VolumeMeter4.Text = "VolumeMeter1"
        ' 
        ' VolumeMeter3
        ' 
        VolumeMeter3.Amplitude = 0F
        VolumeMeter3.Location = New Point(566, 35)
        VolumeMeter3.MaxDb = 18.0F
        VolumeMeter3.MinDb = -60.0F
        VolumeMeter3.Name = "VolumeMeter3"
        VolumeMeter3.Size = New Size(22, 171)
        VolumeMeter3.TabIndex = 2
        VolumeMeter3.Text = "VolumeMeter1"
        ' 
        ' VolumeMeter1
        ' 
        VolumeMeter1.Amplitude = 0F
        VolumeMeter1.Location = New Point(668, 35)
        VolumeMeter1.MaxDb = 18.0F
        VolumeMeter1.MinDb = -60.0F
        VolumeMeter1.Name = "VolumeMeter1"
        VolumeMeter1.Size = New Size(22, 171)
        VolumeMeter1.TabIndex = 2
        VolumeMeter1.Text = "VolumeMeter1"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.FlatStyle = FlatStyle.Flat
        Label7.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label7.ForeColor = SystemColors.Info
        Label7.Location = New Point(519, 209)
        Label7.Name = "Label7"
        Label7.Size = New Size(38, 14)
        Label7.TabIndex = 1
        Label7.Text = "Label1"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.FlatStyle = FlatStyle.Flat
        Label8.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label8.ForeColor = SystemColors.Info
        Label8.Location = New Point(721, 209)
        Label8.Name = "Label8"
        Label8.Size = New Size(38, 14)
        Label8.TabIndex = 1
        Label8.Text = "Label1"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.FlatStyle = FlatStyle.Flat
        Label6.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label6.ForeColor = SystemColors.Info
        Label6.Location = New Point(621, 209)
        Label6.Name = "Label6"
        Label6.Size = New Size(38, 14)
        Label6.TabIndex = 1
        Label6.Text = "Label1"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.FlatStyle = FlatStyle.Flat
        Label5.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label5.ForeColor = SystemColors.Info
        Label5.Location = New Point(416, 209)
        Label5.Name = "Label5"
        Label5.Size = New Size(38, 14)
        Label5.TabIndex = 1
        Label5.Text = "Label1"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.FlatStyle = FlatStyle.Flat
        Label4.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label4.ForeColor = SystemColors.Info
        Label4.Location = New Point(313, 209)
        Label4.Name = "Label4"
        Label4.Size = New Size(38, 14)
        Label4.TabIndex = 1
        Label4.Text = "Label1"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.FlatStyle = FlatStyle.Flat
        Label3.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label3.ForeColor = SystemColors.Info
        Label3.Location = New Point(210, 209)
        Label3.Name = "Label3"
        Label3.Size = New Size(38, 14)
        Label3.TabIndex = 1
        Label3.Text = "Label1"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.FlatStyle = FlatStyle.Flat
        Label2.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label2.ForeColor = SystemColors.Info
        Label2.Location = New Point(107, 209)
        Label2.Name = "Label2"
        Label2.Size = New Size(38, 14)
        Label2.TabIndex = 1
        Label2.Text = "Label1"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.FlatStyle = FlatStyle.Flat
        Label1.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label1.ForeColor = SystemColors.Info
        Label1.Location = New Point(3, 209)
        Label1.Name = "Label1"
        Label1.Size = New Size(38, 14)
        Label1.TabIndex = 1
        Label1.Text = "Label1"
        ' 
        ' Button3
        ' 
        Button3.ContextMenuStrip = cmsMidiLearn
        Button3.Location = New Point(416, 0)
        Button3.Name = "Button3"
        Button3.Size = New Size(41, 19)
        Button3.TabIndex = 0
        Button3.UseVisualStyleBackColor = True
        ' 
        ' cmsMidiLearn
        ' 
        cmsMidiLearn.Items.AddRange(New ToolStripItem() {tsmiLearnMidi})
        cmsMidiLearn.Name = "cmsMidiLearn"
        cmsMidiLearn.Size = New Size(135, 26)
        ' 
        ' tsmiLearnMidi
        ' 
        tsmiLearnMidi.Name = "tsmiLearnMidi"
        tsmiLearnMidi.Size = New Size(134, 22)
        tsmiLearnMidi.Text = "Learn MIDI "
        ' 
        ' Fader8
        ' 
        Fader8.BackColor = SystemColors.ControlLight
        Fader8.ForeColor = SystemColors.Control
        Fader8.Location = New Point(721, 35)
        Fader8.Maximum = 0
        Fader8.Minimum = 0
        Fader8.Name = "Fader8"
        Fader8.Orientation = Orientation.Horizontal
        Fader8.Size = New Size(41, 171)
        Fader8.TabIndex = 0
        Fader8.Text = "Fader1"
        Fader8.Value = 0
        ' 
        ' Button8
        ' 
        Button8.ContextMenuStrip = cmsMidiLearn
        Button8.Location = New Point(721, 0)
        Button8.Name = "Button8"
        Button8.Size = New Size(41, 19)
        Button8.TabIndex = 0
        Button8.UseVisualStyleBackColor = True
        ' 
        ' Fader7
        ' 
        Fader7.BackColor = SystemColors.ControlLight
        Fader7.ContextMenuStrip = cmsMidiLearn
        Fader7.ForeColor = SystemColors.Control
        Fader7.Location = New Point(621, 35)
        Fader7.Maximum = 0
        Fader7.Minimum = 0
        Fader7.Name = "Fader7"
        Fader7.Orientation = Orientation.Horizontal
        Fader7.Size = New Size(41, 171)
        Fader7.TabIndex = 0
        Fader7.Text = "Fader1"
        Fader7.Value = 0
        ' 
        ' Button5
        ' 
        Button5.ContextMenuStrip = cmsMidiLearn
        Button5.Location = New Point(107, 0)
        Button5.Name = "Button5"
        Button5.Size = New Size(41, 19)
        Button5.TabIndex = 0
        Button5.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.ContextMenuStrip = cmsMidiLearn
        Button2.Location = New Point(313, 0)
        Button2.Name = "Button2"
        Button2.Size = New Size(41, 19)
        Button2.TabIndex = 0
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.FlatStyle = FlatStyle.Flat
        Label24.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F, FontStyle.Italic)
        Label24.ForeColor = Color.Cornsilk
        Label24.Location = New Point(727, 18)
        Label24.Name = "Label24"
        Label24.Size = New Size(31, 14)
        Label24.TabIndex = 1
        Label24.Text = "Mute"
        Label24.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.FlatStyle = FlatStyle.Flat
        Label23.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F, FontStyle.Italic)
        Label23.ForeColor = Color.Cornsilk
        Label23.Location = New Point(625, 18)
        Label23.Name = "Label23"
        Label23.Size = New Size(31, 14)
        Label23.TabIndex = 1
        Label23.Text = "Mute"
        Label23.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.FlatStyle = FlatStyle.Flat
        Label22.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F, FontStyle.Italic)
        Label22.ForeColor = Color.Cornsilk
        Label22.Location = New Point(523, 18)
        Label22.Name = "Label22"
        Label22.Size = New Size(31, 14)
        Label22.TabIndex = 1
        Label22.Text = "Mute"
        Label22.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.FlatStyle = FlatStyle.Flat
        Label21.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F, FontStyle.Italic)
        Label21.ForeColor = Color.Cornsilk
        Label21.Location = New Point(420, 18)
        Label21.Name = "Label21"
        Label21.Size = New Size(31, 14)
        Label21.TabIndex = 1
        Label21.Text = "Mute"
        Label21.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.FlatStyle = FlatStyle.Flat
        Label20.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F, FontStyle.Italic)
        Label20.ForeColor = Color.Cornsilk
        Label20.Location = New Point(316, 18)
        Label20.Name = "Label20"
        Label20.Size = New Size(31, 14)
        Label20.TabIndex = 1
        Label20.Text = "Mute"
        Label20.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.FlatStyle = FlatStyle.Flat
        Label19.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F, FontStyle.Italic)
        Label19.ForeColor = Color.Cornsilk
        Label19.Location = New Point(213, 18)
        Label19.Name = "Label19"
        Label19.Size = New Size(31, 14)
        Label19.TabIndex = 1
        Label19.Text = "Mute"
        Label19.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.FlatStyle = FlatStyle.Flat
        Label18.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F, FontStyle.Italic)
        Label18.ForeColor = Color.Cornsilk
        Label18.Location = New Point(110, 18)
        Label18.Name = "Label18"
        Label18.Size = New Size(31, 14)
        Label18.TabIndex = 1
        Label18.Text = "Mute"
        Label18.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.FlatStyle = FlatStyle.Flat
        Label17.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F, FontStyle.Italic)
        Label17.ForeColor = Color.Cornsilk
        Label17.Location = New Point(3, 18)
        Label17.Name = "Label17"
        Label17.Size = New Size(31, 14)
        Label17.TabIndex = 1
        Label17.Text = "Mute"
        Label17.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Fader6
        ' 
        Fader6.BackColor = SystemColors.ControlLight
        Fader6.ContextMenuStrip = cmsMidiLearn
        Fader6.ForeColor = SystemColors.Control
        Fader6.Location = New Point(519, 35)
        Fader6.Maximum = 0
        Fader6.Minimum = 0
        Fader6.Name = "Fader6"
        Fader6.Orientation = Orientation.Horizontal
        Fader6.Size = New Size(41, 171)
        Fader6.TabIndex = 0
        Fader6.Text = "Fader1"
        Fader6.Value = 0
        ' 
        ' Button7
        ' 
        Button7.ContextMenuStrip = cmsMidiLearn
        Button7.Location = New Point(621, 0)
        Button7.Name = "Button7"
        Button7.Size = New Size(41, 19)
        Button7.TabIndex = 0
        Button7.UseVisualStyleBackColor = True
        ' 
        ' Fader5
        ' 
        Fader5.BackColor = SystemColors.ControlLight
        Fader5.ContextMenuStrip = cmsMidiLearn
        Fader5.ForeColor = SystemColors.Control
        Fader5.Location = New Point(416, 35)
        Fader5.Maximum = 0
        Fader5.Minimum = 0
        Fader5.Name = "Fader5"
        Fader5.Orientation = Orientation.Horizontal
        Fader5.Size = New Size(41, 171)
        Fader5.TabIndex = 0
        Fader5.Text = "Fader1"
        Fader5.Value = 0
        ' 
        ' Button4
        ' 
        Button4.ContextMenuStrip = cmsMidiLearn
        Button4.Location = New Point(0, 0)
        Button4.Name = "Button4"
        Button4.Size = New Size(41, 19)
        Button4.TabIndex = 0
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Fader4
        ' 
        Fader4.BackColor = SystemColors.ControlLight
        Fader4.ContextMenuStrip = cmsMidiLearn
        Fader4.ForeColor = SystemColors.Control
        Fader4.Location = New Point(313, 35)
        Fader4.Maximum = 0
        Fader4.Minimum = 0
        Fader4.Name = "Fader4"
        Fader4.Orientation = Orientation.Horizontal
        Fader4.Size = New Size(41, 171)
        Fader4.TabIndex = 0
        Fader4.Text = "Fader1"
        Fader4.Value = 0
        ' 
        ' Button1
        ' 
        Button1.ContextMenuStrip = cmsMidiLearn
        Button1.Location = New Point(210, 0)
        Button1.Name = "Button1"
        Button1.Size = New Size(41, 19)
        Button1.TabIndex = 0
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Fader3
        ' 
        Fader3.BackColor = SystemColors.ControlLight
        Fader3.ContextMenuStrip = cmsMidiLearn
        Fader3.ForeColor = SystemColors.Control
        Fader3.Location = New Point(210, 35)
        Fader3.Maximum = 0
        Fader3.Minimum = 0
        Fader3.Name = "Fader3"
        Fader3.Orientation = Orientation.Horizontal
        Fader3.Size = New Size(41, 171)
        Fader3.TabIndex = 0
        Fader3.Text = "Fader1"
        Fader3.Value = 0
        ' 
        ' Button6
        ' 
        Button6.ContextMenuStrip = cmsMidiLearn
        Button6.Location = New Point(519, 0)
        Button6.Name = "Button6"
        Button6.Size = New Size(41, 19)
        Button6.TabIndex = 0
        Button6.UseVisualStyleBackColor = True
        ' 
        ' Fader2
        ' 
        Fader2.BackColor = SystemColors.ControlLight
        Fader2.ContextMenuStrip = cmsMidiLearn
        Fader2.ForeColor = SystemColors.Control
        Fader2.Location = New Point(107, 35)
        Fader2.Maximum = 0
        Fader2.Minimum = 0
        Fader2.Name = "Fader2"
        Fader2.Orientation = Orientation.Horizontal
        Fader2.Size = New Size(41, 171)
        Fader2.TabIndex = 0
        Fader2.Text = "Fader1"
        Fader2.Value = 0
        ' 
        ' Fader1
        ' 
        Fader1.BackColor = SystemColors.ControlLight
        Fader1.ContextMenuStrip = cmsMidiLearn
        Fader1.ForeColor = SystemColors.Control
        Fader1.Location = New Point(0, 35)
        Fader1.Maximum = 0
        Fader1.Minimum = 0
        Fader1.Name = "Fader1"
        Fader1.Orientation = Orientation.Horizontal
        Fader1.Size = New Size(41, 171)
        Fader1.TabIndex = 0
        Fader1.Text = "Fader1"
        Fader1.Value = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Silver
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Pot6)
        Panel2.Controls.Add(Pot5)
        Panel2.Controls.Add(Pot4)
        Panel2.Controls.Add(Pot3)
        Panel2.Controls.Add(Pot2)
        Panel2.Controls.Add(Pot8)
        Panel2.Controls.Add(Pot7)
        Panel2.Controls.Add(Label16)
        Panel2.Controls.Add(Label15)
        Panel2.Controls.Add(Label14)
        Panel2.Controls.Add(Label13)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(Label25)
        Panel2.Controls.Add(Label11)
        Panel2.Controls.Add(Label10)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(Pot1)
        Panel2.Location = New Point(4, 229)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(856, 82)
        Panel2.TabIndex = 1
        ' 
        ' Pot6
        ' 
        Pot6.ContextMenuStrip = cmsMidiLearn
        Pot6.Location = New Point(33, 23)
        Pot6.Margin = New Padding(4, 3, 4, 3)
        Pot6.Maximum = 1.0R
        Pot6.Minimum = 0R
        Pot6.Name = "Pot6"
        Pot6.Size = New Size(37, 37)
        Pot6.TabIndex = 2
        Pot6.Value = 0.5R
        ' 
        ' Pot5
        ' 
        Pot5.ContextMenuStrip = cmsMidiLearn
        Pot5.Location = New Point(140, 23)
        Pot5.Margin = New Padding(4, 3, 4, 3)
        Pot5.Maximum = 1.0R
        Pot5.Minimum = 0R
        Pot5.Name = "Pot5"
        Pot5.Size = New Size(37, 37)
        Pot5.TabIndex = 2
        Pot5.Value = 0.5R
        ' 
        ' Pot4
        ' 
        Pot4.ContextMenuStrip = cmsMidiLearn
        Pot4.Location = New Point(240, 23)
        Pot4.Margin = New Padding(4, 3, 4, 3)
        Pot4.Maximum = 1.0R
        Pot4.Minimum = 0R
        Pot4.Name = "Pot4"
        Pot4.Size = New Size(37, 37)
        Pot4.TabIndex = 2
        Pot4.Value = 0.5R
        ' 
        ' Pot3
        ' 
        Pot3.ContextMenuStrip = cmsMidiLearn
        Pot3.Location = New Point(343, 23)
        Pot3.Margin = New Padding(4, 3, 4, 3)
        Pot3.Maximum = 1.0R
        Pot3.Minimum = 0R
        Pot3.Name = "Pot3"
        Pot3.Size = New Size(37, 37)
        Pot3.TabIndex = 2
        Pot3.Value = 0.5R
        ' 
        ' Pot2
        ' 
        Pot2.ContextMenuStrip = cmsMidiLearn
        Pot2.Location = New Point(446, 23)
        Pot2.Margin = New Padding(4, 3, 4, 3)
        Pot2.Maximum = 1.0R
        Pot2.Minimum = 0R
        Pot2.Name = "Pot2"
        Pot2.Size = New Size(37, 37)
        Pot2.TabIndex = 2
        Pot2.Value = 0.5R
        ' 
        ' Pot8
        ' 
        Pot8.ContextMenuStrip = cmsMidiLearn
        Pot8.Location = New Point(754, 23)
        Pot8.Margin = New Padding(4, 3, 4, 3)
        Pot8.Maximum = 1.0R
        Pot8.Minimum = 0R
        Pot8.Name = "Pot8"
        Pot8.Size = New Size(37, 37)
        Pot8.TabIndex = 2
        Pot8.Value = 0.5R
        ' 
        ' Pot7
        ' 
        Pot7.ContextMenuStrip = cmsMidiLearn
        Pot7.Location = New Point(651, 23)
        Pot7.Margin = New Padding(4, 3, 4, 3)
        Pot7.Maximum = 1.0R
        Pot7.Minimum = 0R
        Pot7.Name = "Pot7"
        Pot7.Size = New Size(37, 37)
        Pot7.TabIndex = 2
        Pot7.Value = 0.5R
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.FlatStyle = FlatStyle.Flat
        Label16.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label16.ForeColor = SystemColors.ActiveCaptionText
        Label16.Location = New Point(754, 63)
        Label16.Name = "Label16"
        Label16.Size = New Size(38, 14)
        Label16.TabIndex = 1
        Label16.Text = "Label1"
        Label16.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.FlatStyle = FlatStyle.Flat
        Label15.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label15.ForeColor = SystemColors.ActiveCaptionText
        Label15.Location = New Point(651, 63)
        Label15.Name = "Label15"
        Label15.Size = New Size(38, 14)
        Label15.TabIndex = 1
        Label15.Text = "Label1"
        Label15.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.FlatStyle = FlatStyle.Flat
        Label14.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label14.ForeColor = SystemColors.ActiveCaptionText
        Label14.Location = New Point(549, 63)
        Label14.Name = "Label14"
        Label14.Size = New Size(38, 14)
        Label14.TabIndex = 1
        Label14.Text = "Label1"
        Label14.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.FlatStyle = FlatStyle.Flat
        Label13.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label13.ForeColor = SystemColors.ActiveCaptionText
        Label13.Location = New Point(446, 63)
        Label13.Name = "Label13"
        Label13.Size = New Size(38, 14)
        Label13.TabIndex = 1
        Label13.Text = "Label1"
        Label13.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.FlatStyle = FlatStyle.Flat
        Label12.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label12.ForeColor = SystemColors.ActiveCaptionText
        Label12.Location = New Point(343, 63)
        Label12.Name = "Label12"
        Label12.Size = New Size(38, 14)
        Label12.TabIndex = 1
        Label12.Text = "Label1"
        Label12.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label25
        ' 
        Label25.AutoSize = True
        Label25.FlatStyle = FlatStyle.Flat
        Label25.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label25.ForeColor = SystemColors.ActiveCaptionText
        Label25.Location = New Point(139, 63)
        Label25.Name = "Label25"
        Label25.Size = New Size(38, 14)
        Label25.TabIndex = 1
        Label25.Text = "Label1"
        Label25.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.FlatStyle = FlatStyle.Flat
        Label11.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label11.ForeColor = SystemColors.ActiveCaptionText
        Label11.Location = New Point(239, 63)
        Label11.Name = "Label11"
        Label11.Size = New Size(38, 14)
        Label11.TabIndex = 1
        Label11.Text = "Label1"
        Label11.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.FlatStyle = FlatStyle.Flat
        Label10.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label10.ForeColor = SystemColors.ActiveCaptionText
        Label10.Location = New Point(136, 63)
        Label10.Name = "Label10"
        Label10.Size = New Size(38, 14)
        Label10.TabIndex = 1
        Label10.Text = "Label1"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.FlatStyle = FlatStyle.Flat
        Label9.Font = New Font("Bahnschrift Light SemiCondensed", 9.0F)
        Label9.ForeColor = SystemColors.ActiveCaptionText
        Label9.Location = New Point(33, 63)
        Label9.Name = "Label9"
        Label9.Size = New Size(38, 14)
        Label9.TabIndex = 1
        Label9.Text = "Label1"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Pot1
        ' 
        Pot1.ContextMenuStrip = cmsMidiLearn
        Pot1.Location = New Point(549, 23)
        Pot1.Margin = New Padding(4, 3, 4, 3)
        Pot1.Maximum = 1.0R
        Pot1.Minimum = 0R
        Pot1.Name = "Pot1"
        Pot1.Size = New Size(37, 37)
        Pot1.TabIndex = 2
        Pot1.Value = 0.5R
        ' 
        ' cboMidiInDevices
        ' 
        cboMidiInDevices.Font = New Font("Bahnschrift Light SemiCondensed", 10.0F)
        cboMidiInDevices.FormattingEnabled = True
        cboMidiInDevices.Location = New Point(693, 133)
        cboMidiInDevices.Name = "cboMidiInDevices"
        cboMidiInDevices.Size = New Size(159, 24)
        cboMidiInDevices.TabIndex = 4
        ' 
        ' Label26
        ' 
        Label26.AutoSize = True
        Label26.BackColor = Color.Transparent
        Label26.BorderStyle = BorderStyle.FixedSingle
        Label26.Font = New Font("Bahnschrift Light SemiCondensed", 12.0F)
        Label26.ForeColor = SystemColors.ButtonHighlight
        Label26.Location = New Point(693, 109)
        Label26.Name = "Label26"
        Label26.Size = New Size(87, 21)
        Label26.TabIndex = 5
        Label26.Text = "MIDI Device:"
        ' 
        ' Label27
        ' 
        Label27.AutoSize = True
        Label27.BackColor = Color.Transparent
        Label27.BorderStyle = BorderStyle.FixedSingle
        Label27.Font = New Font("Bahnschrift Light SemiCondensed", 20.0F)
        Label27.ForeColor = SystemColors.ButtonHighlight
        Label27.Location = New Point(708, 9)
        Label27.Name = "Label27"
        Label27.Size = New Size(144, 35)
        Label27.TabIndex = 5
        Label27.Text = "MiDi Ghost®"
        ' 
        ' BtnConnect
        ' 
        BtnConnect.Font = New Font("Segoe UI", 7.0F)
        BtnConnect.Location = New Point(4, 160)
        BtnConnect.Name = "BtnConnect"
        BtnConnect.Size = New Size(51, 21)
        BtnConnect.TabIndex = 6
        BtnConnect.Text = "Connect"
        BtnConnect.UseVisualStyleBackColor = True
        ' 
        ' BtnDisconnect
        ' 
        BtnDisconnect.Font = New Font("Segoe UI", 7.0F)
        BtnDisconnect.Location = New Point(61, 160)
        BtnDisconnect.Name = "BtnDisconnect"
        BtnDisconnect.Size = New Size(63, 21)
        BtnDisconnect.TabIndex = 6
        BtnDisconnect.Text = "Disconnect"
        BtnDisconnect.UseVisualStyleBackColor = True
        ' 
        ' lblConnectedDevice
        ' 
        lblConnectedDevice.AutoSize = True
        lblConnectedDevice.BackColor = Color.Transparent
        lblConnectedDevice.BorderStyle = BorderStyle.FixedSingle
        lblConnectedDevice.Font = New Font("Bahnschrift Light SemiCondensed", 12.0F)
        lblConnectedDevice.ForeColor = SystemColors.ButtonHighlight
        lblConnectedDevice.Location = New Point(192, 158)
        lblConnectedDevice.Name = "lblConnectedDevice"
        lblConnectedDevice.Size = New Size(87, 21)
        lblConnectedDevice.TabIndex = 5
        lblConnectedDevice.Text = "MIDI Device:"
        ' 
        ' cboMidiOutDevices
        ' 
        cboMidiOutDevices.Font = New Font("Bahnschrift Light SemiCondensed", 10.0F)
        cboMidiOutDevices.FormattingEnabled = True
        cboMidiOutDevices.Location = New Point(693, 157)
        cboMidiOutDevices.Name = "cboMidiOutDevices"
        cboMidiOutDevices.Size = New Size(159, 24)
        cboMidiOutDevices.TabIndex = 4
        ' 
        ' Label28
        ' 
        Label28.AutoSize = True
        Label28.BackColor = Color.Transparent
        Label28.BorderStyle = BorderStyle.FixedSingle
        Label28.Font = New Font("Bahnschrift Light SemiCondensed", 12.0F)
        Label28.ForeColor = SystemColors.ButtonHighlight
        Label28.Location = New Point(619, 133)
        Label28.Name = "Label28"
        Label28.Size = New Size(56, 21)
        Label28.TabIndex = 5
        Label28.Text = "MIDI IN"
        ' 
        ' Label29
        ' 
        Label29.AutoSize = True
        Label29.BackColor = Color.Transparent
        Label29.BorderStyle = BorderStyle.FixedSingle
        Label29.Font = New Font("Bahnschrift Light SemiCondensed", 12.0F)
        Label29.ForeColor = SystemColors.ButtonHighlight
        Label29.Location = New Point(619, 160)
        Label29.Name = "Label29"
        Label29.Size = New Size(68, 21)
        Label29.TabIndex = 5
        Label29.Text = "MIDI OUT"
        ' 
        ' lbxMidiAddresses
        ' 
        lbxMidiAddresses.AllowUserToAddRows = False
        lbxMidiAddresses.AllowUserToDeleteRows = False
        lbxMidiAddresses.BackgroundColor = SystemColors.ActiveCaption
        lbxMidiAddresses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        lbxMidiAddresses.Columns.AddRange(New DataGridViewColumn() {MiDi_IN, MIDI_OUT})
        lbxMidiAddresses.GridColor = SystemColors.Window
        lbxMidiAddresses.Location = New Point(376, 4)
        lbxMidiAddresses.Name = "lbxMidiAddresses"
        lbxMidiAddresses.ReadOnly = True
        lbxMidiAddresses.Size = New Size(235, 150)
        lbxMidiAddresses.TabIndex = 7
        ' 
        ' MiDi_IN
        ' 
        MiDi_IN.Frozen = True
        MiDi_IN.HeaderText = "MIDI IN"
        MiDi_IN.Name = "MiDi_IN"
        MiDi_IN.ReadOnly = True
        ' 
        ' MIDI_OUT
        ' 
        MIDI_OUT.Frozen = True
        MIDI_OUT.HeaderText = "MIDI OUT"
        MIDI_OUT.Name = "MIDI_OUT"
        MIDI_OUT.ReadOnly = True
        ' 
        ' rtbMidiLog
        ' 
        rtbMidiLog.AcceptsTab = True
        rtbMidiLog.BackColor = SystemColors.ScrollBar
        rtbMidiLog.BorderStyle = BorderStyle.None
        rtbMidiLog.Location = New Point(5, 4)
        rtbMidiLog.Name = "rtbMidiLog"
        rtbMidiLog.Size = New Size(365, 150)
        rtbMidiLog.TabIndex = 8
        rtbMidiLog.Text = ""
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ControlDarkDark
        ClientSize = New Size(864, 548)
        Controls.Add(rtbMidiLog)
        Controls.Add(lbxMidiAddresses)
        Controls.Add(BtnDisconnect)
        Controls.Add(BtnConnect)
        Controls.Add(Label27)
        Controls.Add(lblConnectedDevice)
        Controls.Add(Label29)
        Controls.Add(Label28)
        Controls.Add(Label26)
        Controls.Add(cboMidiOutDevices)
        Controls.Add(cboMidiInDevices)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "Form1"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        cmsMidiLearn.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(lbxMidiAddresses, ComponentModel.ISupportInitialize).EndInit()
        CType(BindingSource1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Fader1 As NAudio.Gui.Fader
    Friend WithEvents Label1 As Label
    Friend WithEvents Fader7 As NAudio.Gui.Fader
    Friend WithEvents Fader6 As NAudio.Gui.Fader
    Friend WithEvents Fader5 As NAudio.Gui.Fader
    Friend WithEvents Fader4 As NAudio.Gui.Fader
    Friend WithEvents Fader3 As NAudio.Gui.Fader
    Friend WithEvents Fader2 As NAudio.Gui.Fader
    Friend WithEvents Fader8 As NAudio.Gui.Fader
    Friend WithEvents Pot1 As NAudio.Gui.Pot
    Friend WithEvents Pot6 As NAudio.Gui.Pot
    Friend WithEvents Pot5 As NAudio.Gui.Pot
    Friend WithEvents Pot4 As NAudio.Gui.Pot
    Friend WithEvents Pot3 As NAudio.Gui.Pot
    Friend WithEvents Pot2 As NAudio.Gui.Pot
    Friend WithEvents Pot8 As NAudio.Gui.Pot
    Friend WithEvents Pot7 As NAudio.Gui.Pot
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents VolumeMeter2 As NAudio.Gui.VolumeMeter
    Friend WithEvents VolumeMeter8 As NAudio.Gui.VolumeMeter
    Friend WithEvents VolumeMeter7 As NAudio.Gui.VolumeMeter
    Friend WithEvents VolumeMeter6 As NAudio.Gui.VolumeMeter
    Friend WithEvents VolumeMeter5 As NAudio.Gui.VolumeMeter
    Friend WithEvents VolumeMeter4 As NAudio.Gui.VolumeMeter
    Friend WithEvents VolumeMeter3 As NAudio.Gui.VolumeMeter
    Friend WithEvents VolumeMeter1 As NAudio.Gui.VolumeMeter
    Friend WithEvents cboMidiInDevices As ComboBox
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents BtnConnect As Button
    Friend WithEvents BtnDisconnect As Button
    Friend WithEvents lblConnectedDevice As Label
    Friend WithEvents cboMidiOutDevices As ComboBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents lbxMidiAddresses As DataGridView
    Friend WithEvents MiDi_IN As DataGridViewTextBoxColumn
    Friend WithEvents MIDI_OUT As DataGridViewTextBoxColumn
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents rtbMidiLog As RichTextBox
    Friend WithEvents cmsMidiLearn As ContextMenuStrip
    Friend WithEvents tsmiLearnMidi As ToolStripMenuItem

End Class
