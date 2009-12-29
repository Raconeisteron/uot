Module RDP_Defs
    Public Enum RDP
        'GENERAL
        G_SETCIMG = &HFF
        G_SETZIMG = &HFE
        G_SETTIMG = &HFD
        G_SETCOMBINE = &HFC
        G_SETENVCOLOR = &HFB
        G_SETBLENDCOLOR = &HF9
        G_SETFOGCOLOR = &HF8
        G_SETPRIMCOLOR = &HFA
        G_SETFILLCOLOR = &HF7
        G_FILLRECT = &HF6
        G_SETTILE = &HF5
        G_LOADTILE = &HF4
        G_LOADBLOCK = &HF3
        G_SETTILESIZE = &HF2
        G_LOADTLUT = &HF0
        G_RDPSETOTHERMODE = &HEF
        G_SETPRIMDEPTH = &HEE
        G_SETSCISSOR = &HED
        G_SETCONVERT = &HEC
        G_SETKEYR = &HEB
        G_SETKEYGB = &HEA
        G_RDPFULLSYNC = &HE9
        G_RDPTILESYNC = &HE8
        G_RDPPIPESYNC = &HE7
        G_RDPLOADSYNC = &HE6
        G_TEXRECTFLIP = &HE5
        G_TEXRECT = &HE4

        'TEXTURE PARAMS
        G_TX_WRAP = 0
        G_TX_MIRROR = 1
        G_TX_CLAMP = 2

        'GEOMETRY MODE
        G_ZBUFFER = &H1
        G_SHADE = &H4
        G_CULL_FRONT = &H200
        G_CULL_BACK = &H400
        G_CULL_BOTH = &H600
        G_FOG = &H10000
        G_LIGHTING = &H20000
        G_TEXTURE_GEN = &H40000
        G_TEXTURE_GEN_LINEAR = &H80000
        G_LOD = &H100000
        G_SHADING_SMOOTH = &H200000
        G_CLIPPING = &H800000

        'SETOTHERMODE_H
        G_MDSFT_BLENDMASK = 0
        G_MDSFT_ALPHADITHER = 4
        G_MDSFT_RGBDITHER = 6
        G_MDSFT_COMBKEY = 8
        G_MDSFT_TEXTCONV = 9
        G_MDSFT_TEXTFILT = 12
        G_MDSFT_TEXTLUT = 14
        G_MDSFT_TEXTLOD = 16
        G_MDSFT_TEXTDETAIL = 17
        G_MDSFT_TEXTPERSP = 19
        G_MDSFT_CYCLETYPE = 20
        G_MDSFT_COLORDITHER = 22
        G_MDSFT_PIPELINE = 23

        'COLOR COMBINER
        G_CCMUX_COMBINED = 0
        G_CCMUX_TEXEL0 = 1
        G_CCMUX_TEXEL1 = 2
        G_CCMUX_PRIMITIVE = 3
        G_CCMUX_SHADE = 4
        G_CCMUX_ENVIRONMENT = 5
        G_CCMUX_CENTER = 6
        G_CCMUX_SCALE = 6
        G_CCMUX_COMBINED_ALPHA = 7
        G_CCMUX_TEXEL0_ALPHA = 8
        G_CCMUX_TEXEL1_ALPHA = 9
        G_CCMUX_PRIMITIVE_ALPHA = 10
        G_CCMUX_SHADE_ALPHA = 11
        G_CCMUX_ENV_ALPHA = 12
        G_CCMUX_LOD_FRACTION = 13
        G_CCMUX_PRIM_LOD_FRAC = 14
        G_CCMUX_NOISE = 7
        G_CCMUX_K4 = 7
        G_CCMUX_K5 = 15
        G_CCMUX_1 = 6
        G_CCMUX_0 = 31

        'ALPHA COMBINER
        G_ACMUX_COMBINED = 0
        G_ACMUX_TEXEL0 = 1
        G_ACMUX_TEXEL1 = 2
        G_ACMUX_PRIMITIVE = 3
        G_ACMUX_SHADE = 4
        G_ACMUX_ENVIRONMENT = 5
        G_ACMUX_LOD_FRACTION = 0
        G_ACMUX_PRIM_LOD_FRAC = 6
        G_ACMUX_1 = 6
        G_ACMUX_0 = 7
    End Enum

    Public FIXED2FLOATRECIP() As Double = {0.5F, 0.25F, 0.125F, 0.0625F, 0.03125F, 0.015625F, 0.0078125F, 0.00390625F, _
                                       0.001953125F, 0.0009765625F, 0.00048828125F, 0.000244140625F, 0.000122070313F, _
                                       0.0000610351563F, 0.0000305175781F, 0.0000152587891F}

    Public ColorAStr() As String = {"cCOMBINED", "cTEXEL0", "cTEXEL1", "cPRIM", "cSHADE", "cENV", "1.0", "cNOISE", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0"}
    Public ColorBStr() As String = {"cCOMBINED", "cTEXEL0", "cTEXEL1", "cPRIM", "cSHADE", "cENV", "cKEYCENTER", "CONVK4", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0"}
    Public ColorCStr() As String = {"cCOMBINED", "cTEXEL0", "cTEXEL1", "cPRIM", "cSHADE", "cENV", "cKEYSCALE", "aCOMBINED", "aTEXEL0", "aTEXEL1", "aPRIM", "aSHADE", "aENV", "LODFRAC", "PRIMLODFRAC", "CONVK5", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0", "0.0"}
    Public ColorDStr() As String = {"cCOMBINED", "cTEXEL0", "cTEXEL1", "cPRIM", "cSHADE", "cENV", "1.0", "0.0"}
    Public AlphaAStr() As String = {"aCOMBINED", "aTEXEL0", "aTEXEL1", "aPRIM", "aSHADE", "aENV", "1.0", "0.0"}
    Public AlphaBStr() As String = {"aCOMBINED", "aTEXEL0", "aTEXEL1", "aPRIM", "aSHADE", "aENV", "1.0", "0.0"}
    Public AlphaCStr() As String = {"LODFRAC", "aTEXEL0", "aTEXEL1", "aPRIM", "aSHADE", "aENV", "PRIMLODFRAC", "0.0"}
    Public AlphaDStr() As String = {"aCOMBINED", "aTEXEL0", "aTEXEL1", "aPRIM", "aSHADE", "aENV", "1.0", "0.0"}


    Public G_COMBINERMUX0() As UInteger = {&H11FFFF, &H127E03, &H127E03, &H127E03, _
    &H121603, &H267E04, &H41FFFF, &H127E0C, &H267E04, &H262A04, &H121803, &H121803, _
    &H41FFFF, &H11FFFF, &H41C7FF, &H41FFFF, &H127E60, &H272C04, &H20AC04, &H26A004, _
    &H277E04, &H20FE04, &H272E04, &H272C04, &H20A203, &H11FE04, &H20AC03, &H272C03, _
    &H271204, &H11FE04, &H272C80, &H11FE04, &H119C04, &H119604, &H262A04, &H262A04, _
    &H262A04, &H127E03, &H267E04, &H11FE04, &H119C04, &H271204, &H272C80, &H127E03, _
    &H267E03}

    Public G_COMBINERMUX1() As UInteger = {&HFFFFFC38, &HFFFFFDF8, &HFFFFF3F8, _
                                           &HFFFFF7F8, &HFF5BFFF8, &H1F0CFDFF, _
                                            &HFFFFFC38, &HFFFFFDF8, &H1FFCFDF8, _
                                            &H1F0C93FF, &HFF5BFFF8, &HFF0FFFFF, _
                                            &HFFFFF638, &HFFFFF238, &HFFFFFE38, _
                                            &HFFFFF838, &HFFFFF3F8, &H1F0C93FF, _
                                            &HFF0F93FF, &H1FFC93F8, &H1F0CF7FF, _
                                            &HFF0FF7FF, &H1F0C93FF, &H1F1093FF, _
                                            &HFF13FFFF, &HFFFFF7F8, &HFF0F93FF, _
                                            &H1F0C93FF, &HFF0FF3FF, &HFFFFFFF8, _
                                            &H1F0CFFFF, &HFFFFF3F8, &H350CF37F, _
                                            &HFF5BFFF8, &H1F5893F8, &H1F1093FF, _
                                            &HFFFFF9F8, &HFFFFF9F8, &H1F10FDFF, _
                                            &HFF0FF3FF, &HFFFFFFF8, &H1F0CFFFF, _
                                            &H350CF37F, &HFFFFF9F8, &H1FFCFDF8}

    Public Function FindLinkedCommand(ByVal DL As N64DisplayList, ByVal Command As Byte, ByVal StartIndex As Integer) As DLCommand
        For i As Integer = StartIndex To DL.Commands.Length - 1
            If DL.Commands(i).CMDParams(0) = Command Then
                Return DL.Commands(i)
                Exit Function
            ElseIf i > StartIndex And DL.Commands(i).CMDParams(0) = DL.Commands(StartIndex).CMDParams(0) Then
                Return Nothing
                Exit Function
            End If
        Next
    End Function
End Module
