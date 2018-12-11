<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_Transaction
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DgView = New System.Windows.Forms.DataGridView()
        Me.txtDibayar = New System.Windows.Forms.TextBox()
        Me.BTNTutup = New System.Windows.Forms.Button()
        Me.BTNBatal = New System.Windows.Forms.Button()
        Me.BTNSimpan = New System.Windows.Forms.Button()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Item = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtKembali = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Faktur = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Jam = New System.Windows.Forms.Label()
        Me.txtTanggal = New System.Windows.Forms.TextBox()
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'DgView
        '
        Me.DgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgView.Location = New System.Drawing.Point(12, 58)
        Me.DgView.Name = "DgView"
        Me.DgView.Size = New System.Drawing.Size(572, 227)
        Me.DgView.TabIndex = 19
        '
        'txtDibayar
        '
        Me.txtDibayar.Location = New System.Drawing.Point(416, 340)
        Me.txtDibayar.Name = "txtDibayar"
        Me.txtDibayar.Size = New System.Drawing.Size(168, 20)
        Me.txtDibayar.TabIndex = 35
        Me.txtDibayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BTNTutup
        '
        Me.BTNTutup.Location = New System.Drawing.Point(174, 399)
        Me.BTNTutup.Name = "BTNTutup"
        Me.BTNTutup.Size = New System.Drawing.Size(75, 25)
        Me.BTNTutup.TabIndex = 34
        Me.BTNTutup.Text = "Tutup"
        Me.BTNTutup.UseVisualStyleBackColor = True
        '
        'BTNBatal
        '
        Me.BTNBatal.Location = New System.Drawing.Point(93, 399)
        Me.BTNBatal.Name = "BTNBatal"
        Me.BTNBatal.Size = New System.Drawing.Size(75, 25)
        Me.BTNBatal.TabIndex = 33
        Me.BTNBatal.Text = "Batal"
        Me.BTNBatal.UseVisualStyleBackColor = True
        '
        'BTNSimpan
        '
        Me.BTNSimpan.Location = New System.Drawing.Point(12, 399)
        Me.BTNSimpan.Name = "BTNSimpan"
        Me.BTNSimpan.Size = New System.Drawing.Size(75, 25)
        Me.BTNSimpan.TabIndex = 32
        Me.BTNSimpan.Text = "Simpan"
        Me.BTNSimpan.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.Location = New System.Drawing.Point(207, 317)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 20)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Item"
        '
        'Item
        '
        Me.Item.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Item.Location = New System.Drawing.Point(265, 317)
        Me.Item.Name = "Item"
        Me.Item.Size = New System.Drawing.Size(76, 20)
        Me.Item.TabIndex = 30
        Me.Item.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Location = New System.Drawing.Point(356, 317)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(54, 20)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Total"
        '
        'txtTotal
        '
        Me.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtTotal.Location = New System.Drawing.Point(416, 317)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Size = New System.Drawing.Size(168, 20)
        Me.txtTotal.TabIndex = 28
        Me.txtTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Location = New System.Drawing.Point(356, 342)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 20)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Dibayar"
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Location = New System.Drawing.Point(356, 363)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 20)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Kembali"
        '
        'txtKembali
        '
        Me.txtKembali.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.txtKembali.Location = New System.Drawing.Point(416, 363)
        Me.txtKembali.Name = "txtKembali"
        Me.txtKembali.Size = New System.Drawing.Size(168, 20)
        Me.txtKembali.TabIndex = 25
        Me.txtKembali.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(169, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Date"
        '
        'Faktur
        '
        Me.Faktur.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Faktur.Location = New System.Drawing.Point(63, 20)
        Me.Faktur.Name = "Faktur"
        Me.Faktur.Size = New System.Drawing.Size(100, 20)
        Me.Faktur.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 20)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Faktur"
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Location = New System.Drawing.Point(438, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 20)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Jam"
        '
        'Jam
        '
        Me.Jam.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Jam.Location = New System.Drawing.Point(484, 20)
        Me.Jam.Name = "Jam"
        Me.Jam.Size = New System.Drawing.Size(100, 20)
        Me.Jam.TabIndex = 24
        '
        'txtTanggal
        '
        Me.txtTanggal.Location = New System.Drawing.Point(232, 18)
        Me.txtTanggal.Name = "txtTanggal"
        Me.txtTanggal.Size = New System.Drawing.Size(100, 20)
        Me.txtTanggal.TabIndex = 36
        '
        'F_Transaction
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(601, 447)
        Me.Controls.Add(Me.txtTanggal)
        Me.Controls.Add(Me.DgView)
        Me.Controls.Add(Me.txtDibayar)
        Me.Controls.Add(Me.BTNTutup)
        Me.Controls.Add(Me.BTNBatal)
        Me.Controls.Add(Me.BTNSimpan)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Item)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtKembali)
        Me.Controls.Add(Me.Jam)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Faktur)
        Me.Controls.Add(Me.Label1)
        Me.Name = "F_Transaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Penjualan"
        CType(Me.DgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents DgView As System.Windows.Forms.DataGridView
    Friend WithEvents txtDibayar As System.Windows.Forms.TextBox
    Friend WithEvents BTNTutup As System.Windows.Forms.Button
    Friend WithEvents BTNBatal As System.Windows.Forms.Button
    Friend WithEvents BTNSimpan As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Item As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotal As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtKembali As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Faktur As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Jam As System.Windows.Forms.Label
    Friend WithEvents txtTanggal As System.Windows.Forms.TextBox
End Class
