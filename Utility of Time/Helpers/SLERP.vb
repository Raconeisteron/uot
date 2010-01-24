Public Class SLERP
    Public startTick As Long
    Public startValue As Double
    Public endTick As Long
    Public endValue As Double
    Public Function getValue(ByVal longTick As Long) As Double

        getValue = (longTick - startTick) / (endTick - startTick)
        getValue = startValue + ((endValue - startValue) * getValue)

        Return getValue
    End Function
End Class
