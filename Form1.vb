Imports NAudio.Midi
Imports System.Text
Imports System.Collections.Generic

Public Class Form1

    Private _midiIn As MidiIn
    Private _midiOut As MidiOut
    Private Const MIDI_CHANNEL_TO_CONNECT As Integer = 1

    Private LearnedMidiAddresses As New Dictionary(Of String, Integer)()
    Private IsLearning As Boolean
    Private ControlToLearn As Object
    Private ExpectedMidiMessageType As String
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
        ' Da das Event in einem anderen Thread ausgelöst wird,
        ' müssen wir Invoke verwenden, um auf UI-Elemente zuzugreifen.
        Me.Invoke(Sub()
                      Dim messageBuilder As New StringBuilder()
                      Dim rawMessage As Integer = e.RawMessage

                      ' Parsen der MIDI-Nachricht und Log-Ausgabe
                      If e.MidiEvent IsNot Nothing Then
                          Select Case e.MidiEvent.CommandCode
                              Case MidiCommandCode.NoteOn
                                  Dim noteOn As NoteOnEvent = CType(e.MidiEvent, NoteOnEvent)
                                  messageBuilder.Append($"Note On - Kanal: {noteOn.Channel}, Note: {noteOn.NoteNumber} ({noteOn.NoteName}), Velocity: {noteOn.Velocity}")
                                  ' Beispiel: MIDI Note-On an ein Control binden
                                  If noteOn.Channel = MIDI_CHANNEL_TO_CONNECT AndAlso noteOn.NoteNumber Then ' Z.B. C4
                                      '     ' Hier könnten Sie ein UI-Element (z.B. ein Label) aktualisieren

                                  End If
                                  LearnMidiAddress($"Note {noteOn.NoteName} (Nr. {noteOn.NoteNumber})", noteOn.NoteNumber, "Note")

                              Case MidiCommandCode.NoteOff
                                  Dim noteOff As NoteEvent = CType(e.MidiEvent, NoteEvent)
                                  messageBuilder.Append($"Note Off - Kanal: {noteOff.Channel}, Note: {noteOff.NoteNumber} ({noteOff.NoteName}), Velocity: {noteOff.Velocity}")
                                  LearnMidiAddress($"Note {noteOff.NoteName} (Nr. {noteOff.NoteNumber})", noteOff.NoteNumber, "Note")

                              Case MidiCommandCode.ControlChange
                                  Dim controlChange As ControlChangeEvent = CType(e.MidiEvent, ControlChangeEvent)
                                  messageBuilder.Append(value:=$"Control Change - Kanal: {controlChange.Channel}, Controller: {controlChange.Controller} ({controlChange.Controller}), Wert: {controlChange.ControllerValue}")
                                  ' Hier binden Sie den Control Change Wert an ein UI-Element
                                  If controlChange.Channel = MIDI_CHANNEL_TO_CONNECT Then
                                      Select Case CType(controlChange.Controller, MidiController)
                                          Case MidiController.MainVolume ' Beispiel: MIDI CC 7
                                              ' LogMessage($"Lautstärke (CC7): {controlChange.ControllerValue}{Environment.NewLine}")
                                              ' Hier könnten Sie einen Slider aktualisieren:
                                              ' Me.hsbVolume.Value = controlChange.ControllerValue
                                          Case MidiController.Pan
                                              ' LogMessage($"Panorama (CC10): {controlChange.ControllerValue}{Environment.NewLine}")
                                          Case Else
                                              ' Andere Controller
                                      End Select
                                      LearnMidiAddress(description:=$"CC {controlChange.Controller} ({controlChange.Controller})", controlChange.Controller, "CC")
                                  End If

                              Case MidiCommandCode.PitchWheelChange
                                  Dim pitchWheel As PitchWheelChangeEvent = CType(e.MidiEvent, PitchWheelChangeEvent)
                                  messageBuilder.Append($"Pitch Bend - Kanal: {pitchWheel.Channel}, Wert: {pitchWheel.Pitch}")
                                  LearnMidiAddress("Pitch Bend", -1, "PitchBend") ' Pitch Bend hat keine feste Controller-Nummer

                              Case MidiCommandCode.PatchChange
                                  Dim programChange As PatchChangeEvent = CType(e.MidiEvent, PatchChangeEvent)
                                  messageBuilder.Append($"Program Change - Kanal: {programChange.Channel}, Programm: {programChange.Patch}")
                                  LearnMidiAddress($"Program Change {programChange.Patch}", programChange.Patch, "ProgramChange")

                              Case MidiCommandCode.ChannelAfterTouch
                                  Dim channelAftertouch As ChannelAfterTouchEvent = CType(e.MidiEvent, ChannelAfterTouchEvent)
                                  messageBuilder.Append($"Channel Aftertouch - Kanal: {channelAftertouch.Channel}, Wert: {channelAftertouch.AfterTouchPressure}")
                                  LearnMidiAddress("Channel Aftertouch", -1, "ChannelAftertouch")

                              Case MidiCommandCode.KeyAfterTouch
                                  Dim keyAftertouch As NoteOnEvent = CType(e.MidiEvent, MidiEvent)
                                  messageBuilder.Append($"Key Aftertouch - Kanal: {keyAftertouch.Channel}, Note: {keyAftertouch.NoteNumber}, Wert: {keyAftertouch}")
                                  LearnMidiAddress($"Key Aftertouch {keyAftertouch.NoteNumber}", keyAftertouch.NoteNumber, "KeyAftertouch")

                              Case MidiCommandCode.TimingClock
                                  messageBuilder.Append("Timing Clock")
                              Case MidiCommandCode.StartSequence
                                  messageBuilder.Append("Start")
                              Case MidiCommandCode.StopSequence
                                  messageBuilder.Append("Stop")
                              Case MidiCommandCode.ContinueSequence
                                  messageBuilder.Append("Continue")
                              Case MidiCommandCode.AutoSensing
                                  ' Ignoriere Active Sensing, da es sehr häufig ist und das Log überfluten kann
                                  Return
                              Case MidiCommandCode.Eox
                                  messageBuilder.Append("Reset")
                              Case MidiCommandCode.Sysex
                                  Dim sysEx As SysexEvent = CType(e.MidiEvent, SysexEvent)
                                  messageBuilder.Append($"SysEx Nachricht - Länge: {sysEx.AbsoluteTime} Bytes")
                                  ' Hier können Sie die SysEx-Daten analysieren, um spezifische Controller-Informationen erhalten.
                                  ' Dies ist hochgradig gerätespezifisch und erfordert das Handbuch des Controllers.
                                  ' Example: SysEx message starting with F0 7E 7F 06 01 (Universal Device Inquiry)


                              Case Else
                                  messageBuilder.Append($"Unbekanntes MIDI Event: {e.MidiEvent.CommandCode}, Roh: 0x{rawMessage:X}")
                          End Select
                      Else
                          ' Wenn NAudio die Nachricht nicht parsen kann, zeige die Rohdaten an.
                          messageBuilder.Append($"Rohdaten empfangen: 0x{rawMessage:X}")
                      End If
                      LogMessage($"[{e.Timestamp}] {messageBuilder}{Environment.NewLine}")

                  End Sub)

        ' Wenn wir im Lernmodus sind, prüfen wir, ob die empfangene Nachricht dem erwarteten Typ entspricht 

        If IsLearning AndAlso ControlToLearn IsNot Nothing Then
            Dim learned As Boolean = False
            Dim midiNumber As Integer = -1
            Dim midiType As String = ""
            Dim midiEvent As MidiEvent = e.MidiEvent
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
                            LogMessage($"Gelernt: '{ControlToLearn.Name}' an MIDI CC {controlChange.Controller} ({controlChange.Controller}){Environment.NewLine}")
                        End If

                    Case MidiCommandCode.PitchWheelChange
                        Dim pitchWheel As PitchWheelChangeEvent = CType(e.MidiEvent, PitchWheelChangeEvent)
                        If ExpectedMidiMessageType = "PitchBend" OrElse ExpectedMidiMessageType = "" Then
                            ' Pitch Bend hat keine einzelne "Nummer", könnte einen Platzhalter verwenden oder spezielle Handhabung
                            midiNumber = -2 ' Platzhalter für Pitch Bend
                            midiType = "PitchBend"
                            learned = True
                            LogMessage($"Gelernt: '{ControlToLearn.Name}' an MIDI Pitch Bend{Environment.NewLine}")
                        End If

                        ' Fügen Sie hier weitere Typen hinzu, wenn Sie andere MIDI-Nachrichten lernen möchten
                End Select
            End If
        End If
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


End Class