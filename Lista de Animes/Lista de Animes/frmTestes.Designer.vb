<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTestes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTestes))
        Me.AxShockwaveFlash1 = New AxShockwaveFlashObjects.AxShockwaveFlash()
        Me.panPrincipal = New System.Windows.Forms.Panel()
        Me.numEpisodio = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxAssistido = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblRecomend = New System.Windows.Forms.Label()
        Me.lblDesc = New System.Windows.Forms.Label()
        Me.picImagem = New System.Windows.Forms.PictureBox()
        Me.lblTitulo = New System.Windows.Forms.Label()
        Me.chkAssistindo = New System.Windows.Forms.CheckBox()
        CType(Me.AxShockwaveFlash1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panPrincipal.SuspendLayout()
        CType(Me.numEpisodio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picImagem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'AxShockwaveFlash1
        '
        Me.AxShockwaveFlash1.Enabled = True
        Me.AxShockwaveFlash1.Location = New System.Drawing.Point(12, 35)
        Me.AxShockwaveFlash1.MaximumSize = New System.Drawing.Size(470, 260)
        Me.AxShockwaveFlash1.Name = "AxShockwaveFlash1"
        Me.AxShockwaveFlash1.OcxState = CType(resources.GetObject("AxShockwaveFlash1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxShockwaveFlash1.Size = New System.Drawing.Size(470, 260)
        Me.AxShockwaveFlash1.TabIndex = 0
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
        Me.panPrincipal.Location = New System.Drawing.Point(443, 70)
        Me.panPrincipal.Name = "panPrincipal"
        Me.panPrincipal.Size = New System.Drawing.Size(523, 509)
        Me.panPrincipal.TabIndex = 2
        Me.panPrincipal.Visible = False
        '
        'numEpisodio
        '
        Me.numEpisodio.Location = New System.Drawing.Point(448, 452)
        Me.numEpisodio.Name = "numEpisodio"
        Me.numEpisodio.Size = New System.Drawing.Size(68, 20)
        Me.numEpisodio.TabIndex = 7
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
        Me.lblRecomend.AutoSize = True
        Me.lblRecomend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRecomend.Location = New System.Drawing.Point(6, 31)
        Me.lblRecomend.Name = "lblRecomend"
        Me.lblRecomend.Size = New System.Drawing.Size(95, 15)
        Me.lblRecomend.TabIndex = 3
        Me.lblRecomend.Text = "Recomendação"
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
        'picImagem
        '
        Me.picImagem.Location = New System.Drawing.Point(87, 59)
        Me.picImagem.Name = "picImagem"
        Me.picImagem.Size = New System.Drawing.Size(430, 172)
        Me.picImagem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picImagem.TabIndex = 1
        Me.picImagem.TabStop = False
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
        'frmTestes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(978, 664)
        Me.Controls.Add(Me.panPrincipal)
        Me.Controls.Add(Me.AxShockwaveFlash1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmTestes"
        Me.Text = "frmTestes"
        CType(Me.AxShockwaveFlash1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panPrincipal.ResumeLayout(False)
        Me.panPrincipal.PerformLayout()
        CType(Me.numEpisodio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picImagem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents AxShockwaveFlash1 As AxShockwaveFlashObjects.AxShockwaveFlash
    Friend WithEvents panPrincipal As System.Windows.Forms.Panel
    Friend WithEvents numEpisodio As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxAssistido As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblRecomend As System.Windows.Forms.Label
    Friend WithEvents lblDesc As System.Windows.Forms.Label
    Friend WithEvents picImagem As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitulo As System.Windows.Forms.Label
    Friend WithEvents chkAssistindo As System.Windows.Forms.CheckBox
End Class
