Module MatrixManipulation
    Public Function MultMatrix(ByVal res(,) As Double, ByVal mf(,) As Double, ByVal nf(,) As Double) As Double(,)
        Dim i, j, k As Integer
        Dim tmp(3, 3) As Double
        For i = 0 To 3
            For j = 0 To 3
                tmp(i, j) = 0.0F
                For k = 0 To 3
                    tmp(i, j) = mf(i, k) * nf(k, j)
                Next
            Next
        Next
        Return tmp
    End Function
    Public Function CopyMatrix(ByVal src(,) As Double, ByVal dst(,) As Double)
        For i As Integer = 0 To 3
            For j As Integer = 0 To 3
                dst(i, j) = src(i, j)
            Next
        Next
    End Function
End Module
