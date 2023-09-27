Public Module BaseDBController
    Private _connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Public ReadOnly Property ConnectionString As String
        Get
            Return _connectionString
        End Get
    End Property
End Module
