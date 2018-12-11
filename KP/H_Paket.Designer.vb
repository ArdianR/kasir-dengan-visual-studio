<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class H_Paket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(H_Paket))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.DgView = New System.Windows.Forms.DataGridView()
        Me.pnlProjectsTitle = New System.Windows.Forms.Panel()
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlProjectsTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 19)
        Me.Label1.TabIndex = 0
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(-39, 492)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(143, 46)
        Me.btnCancel.TabIndex = 24
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'DgView
        '
        Me.DgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgView.Location = New System.Drawing.Point(0, 30)
        Me.DgView.Name = "DgView"
        Me.DgView.Size = New System.Drawing.Size(583, 212)
        Me.DgView.TabIndex = 23
        '
        'pnlProjectsTitle
        '
        Me.pnlProjectsTitle.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlProjectsTitle.BackgroundImage = CType(resources.GetObject("pnlProjectsTitle.BackgroundImage"), System.Drawing.Image)
        Me.pnlProjectsTitle.Controls.Add(Me.Label1)
        Me.pnlProjectsTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProjectsTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlProjectsTitle.Name = "pnlProjectsTitle"
        Me.pnlProjectsTitle.Size = New System.Drawing.Size(583, 30)
        Me.pnlProjectsTitle.TabIndex = 22
        '
        'H_Paket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(583, 242)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.DgView)
        Me.Controls.Add(Me.pnlProjectsTitle)
        Me.Name = "H_Paket"
        Me.Text = "H_Paket"
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlProjectsTitle.ResumeLayout(False)
        Me.pnlProjectsTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents DgView As System.Windows.Forms.DataGridView
    Friend WithEvents pnlProjectsTitle As System.Windows.Forms.Panel
End Class
