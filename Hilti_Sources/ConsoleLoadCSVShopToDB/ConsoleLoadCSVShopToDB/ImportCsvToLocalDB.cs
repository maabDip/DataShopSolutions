using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LumenWorks.Framework.IO.Csv;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Configuration;

namespace ConsoleLoadCSVShopToDB
{
  public class ImportService
    {
       public ImportService()
        {

        }

        public void ImportCsvToLocalDB(string server, string dataBase, string filePath)
        {
            //SqlConnection conn = new SqlConnection(@"Data Source=LFR012236\LFR012236; Initial Catalog=HiltiLocalDB; Integrated Security=True");
            SqlConnection conn = null;
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[10]
                    {
                        new DataColumn("Id_Shop", typeof(int)),
                        new DataColumn("CreatedOn", typeof(string)),
                        new DataColumn("ShopId", typeof(int)),
                        new DataColumn("ShopName", typeof(string)),
                        new DataColumn("CustomerId", typeof(int)),
                        new DataColumn("CustomerName", typeof(string)),
                        new DataColumn("ItemId", typeof(int)),
                        new DataColumn("ItemName", typeof(string)),
                        new DataColumn("Quantity", typeof(int)),
                        new DataColumn("Price", typeof(string))
                    });

                //var path = Path.GetDirectoryName(@"../../Data/Sales.csv");
                //string csvData = File.ReadAllText(@"C:\Users\asizmoha\source\repos\ConsoleLoadCSVShopToDB\Data\Sales.csv");
                //string csvData = File.ReadAllText(ConfigurationManager.AppSettings["csvFilePath"]);
                string csvData = File.ReadAllText(filePath);

                var j = 0;
                foreach(var row in csvData.Split('\n'))
                {
                    
                    if(!string.IsNullOrEmpty(row) && j>0)
                    {
                        dt.Rows.Add();
                        int i = 1;
                        dt.Rows[dt.Rows.Count - 1][0] = j+1;//cellulle pour la clé de la table
                        foreach (string cell in row.Split(';'))
                        {
                            if(!string.IsNullOrEmpty(cell))
                            {
                                dt.Rows[dt.Rows.Count - 1][i] = cell;
                                i++;
                            }
                        }
                    }
                    j++;
                }

                using(/*var */conn = new SqlConnection(@"Data Source="+server/*LFR012236\LFR012236*/ +";Initial Catalog="+dataBase+/*HiltocalDB*/"; Integrated Security=True"))
                //using (/*var */conn = new SqlConnection(ConfigurationManager.AppSettings["connexionStrings"]))
                {
                    using(SqlBulkCopy cpy = new SqlBulkCopy(conn))
                    {
                        cpy.DestinationTableName = "Shop";
                        conn.Open();
                        cpy.WriteToServer(dt);
                        conn.Close();
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        public void Run(string server, string dataBase, string filePath)
        {
            ImportCsvToLocalDB(server, dataBase, filePath);
        }
    }
}
