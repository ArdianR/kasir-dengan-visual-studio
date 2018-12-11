Imports System.Data.OleDb

Public Class R_TransReport
    Dim awal As String
    Dim akhir As String

    Private Sub btnHarian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHarian.Click
        Try

            CRV.ReportSource = "harian.rpt"
            CRV.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnMingguan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMingguan.Click
        Try

            CRV.ReportSource = "mingguan.rpt"
            CRV.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnBulanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBulanan.Click
        Try

            CRV.ReportSource = "Bulanan.rpt"
            CRV.RefreshReport()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub R_TransReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class