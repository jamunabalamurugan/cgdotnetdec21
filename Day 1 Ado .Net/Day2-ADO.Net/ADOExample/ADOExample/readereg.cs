using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ADOExample
{
    class readereg
    {
        public static void Main()
        {
            SqlConnection _SqlConnection = new SqlConnection("Data source=MSBEEYS\\HBSQLEXPRESS;Initial Catalog=northwind;user id=sa;password=newuser123#");
            string _SQL=@"Select * from customers";
            readereg obj=new readereg();
            Dictionary<string, object> dobj=obj.GetSqlDataReaderFirstRow(ref _SqlConnection,_SQL);
            foreach (var de in dobj)
            {
                Console.WriteLine(de);
            }
            Console.ReadKey();
        }
        public Dictionary<string, object> GetSqlDataReaderFirstRow(ref SqlConnection _SqlConnection,
	                string _SQL)
{
	    // temporary dictionary object array to hold SqlDataReader first row
	    Dictionary<string, object> _FirstRow = new Dictionary<string, object>();
	 
	    // Set temporary variable to create data reader
	   SqlDataReader _SqlDataReader = null;
 
	    // lets run the given SQL statement and get the data to SqlDataReader
	    try
	    {
            _SqlConnection.Open();
	        // Pass the connection to a command object
	       SqlCommand _SqlCommand =
	                new SqlCommand(_SQL, _SqlConnection);
	 
	        // get query results
	        _SqlDataReader = _SqlCommand.ExecuteReader();
	 
	    }
	    catch (Exception _Exception)
	    {
	        // Error occurred while trying to execute reader
	        // send error message to console (change below line to customize error handling)
        Console.WriteLine(_Exception.Message);
	 
	        // failed SQL execution, lets return null
        return null;
	    }
	 
    // SQL successfully executed, lets return the SqlDataReader First Data Row
	    if (_SqlDataReader != null && _SqlDataReader.HasRows && _SqlDataReader.Read())
	    {
	        // put the first data row in a temporary object array before close SqlDataReader
	        for (int _Column = 0; _Column <= _SqlDataReader.FieldCount - 1; _Column++)
	        {
	            try
	            {
	                // Add each colum to dictionary
	                _FirstRow.Add(_SqlDataReader.GetName(_Column), _SqlDataReader[_Column]);
	            }
	            catch { }
	        }
	 
	        // close SqlDataReader
	        _SqlDataReader.Close();
	        _SqlDataReader.Dispose();
	 
	        return _FirstRow;
            
	    }
	    else
	    {
	        if (_SqlDataReader != null)
	        {
	            // close SqlDataReader
	            _SqlDataReader.Close();
	            _SqlDataReader.Dispose();
	        }
	 
	        // no data found, return null
	        return null;
	    }
	}
    }
}


