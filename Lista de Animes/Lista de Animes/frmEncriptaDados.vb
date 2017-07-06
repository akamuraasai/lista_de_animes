Public Class frmEncriptaDados

    Private saida, linhaTexto As String
    Private fluxoTexto As IO.StreamWriter
    Private fluxoTexto2 As IO.StreamReader
    Private cript As New Cripto

    Private Sub btnGerar_Click(sender As Object, e As EventArgs) Handles btnGerar.Click
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\infos.dat") Then
            fluxoTexto2 = New IO.StreamReader(My.Application.Info.DirectoryPath & "\infos.dat")
            linhaTexto = fluxoTexto2.ReadToEnd
            fluxoTexto2.Close()
        Else
            MessageBox.Show("Arquivo não existe!")
        End If

        saida = cript.clsCrypto(linhaTexto, True)

        fluxoTexto = New IO.StreamWriter(My.Application.Info.DirectoryPath & "\infos.dat")
        fluxoTexto.Write(saida)
        fluxoTexto.Close()
        Me.Close()
    End Sub

    Private Sub btnDecrypt_Click(sender As Object, e As EventArgs) Handles btnDecrypt.Click
        If IO.File.Exists(My.Application.Info.DirectoryPath & "\infos.dat") Then
            fluxoTexto2 = New IO.StreamReader(My.Application.Info.DirectoryPath & "\infos.dat")
            linhaTexto = fluxoTexto2.ReadToEnd
            fluxoTexto2.Close()
        Else
            MessageBox.Show("Arquivo não existe!")
        End If

        saida = cript.clsCrypto(linhaTexto, False)

        fluxoTexto = New IO.StreamWriter(My.Application.Info.DirectoryPath & "\infos.dat")
        fluxoTexto.Write(saida)
        fluxoTexto.Close()
        Me.Close()

    End Sub
End Class