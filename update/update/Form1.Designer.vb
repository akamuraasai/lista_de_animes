<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdate
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmUpdate))
        Me.lblProgresso = New System.Windows.Forms.Label()
        Me.pgbProgresso = New System.Windows.Forms.ProgressBar()
        Me.tmeEspera = New System.Windows.Forms.Timer(Me.components)
        Me.tmeFinalizacao = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblProgresso
        '
        Me.lblProgresso.AutoSize = True
        Me.lblProgresso.BackColor = System.Drawing.Color.Transparent
        Me.lblProgresso.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgresso.Location = New System.Drawing.Point(12, 35)
        Me.lblProgresso.Name = "lblProgresso"
        Me.lblProgresso.Size = New System.Drawing.Size(212, 20)
        Me.lblProgresso.TabIndex = 0
        Me.lblProgresso.Text = "Buscando Atualizações..."
        '
        'pgbProgresso
        '
        Me.pgbProgresso.Location = New System.Drawing.Point(16, 67)
        Me.pgbProgresso.Name = "pgbProgresso"
        Me.pgbProgresso.Size = New System.Drawing.Size(314, 23)
        Me.pgbProgresso.TabIndex = 1
        '
        'tmeEspera
        '
        Me.tmeEspera.Interval = 3000
        '
        'tmeFinalizacao
        '
        Me.tmeFinalizacao.Interval = 2000
        '
        'frmUpdate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(440, 130)
        Me.Controls.Add(Me.pgbProgresso)
        Me.Controls.Add(Me.lblProgresso)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmUpdate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Atualizador da Lista de Animes"
        Me.TransparencyKey = System.Drawing.SystemColors.Control
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProgresso As System.Windows.Forms.Label
    Friend WithEvents pgbProgresso As System.Windows.Forms.ProgressBar
    Friend WithEvents tmeEspera As System.Windows.Forms.Timer
    Friend WithEvents tmeFinalizacao As System.Windows.Forms.Timer

End Class
