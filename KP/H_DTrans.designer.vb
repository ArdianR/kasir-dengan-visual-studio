<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class H_DTrans
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(H_DTrans))
        Me.pnlProjectsTitle = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DgView = New System.Windows.Forms.DataGridView()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GbSearch = New System.Windows.Forms.GroupBox()
        Me.txtSearch = New System.Windows.Forms.TextBox()
        Me.RbNama = New System.Windows.Forms.RadioButton()
        Me.RbTrans = New System.Windows.Forms.RadioButton()
        Me.pnlProjectsTitle.SuspendLayout()
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GbSearch.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlProjectsTitle
        '
        Me.pnlProjectsTitle.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlProjectsTitle.BackgroundImage = CType(resources.GetObject("pnlProjectsTitle.BackgroundImage"), System.Drawing.Image)
        Me.pnlProjectsTitle.Controls.Add(Me.Label1)
        Me.pnlProjectsTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProjectsTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlProjectsTitle.Name = "pnlProjectsTitle"
        Me.pnlProjectsTitle.Size = New System.Drawing.Size(1059, 30)
        Me.pnlProjectsTitle.TabIndex = 2
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
        'DgView
        '
        Me.DgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgView.Location = New System.Drawing.Point(12, 146)
        Me.DgView.Name = "DgView"
        Me.DgView.Size = New System.Drawing.Size(1034, 342)
        Me.DgView.TabIndex = 3
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(12, 502)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(144, 46)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GbSearch
        '
        Me.GbSearch.Controls.Add(Me.txtSearch)
        Me.GbSearch.Controls.Add(Me.RbNama)
        Me.GbSearch.Controls.Add(Me.RbTrans)
        Me.GbSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbSearch.Location = New System.Drawing.Point(399, 45)
        Me.GbSearch.Name = "GbSearch"
        Me.GbSearch.Size = New System.Drawing.Size(265, 95)
        Me.GbSearch.TabIndex = 0
        Me.GbSearch.TabStop = False
        Me.GbSearch.Text = "Search"
        '
        'txtSearch
        '
        Me.txtSearch.Location = New System.Drawing.Point(20, 59)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New System.Drawing.Size(221, 20)
        Me.txtSearch.TabIndex = 0
        '
        'RbNama
        '
        Me.RbNama.AutoSize = True
        Me.RbNama.Location = New System.Drawing.Point(184, 29)
        Me.RbNama.Name = "RbNama"
        Me.RbNama.Size = New System.Drawing.Size(57, 17)
        Me.RbNama.TabIndex = 1
        Me.RbNama.Text = "Nama"
        Me.RbNama.UseVisualStyleBackColor = True
        '
        'RbTrans
        '
        Me.RbTrans.AutoSize = True
        Me.RbTrans.Checked = True
        Me.RbTrans.Location = New System.Drawing.Point(20, 29)
        Me.RbTrans.Name = "RbTrans"
        Me.RbTrans.Size = New System.Drawing.Size(80, 17)
        Me.RbTrans.TabIndex = 1
        Me.RbTrans.TabStop = True
        Me.RbTrans.Text = "Transaksi"
        Me.RbTrans.UseVisualStyleBackColor = True
        '
        'H_DTrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1059, 560)
        Me.Controls.Add(Me.GbSearch)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.DgView)
        Me.Controls.Add(Me.pnlProjectsTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "H_DTrans"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View DVD List"
        Me.pnlProjectsTitle.ResumeLayout(False)
        Me.pnlProjectsTitle.PerformLayout()
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GbSearch.ResumeLayout(False)
        Me.GbSearch.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnlProjectsTitle As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DgView As System.Windows.Forms.DataGridView
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents GbSearch As System.Windows.Forms.GroupBox
    Friend WithEvents RbNama As System.Windows.Forms.RadioButton
    Friend WithEvents RbTrans As System.Windows.Forms.RadioButton
    Friend WithEvents txtSearch As System.Windows.Forms.TextBox
End Class
