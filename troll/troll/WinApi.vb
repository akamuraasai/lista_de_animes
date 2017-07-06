Public Class WinApi
    Public Declare Function GetSystemMetrics Lib "user32.dll" Alias "GetSystemMetrics" (ByVal which As Integer) As Integer

    Public Declare Sub SetWindowPos Lib "user32.dll" (ByVal hwnd As IntPtr, ByVal hwndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal flags As UInteger)

    Private Const SM_CXSCREEN As Integer = 0

    Private Const SM_CYSCREEN As Integer = 1

    Private Shared HWND_TOP As IntPtr = IntPtr.Zero

    Private Const SWP_SHOWWINDOW As Integer = 64

    ' 0x0040
    Public Shared ReadOnly Property ScreenX As Integer
        Get
            Return GetSystemMetrics(SM_CXSCREEN)
        End Get
    End Property

    Public Shared ReadOnly Property ScreenY As Integer
        Get
            Return GetSystemMetrics(SM_CYSCREEN)
        End Get
    End Property

    Public Shared Sub SetWinFullScreen(ByVal hwnd As IntPtr)
        SetWindowPos(hwnd, HWND_TOP, 0, 0, ScreenX, ScreenY, SWP_SHOWWINDOW)
    End Sub
End Class
