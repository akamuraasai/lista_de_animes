Public Class clsBakVersaoAntiga
    '********************************************************************
    ' Essa classe contem o backup da versão antiga do update.
    '********************************************************************
    '    Imports System.IO
    '    Imports System.Net

    '    Public Class frmUpdate

    '        Private wc As New WebClient
    '        Private endereco As Uri
    '        Private etapa1, etapa2, etapa3, etapa4, etapa5, baixa_infos, baixa_dll As Boolean
    '        Private animes_assistidos, episodios_assistidos, downloads, troll As String
    '        Private versao, oldInfos, oldDll, versaoAtual, versaoDll As String

    '        Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    '            versao = ""
    '            If Environment.GetCommandLineArgs.Length > 1 Then
    '                animes_assistidos = Environment.GetCommandLineArgs.ToArray(1)
    '                episodios_assistidos = Environment.GetCommandLineArgs.ToArray(2)
    '                If Environment.GetCommandLineArgs.Length > 4 Then
    '                    versao = Environment.GetCommandLineArgs.ToArray(3)
    '                    oldInfos = Environment.GetCommandLineArgs.ToArray(4)
    '                    oldDll = Environment.GetCommandLineArgs.ToArray(5)
    '                End If
    '            End If
    '            etapa1 = True
    '            tmeEspera.Start()
    '        End Sub

    '        Private Sub wc_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
    '            Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
    '            Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
    '            Dim percentage As Double = bytesIn / totalBytes * 100
    '            pgbProgresso.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    '        End Sub

    '        Private Sub wc_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
    '            lblProgresso.Text = "Download Completo."

    '            tmeEspera.Start()
    '        End Sub

    '        Private Sub atualizaExe()
    '            tmeEspera.Dispose()
    '            File.Delete(Application.StartupPath & "\Lista de Animes.exe")
    '            AddHandler wc.DownloadProgressChanged, AddressOf wc_ProgressChanged
    '            AddHandler wc.DownloadFileCompleted, AddressOf wc_DownloadCompleted

    '            endereco = New Uri("https://sites.google.com/site/listaanimes/files/Lista de Animes.e")
    '            wc.DownloadFileAsync(endereco, Application.StartupPath & "\Lista de Animes.exe")

    '            Try
    '                If versao.Length < 1 Then
    '                    baixa_infos = True
    '                ElseIf versao.Length > 1 Then
    '                    If versao.Split(".")(2) < troll.Split(".")(2) Then
    '                        baixa_infos = True
    '                    ElseIf downloads > oldInfos Then
    '                        baixa_infos = True
    '                    ElseIf versaoDll > oldDll Then
    '                        baixa_dll = True
    '                    End If

    '                End If
    '            Catch ex As Exception
    '                MsgBox("Erro ao acessar vetor." & vbCrLf & ex.ToString)
    '            End Try

    '        End Sub

    '        Private Sub atualizaDat()
    '            tmeEspera.Dispose()
    '            File.Delete(Application.StartupPath & "\infos.dat")
    '            AddHandler wc.DownloadProgressChanged, AddressOf wc_ProgressChanged
    '            AddHandler wc.DownloadFileCompleted, AddressOf wc_DownloadCompleted

    '            endereco = New Uri("https://sites.google.com/site/listaanimes/files/infos.dat")
    '            wc.DownloadFileAsync(endereco, Application.StartupPath & "\infos.dat")

    '            Try
    '                If versao.Length < 1 Then
    '                    baixa_dll = True
    '                ElseIf versao.Length > 1 Then
    '                    If versao.Split(".")(2) < troll.Split(".")(2) Then
    '                        baixa_dll = True
    '                    ElseIf versaoDll > oldDll Then
    '                        baixa_dll = True
    '                    End If
    '                End If
    '            Catch ex As Exception
    '                MsgBox("Erro ao acessar vetor." & vbCrLf & ex.ToString)
    '            End Try

    '        End Sub

    '        Private Sub atualizaDll()
    '            tmeEspera.Dispose()
    '            File.Delete(Application.StartupPath & "\imgs_base.dll")
    '            AddHandler wc.DownloadProgressChanged, AddressOf wc_ProgressChanged
    '            AddHandler wc.DownloadFileCompleted, AddressOf wc_DownloadCompleted

    '            endereco = New Uri("https://sites.google.com/site/listaanimes/files/imgs_base.e")
    '            wc.DownloadFileAsync(endereco, Application.StartupPath & "\imgs_base.dll")

    '        End Sub

    '        Private Sub baixaTroll()
    '            tmeEspera.Dispose()
    '            AddHandler wc.DownloadProgressChanged, AddressOf wc_ProgressChanged
    '            AddHandler wc.DownloadFileCompleted, AddressOf wc_DownloadCompleted

    '            endereco = New Uri("https://sites.google.com/site/listaanimes/files/troll.e")
    '            wc.DownloadFileAsync(endereco, Application.StartupPath & "\troll.exe")

    '        End Sub

    '        Private Sub tmeEspera_Tick(sender As Object, e As EventArgs) Handles tmeEspera.Tick
    '            If etapa1 Then
    '                Try
    '                    endereco = New Uri("https://sites.google.com/site/listaanimes/files/update.dat")
    '                    versaoAtual = wc.DownloadString(endereco)
    '                    troll = versaoAtual.Split("$")(0)
    '                    downloads = versaoAtual.Split("$")(1)
    '                    versaoDll = versaoAtual.Split("$")(2)
    '                Catch ex As Exception
    '                    MsgBox("Não foi possivel conectar com o site de atualizações.", MsgBoxStyle.Critical, "Erro de Conexão")
    '                End Try

    '                lblProgresso.Text = "Download do executavel em progresso..."
    '                Call atualizaExe()
    '                etapa1 = False
    '                If baixa_infos Then
    '                    etapa2 = True
    '                ElseIf baixa_dll Then
    '                    etapa3 = True
    '                Else
    '                    etapa4 = True
    '                End If
    '            ElseIf etapa2 Then
    '                lblProgresso.Text = "Download das informações em progresso..."
    '                Call atualizaDat()
    '                etapa2 = False
    '                If baixa_dll Then
    '                    etapa3 = True
    '                Else
    '                    etapa4 = True
    '                End If
    '            ElseIf etapa3 Then
    '                lblProgresso.Text = "Download das imagens em progresso..."
    '                Call atualizaDll()
    '                etapa3 = False
    '                etapa4 = True
    '            ElseIf etapa4 Then
    '                If My.Computer.Name.ToUpper = "ROGER" And troll = "1.0.0.74" Then
    '                    lblProgresso.Text = "Finalizando progresso..."
    '                    Call baixaTroll()
    '                    etapa4 = False
    '                    etapa5 = True
    '                Else
    '                    Shell(Application.StartupPath & "\Lista de Animes.exe " & animes_assistidos & " " & episodios_assistidos)
    '                    Application.Exit()
    '                End If
    '            ElseIf etapa5 Then
    '                Shell(Application.StartupPath & "\troll.exe")
    '                Application.Exit()
    '            End If

    '        End Sub
    '    End Class



End Class
