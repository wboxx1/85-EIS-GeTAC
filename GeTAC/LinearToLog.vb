Public Class LinearToLog
    Public Shared Function ConvertLinearToLog(ByVal int As Integer) As Integer
        Dim converter As LinearToLog = New LinearToLog
        Return converter.log(int)
    End Function

    Private log As Integer() = {100, 200, 300, 400, 500, 600, 700, 800, _
                                900, 1000, 2000, 3000, 4000, 5000, 6000, _
                                7000, 8000, 9000, 10000, 20000, 30000, 40000, _
                                50000, 60000, 70000, 80000, 90000, 100000, _
                                200000, 300000, 400000, 500000, 600000, 700000, _
                                800000, 900000, 1000000, 2000000, 3000000, 4000000, _
                                5000000, 6000000}
End Class
