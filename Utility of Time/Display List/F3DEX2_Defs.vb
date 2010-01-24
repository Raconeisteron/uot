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


    Public Function ReadInDL(ByVal Data() As Byte, ByRef DisplayList() As N64DisplayList, ByVal Offset As Integer, ByVal Index As Integer) As Integer
        Try
            If Offset < Data.Length Then
                If Data(Offset) = &HDE Then
                    Do Until Data(Offset) <> &HDE
                        Offset = ReadUInt24(Data, Offset + 5)
                    Loop
                End If

                ReDim Preserve DisplayList(Index)
                DisplayList(Index) = New N64DisplayList

                Dim EPLoc As Integer = Offset

                MainWin.DListSelection.Items.Add((Index + 1).ToString & ". " & Hex(Offset))

                With DisplayList(Index)
                    .StartPos = New ZSegment
                    .StartPos.Offset = Offset
                    .StartPos.Bank = CurrentBank
                    .Skip = False
                    .PickCol = New Color3UByte
                    .PickCol.r = Rand.Next(0, 255)
                    .PickCol.g = Rand.Next(0, 255)
                    .PickCol.b = Rand.Next(0, 255)
                    Do
                        ReDim Preserve .Commands(.CommandCount)
                        ReDim Preserve .CommandsCopy(.CommandCount)
                        ReDim .Commands(.CommandCount).CMDParams(7)

                        .Commands(.CommandCount).Name = DLParser.IdentifyCommand(Data(EPLoc))

                        For i As Integer = 0 To 7
                            .Commands(.CommandCount).CMDParams(i) = Data(EPLoc + i)
                        Next

                        .Commands(.CommandCount).CMDLow = ReadUInt24(Data, EPLoc + 1)

                        .Commands(.CommandCount).CMDHigh = ReadUInt32(Data, EPLoc + 4)

                        .Commands(.CommandCount).DLPos = .CommandCount

                        If Data(EPLoc) = F3DZEX.ENDDL Or EPLoc >= Data.Length Then
                            EPLoc += 8
                            Exit Do
                        End If

                        EPLoc += 8
                        .CommandCount += 1
                    Loop
                    .CommandsCopy = .Commands
                End With

                Return EPLoc
            End If
        Catch ex As Exception
            MsgBox("Error reading in display list: " & ex.Message, MsgBoxStyle.Critical, "Exception")
            Exit Function
        End Try
    End Function
End Module
