Imports System.Windows.Forms

Public Class CombinerEditor
    Private CombinerColors As UnpackedCombiner
    Private CombinerColorsCopy As UnpackedCombiner
    Private CompiledCmb As New DLCommand
    Private Sub Decode(ByVal MUXS0 As UInteger, ByVal MUXS1 As UInteger)
        DLParser.UnpackMUX(MUXS0, MUXS1, CombinerColors)
        With CombinerColors
            cA0.SelectedIndex = .cA(0)
            cA1.SelectedIndex = .cA(1)

            cB0.SelectedIndex = .cB(0)
            cB1.SelectedIndex = .cB(1)

            cC0.SelectedIndex = .cC(0)
            cC1.SelectedIndex = .cC(1)

            cD0.SelectedIndex = .cD(0)
            cD1.SelectedIndex = .cD(1)

            aA0.SelectedIndex = .aA(0)
            aA1.SelectedIndex = .aA(1)

            aB0.SelectedIndex = .aB(0)
            aB1.SelectedIndex = .aB(1)

            aC0.SelectedIndex = .aC(0)
            aC1.SelectedIndex = .aC(1)

            aD0.SelectedIndex = .aD(0)
            aD1.SelectedIndex = .aD(1)
        End With
    End Sub


    Private Sub UpdateEnvColor(ByVal Cmd As DLCommand)
        If Cmd.CMDHigh > 0 Then
            Dim tempEnv As New Color4UByte
            tempEnv.r = Cmd.CMDParams(4)
            tempEnv.g = Cmd.CMDParams(5)
            tempEnv.b = Cmd.CMDParams(6)
            tempEnv.a = &HFF
            EnvR.BackColor = RGBA8ColorToColorObject(tempEnv)
            tempEnv.r = &HFF
            tempEnv.g = &HFF
            tempEnv.b = &HFF
            tempEnv.a = Cmd.CMDParams(7)
            EnvA.BackColor = RGBA8ColorToColorObject(tempEnv)
            EnvR.Enabled = True
            EnvA.Enabled = True
        Else
            EnvR.Enabled = False
            EnvA.Enabled = False
        End If
    End Sub
    Private Sub UpdatePrimColor(ByVal Cmd As DLCommand)
        If Cmd.CMDHigh > 0 Then
            Dim tempPrim As New Color4UByte
            tempPrim.r = Cmd.CMDParams(4)
            tempPrim.g = Cmd.CMDParams(5)
            tempPrim.b = Cmd.CMDParams(6)

            tempPrim.a = &HFF
            PrimR.BackColor = RGBA8ColorToColorObject(tempPrim)

            tempPrim.r = &HFF
            tempPrim.g = &HFF
            tempPrim.b = &HFF
            tempPrim.a = Cmd.CMDParams(7)
            PrimA.BackColor = RGBA8ColorToColorObject(tempPrim)

            PrimA.Enabled = True
            PrimR.Enabled = True

        Else
            PrimA.Enabled = False
            PrimR.Enabled = False
        End If
    End Sub
    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For i As Integer = 0 To ColorAStr.Length - 1
            cA0.Items.Add(ColorAStr(i))
            cA1.Items.Add(ColorAStr(i))
        Next
        For i As Integer = 0 To ColorBStr.Length - 1
            cB0.Items.Add(ColorBStr(i))
            cB1.Items.Add(ColorBStr(i))
        Next
        For i As Integer = 0 To ColorCStr.Length - 1
            cC0.Items.Add(ColorCStr(i))
            cC1.Items.Add(ColorCStr(i))
        Next
        For i As Integer = 0 To ColorDStr.Length - 1
            cD0.Items.Add(ColorDStr(i))
            cD1.Items.Add(ColorDStr(i))
        Next

        For i As Integer = 0 To AlphaAStr.Length - 1
            aA0.Items.Add(AlphaAStr(i))
            aA1.Items.Add(AlphaAStr(i))
        Next
        For i As Integer = 0 To AlphaBStr.Length - 1
            aB0.Items.Add(AlphaBStr(i))
            aB1.Items.Add(AlphaBStr(i))
        Next
        For i As Integer = 0 To AlphaCStr.Length - 1
            aC0.Items.Add(AlphaCStr(i))
            aC1.Items.Add(AlphaCStr(i))
        Next
        For i As Integer = 0 To AlphaDStr.Length - 1
            aD0.Items.Add(AlphaDStr(i))
            aD1.Items.Add(AlphaDStr(i))
        Next

        UpdateEnvColor(LinkedCommands.EnvColor)

        UpdatePrimColor(LinkedCommands.PrimColor)

        Decode(Convert.ToUInt32(MainWin.LowordText.Text, 16), Convert.ToUInt32(MainWin.HiwordText.Text, 16))
    End Sub
    Private Sub Compile()
        CompiledCmb = CompileDL.Compile(UCodes.RDP, RDP.G_SETCOMBINE, CombinerColors)
        CompiledCmbCmd.Text = CompiledCmb.CMDParams(0).ToString("X2") & CompiledCmb.CMDLow.ToString("X6") & CompiledCmb.CMDHigh.ToString("X8")
    End Sub
    Private Sub cA0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cA0.SelectedIndexChanged
        CombinerColors.cA(0) = cA0.SelectedIndex
        Compile()
    End Sub

    Private Sub cB0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cB0.SelectedIndexChanged
        CombinerColors.cB(0) = cB0.SelectedIndex
        Compile()
    End Sub

    Private Sub cC0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cC0.SelectedIndexChanged
        CombinerColors.cC(0) = cC0.SelectedIndex
        Compile()
    End Sub

    Private Sub cD0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cD0.SelectedIndexChanged
        CombinerColors.cD(0) = cD0.SelectedIndex
        Compile()
    End Sub
    Private Sub cA1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cA1.SelectedIndexChanged
        CombinerColors.cA(1) = cA1.SelectedIndex
        Compile()
    End Sub

    Private Sub cB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cB1.SelectedIndexChanged
        CombinerColors.cB(1) = cB1.SelectedIndex
        Compile()
    End Sub

    Private Sub cC1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cC1.SelectedIndexChanged
        CombinerColors.cC(1) = cC1.SelectedIndex
        Compile()
    End Sub

    Private Sub cD1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cD1.SelectedIndexChanged
        CombinerColors.cD(1) = cD1.SelectedIndex
        Compile()
    End Sub

    Private Sub aA0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aA0.SelectedIndexChanged
        CombinerColors.aA(0) = aA0.SelectedIndex
        Compile()
    End Sub

    Private Sub aB0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aB0.SelectedIndexChanged
        CombinerColors.aB(0) = aB0.SelectedIndex
        Compile()
    End Sub

    Private Sub aC0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aC0.SelectedIndexChanged
        CombinerColors.aC(0) = aC0.SelectedIndex
        Compile()
    End Sub

    Private Sub aD0_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aD0.SelectedIndexChanged
        CombinerColors.aD(0) = aD0.SelectedIndex
        Compile()
    End Sub

    Private Sub aA1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aA1.SelectedIndexChanged
        CombinerColors.aA(1) = aA1.SelectedIndex
        Compile()
    End Sub

    Private Sub aB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aB1.SelectedIndexChanged
        CombinerColors.aB(1) = aB1.SelectedIndex
        Compile()
    End Sub

    Private Sub aC1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aC1.SelectedIndexChanged
        CombinerColors.aC(1) = aC1.SelectedIndex
        Compile()
    End Sub

    Private Sub aD1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aD1.SelectedIndexChanged
        CombinerColors.aD(1) = aD1.SelectedIndex
        Compile()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Compile()
    End Sub

    Private Sub CompiledCmbCmd_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompiledCmbCmd.TextChanged
        MainWin.LowordText.Text = CompiledCmb.CMDLow.ToString("X6")
        MainWin.HiwordText.Text = CompiledCmb.CMDHigh.ToString("X8")
        UpdateCommand(N64DList(MainWin.DListSelection.SelectedIndex - 1), MainWin.CommandsListbox.SelectedIndex, Convert.ToByte(MainWin.CommandCodeText.Text, 16), Convert.ToUInt32(MainWin.HiwordText.Text, 16), Convert.ToUInt32(MainWin.LowordText.Text, 16))
    End Sub

    Private Sub PrimR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrimR.Click
        If ColorSelector.ShowDialog() = Windows.Forms.DialogResult.OK Then
            LinkedCommands.PrimColor = CompileDL.Compile(UCodes.RDP, RDP.G_SETPRIMCOLOR, ColorSelector.Color)
            UpdateCommand(N64DList(LinkedCommands.PrimColor.DLPos), LinkedCommands.PrimColor.DLPos, LinkedCommands.PrimColor.CMDParams(0), LinkedCommands.PrimColor.CMDHigh, LinkedCommands.PrimColor.CMDLow)
            UpdatePrimColor(LinkedCommands.PrimColor)
        End If
    End Sub
End Class
