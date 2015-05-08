<Serializable> Public Class FormValues
    Public StartPointLatDirection As LATDirection
    Public StartPointLonDirection As LONDirection
    Public ScanAreaLatDirection As LATDirection
    Public ScanAreaLonDirection As LONDirection
    Public StartPointLatDegree As Integer
    Public StartPointLonDegree As Integer
    Public ScanAreaLatDegree As Integer
    Public ScanAreaLonDegree As Integer
    Public StartPointLatMinute As Double
    Public StartPointLonMinute As Double
    Public ScanAreaLatMinute As Double
    Public ScanAreaLonMinute As Double
    Public ScanStep As Integer
    Public Range As Integer
    Public Dwell As Integer
    Public Heading As Integer
    Public Tilt As Integer
    Public AutoRange As Boolean
    Public OnTop As Boolean
    Public ScreenShot As Boolean
    Public GridOn As Boolean


    Enum LATDirection
        N
        S
    End Enum

    Enum LONDirection
        E
        W
    End Enum
End Class
