using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Airport.Model;

namespace Airport.Model
{
    public static class NHiberControl
    {
        public static void InsertFirm()
        {
            Firm firm = new Firm();
            firm.Account = 10000;
            firm.Name = "Firma na 5";

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(firm);
                    transaction.Commit();
                }
            }
        }

        public static void LoadClients()
        {
            using (ISession session = Session.OpenSession())
            {
                IQuery query = session.CreateQuery("from Client order by Name asc");
                if (query != null)
                {
                    IList<Client> clients = query.List<Client>();
                    MessageBox.Show("znalezieni klienci: " + clients.Count.ToString());
                    foreach (Client client in clients)
                    {
                        MessageBox.Show(client.Name + ", " + client.Surname);

                    }
                }
                else
                {
                    MessageBox.Show("query is null");
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
            Product product = new Product();
            product.Category = "Nowy";
            product.Discounted = true;
            product.Name = "Produkt";

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
                }

                MessageBox.Show("Saved client to database");
            }
        }
    }
}
