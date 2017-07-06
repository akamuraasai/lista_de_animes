Imports System.Data.SqlServerCe

Public Class frmTestes

    Private strAssist As String
    Private carregandoMenu As Boolean
    Private animeInfos As New Hashtable
    Private strCon As String = "Data Source=C:\Users\Akamura Asai\Documents\Visual Studio 2012\Projects\Lista de Animes\Lista de Animes\Lista de Animes\infos_db.sdf; Persist Security Info=False;"
    Private con As New SqlCeConnection(strCon)
    Private cmd As New SqlCeCommand("Select * From TBanime_categorias", con)
    Private dr As SqlCeDataReader

    Private Sub frmTestes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        animeInfos.Add("drrr", New clsListaAnimes(1, "Durarara", "blbablablablab", "balbalblablablabla", "http://durarara.com"))
        animeInfos.Add("SAO", New clsListaAnimes(2, "Sword Art Online", "nkenkenkenkeneknekne", "nkenkenkenkenke", "http://sao.com"))
        animeInfos.Add("steins_gate", New clsListaAnimes(3, "Steins;Gate", "bhebhebhebhehbehbehbeh", "bhebhebhebehbehbe", "http://steins-gate.com"))
        animeInfos.Add("AnoHana", New clsListaAnimes(4, "Ano Hi Mita Hana no Namae wo Bokutachi wa Mada Shiranai", "bhebhebhebhehbehbehbeh", "bhebhebhebehbehbe", "http://steins-gate.com"))

        AxShockwaveFlash1.FlashVars = "textos=Steins;Gate#Sword Art Online#Durarara#Ano Hi Mita Hana no Namae wo Bokutachi wa Mada Shiranai&nomes=steins_gate#SAO#drrr#AnoHana"
        AxShockwaveFlash1.Movie = "C:\Users\Akamura Asai\Documents\Projeto - Programa Para iPhone\Menu - Lista de Animes\menu.dat"
        AxShockwaveFlash1.Play()

        Try
            con.Open()
            dr = cmd.ExecuteReader
            If dr.Read Then
                MsgBox(dr.GetString(1))
            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        Finally
            con.Dispose()
            cmd.Dispose()
        End Try

        'MsgBox(AxShockwaveFlash1.GetVariable("stage.main.retorno"))

        frmAgent.Show()
    End Sub

    Private Sub AxShockwaveFlash1_FSCommand(sender As Object, e As AxShockwaveFlashObjects._IShockwaveFlashEvents_FSCommandEvent) Handles AxShockwaveFlash1.FSCommand
        MsgBox(e.command.ToString() & " " & e.args.ToString())

        strAssist = e.command.ToString()
        Call mudaPainel(e.command.ToString())
    End Sub

    Private Sub mudaPainel(ByVal menu As String)
        carregandoMenu = True
        panPrincipal.Visible = True
        lblTitulo.Text = animeInfos(menu).Nome
        picImagem.Image = imgs_base.My.Resources.ResourceManager.GetObject(menu)
        lblDesc.Text = animeInfos(menu).Descricao
        lblRecomend.Text = animeInfos(menu).Recomendacao
        carregandoMenu = False
    End Sub

End Class