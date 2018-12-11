Public Class F_Internal

#Region "Deklarasi"
    Protected AccessInternal As New AccessData.AccessInternal
    Dim filenaming As String
    Dim columns As String() = {}
#End Region

#Region "Process"

    Private Function No() As String
        Dim InternalList As New List(Of Entity.Internal)

        KPModule.FillListWithoutParam(InternalList, columns, "usp_SelectIntTop1", _
                                                         GetType(Entity.Internal))
        If InternalList.Count = 0 Then
            txtID.Text = "P0001"
        Else
            txtID.Text = "P" & Format(Val(CInt(Microsoft.VisualBasic.Right(InternalList.First.No, _
                               InternalList.First.No.Length - 1)) + 1), "0000")

        End If
        Return txtID.Text

    End Function

    Private Sub Clear()
        Dim C As Control
        Dim T As TextBox

        For Each C In Me.GbDetail.Controls
            If TypeOf C Is TextBox Then
                T = CType(C, TextBox)
                If UCase(T.Name) <> UCase("txtID") Then
                    T.Text = ""
                End If

            End If
        Next
        txtID.Text = ""
        txtTunai.Text = ""
        txtKeterangan.Text = ""
        DtDate.Text = Now
    End Sub

    Private Sub ViewInternal()

        Dim InternalList As New List(Of Entity.Internal)
        Dim Coltype As System.Data.OleDb.OleDbType() = {System.Data.OleDb.OleDbType.VarChar}
        Dim FieldName As String() = {"@No"}
        Dim Size As Integer() = {8}
        Dim Value As String() = {txtID.Text}

        KPModule.FillListWithParam(InternalList, columns, "usp_selectIntbyNo", _
                                                         GetType(Entity.Internal), FieldName, _
                                                         Coltype, Size, Value)

        txtID.Text = InternalList.First.No
        DtDate.Text = InternalList.First.Tanggal
        txtTunai.Text = InternalList.First.Tunai
        txtKeterangan.Text = InternalList.First.Keterangan

    End Sub

#End Region

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Operate = "Add" Then
            Clear()
            Me.Close()
        Else
            Operate = Nothing
            Me.Close()
        End If
    End Sub

    Private Sub F_Customer_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Operate = Nothing
    End Sub

    Private Sub F_Customer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            If Operate = "Add" Then
                No()
                txtTunai.Focus()
            Else
                ViewInternal()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "KP")
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtTunai.Text = "" Then
            MsgBox("Masukan Tunai")
            Exit Sub
        ElseIf txtKeterangan.Text = "" Then
            MsgBox("Masukan Keterangan")
            Exit Sub
        End If
        Try
            Dim internal As New Entity.Internal With {.No = txtID.Text, .Tanggal = DtDate.Text,
            .Tunai = txtTunai.Text, .Keterangan = txtKeterangan.Text}

            Dim mYes_No As String = MsgBox("Apakah kamu ingin menyimpan data ?", vbYesNo, "KP")
            If mYes_No = vbYes Then
                If Operate = "Add" Then
                    AccessInternal.InternalInsert(internal)
                    Clear()
                    No()
                Else
                    AccessInternal.InternalUpdate(internal)
                    MsgBox("Update Selesai", MsgBoxStyle.Information, "KP")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "KP")
        End Try
    End Sub

    Private Sub txtTunai_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTunai.KeyPress
        Try
            If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
                e.Handled() = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class