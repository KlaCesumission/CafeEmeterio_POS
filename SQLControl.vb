Imports System.Data.SqlClient

Public Class SQLControl
    Private DBCon As New SqlConnection("Server=(LocalDB)\CafeEmeterioDB;Database=CafePOS;Trusted_Connection=True")
    Private DBCmd As SqlCommand

    'DB Data
    Public DBDA As SqlDataAdapter
    Public DBDT As DataTable
    Public DBDS As DataSet


    ' QUERY PARAMETERS
    Public Params As New List(Of SqlParameter)

    ' QUERY STATISTICS
    Public RecordCount As Integer
    Public Exception As String

    Public CurrentBillNo As String


    ' ALLOW CONNECTION STRING OVERRIDE
    Public Sub New(ConnectionString As String)
        DBCon = New SqlConnection(ConnectionString)
    End Sub

    Sub New()
        ' TODO: Complete member initialization 
    End Sub

    ' EXECUTE QUERY SUB
    Public Sub ExecQuery(Query As String, Optional ReturnIdentity As Boolean = False)

        ' RESET QUERY STATS
        RecordCount = 0
        Exception = ""

        Try
            DBCon.Open()

            ' CREATE DB COMMAND
            DBCmd = New SqlCommand(Query, DBCon)

            ' LOAD PARAMS INTO DB COMMAND
            Params.ForEach(Sub(p) DBCmd.Parameters.Add(p))

            ' CLEAR PARAM LIST
            Params.Clear()

            ' EXECUTE COMMAND & FILL DATASET
            DBDT = New DataTable
            DBDS = New DataSet
            DBDA = New SqlDataAdapter(DBCmd)
            RecordCount = DBDA.Fill(DBDT)

            If ReturnIdentity = True Then
                Dim ReturnQuery As String = "SELECT @@IDENTITY as LastID; "
                DBCmd = New SqlCommand(ReturnQuery, DBCon)
                DBDT = New DataTable
                DBDA = New SqlDataAdapter(DBCmd)
                RecordCount = DBDA.Fill(DBDT)


            End If


        Catch ex As Exception
            Exception = "ExecQuery Error: " & vbNewLine & ex.Message

        Finally
            ' CLOSE CONNECTION
            If DBCon.State = ConnectionState.Open Then DBCon.Close()
        End Try

    End Sub

    ' ADD PARAMS
    Public Sub AddParam(Name As String, Value As Object)
        Dim NewParam As New SqlParameter(Name, Value)
        Params.Add(NewParam)
    End Sub

    ' ERROR CHECKING
    Public Function HasException(Optional Report As Boolean = False) As Boolean
        If String.IsNullOrEmpty(Exception) Then Return False
        If Report = True Then MsgBox(Exception, MsgBoxStyle.Critical, "Exception: ")
        Return True
    End Function

End Class