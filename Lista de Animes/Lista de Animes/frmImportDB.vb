Imports System.Data.SqlServerCe

Public Class frmImportDB

    Private fluxoTexto As IO.StreamReader
    Private linhaTexto As String
    Private animes() As String
    Private cript As New Cripto
    Private i As Integer
    Private infos() As String

    Private strCon As String = "Data Source=C:\Users\Akamura Asai\Documents\Visual Studio 2012\Projects\Lista de Animes\Lista de Animes\Lista de Animes\infos_db.sdf; Persist Security Info=False;"
    Private con As New SqlCeConnection(strCon)
    Private cmd As SqlCeCommand
    Private strCmd As String

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click

        If IO.File.Exists(My.Application.Info.DirectoryPath & "\importar.dat") Then
            fluxoTexto = New IO.StreamReader(My.Application.Info.DirectoryPath & "\importar.dat")
            linhaTexto = fluxoTexto.ReadToEnd
            linhaTexto = cript.clsCrypto(linhaTexto, False)
            animes = linhaTexto.Split("|")(1).Split("$")

            fluxoTexto.Close()
        Else
            MsgBox("Arquivo importar.dat não encontrado ou corrompido!", MsgBoxStyle.Critical, "Erro ao Importar Dados")
        End If

        For Me.i = 0 To animes.Length - 1
            infos = animes(i).Split("#")

            'INSERT
            strCmd = "INSERT INTO TBanime_infos (inf_nome, inf_categoria, inf_sinopse, inf_opniao, inf_cod, inf_link) VALUES " & _
                     "('" & infos(0).Trim & "', " & infos(1).Trim & ", '" & infos(2).Trim & "', '" & infos(3).Trim & "', '" & infos(4).Trim & "', '" & infos(5).Trim & "')"

            cmd = New SqlCeCommand(strCmd, con)
            Try
                con.Open()
                cmd.ExecuteNonQuery()

            Catch ex As Exception
                MsgBox("Erro ao importar." & vbCrLf & ex.ToString, MsgBoxStyle.Exclamation)
            Finally
                con.Close()
                cmd.Dispose()
            End Try
        Next
        con.Dispose()
        MsgBox("Processo Concluido!", MsgBoxStyle.Information)

    End Sub
End Class