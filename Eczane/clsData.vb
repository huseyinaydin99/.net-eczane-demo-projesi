Imports System.Data
Imports System.Data.SqlClient
Public Class clsData

    Public cs As String = "DATA SOURCE=SQLEGITIM;INITIAL CATALOG=MEDICAL;UID=SA;PWD=Password1;"


    Public conn As New SqlConnection(cs)

    Public Function fill(ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray parameters() As SqlParameter) As DataSet
        Try
            Dim ds As New DataSet
            Dim cmd As New SqlCommand(commandText, conn)
            cmd.CommandType = commandType
            cmd.CommandTimeout = 200
            Dim i As Integer
            For i = 0 To parameters.Length - 1
                cmd.Parameters.Add(parameters(i))
            Next
            cmd.CommandTimeout = 10000
            Dim da As New SqlDataAdapter(cmd)
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub executeNonQuery(ByVal commandType As CommandType, ByVal commandText As String, ByVal ParamArray parameters() As SqlParameter)
        Try
            Dim conn As New SqlConnection(cs)
            Dim cmd As New SqlCommand(commandText, conn)
            cmd.CommandType = commandType
            cmd.CommandTimeout = 200
            Dim i As Integer
            For i = 0 To parameters.Length - 1
                cmd.Parameters.Add(parameters(i))
            Next
            cmd.CommandTimeout = 10000
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            cmd.Dispose()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Class
