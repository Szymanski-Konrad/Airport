using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport.Model
{
    public class Flight
    {
        //UPGRADE: Mozna dodac jeszcze pojemnosc lotu i wtedy sprawdzac przy rezerwacji, czy sa jeszcze wolne miejsca.
        public int id { get; set; }
        public int idConnection { get; set; }
        public int idPlane { get; set; }
        public DateTime dateDeparture { get; set; }
        public DateTime dateArrival { get; set; }

        public override string ToString()
        {

            return $"Połączenie: {NHiberControl.LoadConnectionsToList().Single(x=>x.id==idConnection).Name}.\tOdlot: {dateDeparture}.\tPrzylot: {dateArrival}.";
        }
    }
}
