using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Airport.Model;
using System.Diagnostics;

namespace Airport.Model
{
    public static class NHiberControl
    {
        public static void InsertFirm()
        {
            Firm firm = new Firm();
            firm.account = 10000;
            firm.name = "Firma na 5";

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(firm);
                    transaction.Commit();
                }
            }
        }

        public static void RefreshTables()
        {
            using(ISession session = Session.OpenSession())
            {

            }
        }

        public static void InsertClient(string name, string surname, bool isMale, int milesTraveled, int age)
        {
            Debug.Print($"NHiberControl method InsertClient called.");
            Client client = new Client();
            client.Name = name;
            client.Surname = surname;
            client.isMale = isMale;
            client.milesTraveled = milesTraveled;
            client.age = age;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(client);
                    transaction.Commit();
                }
            }
            Debug.Print("Insert client to database.");
        }

        public static void LoadClients()
        {
            Debug.Print($"NHiberControl method LoadClients called.");
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Client order by Name asc");
                if (query != null)
                {
                    IList<Client> clients = query.List<Client>();
                    Debug.Print("znalezieni klienci: " + clients.Count.ToString());
                    foreach (Client client in clients)
                    {
                        Debug.Print(client.Surname + " " + client.Name);
                    }
                }
                else
                {
                    Debug.Print("Query is null.");
                }
            }
        }

        public static List<Client> LoadClientsToList()
        {
            Debug.Print($"NHiberControl method LoadClientsList called.");
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Client order by Name asc");
                if (query != null)
                {
                    IList<Client> clients = query.List<Client>();
                    Debug.Print("Clients found: " + clients.Count.ToString());
                    return (List<Client>)clients;
                }
                else
                {
                    Debug.Print("Query is null.");
                    return new List<Client>();
                }
            }
        }

        public static void LoadGames()
        {
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Product order by Name asc");
                IList<Product> foundGames = query.List<Product>();
                MessageBox.Show("znalezione gry:" + foundGames.Count.ToString());
                foreach (Product game in foundGames)
                {
                    MessageBox.Show(game.Say());
                }
            }
        }

        public static void SaveGame()
        {
            //Product product = new Product();
            //product.Category = "Nowy";
            //product.Discounted = true;
            //product.Name = "Produkt";

            Firm product = new Firm();
            product.id = 0;
            product.account = 100;
            product.name = "Dupa";

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(product);
                    transaction.Commit();
                }

                MessageBox.Show("Saved product to database");
            }
        }

        public static void SaveClient()
        {
            Debug.Print($"NHiberControl method SaveClient called.");
            Client client = new Client();
            client.Name = "Joy";
            client.Surname = "En";
            client.isMale = false;
            client.milesTraveled = 0;
            client.age = 18;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(client);
                    transaction.Commit();
                    Debug.Print("Saved client to database.");
                }
            }
        }
    }
}
