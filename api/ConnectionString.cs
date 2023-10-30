using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace api
{
    public class ConnectionString
    {
        private string host {get; set;}
        private string database {get; set;}
        private string username {get; set;}
        private string port {get; set;}
        private string password {get; set;}
        public string cs {get; set;}
        public ConnectionString()
        {
            string host = "wcwimj6zu5aaddlj.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "pxbsx64s2mkji4i3";
            string username = "grm6m3wxnu16r0tz";
            string port = "3306";
            string password = "yminvgjfvj7dfnxe";

            cs = $@"server={host};user={username};database={database};port={port};password={password};";
        }
    }
}
