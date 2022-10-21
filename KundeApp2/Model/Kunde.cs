using System;
namespace KundeApp2.Model
{
     public class Kunde
     {
        public int Id { get; set; }  // med Id som variabel blir dette en autoincrement i databasen (pr. default).
        public string Symbol { get; set; }
        public double Open { get; set; }
        public double High { get; set; }

        public double  Low{ get; set; }

        public double Price { get; set; }
        public double Volume { get; set; }
        
       
     }
}
