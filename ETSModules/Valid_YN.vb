Imports System.Configuration
Imports ETS.Common.Module1
Imports PS.Common

Public Class YNValuePair
    Public ValidData As String
    Sub New(ByVal newValidData As String)
        ValidData = newValidData
    End Sub

End Class


Public Class Valid_YN
    'this looks up the table, column, data and returns Y or N
    'we first look in the collection so that we are not going to the server for repeat requests
    'incoming variables will be concated with a * sepearating them to make a key and the value will be Y or N

    Private strYNCollection As Collection
    Private strYNKey As String
    Private strYNTable As String
    Private strYNColumn As String
    Private strYNValue As String
    Private strValidYN As String

    Public Sub New()
        'when and how do i do this - when program starts
        '   YNCollection = strYNCollection.New(Nothing, Nothing)
        ValidYN = "N"

    End Sub

    Public Property YNTable() As String
        Get
            Return strYNTable
        End Get
        Set(ByVal value As String)
            strYNTable = value
        End Set
    End Property

    Public Property YNColumn() As String
        Get
            Return strYNColumn
        End Get
        Set(ByVal value As String)
            strYNColumn = value
        End Set
    End Property

    Public Property YNValue() As String
        Get
            Return strYNValue
        End Get
        Set(ByVal value As String)
            strYNValue = value
        End Set
    End Property

    Public Property ValidYN() As String
        Get
            Return strValidYN
        End Get
        Set(ByVal value As String)
            strValidYN = value
        End Set
    End Property


    Public Function YNValidate() As String
        'first check the collection and then do a sql and add to collection
        strYNKey = strYNTable & "*" & strYNColumn & "*" & strYNValue
        If strYNCollection.Contains(strYNKey) Then
            strValidYN = CStr(strYNCollection.Item(strYNKey))
        Else
            Using db As Database = New Database(top_data_path)
                Dim sql As String = "Select Count ('" & strYNColumn & "') "
                sql = sql & " as validnum from '" & strYNTable & "' where '"
                sql = sql & strYNColumn & "' = '" & strYNValue & " '"
                Dim validnum As String
                validnum = db.ExecuteQuery(sql).ToString
                If Val(validnum) = 0 Then
                    strValidYN = "N"
                Else
                    strValidYN = "Y"
                End If

                strYNCollection.Add(New YNValuePair(strYNKey), strValidYN)
            End Using

        End If

        Return ValidYN
    End Function

End Class

