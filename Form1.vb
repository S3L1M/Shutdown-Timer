Public Class Form1
    Dim SC, SD As Integer

    Public Function GetTime(ByVal Time As Integer) As String
        Dim Hrs As Integer  'number of hours   '
        Dim Min As Integer  'number of Minutes '
        Dim Sec As Integer  'number of Sec     '
        'Seconds'
        Sec = Time Mod 60
        'Minutes'
        Min = ((Time - Sec) / 60) Mod 60
        'Hours'
        Hrs = ((Time - (Sec + (Min * 60))) / 3600) Mod 60
        Return Format(Hrs, "00") & ":" & Format(Min, "00") & ":" & Format(Sec, "00")
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        TLabel1.Text = "Time : " & TimeOfDay & " , Date : " & Today
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If NumericUpDown1.Value = 0 And NumericUpDown2.Value = 0 And NumericUpDown3.Value = 0 Then
            MsgBox("Please set the time first", MsgBoxStyle.Exclamation, "Set The Time")
        End If
        If ComboBox1.Text = "" Or ComboBox1.Text <> ComboBox1.SelectedItem Then
            MsgBox("Please choose from the chioces first", MsgBoxStyle.Exclamation, "Choose First")
        End If
        If NumericUpDown1.Value > 0 Or NumericUpDown2.Value > 0 Or NumericUpDown3.Value > 0 And ComboBox1.Text = ComboBox1.SelectedItem Then
            SC = NumericUpDown1.Value * 60 * 60 + NumericUpDown2.Value * 60 + NumericUpDown3.Value
            SD = SC
            Label1.Text = GetTime(SD)
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        SD = SD - 1
        If SD >= 0 Then
            Label1.Text = GetTime(SD)
            ProgressBar1.Maximum = SC
            ProgressBar1.Value = SC - SD
        Else
            Select Case ComboBox1.SelectedIndex
                Case 0
                    Process.Start("cmd", "/c shutdown -s -f -t 0")
                Case 1
                    Process.Start("cmd", "/c shutdown -r -f -t 0")
                Case 2
                    Process.Start("cmd", "/c shutdown -l -f")
            End Select
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If NumericUpDown1.Value = 0 And NumericUpDown2.Value = 0 And NumericUpDown3.Value = 0 Then
            MsgBox("Please set the time first", MsgBoxStyle.Exclamation, "Set The Time")
        End If
        If ComboBox1.Text = "" Or ComboBox1.Text <> ComboBox1.SelectedItem Then
            MsgBox("Please choose from the chioces first", MsgBoxStyle.Exclamation, "Choose First")
        End If
        If Timer2.Enabled = True Then
            MsgBox("It's already running", MsgBoxStyle.Exclamation, "Shutdown Timer")
        ElseIf NumericUpDown1.Value > 0 Or NumericUpDown2.Value > 0 Or NumericUpDown3.Value > 0 And ComboBox1.Text = ComboBox1.SelectedItem Then
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox2.Click
        If Timer2.Enabled = False Then
            MsgBox("It's already pausing", MsgBoxStyle.Exclamation, "Shutdown Timer")
        Else
            Timer2.Enabled = False
            Timer2.Enabled = False
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        PictureBox1.BorderStyle = BorderStyle.None
    End Sub

    Private Sub PictureBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
    End Sub

    Private Sub PictureBox2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        PictureBox2.BorderStyle = BorderStyle.None
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        MsgBox("Shutdown Timer v2.0", MsgBoxStyle.Information, "About")
    End Sub

    Private Sub CreditsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreditsToolStripMenuItem.Click
        MsgBox("All right © are resered to Mohamed Selim", MsgBoxStyle.Information, "Credits")
    End Sub

    Private Sub MenuColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then MenuStrip1.BackColor = ColorDialog1.Color
    End Sub

    Private Sub FormColorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormColorToolStripMenuItem.Click
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then Me.BackColor = ColorDialog1.Color
    End Sub

    Private Sub ResetColorsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetColorsToolStripMenuItem.Click
        MenuStrip1.BackColor = Color.WhiteSmoke
        Me.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub StartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartToolStripMenuItem.Click
        If NumericUpDown1.Value = 0 And NumericUpDown2.Value = 0 And NumericUpDown3.Value = 0 Then
            MsgBox("Please set the time first", MsgBoxStyle.Exclamation, "Set The Time")
        End If
        If ComboBox1.Text = "" Or ComboBox1.Text <> ComboBox1.SelectedItem Then
            MsgBox("Please choose from the chioces first", MsgBoxStyle.Exclamation, "Choose First")
        End If
        If Timer2.Enabled = True Then
            MsgBox("It's already running", MsgBoxStyle.Exclamation, "Shutdown Timer")
        ElseIf NumericUpDown1.Value > 0 Or NumericUpDown2.Value > 0 Or NumericUpDown3.Value > 0 And ComboBox1.Text = ComboBox1.SelectedItem Then
            Timer2.Enabled = True
        End If
    End Sub

    Private Sub PauseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PauseToolStripMenuItem.Click
        If Timer2.Enabled = False Then
            MsgBox("It's already pausing", MsgBoxStyle.Exclamation, "Shutdown Timer")
        Else
            Timer2.Enabled = False
            Timer2.Enabled = False
            Timer2.Enabled = False
            Timer2.Enabled = False
            Timer2.Enabled = False
        End If
    End Sub

    Private Sub ResetToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResetToolStripMenuItem1.Click
        Timer2.Enabled = False
        Label1.Text = "00:00:00"
        ProgressBar1.Value = 0
        NumericUpDown1.Value = 0
        NumericUpDown2.Value = 0
        NumericUpDown3.Value = 0
        ComboBox1.Text = ""
        PictureBox1.BorderStyle = BorderStyle.None
        PictureBox2.BorderStyle = BorderStyle.None
        SC = 0
        SD = 0
        Refresh()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class