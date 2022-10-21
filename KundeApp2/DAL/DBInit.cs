using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using Avapi;
using Avapi.AvapiTIME_SERIES_DAILY;
using System.Threading.Tasks;
using Avapi.AvapiTIME_SERIES_INTRADAY;
using YahooFinanceApi;

namespace KundeApp2.Model
{
    public static class DBInit
    {
        public static async void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<KundeContext>();

                // må slette og opprette databasen hver gang når den skalinitieres (seed`es)
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var securities = await Yahoo.Symbols("AAPL", "IBM").Fields(Field.Symbol, Field.RegularMarketPrice, Field.RegularMarketOpen, Field.RegularMarketDayHigh,
                  Field.RegularMarketDayLow, Field.RegularMarketVolume).QueryAsync();
                var ibm = securities["IBM"];
                var aapl = securities["AAPL"];
                var symbol = ibm[Field.Symbol]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var price = ibm[Field.RegularMarketPrice]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var open = ibm[Field.RegularMarketOpen]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var high = ibm[Field.RegularMarketDayHigh]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var low = ibm[Field.RegularMarketDayLow]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var volume = ibm[Field.RegularMarketVolume]; // or, you could use aapl.RegularMarketPrice directly for typed-value


                var symbol2 = aapl[Field.Symbol]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var price2 = aapl[Field.RegularMarketPrice]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var open2 = aapl[Field.RegularMarketOpen]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var high2 = aapl[Field.RegularMarketDayHigh]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var low2 = aapl[Field.RegularMarketDayLow]; // or, you could use aapl.RegularMarketPrice directly for typed-value
                var volume2 = aapl[Field.RegularMarketVolume]; // or, you could use aapl.RegularMarketPrice directly for typed-value

             



                var stock1 = new Kunder { Symbol = symbol, Open = open, High = high, Low = low, Price = price, Volume = volume };
                var stock2 = new Kunder { Symbol = symbol2, Open = open2, High = high2, Low = low2, Price = price2, Volume = volume2 };

                context.Kunder.Add(stock1);
                context.Kunder.Add(stock2);




                context.SaveChanges();
            }
        }
    }
       
}
