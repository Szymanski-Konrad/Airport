using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public static class FirmNHiberControl
    {
        public static void BuyPlane(PlaneMarket plane)
        {
            Fleet newPlane = new Fleet();
            newPlane.capacityGasTank = plane.capacityGasTank;
            newPlane.idPlane = plane.id;
            newPlane.planeCondition = 100;

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(newPlane);
                    transaction.Commit();
                }
            }
        }

        public static void SoldPlane(Fleet plane)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(plane);
                    transaction.Commit();
                }
            }
        }

        public static void EditPlane(Fleet plane)
        {

        }

        public static void BuyAirport(Airport airport)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(airport);
                    transaction.Commit();
                }
            }
        }

        public static void BuyFuel(Warehouse warehouse)
        {
            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(warehouse);
                    transaction.Commit();
                }
             }
        }

        public static List<Fleet> GetFleets()
        {
            List<Fleet> list = new List<Fleet>();

            using (ISession session = Session.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    list = session.Query<Fleet>().ToList();
                }
            }

            return list;
        }
    }
}
