Imports System.IO
Imports System.Text
Imports System.Security.Cryptography

Public Class Cripto

    Dim myKey As String
    Dim des As New TripleDESCryptoServiceProvider()
    Dim hashmd5 As New MD5CryptoServiceProvider()

    Public Sub New()
        'Inserir o codigo de configuração da classe
        myKey = "SenhaDoMeuBago"
    End Sub

    Public Function clsCrypto(ByVal texto As String, ByVal Operacao As Boolean) As String
        If Operacao Then
            clsCrypto = Cifra(texto)
        Else
            clsCrypto = DeCifra(texto)
        End If
    End Function

    Private Function DeCifra(ByVal texto As String) As String

        des.Key = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(myKey))
        DES.Mode = CipherMode.ECB
        Dim desdencrypt As ICryptoTransform = DES.CreateDecryptor()
        Dim buff() As Byte = Convert.FromBase64String(texto)
        DeCifra = UTF8Encoding.UTF8.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length))

    End Function

    Private Function Cifra(ByVal texto As String) As String
        des.Key = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(myKey))
        des.Mode = CipherMode.ECB
        Dim desdencrypt As ICryptoTransform = des.CreateEncryptor()
        Dim MyUTF8Encoding = New UTF8Encoding()
        Dim buff() As Byte = UTF8Encoding.UTF8.GetBytes(texto)
        Cifra = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length))
    End Function
    

End Class
