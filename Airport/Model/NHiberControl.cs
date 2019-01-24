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
    }
}
