Imports NAudio.Midi
Imports System.Text
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Form1

    Private _midiIn As MidiIn
    Private _midiOut As MidiOut
    Private Const MIDI_CHANNEL_TO_CONNECT As Integer = 1

    Private LearnedMidiAddresses As New Dictionary(Of String, Integer)()
    Private IsLearning As Boolean
    Private ControlToLearn As Object
    Private ExpectedMidiMessageType As String
    Private MidiControlMappings As Object
    Private learned As Boolean
    'Public MidiControlMappings As Object

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        PopulateMidiDevices()
        If cboMidiInDevices.Items.Count = 1 AndAlso cboMidiOutDevices.Items.Count = 1 Then
            cboMidiInDevices.SelectedIndex = 0
            cboMidiOutDevices.SelectedIndex = 0
            ConnectMidi()
        End If
    End Sub

    Private Sub PopulateMidiDevices()
        ' MIDI-Eingangsgeräte auflisten
        cboMidiInDevices.Items.Clear()
        For i As Integer = 0 To MidiIn.NumberOfDevices - 1 ' <-- Korrektur hier
            cboMidiInDevices.Items.Add(MidiIn.DeviceInfo(i).ProductName) ' <-- Korrektur hier
        Next
        If MidiIn.NumberOfDevices > 0 Then ' <-- Korrektur hier
            cboMidiInDevices.SelectedIndex = 0
        End If

        ' MIDI-Ausgangsgeräte auflisten
        cboMidiOutDevices.Items.Clear()
        For i As Integer = 0 To MidiOut.NumberOfDevices - 1 ' <-- Korrektur hier
            cboMidiOutDevices.Items.Add(MidiOut.DeviceInfo(i).ProductName) ' <-- Korrektur hier
        Next
        If MidiOut.NumberOfDevices > 0 Then ' <-- Korrektur hier
            cboMidiOutDevices.SelectedIndex = 0
        End If
    End Sub

    ' ... (Der Rest des Codes bleibt wie im vorherigen Beispiel) ...

    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles BtnConnect.Click
        ConnectMidi()
    End Sub

    Private Sub ConnectMidi()
        DisconnectMidi()

        If cboMidiInDevices.SelectedIndex >= 0 Then
            Try
                _midiIn = New MidiIn(cboMidiInDevices.SelectedIndex)
                AddHandler _midiIn.MessageReceived, AddressOf MidiIn_MessageReceived
                AddHandler _midiIn.ErrorReceived, AddressOf MidiIn_ErrorReceived
                _midiIn.Start()
                LogMessage($"Verbunden mit MIDI IN: {MidiIn.DeviceInfo(cboMidiInDevices.SelectedIndex).ProductName}{Environment.NewLine}")
                lblConnectedDevice.Text = $"Verbunden mit: {MidiIn.DeviceInfo(cboMidiInDevices.SelectedIndex).ProductName}"
                LearnedMidiAddresses.Clear()

            Catch ex As Exception
                MessageBox.Show($"Fehler beim Verbinden mit MIDI IN: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Bitte wählen Sie ein MIDI IN Gerät aus.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        If cboMidiOutDevices.SelectedIndex >= 0 Then
            Try
                _midiOut = New MidiOut(cboMidiOutDevices.SelectedIndex)
                LogMessage($"Verbunden mit MIDI OUT: {MidiOut.DeviceInfo(cboMidiOutDevices.SelectedIndex).ProductName}{Environment.NewLine}")
            Catch ex As Exception
                MessageBox.Show($"Fehler beim Verbinden mit MIDI OUT: {ex.Message}", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("Bitte wählen Sie ein MIDI OUT Gerät aus.", "Warnung", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub BtnDisconnect_Click(sender As Object, e As EventArgs) Handles BtnDisconnect.Click
        DisconnectMidi()
        LogMessage("MIDI-Verbindung getrennt." & Environment.NewLine)
        lblConnectedDevice.Text = "Nicht verbunden"
    End Sub

    Private Sub DisconnectMidi()
        If _midiIn IsNot Nothing Then
            _midiIn.Stop()
            RemoveHandler _midiIn.MessageReceived, AddressOf MidiIn_MessageReceived
            RemoveHandler _midiIn.ErrorReceived, AddressOf MidiIn_ErrorReceived
            _midiIn.Dispose()
            _midiIn = Nothing
        End If
        If _midiOut IsNot Nothing Then
            _midiOut.Dispose()
            _midiOut = Nothing
        End If
    End Sub

    Private Sub MidiIn_MessageReceived(sender As Object, e As MidiInMessageEventArgs)
        Me.Invoke(Sub()
                      ' SICHERSTELLEN, DASS DAS DICTIONARY INITIALISIERT IST
                      If MidiControlMappings Is Nothing Then
                          MidiControlMappings = New Dictionary(Of Integer, Control)()
                          LogMessage("INFO: MidiControlMappings wurde initialisiert (war Nothing)." & Environment.NewLine)
                      End If

                      Dim messageBuilder As New StringBuilder()
                      Dim rawMessage As Integer = e.RawMessage

                      ' --- LERNMODUS LOGIK ---
                      If IsLearning AndAlso ControlToLearn IsNot Nothing Then
                          Dim learned As Boolean = False
                          Dim midiNumber As Integer = -1
                          Dim midiType As String = ""

                          If e.MidiEvent IsNot Nothing Then
                              Select Case e.MidiEvent.CommandCode
                                  Case MidiCommandCode.NoteOn
                                      Dim noteOn As NoteOnEvent = CType(e.MidiEvent, NoteOnEvent)
                                      If ExpectedMidiMessageType = "Note" OrElse ExpectedMidiMessageType = "" Then
                                          midiNumber = noteOn.NoteNumber
                                          midiType = "Note"
                                          learned = True
                                          LogMessage($"Gelernt: '{ControlToLearn.Name}' an MIDI Note {noteOn.NoteNumber} ({noteOn.NoteName}){Environment.NewLine}")
                                      End If

                                  Case MidiCommandCode.ControlChange
                                      Dim controlChange As ControlChangeEvent = CType(e.MidiEvent, ControlChangeEvent)
                                      If ExpectedMidiMessageType = "CC" OrElse ExpectedMidiMessageType = "" Then
                                          midiNumber = controlChange.Controller
                                          midiType = "CC"
                                          learned = True
                                          LogMessage($"Gelernt: '{ControlToLearn.Name}' an MIDI CC {controlChange.Controller} ({CType(controlChange.Controller, MidiController)}){Environment.NewLine}")
                                      End If

                                  Case MidiCommandCode.PitchWheelChange
                                      Dim pitchWheel As PitchWheelChangeEvent = CType(e.MidiEvent, PitchWheelChangeEvent)
                                      If ExpectedMidiMessageType = "PitchBend" OrElse ExpectedMidiMessageType = "" Then
                                          midiNumber = -2 ' Platzhalter für Pitch Bend
                                          midiType = "PitchBend"
                                          learned = True
                                          LogMessage($"Gelernt: '{ControlToLearn.Name}' an MIDI Pitch Bend{Environment.NewLine}")
                                      End If
                              End Select
                          End If

                          If learned Then
                              ' HIER IST DIE KORREKTUR: Verwenden Sie ContainsKey()
                              If MidiControlMappings.ContainsKey(midiNumber) Then
                                  MidiControlMappings(midiNumber) = ControlToLearn
                              Else
                                  MidiControlMappings.Add(midiNumber, ControlToLearn)
                              End If

                              ' Update den gelernten Adressen-Log
                              LearnMidiAddress($"{midiType}: {ControlToLearn.Name}", midiNumber, midiType)

                              ' Lernmodus beenden
                              IsLearning = False
                              ControlToLearn = Nothing
                              ExpectedMidiMessageType = ""
                              Return ' Nachricht wurde für Lernzwecke verwendet, keine weitere Verarbeitung als Log
                          Else
                              If IsLearning Then
                                  Dim controlName As String = If(ControlToLearn IsNot Nothing, ControlToLearn.Name, "unbekanntes Control")
                                  LogMessage($"WARNUNG: '{controlName}' erwartet {ExpectedMidiMessageType}, aber {e.MidiEvent?.CommandCode} empfangen. Versuchen Sie es erneut.{Environment.NewLine}")
                              End If
                          End If
                      End If
                      ' --- ENDE LERNMODUS LOGIK ---


                      ' --- NORMALE VERARBEITUNG DER MIDI-NACHRICHTEN ---
                      If e.MidiEvent IsNot Nothing Then
                          Select Case e.MidiEvent.CommandCode
                              Case MidiCommandCode.NoteOn
                                  Dim noteOn As NoteOnEvent = CType(e.MidiEvent, NoteOnEvent)
                                  messageBuilder.Append($"Note On - Kanal: {noteOn.Channel}, Note: {noteOn.NoteNumber} ({noteOn.NoteName}), Velocity: {noteOn.Velocity}")
                                  If MidiControlMappings.ContainsKey(noteOn.NoteNumber) Then
                                      Dim targetControl As Control = MidiControlMappings(noteOn.NoteNumber)
                                      If targetControl IsNot Nothing Then
                                          If TypeOf targetControl Is Button Then
                                              CType(targetControl, Button).PerformClick()
                                              CType(targetControl, Button).BackColor = System.Drawing.Color.LightBlue
                                          End If
                                      End If
                                  End If
                              Case MidiCommandCode.NoteOff
                                  Dim noteOff As NoteEvent = CType(e.MidiEvent, NoteEvent)
                                  messageBuilder.Append($"Note Off - Kanal: {noteOff.Channel}, Note: {noteOff.NoteNumber} ({noteOff.NoteName}), Velocity: {noteOff.Velocity}")
                                  If MidiControlMappings.ContainsKey(noteOff.NoteNumber) Then
                                      Dim targetControl As Control = MidiControlMappings(noteOff.NoteNumber)
                                      If targetControl IsNot Nothing Then
                                          If TypeOf targetControl Is Button Then
                                              CType(targetControl, Button).BackColor = System.Drawing.SystemColors.Control
                                          End If
                                      End If
                                  End If
                              Case MidiCommandCode.ControlChange
                                  Dim controlChange As ControlChangeEvent = CType(e.MidiEvent, ControlChangeEvent)
                                  messageBuilder.Append(value:=$"Control Change - Kanal: {controlChange.Channel}, Controller: {controlChange.Controller} ({controlChange.Controller}), Wert: {controlChange.ControllerValue}")

                                  If MidiControlMappings.ContainsKey(controlChange.Controller) Then
                                      Dim targetControl As Control = MidiControlMappings(controlChange.Controller)
                                      If targetControl IsNot Nothing Then
                                          If TypeOf targetControl Is NAudio.Gui.Fader Then
                                              Dim scaledValue As Integer = CInt((controlChange.ControllerValue) / 127.0)
                                              CType(targetControl, NAudio.Gui.Fader).Value = scaledValue
                                          ElseIf TypeOf targetControl Is NAudio.Gui.Pot Then

                                              ' MessageBox.Show("scalesValue: " & scaledValue)
                                              Label10.Text = ((controlChange.ControllerValue) / 127).ToString()
                                              CType(targetControl, NAudio.Gui.Pot).Value = CInt((controlChange.ControllerValue) / 127)
                                              CType(targetControl, NAudio.Gui.Pot).Capture = True
                                          ElseIf TypeOf targetControl Is Label Then
                                              CType(targetControl, Label).Text = controlChange.ControllerValue.ToString()
                                          End If
                                      Else
                                          LogMessage($"WARNUNG: Zugeordnetes Control für CC {controlChange.Controller} ist Nothing. Zuordnung wird entfernt.{Environment.NewLine}")
                                          MidiControlMappings.Remove(controlChange.Controller)
                                          UpdateLearnedAddressesList()
                                      End If
                                  End If

                              Case MidiCommandCode.PitchWheelChange
                                  Dim pitchWheel As PitchWheelChangeEvent = CType(e.MidiEvent, PitchWheelChangeEvent)
                                  messageBuilder.Append($"Pitch Bend - Kanal: {pitchWheel.Channel}, Wert: {pitchWheel.Pitch}")
                                  If MidiControlMappings.ContainsKey(-2) Then
                                      Dim targetControl As Control = MidiControlMappings(-2)
                                      If targetControl IsNot Nothing Then
                                          If TypeOf targetControl Is NAudio.Gui.Fader Then
                                              Dim scaledValue As Integer = CInt((pitchWheel.Pitch + 8192) / 16383.0 * 127.0)
                                              CType(targetControl, NAudio.Gui.Fader).Value = scaledValue
                                          End If
                                      End If
                                  End If

                              Case MidiCommandCode.PatchChange, MidiCommandCode.ChannelAfterTouch, MidiCommandCode.KeyAfterTouch
                    ' ... Verarbeitungslogik ...

                              Case MidiCommandCode.TimingClock, MidiCommandCode.StartSequence, MidiCommandCode.StopSequence, MidiCommandCode.ContinueSequence, MidiCommandCode.AutoSensing, MidiCommandCode.Sysex
                                  If e.MidiEvent.CommandCode = MidiCommandCode.AutoSensing OrElse e.MidiEvent.CommandCode = MidiCommandCode.TimingClock Then Return
                                  If e.MidiEvent.CommandCode = MidiCommandCode.Sysex Then
                                      Dim sysEx As SysexEvent = CType(e.MidiEvent, SysexEvent)
                                      messageBuilder.Append($"SysEx Nachricht - Länge: {sysEx.CommandCode} Bytes")
                                  Else
                                      messageBuilder.Append($"{e.MidiEvent.CommandCode} Event")
                                  End If

                              Case Else
                                  messageBuilder.Append($"Unbekanntes MIDI Event: {e.MidiEvent.CommandCode}, Roh: 0x{rawMessage:X}")
                          End Select
                      Else
                          messageBuilder.Append($"Rohdaten empfangen: 0x{rawMessage:X}")
                      End If

                      LogMessage($"[{e.Timestamp}] {messageBuilder}{Environment.NewLine}")
                  End Sub)
    End Sub

    Private Sub MidiIn_ErrorReceived(sender As Object, e As MidiInMessageEventArgs)
        Me.Invoke(Sub()
                      LogMessage($"[FEHLER] Rohdaten: 0x{e.RawMessage:X}{Environment.NewLine}")
                  End Sub)
    End Sub

    Private Function GetRtbMidiLog()
        Return rtbMidiLog.Text.Aggregate(New NAudio.Utils.ProgressLog(), Function(log, line) log.Text.Append(line))
    End Function

    Private Sub LogMessage(message As String)
        If Me.rtbMidiLog.InvokeRequired Then
            Me.rtbMidiLog.Invoke(Sub()
                                     Me.rtbMidiLog.AppendText(message)
                                     Me.rtbMidiLog.ScrollToCaret()
                                 End Sub)
        Else
            Me.rtbMidiLog.AppendText(message)
            Me.rtbMidiLog.ScrollToCaret()
        End If
    End Sub

    Private Sub UpdateLearnedAddressesList()
        Me.Invoke(Sub()
                      lbxMidiAddresses.Rows.Clear() ' DataGridView Zeilen löschen
                      For Each kvp As KeyValuePair(Of String, Integer) In LearnedMidiAddresses
                          ' Eine neue Zeile hinzufügen
                          lbxMidiAddresses.Rows.Add(kvp.Key, kvp.Value)
                      Next
                  End Sub)
    End Sub
    ' Fügt eine gelernte MIDI-Adresse hinzu oder aktualisiert sie
    Private Sub LearnMidiAddress(description As String, midiNumber As Integer, midiType As String)
        ' Der Key für das Dictionary ist eine Kombination aus Typ und Beschreibung/Nummer, um Eindeutigkeit zu gewährleisten
        Dim dictKey As String = $"{midiType}: {description}"
        If LearnedMidiAddresses.TryAdd(dictKey, midiNumber) Then
            UpdateLearnedAddressesList()
        Else
            ' Wenn die Adresse bereits gelernt wurde, können wir sie optional aktualisieren oder ignorieren
            ' In diesem Fall ignorieren wir, um keine Duplikate im lbxMidiAddresses zu haben.
        End If
    End Sub
    ' NEU: Event-Handler für den "Lernen"-Menüpunkt im ContextMenuStrip
    Private Sub TsmiLearnMidi_Click(sender As Object, e As EventArgs) Handles tsmiLearnMidi.Click
        ' Der 'sender' ist hier der ToolStripMenuItem (tsmiLearnMidi)
        ' Um auf das Control zuzugreifen, das das ContextMenuStrip geöffnet hat,
        ' verwenden wir die SourceControl-Eigenschaft des ContextMenuStrip.
        Dim clickedControl As Control = CType(cmsMidiLearn.SourceControl, Control)

        If clickedControl IsNot Nothing Then
            LogMessage($"Lernmodus aktiviert für: {clickedControl.Name}. Bitte bewegen Sie ein MIDI-Steuerelement.{Environment.NewLine}")
            IsLearning = True
            ControlToLearn = clickedControl ' Speichere das Control, das lernt
            ExpectedMidiMessageType = "" ' Erlaubt jeden MIDI-Nachrichtentyp
            ' Oder spezifisch:
            If TypeOf clickedControl Is Button Then
                ExpectedMidiMessageType = "Note" ' Knöpfe lernen oft Noten
            ElseIf TypeOf clickedControl Is NAudio.Gui.Fader OrElse TypeOf clickedControl Is NAudio.Gui.Pot Then
                ExpectedMidiMessageType = "CC" ' Fader/Pots lernen oft Control Changes
            End If

        Else
            LogMessage("Fehler: Kein Control erkannt für den Lernmodus.{Environment.NewLine}")
        End If
    End Sub

    ' Wichtig: Ressourcen freigeben, wenn das Formular geschlossen wird
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        DisconnectMidi()
    End Sub

    ' NEU: Anpassung für DataGridView (falls verwendet)
    ' Initialisierung der Spalten
    Private Sub LbxMidiAddresses_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles lbxMidiAddresses.CellContentClick
        ' Dies ist ein Beispiel-Handler, um eine Fehlermeldung zu vermeiden, falls Sie darauf klicken.
        ' Sie können hier Logik hinzufügen, wenn Sie auf Zellen klicken.
    End Sub





    Private Sub Form1_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ' Initialisiere die Spalten des DataGridView, wenn das Formular angezeigt wird
        If lbxMidiAddresses.Columns.Count = 0 Then
            lbxMidiAddresses.Columns.Add("MiDi_IN", "MIDI Address Type / Control Name")
            lbxMidiAddresses.Columns.Add("MIDI_OUT", "MIDI Number")
            lbxMidiAddresses.Columns("MiDi_IN").Width = 200 ' Oder AutoSizeColumnsMode
            lbxMidiAddresses.Columns("MIDI_OUT").Width = 100
        End If
    End Sub

    Private Sub Pot6_ValueChanged(sender As Object, e As EventArgs) Handles Pot6.ValueChanged
        If True Then
            Label9.Text = Pot6.Value
        End If
    End Sub


End Class