Imports System.Threading
Public Class Form1

    Dim dsBarcodes As New DataSet


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.CheckForIllegalCrossThreadCalls = False
        dsBarcodes = data.fill(CommandType.Text, "SELECT * FROM BARCODES")

        trd = New Thread(AddressOf ThreadTask)
        trd.IsBackground = True
        trd.Start()
    End Sub

    Private trd As Thread
    Dim data As New clsData
    Dim count As Integer = 0
    Dim sum As Double = 0

    Private Sub ThreadTask()

        For i = 0 To 1000
            Try

                System.Threading.Thread.Sleep(77)
                lblMsg.Visible = True

                Update()
                Dim startTime As DateTime = Now

                PictureBox1.Visible = False
                Update()
                System.Threading.Thread.Sleep(1)
                PictureBox1.Visible = True
                Update()
                Dim rnd As New Random()

                Dim idx As Integer = rnd.Next(1, 1000)

                Dim qrCode As String = dsBarcodes.Tables(0).Rows(idx).Item("BARCODE").ToString()
                Dim sql As String = "EXEC GETDRUGINFO '" + qrCode + "'"
                Dim ds As New DataSet
                ds = data.fill(CommandType.Text, sql)
                lblBarcode.Text = ds.Tables(0).Rows(0).Item("BARCODE").ToString
                lblDrugName.Text = ds.Tables(0).Rows(0).Item("DRUGNAME").ToString
                lblPrice.Text = ds.Tables(0).Rows(0).Item("PRICE").ToString + " TL"
                '  lblProducer.Text = ds.Tables(0).Rows(0).Item("PRODUCER").ToString
                Dim endTime As DateTime = Now
                Dim duration As TimeSpan = endTime - startTime


                lblTime.Text = "Süre:" + duration.ToString("mm':'ss':'ff")
                lblMsg.Visible = False

                Update()
                count = count + 1
                sum = sum + (duration.Seconds + duration.Milliseconds / 1000)

                Dim avg As Double
                avg = sum / count
                lblAvg.Text = "Ortalama süre:" + Math.Round(avg, 4).ToString
                lblCount.Text = "Okutulan barkod sayısı:" + count.ToString
            Catch ex As Exception

            End Try
        Next


     
    End Sub
End Class
