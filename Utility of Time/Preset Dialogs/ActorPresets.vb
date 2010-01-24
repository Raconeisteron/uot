Imports System.Windows.Forms

Public Class ActorPresets
    Private ind As Integer = 0
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If SelectedRoomActors.Count > 0 Or SelectedSceneActors.Count > 0 Then
            If AvailableActors.SelectedIndex > -1 Then
                MainWin.ActorNumberText.Text = actornp(AvailableActors.SelectedIndex)
                MainWin.ActorVarText.Text = actorvp(AvailableActors.SelectedIndex)
                MainWin.UpdateActors()
            ElseIf UnavailableActors.SelectedIndex > -1 Then
                MainWin.ActorNumberText.Text = actornpu(UnavailableActors.SelectedIndex)
                MainWin.ActorVarText.Text = actorvpu(UnavailableActors.SelectedIndex)
                MainWin.UpdateActors()
            End If
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AvailableActors.SelectedIndexChanged
        UnavailableActors.SelectedIndex = -1
    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UnavailableActors.SelectedIndexChanged
        AvailableActors.SelectedIndex = -1
        If UnavailableActors.SelectedIndex > -1 Then
            Label2.Text = "Missing group (0x" & actorgpu(UnavailableActors.SelectedIndex) & ")"
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        MainWin.DelimitActors()
    End Sub

    Private Sub ActorPresets_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MainWin.DelimitActors()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Not SearchListbox(AvailableActors, TextBox1, AvailableActors.SelectedIndex, True) Then NotFoundLabel.Show() Else NotFoundLabel.Hide()
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If Not SearchListbox(UnavailableActors, TextBox2, UnavailableActors.SelectedIndex, True) Then NotFoundLabel.Show() Else NotFoundLabel.Hide()
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        If Not SearchListbox(AvailableActors, TextBox1, 0, False) Then NotFoundLabel.Show() Else NotFoundLabel.Hide()
    End Sub
    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged
        If Not SearchListbox(UnavailableActors, TextBox2, 0, False) Then NotFoundLabel.Show() Else NotFoundLabel.Hide()
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not SearchListbox(AvailableActors, TextBox1, AvailableActors.SelectedIndex, True) Then NotFoundLabel.Show() Else NotFoundLabel.Hide()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not SearchListbox(UnavailableActors, TextBox2, UnavailableActors.SelectedIndex, True) Then NotFoundLabel.Show() Else NotFoundLabel.Hide()
        End If
    End Sub
End Class
