<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Internal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_Internal))
        Me.GbDetail = New System.Windows.Forms.GroupBox()
        Me.txtTunai = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.DtDate = New System.Windows.Forms.DateTimePicker()
        Me.txtID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OFD = New System.Windows.Forms.OpenFileDialog()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlProjectsTitle = New System.Windows.Forms.Panel()
        Me.GbDetail.SuspendLayout()
        Me.pnlProjectsTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'GbDetail
        '
        Me.GbDetail.Controls.Add(Me.txtTunai)
        Me.GbDetail.Controls.Add(Me.Label3)
        Me.GbDetail.Controls.Add(Me.Label9)
        Me.GbDetail.Controls.Add(Me.txtKeterangan)
        Me.GbDetail.Controls.Add(Me.DtDate)
        Me.GbDetail.Controls.Add(Me.txtID)
        Me.GbDetail.Controls.Add(Me.Label2)
        Me.GbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GbDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbDetail.Location = New System.Drawing.Point(14, 45)
        Me.GbDetail.Name = "GbDetail"
        Me.GbDetail.Size = New System.Drawing.Size(509, 181)
        Me.GbDetail.TabIndex = 3
        Me.GbDetail.TabStop = False
        '
        'txtTunai
        '
        Me.txtTunai.Location = New System.Drawing.Point(89, 56)
        Me.txtTunai.Name = "txtTunai"
        Me.txtTunai.Size = New System.Drawing.Size(176, 20)
        Me.txtTunai.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Tunai"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 94)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 13)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Keterangan"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(89, 91)
        Me.txtKeterangan.Multiline = True
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(406, 74)
        Me.txtKeterangan.TabIndex = 6
        '
        'DtDate
        '
        Me.DtDate.CustomFormat = ""
        Me.DtDate.Enabled = False
        Me.DtDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DtDate.Location = New System.Drawing.Point(350, 19)
        Me.DtDate.Name = "DtDate"
        Me.DtDate.Size = New System.Drawing.Size(145, 20)
        Me.DtDate.TabIndex = 5
        '
        'txtID
        '
        Me.txtID.Enabled = False
        Me.txtID.Location = New System.Drawing.Point(89, 19)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(93, 20)
        Me.txtID.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(54, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "No"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OFD
        '
        Me.OFD.FileName = "OpenFileDialog1"
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(335, 246)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(80, 29)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(103, 246)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(80, 29)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
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
        'pnlProjectsTitle
        '
        Me.pnlProjectsTitle.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlProjectsTitle.BackgroundImage = CType(resources.GetObject("pnlProjectsTitle.BackgroundImage"), System.Drawing.Image)
        Me.pnlProjectsTitle.Controls.Add(Me.Label1)
        Me.pnlProjectsTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProjectsTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlProjectsTitle.Name = "pnlProjectsTitle"
        Me.pnlProjectsTitle.Size = New System.Drawing.Size(544, 30)
        Me.pnlProjectsTitle.TabIndex = 5
        '
        'F_Internal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(544, 292)
        Me.Controls.Add(Me.GbDetail)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.pnlProjectsTitle)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "F_Internal"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Internal"
        Me.GbDetail.ResumeLayout(False)
        Me.GbDetail.PerformLayout()
        Me.pnlProjectsTitle.ResumeLayout(False)
        Me.pnlProjectsTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents DtDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OFD As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlProjectsTitle As System.Windows.Forms.Panel
    Friend WithEvents txtTunai As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
