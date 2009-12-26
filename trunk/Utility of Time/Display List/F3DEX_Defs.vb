Module F3DEX_Defs
    Public Enum F3DEX
        MTX_STACKSIZE = 18

        MTX_MODELVIEW = &H0
        MTX_PROJECTION = &H1
        MTX_MUL = &H0
        MTX_LOAD = &H2
        MTX_NOPUSH = &H0
        MTX_PUSH = &H4

        TEXTURE_ENABLE = &H2
        SHADING_SMOOTH = &H200
        CULL_FRONT = &H1000
        CULL_BACK = &H2000
        CULL_BOTH = &H3000
        CLIPPING = &H800000

        MV_VIEWPORT = &H80

        MWO_aLIGHT_1 = &H0
        MWO_bLIGHT_1 = &H4
        MWO_aLIGHT_2 = &H20
        MWO_bLIGHT_2 = &H24
        MWO_aLIGHT_3 = &H40
        MWO_bLIGHT_3 = &H44
        MWO_aLIGHT_4 = &H60
        MWO_bLIGHT_4 = &H64
        MWO_aLIGHT_5 = &H80
        MWO_bLIGHT_5 = &H84
        MWO_aLIGHT_6 = &HA0
        MWO_bLIGHT_6 = &HA4
        MWO_aLIGHT_7 = &HC0
        MWO_bLIGHT_7 = &HC4
        MWO_aLIGHT_8 = &HE0
        MWO_bLIGHT_8 = &HE4

        MODIFYVTX = &HB2
        TRI1 = &HBF
        TRI2 = &HB1
        BRANCH_Z = &HB0
        LOAD_UCODE = &HAF
    End Enum
End Module
