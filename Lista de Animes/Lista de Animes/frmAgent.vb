Public Class frmAgent

    '**************************************************************
    ' Arrastando form sem borda pelo PictureBox
    '**************************************************************
    Private Const WM_NCLBUTTONDOWN = &HA1
    Private Const HTCAPTION = 2

    Private Declare Function SendMessage Lib "user32" Alias "SendMessageA" _
                 (ByVal hwnd As Integer, ByVal wMsg As Integer, _
                  ByVal wParam As Integer, ByVal lParam As String) As Integer
    Private Declare Sub ReleaseCapture Lib "user32" ()

    'Deslocamento da forma 
    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Dim lHwnd As Int32
        lHwnd = Me.Handle
        If lHwnd = 0 Then Exit Sub
        ReleaseCapture()
        SendMessage(lHwnd, WM_NCLBUTTONDOWN, HTCAPTION, 0&)
    End Sub

    '**************************************************************
    ' Fim da função de arrastar form sem borda
    '**************************************************************



    Private movAtual As Integer

    Private Sub tmeMovimentos_Tick(sender As Object, e As EventArgs) Handles tmeMovimentos.Tick
        Call movimenta()
    End Sub

    Private Sub frmAgent_Load(sender As Object, e As EventArgs) Handles Me.Load
        tmeMovimentos.Start()
    End Sub

    Private Sub movimenta()
        Select Case movAtual

            Case 0
                Me.BackgroundImage = My.Resources.shime2
                Me.Left -= 6
                movAtual = 1

            Case 1
                Me.BackgroundImage = My.Resources.shime1
                Me.Left -= 6
                movAtual = 2

            Case 2
                Me.BackgroundImage = My.Resources.shime3
                Me.Left -= 6
                movAtual = 3

            Case 3
                Me.BackgroundImage = My.Resources.shime1
                Me.Left -= 6
                movAtual = 0

        End Select
    End Sub
End Class