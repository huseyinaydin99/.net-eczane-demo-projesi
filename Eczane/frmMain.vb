Public Class frmMain

   

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        For i = 1 To CInt(txtFormCount.Text)
            Dim frm As New Form1
            frm.MdiParent = Me
            frm.Text = "Eczane " + i.ToString()
            frm.Show()
        Next
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class