<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrincipal
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DramaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AçãoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComédiaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RomanceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tipLegenda = New System.Windows.Forms.ToolTip(Me.components)
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.btnFechar = New System.Windows.Forms.Button()
        Me.btnMinimiza = New System.Windows.Forms.Button()
        Me.picImagem = New System.Windows.Forms.PictureBox()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRecomend = New System.Windows.Forms.Label()
        Me.cbxAssistido = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numEpisodio = New System.Windows.Forms.NumericUpDown()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.chkAssistindo = New System.Windows.Forms.CheckBox()
        Me.icoPrincipal = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.menIcone = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AtualizarEpisódioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RestaurarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.SairToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tmePlayer = New System.Windows.Forms.Timer(Me.components)
        Me.tmeDelUpdate = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picImagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.numEpisodio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panPrincipal.SuspendLayout()
        Me.menIcone.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.Transparent
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(64, 64)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DramaToolStripMenuItem, Me.AçãoToolStripMenuItem, Me.ComédiaToolStripMenuItem, Me.RomanceToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(429, 67)
        Me.MenuStrip1.Margin = New System.Windows.Forms.Padding(2)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.MenuStrip1.Size = New System.Drawing.Size(525, 72)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DramaToolStripMenuItem
        '
        Me.DramaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DramaToolStripMenuItem.Image = CType(resources.GetObject("DramaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.DramaToolStripMenuItem.Name = "DramaToolStripMenuItem"
        Me.DramaToolStripMenuItem.Size = New System.Drawing.Size(125, 68)
        Me.DramaToolStripMenuItem.Text = "Drama"
        '
        'AçãoToolStripMenuItem
        '
        Me.AçãoToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AçãoToolStripMenuItem.Image = CType(resources.GetObject("AçãoToolStripMenuItem.Image"), System.Drawing.Image)
        Me.AçãoToolStripMenuItem.Name = "AçãoToolStripMenuItem"
        Me.AçãoToolStripMenuItem.Size = New System.Drawing.Size(114, 68)
        Me.AçãoToolStripMenuItem.Text = "Ação"
        '
        'ComédiaToolStripMenuItem
        '
        Me.ComédiaToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComédiaToolStripMenuItem.Image = CType(resources.GetObject("ComédiaToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ComédiaToolStripMenuItem.Name = "ComédiaToolStripMenuItem"
        Me.ComédiaToolStripMenuItem.Size = New System.Drawing.Size(138, 68)
        Me.ComédiaToolStripMenuItem.Text = "Comédia"
        '
        'RomanceToolStripMenuItem
        '
        Me.RomanceToolStripMenuItem.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RomanceToolStripMenuItem.Image = CType(resources.GetObject("RomanceToolStripMenuItem.Image"), System.Drawing.Image)
        Me.RomanceToolStripMenuItem.Name = "RomanceToolStripMenuItem"
        Me.RomanceToolStripMenuItem.Size = New System.Drawing.Size(140, 68)
        Me.RomanceToolStripMenuItem.Text = "Romance"
        '
        'tipLegenda
        '
        Me.tipLegenda.AutomaticDelay = 200
        Me.tipLegenda.AutoPopDelay = 5000
        Me.tipLegenda.InitialDelay = 200
        Me.tipLegenda.IsBalloon = True
        Me.tipLegenda.ReshowDelay = 40
        '
        'lblTitulo
        '
        Me.lblTitulo.AutoEllipsis = True
        Me.lblTitulo.BackColor = System.Drawing.Color.Transparent
        Me.lblTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblTitulo.Location = New System.Drawing.Point(87, 8)
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(429, 48)
        Me.lblTitulo.TabIndex = 0
        Me.lblTitulo.Text = "Titulo"
        Me.tipLegenda.SetToolTip(Me.lblTitulo, "Clique Para Abrir a Página de Download")
        '
        'btnFechar
        '
        Me.btnFechar.AutoEllipsis = True
        Me.btnFechar.BackColor = System.Drawing.Color.Transparent
        Me.btnFechar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFechar.ForeColor = System.Drawing.Color.Silver
        Me.btnFechar.Image = CType(resources.GetObject("btnFechar.Image"), System.Drawing.Image)
        Me.btnFechar.Location = New System.Drawing.Point(955, 71)
        Me.btnFechar.Name = "btnFechar"
        Me.btnFechar.Size = New System.Drawing.Size(25, 25)
        Me.btnFechar.TabIndex = 2
        Me.btnFechar.UseVisualStyleBackColor = False
        '
        'btnMinimiza
        '
        Me.btnMinimiza.BackColor = System.Drawing.Color.Transparent
        Me.btnMinimiza.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMinimiza.ForeColor = System.Drawing.Color.LightGray
        Me.btnMinimiza.Image = CType(resources.GetObject("btnMinimiza.Image"), System.Drawing.Image)
        Me.btnMinimiza.Location = New System.Drawing.Point(955, 96)
        Me.btnMinimiza.Name = "btnMinimiza"
        Me.btnMinimiza.Size = New System.Drawing.Size(25, 25)
        Me.btnMinimiza.TabIndex = 3
        Me.btnMinimiza.UseVisualStyleBackColor = False
        '
        'picImagem
        '
        Me.picImagem.Location = New System.Drawing.Point(87, 59)
        Me.picImagem.Name = "picImagem"
        Me.picImagem.Size = New System.Drawing.Size(430, 172)
        Me.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagem.TabIndex = 1
        Me.picImagem.TabStop = False
        '
        'lblDesc
        '
        Me.lblDesc.AutoEllipsis = True
        Me.lblDesc.BackColor = System.Drawing.Color.Transparent
        Me.lblDesc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDesc.Location = New System.Drawing.Point(84, 237)
        Me.lblDesc.Name = "lblDesc"
        Me.lblDesc.Size = New System.Drawing.Size(430, 97)
        Me.lblDesc.TabIndex = 2
        Me.lblDesc.Text = "Descrição"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.lblRecomend)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(147, 347)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(369, 84)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Considerações Finais"
        '
        'lblRecomend
        '
        Me.lblRecomend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecomend.Location = New System.Drawing.Point(6, 26)
        Me.lblRecomend.Name = "lblRecomend"
        Me.lblRecomend.Size = New System.Drawing.Size(357, 50)
        Me.lblRecomend.TabIndex = 3
        Me.lblRecomend.Text = "Recomendação"
        '
        'cbxAssistido
        '
        Me.cbxAssistido.AutoSize = True
        Me.cbxAssistido.BackColor = System.Drawing.Color.Transparent
        Me.cbxAssistido.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbxAssistido.Location = New System.Drawing.Point(152, 453)
        Me.cbxAssistido.Name = "cbxAssistido"
        Me.cbxAssistido.Size = New System.Drawing.Size(83, 19)
        Me.cbxAssistido.TabIndex = 5
        Me.cbxAssistido.Text = "Assistido"
        Me.cbxAssistido.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(319, 455)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Ultimo episódio visto:"
        '
        'numEpisodio
        '
        Me.numEpisodio.Location = New System.Drawing.Point(448, 452)
        Me.numEpisodio.Name = "numEpisodio"
        Me.numEpisodio.Size = New System.Drawing.Size(68, 20)
        Me.numEpisodio.TabIndex = 7
        '
        'panPrincipal
        '
        Me.panPrincipal.BackColor = System.Drawing.Color.Transparent
        Me.panPrincipal.Controls.Add(Me.numEpisodio)
        Me.panPrincipal.Controls.Add(Me.Label1)
        Me.panPrincipal.Controls.Add(Me.cbxAssistido)
        Me.panPrincipal.Controls.Add(Me.GroupBox1)
        Me.panPrincipal.Controls.Add(Me.lblDesc)
        Me.panPrincipal.Controls.Add(Me.picImagem)
        Me.panPrincipal.Controls.Add(Me.lblTitulo)
        Me.panPrincipal.Controls.Add(Me.chkAssistindo)
        Me.panPrincipal.Location = New System.Drawing.Point(444, 144)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(523, 509)
        Me.panPrincipal.TabIndex = 1
        Me.panPrincipal.Visible = False
        '
        'chkAssistindo
        '
        Me.chkAssistindo.AutoSize = True
        Me.chkAssistindo.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.chkAssistindo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAssistindo.Location = New System.Drawing.Point(-2, 8)
        Me.chkAssistindo.Name = "chkAssistindo"
        Me.chkAssistindo.Size = New System.Drawing.Size(96, 38)
        Me.chkAssistindo.TabIndex = 8
        Me.chkAssistindo.Text = "Assistindo"
        Me.chkAssistindo.UseVisualStyleBackColor = True
        Me.chkAssistindo.Visible = False
        '
        'icoPrincipal
        '
        Me.icoPrincipal.ContextMenuStrip = Me.menIcone
        Me.icoPrincipal.Icon = CType(resources.GetObject("icoPrincipal.Icon"), System.Drawing.Icon)
        Me.icoPrincipal.Text = "Lista de Animes"
        Me.icoPrincipal.Visible = True
        '
        'menIcone
        '
        Me.menIcone.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtualizarEpisódioToolStripMenuItem, Me.RestaurarToolStripMenuItem, Me.ToolStripSeparator1, Me.SairToolStripMenuItem})
        Me.menIcone.Name = "ContextMenuStrip1"
        Me.menIcone.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.menIcone.Size = New System.Drawing.Size(169, 76)
        Me.menIcone.Text = "Lista de Animes"
        '
        'AtualizarEpisódioToolStripMenuItem
        '
        Me.AtualizarEpisódioToolStripMenuItem.Name = "AtualizarEpisódioToolStripMenuItem"
        Me.AtualizarEpisódioToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.AtualizarEpisódioToolStripMenuItem.Text = "Atualizar Episódio"
        '
        'RestaurarToolStripMenuItem
        '
        Me.RestaurarToolStripMenuItem.Name = "RestaurarToolStripMenuItem"
        Me.RestaurarToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.RestaurarToolStripMenuItem.Text = "Restaurar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(165, 6)
        '
        'SairToolStripMenuItem
        '
        Me.SairToolStripMenuItem.Name = "SairToolStripMenuItem"
        Me.SairToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.SairToolStripMenuItem.Text = "Sair"
        '
        'tmePlayer
        '
        Me.tmePlayer.Interval = 500
        '
        'tmeDelUpdate
        '
        Me.tmeDelUpdate.Interval = 4000
        '
        'frmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(994, 702)
        Me.Controls.Add(Me.btnMinimiza)
        Me.Controls.Add(Me.btnFechar)
        Me.Controls.Add(Me.panPrincipal)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(994, 702)
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Animes For Watch"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picImagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.numEpisodio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        Me.menIcone.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DramaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComédiaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RomanceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tipLegenda As System.Windows.Forms.ToolTip
    Friend WithEvents AçãoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnFechar As System.Windows.Forms.Button
    Friend WithEvents btnMinimiza As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents picImagem As System.Windows.Forms.PictureBox
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecomend As System.Windows.Forms.Label
    Friend WithEvents cbxAssistido As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numEpisodio As System.Windows.Forms.NumericUpDown
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents icoPrincipal As System.Windows.Forms.NotifyIcon
    Friend WithEvents menIcone As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents RestaurarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SairToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmePlayer As System.Windows.Forms.Timer
    Friend WithEvents chkAssistindo As System.Windows.Forms.CheckBox
    Friend WithEvents AtualizarEpisódioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tmeDelUpdate As System.Windows.Forms.Timer

End Class
