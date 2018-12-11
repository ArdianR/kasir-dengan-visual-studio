<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_User
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_User))
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GbDetail = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CbRole = New System.Windows.Forms.ComboBox()
        Me.txtLast = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFirst = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CbStatus = New System.Windows.Forms.CheckBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlProjectsTitle = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.GbDetail.SuspendLayout()
        Me.pnlProjectsTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(275, 279)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(84, 38)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "&Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(93, 279)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(84, 38)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GbDetail
        '
        Me.GbDetail.Controls.Add(Me.Label10)
        Me.GbDetail.Controls.Add(Me.CbRole)
        Me.GbDetail.Controls.Add(Me.txtLast)
        Me.GbDetail.Controls.Add(Me.Label1)
        Me.GbDetail.Controls.Add(Me.txtFirst)
        Me.GbDetail.Controls.Add(Me.Label2)
        Me.GbDetail.Controls.Add(Me.CbStatus)
        Me.GbDetail.Controls.Add(Me.txtPassword)
        Me.GbDetail.Controls.Add(Me.Label5)
        Me.GbDetail.Controls.Add(Me.txtUser)
        Me.GbDetail.Controls.Add(Me.Label3)
        Me.GbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.GbDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GbDetail.Location = New System.Drawing.Point(46, 40)
        Me.GbDetail.Name = "GbDetail"
        Me.GbDetail.Size = New System.Drawing.Size(340, 229)
        Me.GbDetail.TabIndex = 3
        Me.GbDetail.TabStop = False
        Me.GbDetail.Text = "User Detail"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(57, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 13)
        Me.Label10.TabIndex = 37
        Me.Label10.Text = "Role"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CbRole
        '
        Me.CbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CbRole.FormattingEnabled = True
        Me.CbRole.Location = New System.Drawing.Point(106, 147)
        Me.CbRole.Name = "CbRole"
        Me.CbRole.Size = New System.Drawing.Size(121, 21)
        Me.CbRole.TabIndex = 4
        '
        'txtLast
        '
        Me.txtLast.Location = New System.Drawing.Point(106, 121)
        Me.txtLast.Name = "txtLast"
        Me.txtLast.Size = New System.Drawing.Size(176, 20)
        Me.txtLast.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(31, 124)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Last Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFirst
        '
        Me.txtFirst.Location = New System.Drawing.Point(106, 92)
        Me.txtFirst.Name = "txtFirst"
        Me.txtFirst.Size = New System.Drawing.Size(176, 20)
        Me.txtFirst.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(31, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "First Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CbStatus
        '
        Me.CbStatus.AutoSize = True
        Me.CbStatus.Location = New System.Drawing.Point(106, 183)
        Me.CbStatus.Name = "CbStatus"
        Me.CbStatus.Size = New System.Drawing.Size(62, 17)
        Me.CbStatus.TabIndex = 5
        Me.CbStatus.Text = "Status"
        Me.CbStatus.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(106, 65)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(176, 20)
        Me.txtPassword.TabIndex = 1
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(37, 65)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 13)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Password"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(106, 33)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(176, 20)
        Me.txtUser.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(35, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Username"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlProjectsTitle
        '
        Me.pnlProjectsTitle.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlProjectsTitle.BackgroundImage = CType(resources.GetObject("pnlProjectsTitle.BackgroundImage"), System.Drawing.Image)
        Me.pnlProjectsTitle.Controls.Add(Me.Label4)
        Me.pnlProjectsTitle.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlProjectsTitle.Location = New System.Drawing.Point(0, 0)
        Me.pnlProjectsTitle.Name = "pnlProjectsTitle"
        Me.pnlProjectsTitle.Size = New System.Drawing.Size(428, 30)
        Me.pnlProjectsTitle.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 19)
        Me.Label4.TabIndex = 0
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'F_User
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(428, 331)
        Me.Controls.Add(Me.pnlProjectsTitle)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.GbDetail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "F_User"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add/Edit User"
        Me.GbDetail.ResumeLayout(False)
        Me.GbDetail.PerformLayout()
        Me.pnlProjectsTitle.ResumeLayout(False)
        Me.pnlProjectsTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GbDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CbStatus As System.Windows.Forms.CheckBox
    Friend WithEvents txtLast As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFirst As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CbRole As System.Windows.Forms.ComboBox
    Friend WithEvents pnlProjectsTitle As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
