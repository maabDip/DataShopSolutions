using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleLoadCSVShopToDB
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("#### Start to load CSV to Local DB Hilti Shop\n");
            System.Console.WriteLine("la commande à executer doit contenir les arguments suivants:\n");
            System.Console.WriteLine("--server :  le nom du serveur source de données\n");
            System.Console.WriteLine("--dataBase :  le nom de la base de données\n");
            System.Console.WriteLine("--csv:  Fichier csv\n");


            if (args == null)
            {
                return;
            }
            if(args.Length < 6 )
            {
                System.Console.WriteLine("la commande à executer doit contenir les arguments suivants:\n");
                System.Console.WriteLine("--server :  le nom du serveur source de données\n");
                System.Console.WriteLine("--dataBase :  le nom de la base de données\n");
                System.Console.WriteLine("--csv :  Fichier csv\n");
                return;
            }
            //Valeur par défaut du PC local 
            string server = @"LFR012236\LFR012236";
            string dataBase = @"HiltiLocalDB";
            string filePath = @"C:\Users\asizmoha\source\repos\ConsoleLoadCSVShopToDB\Data\Sales.csv";

            for (var idx = 0; idx < args.Length-1; idx +=2)
            {
                switch(args[idx].ToLower())
                {
                    case "--server":
                        {

                            server = args[idx + 1];
                        }
                        break;
                    case "--dataBase":
                        {

                            dataBase = args[idx + 1];
                        }
                        break;
                    case "--csv":
                        {

                            filePath = args[idx + 1];
                        }
                        break;
                }
            }
            var importService = new ImportService();
            importService.Run(server, dataBase, filePath);
            Thread.Sleep(2000);
            System.Console.WriteLine("Import OK vers la base Sql\n");

        }
    }
}
