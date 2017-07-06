Public Class frmAssistindo

    Private strAssist As String = My.Settings.now_playing

    '**************************************************************
    ' Arrastando form sem borda
    '**************************************************************
    Private WM_NCHITTEST As Integer = &H84
    Private HTCLIENT As Integer = &H1
    Private HTCAPTION As Integer = &H2
    Private HT_SYSCOMMAND As Integer = &H112

    Protected Overrides Sub WndProc(ByRef m As Message)
        MyBase.WndProc(m)

        Select Case m.Msg
            Case WM_NCHITTEST
                If m.Result = New IntPtr(HTCLIENT) Then
                    m.Result = New IntPtr(HTCAPTION)
                End If
        End Select

    End Sub

    '**************************************************************
    ' Fim da função de arrastar form sem borda
    '**************************************************************

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub

    Private Sub btnGravar_Click(sender As Object, e As EventArgs) Handles btnGravar.Click
        If Not frmPrincipal.verificaAdicionado(strAssist) Then
            If Not frmPrincipal.adicionaAnime(strAssist) Then
                Exit Sub
            End If
        End If

        If Not frmPrincipal.alteraWatching(strAssist, numEpisodio.Value) Then
            Exit Sub
        End If

        'If My.Settings.episodio_assistido Like ("*" & strAssist & "*") Then
        '    My.Settings.episodio_assistido = My.Settings.episodio_assistido.Replace(arrumaEpisodio(), strAssist & "=" & verificaZeros())
        'Else
        '    My.Settings.episodio_assistido &= strAssist & "=" & verificaZeros()
        'End If

        frmPrincipal.panPrincipal.Visible = False
        Me.Dispose()
    End Sub

    Private Sub frmAssistindo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNomeAnime.Text = My.Settings.nome_atual_assit
        numEpisodio.Value = frmPrincipal.verificaEpisodio()
    End Sub

    'Private Function verificaEpisodio() As Integer
    '    If My.Settings.episodio_assistido Like ("*" & strAssist & "*") Then
    '        Return My.Settings.episodio_assistido.Substring(My.Settings.episodio_assistido.IndexOf(strAssist & "=") + strAssist.Length + 1, 2)
    '    End If

    '    Return 0
    'End Function

    'Private Function arrumaEpisodio() As String
    '    Return My.Settings.episodio_assistido.Substring(My.Settings.episodio_assistido.IndexOf(strAssist), strAssist.Length + 3)
    'End Function

    'Private Function verificaZeros() As String
    '    If numEpisodio.Value < 10 Then
    '        Return "0" & numEpisodio.Value
    '    End If
    '    Return numEpisodio.Value.ToString
    'End Function

End Class