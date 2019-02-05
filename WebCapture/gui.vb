Module gui
#Region "DPI 계산 (고해상도 디스플레이용)"
    Public Function dpicalc(targetform As Form, size As Integer)
        Dim g As Graphics = targetform.CreateGraphics
        Dim dpi = g.DpiX.ToString()

        Dim current = dpi / 96
        Dim expand = current * size

        Return expand
    End Function
#End Region
End Module
