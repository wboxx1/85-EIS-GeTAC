Imports System
Imports System.Windows.Forms
Public Class TextBoxColor : Inherits TextBox

    Public Sub New()
        Me.SetStyle(ControlStyles.Selectable, False)
        Me.TabStop = False
        Me.Cursor = Cursors.Default

    End Sub

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = &H84 Then m.Result = IntPtr.Zero
        MyBase.WndProc(m)
    End Sub

    '    using System;
    'using System.Windows.Forms;

    'class TextBoxLabel : TextBox {
    '    public TextBoxLabel() {
    '        this.SetStyle(ControlStyles.Selectable, false);
    '        this.TabStop = false;
    '    }
    '    protected override void WndProc(ref Message m) {
    '        // Workaround required since TextBox calls Focus() on a mouse click
    '        // Intercept WM_NCHITTEST to make it transparent to mouse clicks
    '        if (m.Msg == 0x84) m.Result = IntPtr.Zero;
    '        else base.WndProc(ref m);
    '    }
    '}
End Class
