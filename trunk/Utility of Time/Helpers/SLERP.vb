Public Class SLERP
    Public startTick As Long
    Public startValue As Double
    Public endTick As Long
    Public endValue As Double
    Public Function getValue(ByVal longTick As Long) As Double
        If longTick > endTick Then
            getValue = endValue
        ElseIf longTick < startTick Then
            getValue = startValue
        Else
            getValue = (longTick - startTick) / (endTick - startTick)
            getValue = startValue + ((endValue - startValue) * getValue)
        End If
        Return getValue
    End Function
End Class
