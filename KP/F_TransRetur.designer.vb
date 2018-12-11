<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_TransRetur
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(F_TransRetur))
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TTanggal = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TKembali = New System.Windows.Forms.TextBox()
        Me.TDibayar = New System.Windows.Forms.TextBox()
        Me.TTotal = New System.Windows.Forms.TextBox()
        Me.TItem = New System.Windows.Forms.TextBox()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CmdTutup = New System.Windows.Forms.Button()
        Me.TItemretur = New System.Windows.Forms.TextBox()
        Me.TTotalRetur = New System.Windows.Forms.TextBox()
        Me.CmdBatal = New System.Windows.Forms.Button()
        Me.TDibayarRetur = New System.Windows.Forms.TextBox()
        Me.TKembaliRetur = New System.Windows.Forms.TextBox()
        Me.TSubtotal = New System.Windows.Forms.TextBox()
        Me.TJumlah = New System.Windows.Forms.TextBox()
        Me.THarga = New System.Windows.Forms.TextBox()
        Me.TNama = New System.Windows.Forms.TextBox()
        Me.TKode = New System.Windows.Forms.TextBox()
        Me.CmdSimpan = New System.Windows.Forms.Button()
        Me.DGV1 = New System.Windows.Forms.DataGridView()
        Me.TFaktur = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TTanggalRetur = New System.Windows.Forms.TextBox()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(94, 13)
        Me.Label7.TabIndex = 60
        Me.Label7.Text = "Transaction No"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 13)
        Me.Label5.TabIndex = 57
        Me.Label5.Text = "Tanggal"
        '
        'TTanggal
        '
        Me.TTanggal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTanggal.Enabled = False
        Me.TTanggal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTanggal.Location = New System.Drawing.Point(70, 191)
        Me.TTanggal.Name = "TTanggal"
        Me.TTanggal.ReadOnly = True
        Me.TTanggal.Size = New System.Drawing.Size(100, 20)
        Me.TTanggal.TabIndex = 56
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(673, 246)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Kembali"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(673, 220)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Dibayar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(687, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 53
        Me.Label2.Text = "Total"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(544, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 52
        Me.Label1.Text = "Item"
        '
        'TKembali
        '
        Me.TKembali.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKembali.Enabled = False
        Me.TKembali.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKembali.Location = New System.Drawing.Point(729, 243)
        Me.TKembali.Name = "TKembali"
        Me.TKembali.ReadOnly = True
        Me.TKembali.Size = New System.Drawing.Size(111, 20)
        Me.TKembali.TabIndex = 51
        Me.TKembali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TDibayar
        '
        Me.TDibayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDibayar.Enabled = False
        Me.TDibayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDibayar.Location = New System.Drawing.Point(729, 217)
        Me.TDibayar.Name = "TDibayar"
        Me.TDibayar.ReadOnly = True
        Me.TDibayar.Size = New System.Drawing.Size(111, 20)
        Me.TDibayar.TabIndex = 48
        Me.TDibayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TTotal
        '
        Me.TTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTotal.Enabled = False
        Me.TTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTotal.Location = New System.Drawing.Point(729, 191)
        Me.TTotal.Name = "TTotal"
        Me.TTotal.ReadOnly = True
        Me.TTotal.Size = New System.Drawing.Size(111, 20)
        Me.TTotal.TabIndex = 50
        Me.TTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TItem
        '
        Me.TItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TItem.Enabled = False
        Me.TItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TItem.Location = New System.Drawing.Point(581, 191)
        Me.TItem.Name = "TItem"
        Me.TItem.ReadOnly = True
        Me.TItem.Size = New System.Drawing.Size(56, 20)
        Me.TItem.TabIndex = 49
        '
        'DGV
        '
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(8, 34)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(832, 151)
        Me.DGV.TabIndex = 47
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(687, 280)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 13)
        Me.Label11.TabIndex = 83
        Me.Label11.Text = "Total"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(529, 281)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 82
        Me.Label10.Text = "Jumlah"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(309, 281)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 81
        Me.Label9.Text = "Harga"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 281)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 80
        Me.Label8.Text = "Stock Name"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(673, 511)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 13)
        Me.Label12.TabIndex = 78
        Me.Label12.Text = "Kembali"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(674, 485)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 77
        Me.Label13.Text = "Dibayar"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(687, 459)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 76
        Me.Label14.Text = "Total"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(544, 459)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 13)
        Me.Label15.TabIndex = 75
        Me.Label15.Text = "Item"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(34, 248)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "Stock ID"
        '
        'CmdTutup
        '
        Me.CmdTutup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdTutup.Location = New System.Drawing.Point(178, 462)
        Me.CmdTutup.Name = "CmdTutup"
        Me.CmdTutup.Size = New System.Drawing.Size(75, 36)
        Me.CmdTutup.TabIndex = 74
        Me.CmdTutup.Text = "Close"
        Me.CmdTutup.UseVisualStyleBackColor = True
        '
        'TItemretur
        '
        Me.TItemretur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TItemretur.Enabled = False
        Me.TItemretur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TItemretur.Location = New System.Drawing.Point(581, 456)
        Me.TItemretur.Name = "TItemretur"
        Me.TItemretur.ReadOnly = True
        Me.TItemretur.Size = New System.Drawing.Size(56, 20)
        Me.TItemretur.TabIndex = 73
        Me.TItemretur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TTotalRetur
        '
        Me.TTotalRetur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTotalRetur.Enabled = False
        Me.TTotalRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTotalRetur.Location = New System.Drawing.Point(729, 456)
        Me.TTotalRetur.Name = "TTotalRetur"
        Me.TTotalRetur.ReadOnly = True
        Me.TTotalRetur.Size = New System.Drawing.Size(111, 20)
        Me.TTotalRetur.TabIndex = 66
        Me.TTotalRetur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmdBatal
        '
        Me.CmdBatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBatal.Location = New System.Drawing.Point(97, 462)
        Me.CmdBatal.Name = "CmdBatal"
        Me.CmdBatal.Size = New System.Drawing.Size(75, 36)
        Me.CmdBatal.TabIndex = 72
        Me.CmdBatal.Text = "Cancel"
        Me.CmdBatal.UseVisualStyleBackColor = True
        '
        'TDibayarRetur
        '
        Me.TDibayarRetur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TDibayarRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TDibayarRetur.Location = New System.Drawing.Point(729, 482)
        Me.TDibayarRetur.Name = "TDibayarRetur"
        Me.TDibayarRetur.Size = New System.Drawing.Size(111, 20)
        Me.TDibayarRetur.TabIndex = 6
        '
        'TKembaliRetur
        '
        Me.TKembaliRetur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKembaliRetur.Enabled = False
        Me.TKembaliRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKembaliRetur.Location = New System.Drawing.Point(729, 508)
        Me.TKembaliRetur.Name = "TKembaliRetur"
        Me.TKembaliRetur.ReadOnly = True
        Me.TKembaliRetur.Size = New System.Drawing.Size(111, 20)
        Me.TKembaliRetur.TabIndex = 70
        '
        'TSubtotal
        '
        Me.TSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TSubtotal.Enabled = False
        Me.TSubtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TSubtotal.Location = New System.Drawing.Point(729, 278)
        Me.TSubtotal.Name = "TSubtotal"
        Me.TSubtotal.ReadOnly = True
        Me.TSubtotal.Size = New System.Drawing.Size(111, 20)
        Me.TSubtotal.TabIndex = 5
        '
        'TJumlah
        '
        Me.TJumlah.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TJumlah.Location = New System.Drawing.Point(581, 278)
        Me.TJumlah.Name = "TJumlah"
        Me.TJumlah.Size = New System.Drawing.Size(56, 20)
        Me.TJumlah.TabIndex = 4
        '
        'THarga
        '
        Me.THarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.THarga.Enabled = False
        Me.THarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.THarga.Location = New System.Drawing.Point(356, 278)
        Me.THarga.Name = "THarga"
        Me.THarga.ReadOnly = True
        Me.THarga.Size = New System.Drawing.Size(100, 20)
        Me.THarga.TabIndex = 3
        '
        'TNama
        '
        Me.TNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TNama.Location = New System.Drawing.Point(97, 278)
        Me.TNama.Name = "TNama"
        Me.TNama.Size = New System.Drawing.Size(135, 20)
        Me.TNama.TabIndex = 2
        '
        'TKode
        '
        Me.TKode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TKode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TKode.Location = New System.Drawing.Point(97, 246)
        Me.TKode.Name = "TKode"
        Me.TKode.Size = New System.Drawing.Size(135, 20)
        Me.TKode.TabIndex = 1
        '
        'CmdSimpan
        '
        Me.CmdSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdSimpan.Location = New System.Drawing.Point(16, 462)
        Me.CmdSimpan.Name = "CmdSimpan"
        Me.CmdSimpan.Size = New System.Drawing.Size(75, 36)
        Me.CmdSimpan.TabIndex = 69
        Me.CmdSimpan.Text = "Save"
        Me.CmdSimpan.UseVisualStyleBackColor = True
        '
        'DGV1
        '
        Me.DGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV1.Location = New System.Drawing.Point(16, 304)
        Me.DGV1.Name = "DGV1"
        Me.DGV1.Size = New System.Drawing.Size(824, 146)
        Me.DGV1.TabIndex = 68
        '
        'TFaktur
        '
        Me.TFaktur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TFaktur.Location = New System.Drawing.Point(111, 8)
        Me.TFaktur.Name = "TFaktur"
        Me.TFaktur.Size = New System.Drawing.Size(100, 20)
        Me.TFaktur.TabIndex = 0
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(681, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(53, 13)
        Me.Label17.TabIndex = 85
        Me.Label17.Text = "Tanggal"
        '
        'TTanggalRetur
        '
        Me.TTanggalRetur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TTanggalRetur.Enabled = False
        Me.TTanggalRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TTanggalRetur.Location = New System.Drawing.Point(740, 8)
        Me.TTanggalRetur.Name = "TTanggalRetur"
        Me.TTanggalRetur.ReadOnly = True
        Me.TTanggalRetur.Size = New System.Drawing.Size(100, 20)
        Me.TTanggalRetur.TabIndex = 84
        '
        'F_TransRetur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(852, 544)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TTanggalRetur)
        Me.Controls.Add(Me.TFaktur)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.CmdTutup)
        Me.Controls.Add(Me.TItemretur)
        Me.Controls.Add(Me.TTotalRetur)
        Me.Controls.Add(Me.CmdBatal)
        Me.Controls.Add(Me.TDibayarRetur)
        Me.Controls.Add(Me.TKembaliRetur)
        Me.Controls.Add(Me.TSubtotal)
        Me.Controls.Add(Me.TJumlah)
        Me.Controls.Add(Me.THarga)
        Me.Controls.Add(Me.TNama)
        Me.Controls.Add(Me.TKode)
        Me.Controls.Add(Me.CmdSimpan)
        Me.Controls.Add(Me.DGV1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TTanggal)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TKembali)
        Me.Controls.Add(Me.TDibayar)
        Me.Controls.Add(Me.TTotal)
        Me.Controls.Add(Me.TItem)
        Me.Controls.Add(Me.DGV)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "F_TransRetur"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Retur Transaction"
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TTanggal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TKembali As System.Windows.Forms.TextBox
    Friend WithEvents TDibayar As System.Windows.Forms.TextBox
    Friend WithEvents TTotal As System.Windows.Forms.TextBox
    Friend WithEvents TItem As System.Windows.Forms.TextBox
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CmdTutup As System.Windows.Forms.Button
    Friend WithEvents TItemretur As System.Windows.Forms.TextBox
    Friend WithEvents TTotalRetur As System.Windows.Forms.TextBox
    Friend WithEvents CmdBatal As System.Windows.Forms.Button
    Friend WithEvents TDibayarRetur As System.Windows.Forms.TextBox
    Friend WithEvents TKembaliRetur As System.Windows.Forms.TextBox
    Friend WithEvents TSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents TJumlah As System.Windows.Forms.TextBox
    Friend WithEvents THarga As System.Windows.Forms.TextBox
    Friend WithEvents TNama As System.Windows.Forms.TextBox
    Friend WithEvents TKode As System.Windows.Forms.TextBox
    Friend WithEvents CmdSimpan As System.Windows.Forms.Button
    Friend WithEvents DGV1 As System.Windows.Forms.DataGridView
    Friend WithEvents TFaktur As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TTanggalRetur As System.Windows.Forms.TextBox
End Class
