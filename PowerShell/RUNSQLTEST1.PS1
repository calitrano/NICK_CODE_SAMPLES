$SQLServer = “(LOCAL)”

$SQLDBName = “NICK_TEST”

#$SqlQuery = ‘EXEC [dbo].[usp_mystoredprocedure] ”’ + $parameter1 + ”’, ”’ + $parameter2 + ””

$SqlQuery = "SELECT TOP 1000 [Id]
      ,[TODAYS_DATE]
  FROM [NICK_TEST].[dbo].[NICK_DATE_TBL]"

$SqlConnection = New-Object System.Data.SqlClient.SqlConnection

$SqlConnection.ConnectionString = “Server=$SQLServer;Database=$SQLDBName;Integrated Security=True”

$SqlCmd = New-Object System.Data.SqlClient.SqlCommand

$SqlCmd.CommandText = $SqlQuery

$SqlCmd.Connection = $SqlConnection

$SqlAdapter = New-Object System.Data.SqlClient.SqlDataAdapter

$SqlAdapter.SelectCommand = $SqlCmd

$DataSet = New-Object System.Data.DataSet

$SqlAdapter.Fill($DataSet)

$SqlConnection.Close()

foreach ($row in $DataSet.Tables[0].Rows)

{

$Drive = $row[1].ToString().Trim()

$Threshold = $row[2].ToString()

$MountPoint = $row[3].ToString().Trim()

}