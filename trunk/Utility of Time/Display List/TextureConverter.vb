Public Class TextureUpscaler

    Shared SourceTexPos As Integer = 0
    Shared DestTexPos As Integer = 0

    Public Class RGBA
        Public Function RGBA16(ByVal Width As UInteger, ByVal Height As UInteger, ByVal LineSize As UInteger, _
                               ByVal SourceImg() As Byte, ByRef DestImg() As Byte)

            Dim RGBA5551 As UShort = 0
            ReDim DestImg(Width * Height * 8)

            For i As Integer = 0 To Height - 1
                For j As Integer = 0 To Width - 1
                    RGBA5551 = ReadInt16(SourceImg, SourceTexPos)

                    DestImg(DestTexPos) = (RGBA5551 And &HF800) >> 8
                    DestImg(DestTexPos + 1) = ((RGBA5551 And &H7C0) << 5) >> 8
                    DestImg(DestTexPos + 2) = ((RGBA5551 And &H3E) << 18) >> 16
                    If RGBA5551 And 1 Then DestImg(DestTexPos + 3) = 255 Else DestImg(DestTexPos + 3) = 0

                    SourceTexPos += 2
                    DestTexPos += 4
                Next
                SourceTexPos += (LineSize * 4) - Width
            Next

            SourceTexPos = 0
            DestTexPos = 0
        End Function
    End Class
    Public Class CI
        Dim PaletteIndex(1) As Byte

        Public Function CI4(ByVal Width As UInteger, ByVal Height As UInteger, ByVal LineSize As UInteger, _
                            ByVal SourceImg() As Byte, ByRef DestImg() As Byte, ByVal Palette() As Color4UByte)

            ReDim DestImg(Width * Height * 8)

            For i As Integer = 0 To Height - 1
                For j As Integer = 0 To Width - 1
                    PaletteIndex(0) = SourceImg(SourceTexPos)

                    DestImg(DestTexPos) = CByte(Palette(PaletteIndex(0)).r)
                    DestImg(DestTexPos + 1) = CByte(Palette(PaletteIndex(0)).g)
                    DestImg(DestTexPos + 2) = CByte(Palette(PaletteIndex(0)).b)
                    DestImg(DestTexPos + 3) = CByte(Palette(PaletteIndex(0)).a)

                    SourceTexPos += 1
                    DestTexPos += 4
                Next
                SourceTexPos += (LineSize * 8) - (Width)
            Next

            SourceTexPos = 0
            DestTexPos = 0
        End Function
        Public Function CI8(ByVal Width As UInteger, ByVal Height As UInteger, ByVal LineSize As UInteger, _
                            ByVal SourceImg() As Byte, ByRef DestImg() As Byte, ByVal Palette() As Color4UByte)

            ReDim DestImg(Width * Height * 8)

            For i As Integer = 0 To Height - 1
                For j As Integer = 0 To Width \ 2 - 1
                    PaletteIndex(0) = (SourceImg(SourceTexPos) And &HF0) >> 4
                    PaletteIndex(1) = (SourceImg(SourceTexPos) And &HF)

                    DestImg(DestTexPos) = CByte(Palette(PaletteIndex(0)).r)
                    DestImg(DestTexPos + 1) = CByte(Palette(PaletteIndex(0)).g)
                    DestImg(DestTexPos + 2) = CByte(Palette(PaletteIndex(0)).b)
                    DestImg(DestTexPos + 3) = CByte(Palette(PaletteIndex(0)).a)

                    DestImg(DestTexPos + 4) = CByte(Palette(PaletteIndex(1)).r)
                    DestImg(DestTexPos + 5) = CByte(Palette(PaletteIndex(1)).g)
                    DestImg(DestTexPos + 6) = CByte(Palette(PaletteIndex(1)).b)
                    DestImg(DestTexPos + 7) = CByte(Palette(PaletteIndex(1)).a)

                    SourceTexPos += 1
                    DestTexPos += 8
                Next
                SourceTexPos += (LineSize * 8) - (Width \ 2)
            Next

            SourceTexPos = 0
            DestTexPos = 0
        End Function
    End Class
    Public Class I
        Dim IIntensity As Byte = 0

        Public Function I4(ByVal Width As UInteger, ByVal Height As UInteger, ByVal LineSize As UInteger, _
                            ByVal SourceImg() As Byte, ByRef DestImg() As Byte)

            ReDim DestImg(Width * Height * 8)

            Dim IIntensity As Byte = 0
            For i As Integer = 0 To Height - 1
                For j As Integer = 0 To Width \ 2 - 1
                    IIntensity = SourceImg(SourceTexPos) >> 4
                    DestImg(DestTexPos) = IIntensity * 17
                    DestImg(DestTexPos + 1) = IIntensity * 17
                    DestImg(DestTexPos + 2) = IIntensity * 17
                    DestImg(DestTexPos + 3) = 255
                    IIntensity = SourceImg(SourceTexPos) << 4 >> 4
                    DestImg(DestTexPos + 4) = IIntensity * 17
                    DestImg(DestTexPos + 5) = IIntensity * 17
                    DestImg(DestTexPos + 6) = IIntensity * 17
                    DestImg(DestTexPos + 7) = 255
                    SourceTexPos += 1
                    DestTexPos += 8
                Next
                SourceTexPos += (LineSize * 8) - Width \ 2
            Next

            SourceTexPos = 0
            DestTexPos = 0
        End Function
        Public Function I8(ByVal Width As UInteger, ByVal Height As UInteger, ByVal LineSize As UInteger, _
                            ByVal SourceImg() As Byte, ByRef DestImg() As Byte)

            ReDim DestImg(Width * Height * 8)

            For i As Integer = 0 To Height - 1
                For j As Integer = 0 To Width - 1
                    IIntensity = SourceImg(SourceTexPos) \ 16
                    DestImg(DestTexPos) = IIntensity * 17
                    DestImg(DestTexPos + 1) = IIntensity * 17
                    DestImg(DestTexPos + 2) = IIntensity * 17
                    DestImg(DestTexPos + 3) = 255
                    SourceTexPos += 1
                    DestTexPos += 4
                Next
                SourceTexPos += (LineSize * 8) - Width
            Next

            SourceTexPos = 0
            DestTexPos = 0
        End Function
    End Class
    Public Class IA
        Dim IAIntensity As Byte = 0
        Dim IAAlpha As Byte = 0

        Public Function IA4(ByVal Width As UInteger, ByVal Height As UInteger, ByVal LineSize As UInteger, _
                            ByVal SourceImg() As Byte, ByRef DestImg() As Byte)

            ReDim DestImg(Width * Height * 8)

            For i As Integer = 0 To Height - 1
                For j As Integer = 0 To Width \ 2 - 1
                    IAIntensity = (SourceImg(SourceTexPos) And &HF0) >> 4
                    If IAIntensity And 1 Then IAAlpha = 255 Else IAAlpha = 0

                    DestImg(DestTexPos) = IAIntensity * 17
                    DestImg(DestTexPos + 1) = IAIntensity * 17
                    DestImg(DestTexPos + 2) = IAIntensity * 17
                    DestImg(DestTexPos + 3) = IAAlpha

                    IAIntensity = (SourceImg(SourceTexPos) And &HF)
                    If IAIntensity And 1 Then IAAlpha = 255 Else IAAlpha = 0

                    DestImg(DestTexPos + 4) = IAIntensity * 17
                    DestImg(DestTexPos + 5) = IAIntensity * 17
                    DestImg(DestTexPos + 6) = IAIntensity * 17
                    DestImg(DestTexPos + 7) = IAAlpha
                    SourceTexPos += 1
                    DestTexPos += 8
                Next
                SourceTexPos += (LineSize * 8) - Width \ 2
            Next

            SourceTexPos = 0
            DestTexPos = 0
        End Function
        Public Function IA8(ByVal Width As UInteger, ByVal Height As UInteger, ByVal LineSize As UInteger, _
                            ByVal SourceImg() As Byte, ByRef DestImg() As Byte)

            ReDim DestImg(Width * Height * 8)

            For i As Integer = 0 To Height - 1
                For j As Integer = 0 To Width - 1
                    IAIntensity = SourceImg(SourceTexPos) >> 4
                    IAAlpha = (SourceImg(SourceTexPos) << 4) >> 4
                    DestImg(DestTexPos) = IAIntensity * 17
                    DestImg(DestTexPos + 1) = IAIntensity * 17
                    DestImg(DestTexPos + 2) = IAIntensity * 17
                    DestImg(DestTexPos + 3) = IAAlpha * 17
                    SourceTexPos += 1
                    DestTexPos += 4
                Next
                SourceTexPos += (LineSize * 8) - (Width)
            Next

            SourceTexPos = 0
            DestTexPos = 0
        End Function
        Public Function IA16(ByVal Width As UInteger, ByVal Height As UInteger, ByVal LineSize As UInteger, _
                             ByVal SourceImg() As Byte, ByRef DestImg() As Byte)

            ReDim DestImg(Width * Height * 8)

            For i As Integer = 0 To Height - 1
                For j As Integer = 0 To Width - 1
                    IAIntensity = SourceImg(SourceTexPos)
                    IAAlpha = SourceImg(SourceTexPos + 1)
                    DestImg(DestTexPos) = IAIntensity
                    DestImg(DestTexPos + 1) = IAIntensity
                    DestImg(DestTexPos + 2) = IAIntensity
                    DestImg(DestTexPos + 3) = IAAlpha
                    SourceTexPos += 2
                    DestTexPos += 4
                Next
                SourceTexPos += (LineSize * 4) - Width
            Next

            SourceTexPos = 0
            DestTexPos = 0
        End Function
    End Class
End Class
