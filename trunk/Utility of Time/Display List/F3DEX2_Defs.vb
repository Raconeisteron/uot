Module F3DEX2_Defs

    'ALL UCODES - BASIC
  
    'F3DZEX (F3DEX v2.0)
    Public Enum F3DZEX
        'GEOMETRY DRAWING
        VTX = 1
        MODIFYVTX = 2
        CULLDL = 3
        BRANCH_Z = 4
        TRI1 = 5
        TRI2 = 6
        QUAD = 7

        'MATRIX MANIPULATION
        MTX_MODELVIEW = 0
        MTX_PROJECTION = 4
        MTX_MUL = 3
        MTX_LOAD = 2
        MTX_NOPUSH = 0
        MTX_PUSH = 1

        'GENERAL
        RDPHALF_2 = &HF1
        SETOTHERMODE_H = &HE3
        SETOTHERMODE_L = &HE2
        RDPHALF_1 = &HE1
        SPNOOP = &HE0
        ENDDL = &HDF
        DL = &HDE
        LOAD_UCODE = &HDD
        MOVEMEM = &HDC
        MOVEWORD = &HDB
        MTX = &HDA
        GEOMETRYMODE = &HD9
        POPMTX = &HD8
        TEXTURE = &HD7
        DMA_IO = &HD6
        SPECIAL_1 = &HD5
        SPECIAL_2 = &HD4
        SPECIAL_3 = &HD3
    End Enum



End Module
