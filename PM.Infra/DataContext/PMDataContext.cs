using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace PM.Infra.DataContext
{
    public class PMDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public PMDataContext()
        {
            Connection = new SqlConnection("Server=DESKTOP-VI9V6I4;Database=PastureManagement;Trusted_Connection=True;");
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
