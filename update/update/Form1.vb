Imports System.IO
Imports System.Net

Public Class frmUpdate

    Private wc As New WebClient
    Private endereco As Uri
    Private versaoAtual As Integer
    Private listaUpdates As New SortedList

    Private strCon As String = "Data Source=infos_db.sdf; Persist Security Info=False;"
    Private con As New SqlServerCe.SqlCeConnection(strCon)
    Private strCmd As String
    Private cmd As SqlServerCe.SqlCeCommand
    Private dr As SqlServerCe.SqlCeDataReader

    Private updateOnline() As String
    Private endereco2 As String = "https://sites.google.com/site/listaanimes/files/"
    Private auxVersao As Integer
    Private auxUltimoUPD As Boolean
    Private auxDR As Boolean = False
    Private auxListaVerAtual, auxListaVer, auxDLLVerAtual, auxDLLVer As String
    Private iniciou As Boolean
    Private tmeAtua, tmeAtua2 As Boolean

    Private baixa_bd As Boolean

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call procuraUpdates()
        tmeEspera.Start()
    End Sub

    Private Sub baixaBD()
        lblProgresso.Text = "Baixando Banco de Dados..."

        File.Delete(Application.StartupPath & "\infos.dat")
        AddHandler wc.DownloadProgressChanged, AddressOf wc_ProgressChanged
        AddHandler wc.DownloadFileCompleted, AddressOf wc_DownloadCompleted

        endereco = New Uri("https://sites.google.com/site/listaanimes/files/infos_db.e")
        wc.DownloadFileAsync(endereco, Application.StartupPath & "\infos_db.sdf")

    End Sub

    Private Sub procuraUpdates()
        Try
            updateOnline = wc.DownloadString(endereco2 & "query.dat").Split("$")
        Catch ex As Exception
            MsgBox("Não foi possivel conectar com o site de atualizações.", MsgBoxStyle.Exclamation, "Erro de Conexão")
        End Try
    End Sub

    Private Function atualizaBanco() As Boolean
        If updateOnline(updateOnline.Length - 1).Split("#")(0) > auxVersao Then
            For i As Integer = auxVersao To updateOnline.Length - 1
                strCmd = "INSERT INTO TBlista_updates (upd_id, upd_lista_ver, upd_dll_ver, upd_atuali_lista, upd_atuali_dll, upd_atuali_db, upd_query) VALUES (" & _
                         updateOnline(i).Split("#")(0) & ", '" & updateOnline(i).Split("#")(1).ToString & "', '" & updateOnline(i).Split("#")(2).ToString & "', '" & updateOnline(i).Split("#")(3) & "', '" & updateOnline(i).Split("#")(4) & "', '" & updateOnline(i).Split("#")(5) & "', '" & updateOnline(i).Split("#")(6).Replace("'", "''").ToString & "')"
                cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
                Try
                    'con.Open()
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    MsgBox("Erro ao adicionar Update ao banco. " & ex.ToString, MsgBoxStyle.Critical, "Erro de Banco")
                Finally
                    'con.Close()
                    cmd.Dispose()
                End Try
            Next

            Return False
        End If

        Return True
    End Function

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

    Private Sub ultimaVersaoArquivos()
        strCmd = "SELECT TOP 1 * FROM TBlista_updates WHERE upd_atuali_lista = 1 ORDER BY upd_id DESC"
        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            dr = cmd.ExecuteReader
            If dr.Read Then
                auxListaVer = dr("upd_lista_ver").ToString
            End If
        Catch ex As Exception
            MsgBox("Erro ao determinar ultima atualização. " & ex.ToString, MsgBoxStyle.Critical, "Erro no Banco de Dados")
        Finally
            cmd.Dispose()
        End Try

        strCmd = "SELECT TOP 1 * FROM TBlista_updates WHERE upd_atuali_dll = 1 ORDER BY upd_id DESC"
        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            dr = cmd.ExecuteReader
            If dr.Read Then
                auxDLLVer = dr("upd_dll_ver").ToString
            End If
        Catch ex As Exception
            MsgBox("Erro ao determinar ultima atualização. " & ex.ToString, MsgBoxStyle.Critical, "Erro no Banco de Dados")
        Finally
            cmd.Dispose()
        End Try

    End Sub

    Private Sub versaoAtualArquivos()
        strCmd = "SELECT TOP 1 * FROM TBlista_updates ORDER BY upd_id DESC"
        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            dr = cmd.ExecuteReader
            If dr.Read Then
                auxListaVerAtual = dr("upd_lista_ver").ToString
            End If
        Catch ex As Exception
            MsgBox("Erro ao determinar ultima atualização. " & ex.ToString, MsgBoxStyle.Critical, "Erro no Banco de Dados")
        Finally
            cmd.Dispose()
        End Try

        strCmd = "SELECT TOP 1 * FROM TBlista_updates ORDER BY upd_id DESC"
        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            dr = cmd.ExecuteReader
            If dr.Read Then
                auxDLLVerAtual = dr("upd_dll_ver").ToString
            End If
        Catch ex As Exception
            MsgBox("Erro ao determinar ultima atualização. " & ex.ToString, MsgBoxStyle.Critical, "Erro no Banco de Dados")
        Finally
            cmd.Dispose()
        End Try

    End Sub

    Private Sub criaListaUpdates()
        If auxUltimoUPD Then
            strCmd = "SELECT * FROM TBlista_updates WHERE (upd_id > " & versaoAtual & ")"
        Else
            strCmd = "SELECT * FROM TBlista_updates"
        End If

        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            con.Open()
            dr = cmd.ExecuteReader
            If Not auxDR Then
                If Not dr.Read Then
                    auxVersao = 0
                    auxDLLVerAtual = "1.1.26.1"
                    auxListaVerAtual = "1.3.29.20"

                    If Not auxUltimoUPD Then
                        If atualizaBanco() Then
                            Application.Exit()
                        Else
                            auxUltimoUPD = True
                            con.Close()
                            dr.Dispose()
                            auxDR = True
                            Call criaListaUpdates()
                            Exit Sub
                        End If
                    End If
                Else
                    Call versaoAtualArquivos()
                    auxVersao = versaoAtual
                    Call atualizaBanco()
                    auxUltimoUPD = True
                    con.Close()
                    dr.Dispose()
                    auxDR = True
                    Call criaListaUpdates()
                    Exit Sub
                End If
            End If

            While (dr.Read)
                If Not auxDR Then
                    auxVersao = versaoAtual
                    auxDLLVerAtual = dr("upd_dll_ver")
                    auxListaVerAtual = dr("upd_lista_ver")
                    auxDR = True
                End If

                If Not auxUltimoUPD Then
                    If atualizaBanco() Then
                        Application.Exit()
                    ElseIf Not atualizaBanco() Then
                        auxUltimoUPD = True
                        con.Close()
                        Call criaListaUpdates()
                    End If
                End If

                auxDLLVer = dr("upd_dll_ver")
                auxListaVer = dr("upd_lista_ver")
                listaUpdates.Add(dr("upd_id") & " - " & dr("upd_lista_ver").ToString, New clsListaUpdates(dr("upd_id"), dr("upd_lista_ver").ToString, dr("upd_dll_ver").ToString, dr("upd_query").ToString))
            End While

            Call ultimaVersaoArquivos()
            If iniciaAtualizacoes() Then
                tmeEspera.Stop()
                Call verificaAtualizacaoArquivos()
            End If

        Catch ex As Exception
            MsgBox("Erro ao determinar ultima atualização. " & ex.ToString, MsgBoxStyle.Critical, "Erro no Banco de Dados")
        Finally
            cmd.Dispose()
            con.Close()
        End Try

    End Sub

    Private Function iniciaAtualizacoes() As Boolean
        'Faz as atualizações necessárias.
        con.Close()

        For Each update As String In listaUpdates.Keys
            If listaUpdates(update).pQuery.ToString.Length > 5 Then
                strCmd = listaUpdates(update).pQuery

                cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
                lblProgresso.Text = "Instalando Update " & listaUpdates(update).Ident & "."
                Try
                    con.Open()
                    cmd.ExecuteNonQuery()

                    'Adicionar a lista de updates feitos
                    Call adicionaHistorico(listaUpdates(update).Ident, True)
                    lblProgresso.Text = "Update " & listaUpdates(update).Ident & " instalado com sucesso."

                Catch ex As Exception
                    MsgBox("Erro ao executar atualização. " & ex.ToString, MsgBoxStyle.Critical, "Erro no Banco de Dados")
                    Call adicionaHistorico(listaUpdates(update).Ident, True, ex.ToString)
                    lblProgresso.Text = "Falha ao instalar Update " & listaUpdates(update).Ident & "."
                Finally
                    cmd.Dispose()
                    con.Close()
                End Try
            Else
                Call adicionaHistorico(listaUpdates(update).Ident, True)
            End If

            
        Next

        Return True
    End Function

    Private Sub adicionaHistorico(numUpdate As Integer, sucesso As Boolean, Optional ByVal erro As String = "")

        If sucesso Then
            strCmd = "INSERT INTO TBupdates_historico (his_update, his_sucesso) VALUES (" & numUpdate & ", 1)"
        Else
            strCmd = "INSERT INTO TBupdates_historico (his_update, his_sucesso, his_erro) VALUES (" & numUpdate & ", 0, '" & erro & "')"
        End If

        cmd.Dispose()
        con.Close()
        cmd = New SqlServerCe.SqlCeCommand(strCmd, con)
        Try
            con.Open()
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Erro ao adicionar histórico. " & ex.ToString, MsgBoxStyle.Critical, "Erro no Banco de Dados")
        Finally
            cmd.Dispose()
            con.Close()
        End Try

    End Sub

    Private Sub wc_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        pgbProgresso.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub wc_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        lblProgresso.Text = "Download Completo."

        If Not baixa_bd Then
            tmeEspera.Start()
        Else
            baixa_bd = False
        End If

    End Sub

    Private Sub atualizaExe()
        tmeEspera.Dispose()
        If (Process.GetProcessesByName("Lista de Animes").Length > 0) Then
            Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("Lista de Animes")

            For Each p As Process In pProcess
                p.Kill()
            Next
        End If
        File.Delete(Application.StartupPath & "\Lista de Animes.exe")
        AddHandler wc.DownloadProgressChanged, AddressOf wc_ProgressChanged
        AddHandler wc.DownloadFileCompleted, AddressOf wc_DownloadCompleted

        endereco = New Uri("https://sites.google.com/site/listaanimes/files/Lista de Animes.e")
        wc.DownloadFileAsync(endereco, Application.StartupPath & "\Lista de Animes.exe")

    End Sub

    Private Sub atualizaDll()
        tmeEspera.Dispose()
        If (Process.GetProcessesByName("Lista de Animes").Length > 0) Then
            Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("Lista de Animes")

            For Each p As Process In pProcess
                p.Kill()
            Next
        End If
        File.Delete(Application.StartupPath & "\imgs_base.dll")
        AddHandler wc.DownloadProgressChanged, AddressOf wc_ProgressChanged
        AddHandler wc.DownloadFileCompleted, AddressOf wc_DownloadCompleted

        endereco = New Uri("https://sites.google.com/site/listaanimes/files/imgs_base.e")
        wc.DownloadFileAsync(endereco, Application.StartupPath & "\imgs_base.dll")

    End Sub

    Private Sub verificaAtualizacaoArquivos()
        If auxDLLVer > auxDLLVerAtual Then
            lblProgresso.Text = "Atualizando base de imagens..."
            tmeAtua = True
            tmeEspera.Dispose()
            Call atualizaDll()
        Else
            If auxListaVer > auxListaVerAtual Then
                lblProgresso.Text = "Atualizando executavel..."
                tmeEspera.Dispose()
                Call atualizaExe()
            Else
                tmeAtua2 = True
                tmeFinalizacao.Start()
            End If
        End If

    End Sub

    Private Sub tmeEspera_Tick(sender As Object, e As EventArgs) Handles tmeEspera.Tick

        If Not File.Exists(My.Application.Info.DirectoryPath & "\infos_db.sdf") Then
            baixa_bd = True
            Call baixaBD()
        Else
            If Not iniciou Then
                versaoAtual = verificaUpdate()
                Call criaListaUpdates()
                iniciou = True
                Exit Sub
            End If

            If tmeAtua Then
                If auxListaVer > auxListaVerAtual Then
                    lblProgresso.Text = "Atualizando executavel..."
                    tmeEspera.Dispose()
                    tmeAtua = False
                    Call atualizaExe()
                Else
                    tmeAtua = False
                    tmeAtua2 = True
                    tmeFinalizacao.Start()
                End If
            Else
                tmeAtua2 = True
                tmeFinalizacao.Start()
            End If
        End If
    End Sub

    Private Sub tmeFinalizacao_Tick(sender As Object, e As EventArgs) Handles tmeFinalizacao.Tick
        If tmeAtua2 Then
            lblProgresso.Text = "Atualizações instaladas com sucesso."
            If Not pgbProgresso.Value = 100 Then
                pgbProgresso.Value = 100
            End If
            tmeAtua2 = False
        Else
            If Not (Process.GetProcessesByName("Lista de Animes").Length > 0) Then
                Shell(Application.StartupPath & "\Lista de Animes.exe")
            End If
            Application.Exit()
        End If
    End Sub
End Class
