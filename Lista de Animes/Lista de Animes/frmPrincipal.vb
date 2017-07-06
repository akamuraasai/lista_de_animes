Imports System.IO
Imports System.Net
Imports System.Management
Imports VB = Microsoft.VisualBasic

Public Class frmPrincipal

    Private animes() As String
    Private infos() As String
    Private animeInfos As New Hashtable
    Private cript As New Cripto
    Private linhaTexto As String
    Private fluxoTexto As IO.StreamReader
    Private link As String
    Private i As Integer
    Private menAnimes As System.Windows.Forms.ToolStripMenuItem
    Private wc As New WebClient
    Private endereco As String = "https://sites.google.com/site/listaanimes/files/"
    Private strAssist, versao As String
    Private carregandoMenu As Boolean = False
    Private nowPlaying As String
    Private versaoInfo As String
    Private nomesAnimesListados As New SortedDictionary(Of String, String)

    'Versão Com SQL
    Private strCon As String = "Data Source=infos_db.sdf; Persist Security Info=False;"
    Private con As New SqlServerCe.SqlCeConnection(strCon)
    Private strCmd As String
    Private cmd As SqlServerCe.SqlCeCommand
    Private dr As SqlServerCe.SqlCeDataReader
    Private auxRetorna As Integer

    Private versaoWeb() As String
    Private versaoAtual As String
    Private atualizandoSistema As Boolean
    '---------------------------------------

    '**************************************************************
    ' Arrastando form sem borda
    '**************************************************************
    Private WM_NCHITTEST As Integer = &H84
    Private HTCLIENT As Integer = &H1
    Private HTCAPTION As Integer = &H2

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

    Private Sub procuraUpdates()
        Try
            versaoAtual = verificaUpdate()

            versaoWeb = wc.DownloadString(endereco & "query.dat").Split("$")
            If versaoWeb(versaoWeb.Length - 1).Split("#")(0).ToString.Trim > versaoAtual Then
                Call atualiza()
            End If
        Catch ex As Exception
            MsgBox("Não foi possivel conectar com o site de atualizações.", MsgBoxStyle.Exclamation, "Erro de Conexão")
        End Try
    End Sub

    Private Function verificaUpdate() As Integer
        strCmd = "SELECT TOP 1 his_update FROM TBupdates_historico ORDER BY his_update DESC"
        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            con.Open()
            dr = cmd.ExecuteReader
            If (dr.Read) Then
                Return dr("his_update")
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox("Erro ao determinar atualização. " & ex.ToString, MsgBoxStyle.Critical, "Erro no Banco de Dados")
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        Return 0
    End Function

    Private Sub frmPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'My.Settings.episodio_assistido = ""
        'My.Settings.anime_assistido = ""
        tmePlayer.Start()

        Call procuraUpdates()

        'Try
        '    versao = wc.DownloadString(endereco & "update.dat").Split("$")(0)
        '    If versao > Application.ProductVersion Then
        '        Call atualiza()
        '    End If
        'Catch ex As Exception
        '    MsgBox("Não foi possivel conectar com o site de atualizações.", MsgBoxStyle.Exclamation, "Erro de Conexão")
        'End Try

        'Animes assistidos via Settings
        'If Environment.GetCommandLineArgs.Length > 1 Then
        '    My.Settings.anime_assistido = Environment.GetCommandLineArgs.ToArray(1)
        '    My.Settings.episodio_assistido = Environment.GetCommandLineArgs.ToArray(2)
        'End If
        '------------------------------------------------------------------------------

        If File.Exists(My.Application.Info.DirectoryPath & "\troll.exe") Then
            File.Delete(Application.StartupPath & "\troll.exe")
        End If

        '********************************************************************************************************************
        ' Versão via texto
        '********************************************************************************************************************

        'If IO.File.Exists(My.Application.Info.DirectoryPath & "\infos.dat") Then
        '    fluxoTexto = New IO.StreamReader(My.Application.Info.DirectoryPath & "\infos.dat")
        '    linhaTexto = fluxoTexto.ReadToEnd
        '    linhaTexto = cript.clsCrypto(linhaTexto, False)
        '    animes = linhaTexto.Split("|")(1).Split("$")

        '    fluxoTexto.Close()
        'Else
        '    MsgBox("Arquivo infos.dat não encontrado ou corrompido!", MsgBoxStyle.Critical, "Erro ao Iniciar Programa")
        'End If

        'For Me.i = 0 To animes.Length - 1
        '    infos = animes(i).Split("#")

        '    menAnimes = New System.Windows.Forms.ToolStripMenuItem()
        '    menAnimes.Name = infos(4).Trim
        '    menAnimes.Text = infos(0).Trim
        '    'adiciona ao vetor de animes para verificação futura
        '    nomesAnimesListados.Add(infos(4).Trim, infos(0).Trim)
        '    '---------------------------------------------------
        '    Select Case (infos(1).Trim)
        '        Case 1
        '            Me.DramaToolStripMenuItem.DropDownItems.Add(menAnimes)
        '        Case 2
        '            Me.AçãoToolStripMenuItem.DropDownItems.Add(menAnimes)
        '        Case 3
        '            Me.ComédiaToolStripMenuItem.DropDownItems.Add(menAnimes)
        '        Case 4
        '            Me.RomanceToolStripMenuItem.DropDownItems.Add(menAnimes)
        '    End Select
        '    AddHandler menAnimes.Click, AddressOf Me.ToolStripMenuItem_Click
        '    animeInfos.Add(infos(4).Trim, New clsListaAnimes(infos(0).Trim, infos(2).Trim, infos(3).Trim, infos(5).Trim))
        'Next

        '********************************************************************************************************************
        ' Fim da versão via Texto
        '********************************************************************************************************************


        '********************************************************************************************************************
        ' Versão via Banco de Dados
        '********************************************************************************************************************
        strCmd = "SELECT * FROM TBanime_infos"
        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)

        Try
            con.Open()
            dr = cmd.ExecuteReader()
            While dr.Read
                menAnimes = New System.Windows.Forms.ToolStripMenuItem()
                menAnimes.Name = dr("inf_cod").ToString
                menAnimes.Text = dr("inf_nome").ToString
                'adiciona ao vetor de animes para verificação futura
                nomesAnimesListados.Add(dr("inf_cod").ToString, dr("inf_nome").ToString)
                '---------------------------------------------------
                Select Case (dr("inf_categoria"))
                    Case 1
                        Me.DramaToolStripMenuItem.DropDownItems.Add(menAnimes)
                    Case 2
                        Me.AçãoToolStripMenuItem.DropDownItems.Add(menAnimes)
                    Case 3
                        Me.ComédiaToolStripMenuItem.DropDownItems.Add(menAnimes)
                    Case 4
                        Me.RomanceToolStripMenuItem.DropDownItems.Add(menAnimes)
                End Select
                AddHandler menAnimes.Click, AddressOf Me.ToolStripMenuItem_Click
                animeInfos.Add(dr("inf_cod").ToString, New clsListaAnimes(dr("inf_id"), dr("inf_nome").ToString, dr("inf_sinopse").ToString, dr("inf_opniao").ToString, dr("inf_link").ToString))
            End While

        Catch ex As Exception
            MsgBox("Erro ao fazer operação." & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation)

        Finally
            con.Close()
            cmd.Dispose()
            dr.Dispose()
        End Try

        '********************************************************************************************************************
        ' Fim da Versão via Banco de Dados
        '********************************************************************************************************************

        tmeDelUpdate.Start()

    End Sub

    Private Sub mudaPainel(ByVal menu As String)
        carregandoMenu = True
        panPrincipal.Visible = True
        lblTitulo.Text = animeInfos(menu).Nome
        picImagem.Image = imgs_base.My.Resources.ResourceManager.GetObject(menu)
        link = animeInfos(menu).Link
        lblDesc.Text = animeInfos(menu).Descricao
        lblRecomend.Text = animeInfos(menu).Recomendacao
        cbxAssistido.Checked = verificaCheckBox()
        'chkAssistindo.Checked = verificaAssistindo()
        numEpisodio.Value = verificaEpisodio()
        carregandoMenu = False
    End Sub

    Private Sub ToolStripMenuItem_Click(sender As Object, e As EventArgs)
        strAssist = sender.Name.ToString
        Call mudaPainel(sender.Name.ToString)
    End Sub

    Private Sub lblTitulo_Click(sender As Object, e As EventArgs) Handles lblTitulo.Click
        If lblTitulo.Text = "Onegai Twins" Then
            MsgBox("Desça a página até o final, vão estar os links lá.")
        End If
        System.Diagnostics.Process.Start(link)
    End Sub

    Private Sub cbxAssistido_CheckStateChanged(sender As Object, e As EventArgs) Handles cbxAssistido.CheckStateChanged
        If Not carregandoMenu Then
            If Not verificaAdicionado(strAssist) Then
                If Not adicionaAnime(strAssist) Then
                    Exit Sub
                End If
            End If

            If cbxAssistido.Checked Then
                If Not alteraWatching(strAssist, , 1) Then
                    'carregandoMenu = True
                    cbxAssistido.Checked = False
                    'carregandoMenu = False
                    Exit Sub
                End If
            Else
                If Not alteraWatching(strAssist, , 0) Then
                    'carregandoMenu = True
                    cbxAssistido.Checked = True
                    'carregandoMenu = False
                    Exit Sub
                End If
            End If

            'Versão via Settings
            'If cbxAssistido.Checked Then
            '    My.Settings.anime_assistido &= strAssist
            'Else
            '    If My.Settings.anime_assistido Like ("*" & strAssist & "*") Then
            '        My.Settings.anime_assistido = My.Settings.anime_assistido.Replace(strAssist, "")
            '    End If
            'End If
        End If
    End Sub

    Public Function alteraWatching(anime As String, Optional ByVal epi As Integer = -1, Optional ByVal assistid As Integer = -1) As Boolean
        If Not (epi = -1) Then
            strCmd = "UPDATE TBanime_watching SET wat_episodio = " & epi & " WHERE wat_anime = '" & anime & "'"
        End If

        If Not (assistid = -1) Then
            strCmd = "UPDATE TBanime_watching SET wat_assistido = " & assistid & " WHERE wat_anime = '" & anime & "'"
        End If

        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao atualizar anime na tabela de Assistidos.", MsgBoxStyle.Critical, "Erro no Banco de Dados")
            Return False
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        Return True
    End Function

    Public Function verificaAdicionado(anime As String, Optional ByVal retorna As Integer = -1) As Boolean
        strCmd = "SELECT * FROM TBanime_watching WHERE wat_anime = '" & anime & "'"
        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            con.Open()
            dr = cmd.ExecuteReader
            If (dr.Read) Then
                If (retorna = 0) Then
                    If dr("wat_assistido") = 0 Then
                        Return False
                    End If
                ElseIf (retorna = 1) Then
                    auxRetorna = dr("wat_episodio")
                End If
                Return True
            End If
        Catch ex As Exception
            MsgBox("Erro ao acessar banco de dados: " & vbCrLf & ex.ToString, MsgBoxStyle.Critical, "Erro no Banco")
        Finally
            cmd.Dispose()
            dr.Dispose()
            con.Close()
        End Try

        Return False
    End Function

    Public Function adicionaAnime(anime As String) As Boolean
        strCmd = "INSERT INTO TBanime_watching (wat_anime, wat_episodio, wat_assistido) VALUES ('" & anime & "', 0, 0)"
        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao adicionar anime à tabela de Assistidos.", MsgBoxStyle.Critical, "Erro no Banco de Dados")
            Return False
        Finally
            cmd.Dispose()
            con.Close()
        End Try

        Return True
    End Function

    Private Function verificaCheckBox() As Boolean

        If verificaAdicionado(strAssist, 0) Then
            Return True
        End If

        'If My.Settings.anime_assistido Like ("*" & strAssist & "*") Then
        '    Return True
        'End If
        Return False
    End Function

    Private Sub numEpisodio_ValueChanged(sender As Object, e As EventArgs) Handles numEpisodio.ValueChanged
        If Not carregandoMenu Then
            If Not verificaAdicionado(strAssist) Then
                If Not adicionaAnime(strAssist) Then
                    Exit Sub
                End If
            End If

            If Not alteraWatching(strAssist, numEpisodio.Value) Then
                Exit Sub
            End If


            'If My.Settings.episodio_assistido Like ("*" & strAssist & "*") Then
            '    My.Settings.episodio_assistido = My.Settings.episodio_assistido.Replace(arrumaEpisodio(), strAssist & "=" & verificaZeros())
            'Else
            '    My.Settings.episodio_assistido &= strAssist & "=" & verificaZeros()
            'End If
        End If
    End Sub

    Public Function verificaEpisodio() As Integer
        If verificaAdicionado(strAssist, 1) Then
            Return auxRetorna
        End If


        'If My.Settings.episodio_assistido Like ("*" & strAssist & "*") Then
        '    Return My.Settings.episodio_assistido.Substring(My.Settings.episodio_assistido.IndexOf(strAssist & "=") + strAssist.Length + 1, 2)
        'End If

        Return 0
    End Function

    Private Sub atualiza()
        Try
            'fluxoTexto = New IO.StreamReader(My.Application.Info.DirectoryPath & "\infos.dat")
            'linhaTexto = fluxoTexto.ReadToEnd
            'linhaTexto = cript.clsCrypto(linhaTexto, False)
            'versaoInfo = linhaTexto.Split("|")(0)
            'fluxoTexto.Close()

            atualizandoSistema = True
            wc.DownloadFile(endereco & "update.e", Application.StartupPath & "\update.exe")
            Shell(Application.StartupPath & "\update.exe")
            'Shell(Application.StartupPath & "\update.exe " & My.Settings.anime_assistido & " " & My.Settings.episodio_assistido & " " & Application.ProductVersion & " " & versaoInfo & " " & imgs_base.My.Resources.Version)
            'Application.Exit()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnFechar_Click(sender As Object, e As EventArgs) Handles btnFechar.Click
        Application.Exit()
    End Sub

    Private Sub btnMinimiza_Click(sender As Object, e As EventArgs) Handles btnMinimiza.Click
        Me.WindowState = FormWindowState.Minimized
        Me.Visible = False
        If Not My.Settings.viu_msg_bandeja Then
            icoPrincipal.ShowBalloonTip(2000, "Lista de Animes", "Programa minimizado para a bandeja.", ToolTipIcon.Info)
            My.Settings.viu_msg_bandeja = True
        End If

    End Sub

    Private Sub icoPrincipal_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles icoPrincipal.MouseDoubleClick
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
        Else
            Me.Activate()
        End If
    End Sub

    Private Sub RestaurarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RestaurarToolStripMenuItem.Click
        If Me.WindowState = FormWindowState.Minimized Then
            Me.Visible = True
            Me.WindowState = FormWindowState.Normal
        Else
            Me.Activate()
        End If
    End Sub

    Private Sub SairToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SairToolStripMenuItem.Click
        Application.Exit()
    End Sub

    '****************************************************************************************************************
    'Funções desativadas

    'Private Function arrumaEpisodio() As String
    '    Return My.Settings.episodio_assistido.Substring(My.Settings.episodio_assistido.IndexOf(strAssist), strAssist.Length + 3)
    'End Function

    'Private Function verificaZeros() As String
    '    If numEpisodio.Value < 10 Then
    '        Return "0" & numEpisodio.Value
    '    End If
    '    Return numEpisodio.Value.ToString
    'End Function

    '****************************************************************************************************************
    'Chekbox Desativo por não necessidade.
    '****************************************************************************************************************

    'Private Function verificaAssistindo() As Boolean
    '    If My.Settings.atual_assit Like ("*" & strAssist & "*") Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    'Private Sub chkAssistindo_CheckedChanged(sender As Object, e As EventArgs) Handles chkAssistindo.CheckedChanged
    '    If Not carregandoMenu Then
    '        If chkAssistindo.Checked Then
    '            My.Settings.atual_assit &= strAssist
    '        Else
    '            If My.Settings.atual_assit Like ("*" & strAssist & "*") Then
    '                My.Settings.atual_assit = My.Settings.atual_assit.Replace(strAssist, "")
    '            End If
    '        End If
    '    End If


    '    'If Not carregandoMenu Then
    '    '    If chkAssistindo.Checked Then
    '    '        My.Settings.atual_assit = strAssist
    '    '        My.Settings.nome_atual_assit = lblTitulo.Text
    '    '    Else
    '    '        My.Settings.atual_assit = String.Empty
    '    '        My.Settings.nome_atual_assit = String.Empty
    '    '    End If
    '    'End If

    'End Sub
    '*****************************************************************************************************************************
    ' Fim do Checkbox
    '*****************************************************************************************************************************

    Private Sub AtualizarEpisódioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AtualizarEpisódioToolStripMenuItem.Click
        frmAssistindo.Show()
        frmAssistindo.Activate()
    End Sub

    Private Sub tmePlayer_Tick(sender As Object, e As EventArgs) Handles tmePlayer.Tick
        If (Process.GetProcessesByName("mpc-hc").Length > 0) Then
            If Not (nowPlaying = Process.GetProcessesByName("mpc-hc").Last.MainWindowTitle) Then
                nowPlaying = Process.GetProcessesByName("mpc-hc").Last.MainWindowTitle

                If verificaNowPlaying(nowPlaying) Then
                    frmAssistindo.Show()
                    frmAssistindo.Activate()
                End If
            End If

        End If

        If (Process.GetProcessesByName("vlc").Length > 0) Then
            If Not (nowPlaying = Process.GetProcessesByName("vlc").Last.MainWindowTitle) Then
                nowPlaying = Process.GetProcessesByName("vlc").Last.MainWindowTitle

                If verificaNowPlaying(nowPlaying) Then
                    frmAssistindo.Show()
                    frmAssistindo.Activate()
                End If
            End If
        End If
    End Sub

    Private Function verificaNowPlaying(ByVal playing As String) As Boolean
        'If nomesAnimesListados.Contains(playing.Split(".")(0).Split("-")(0)) Then
        '    Return True
        'End If

        For Each anime As String In nomesAnimesListados.Values
            If playing.Split(".")(0) Like ("*" & anime & "*") Then
                My.Settings.nome_atual_assit = anime
                My.Settings.now_playing = FindKeyByValue(nomesAnimesListados, anime)
                Return True
            End If
        Next
        

        'If playing.Split(".")(0) Like ("*" & My.Settings.nome_atual_assit & "*") Then
        '    Return True
        'End If
        Return False
    End Function

    Public Shared Function FindKeyByValue(Of TKey, TValue)(dictionary As IDictionary(Of TKey, TValue), value As TValue) As TKey
        If dictionary Is Nothing Then
            Throw New ArgumentNullException("dictionary")
        End If

        For Each pair As KeyValuePair(Of TKey, TValue) In dictionary
            If value.Equals(pair.Value) Then
                Return pair.Key
            End If
        Next

        Throw New Exception("the value is not found in the dictionary")
    End Function

    '*********************************************************************************************************
    ' Sistema de atualizar episodio pela data de criação do processo
    '*********************************************************************************************************
    'Private nowPlaying As DateTime

    'Private Sub tmePlayer_Tick(sender As Object, e As EventArgs) Handles tmePlayer.Tick
    '    If My.Settings.atual_assit.Length > 0 Then
    '        Dim searcher As New ManagementObjectSearcher("SELECT * FROM Win32_Process WHERE Name='mpc-hc.exe' or Name='vlc.exe'")
    '        For Each process As ManagementObject In searcher.Get()
    '            If My.Settings.assistindo Then
    '                If Not nowPlaying = WMIDateStringToDate(process("CreationDate")) Then
    '                    My.Settings.assistindo = False
    '                End If
    '            Else
    '                nowPlaying = WMIDateStringToDate(process("CreationDate"))
    '                My.Settings.assistindo = True
    '                frmAssistindo.Show()
    '                frmAssistindo.Activate()
    '            End If

    '        Next
    '    End If

    'End Sub

    'Private Function WMIDateStringToDate(dtmStart) As DateTime
    '    Dim strData As String = Mid(dtmStart, 5, 2) & "-" & Mid(dtmStart, 7, 2) & "-" & VB.Left(dtmStart, 4) & " " & Mid(dtmStart, 9, 2) & ":" & Mid(dtmStart, 11, 2) & ":" & Mid(dtmStart, 13, 2)
    '    Dim dataTrans As DateTime
    '    dataTrans = DateTime.ParseExact(strData, "MM-dd-yyyy HH:mm:ss", Nothing)

    '    Return dataTrans

    'End Function
    '*********************************************************************************************************
    ' Fim do sistema
    '*********************************************************************************************************

    Private Sub tmeDelUpdate_Tick(sender As Object, e As EventArgs) Handles tmeDelUpdate.Tick
        If Not atualizandoSistema Then
            If File.Exists(Application.StartupPath & "\update.exe") Then
                File.Delete(Application.StartupPath & "\update.exe")
            End If
            tmeDelUpdate.Dispose()
        Else
            If Not (Process.GetProcessesByName("update").Length > 0) Then
                atualizandoSistema = False
                Me.Dispose()
                Me.Show()
            End If
        End If
    End Sub
End Class