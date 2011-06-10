using System.Data.SqlClient;

namespace DotNetRocks.FluentSPRibbon
{
    public class SampleClass
    {
        public void Store()
        {
            using (SqlConnection con = new SqlConnection(""))
            {
                con.Open();
            }
        }
    }
}