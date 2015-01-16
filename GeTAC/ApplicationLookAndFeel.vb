Public Class ApplicationLookAndFeel

    Shared Sub ApplyTheme(ByVal C As TextBoxLabel)
        C.Font = New Font("Cambria", 9.0F, FontStyle.Bold)
        C.BackColor = SystemColors.ControlLight
    End Sub
    Shared Sub ApplyTheme(ByVal C As TextBox)
        C.Font = New Font("Cambria", 9.0F)
    End Sub

    Shared Sub ApplyTheme(ByVal C As Label)
        C.Font = New Font("Cambria", 9.0F)
    End Sub

    Shared Sub ApplyTheme(ByVal C As Form)
        C.Font = New Font("Cambria", 9.0F)
        C.BackColor = SystemColors.ControlLight
    End Sub

    Shared Sub ApplyTheme(ByVal C As Button)
        C.Font = New Font("Cambria", 9.0F)
    End Sub

    Public Shared Sub UseTheme(ByVal form As Form)
        ApplyTheme(form)

        For Each c In form.Controls
            Select Case c.GetType.ToString
                Case "System.Windows.Forms.GroupBox"
                    UseTheme(c)
                Case "System.Windows.Forms.TextBox"
                    ApplyTheme(c)
                Case "System.Windows.Forms.Label"
                    ApplyTheme(c)
                Case "GeTAC.TextBoxLabel"
                    ApplyTheme(c)
                Case "System.Windows.Forms.Button"
                    ApplyTheme(c)
            End Select

        Next
    End Sub

    Public Shared Sub UseTheme(ByRef grpBox As GroupBox)

        For Each c In grpBox.Controls
            Select Case c.GetType.ToString
                Case "System.Windows.Forms.GroupBox"
                    UseTheme(c)
                Case "System.Windows.Forms.TextBox"
                    ApplyTheme(c)
                Case "System.Windows.Forms.Label"
                    ApplyTheme(c)
                Case "GeTAC.TextBoxLabel"
                    ApplyTheme(c)
                Case "System.Windows.Forms.Button"
                    ApplyTheme(c)
            End Select
        Next
    End Sub
End Class
