using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KundeApp2.Model;
using Microsoft.EntityFrameworkCore;

namespace KundeApp2.DAL
{
    public class KundeRepository : IKundeRepository
    {
        private readonly KundeContext _db;

        public KundeRepository(KundeContext db)
        {
            _db = db;
        }

        public async Task<bool> Lagre(Kunde innKunde)
        {
            try
            {
                var nyKundeRad = new Kunder();
                nyKundeRad.Symbol = innKunde.Symbol;
                nyKundeRad.Open = innKunde.Open;
                nyKundeRad.High = innKunde.High;
                nyKundeRad.Low = innKunde.Low;
                nyKundeRad.Price = innKunde.Price;
                nyKundeRad.Volume = innKunde.Volume;

              
                _db.Kunder.Add(nyKundeRad);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<List<Kunde>> HentAlle()
        {
            try
            {
                List<Kunde> alleKunder = await _db.Kunder.Select(k => new Kunde
                {
                    Id = k.Id,
                    Symbol = k.Symbol,
                    Open = k.Open,
                    High = k.High,
                    Low = k.Low,
                    Price = k.Price,
                    Volume = k.Volume,
                   
                }).ToListAsync();
                return alleKunder;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> Slett(int id)
        {
            try
            {
                Kunder enDBKunde = await _db.Kunder.FindAsync(id);
                _db.Kunder.Remove(enDBKunde);
                await _db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Kunde> HentEn(int id)
        {
            Kunder enKunde = await _db.Kunder.FindAsync(id);
            var hentetKunde = new Kunde()
            {
                Id = enKunde.Id,
                Symbol = enKunde.Symbol,
                Open = enKunde.Open,
                High = enKunde.High,
                Low = enKunde.Low,
                Price = enKunde.Price,
                Volume = enKunde.Volume
            };
            return hentetKunde;
        }

        public async Task<bool> Endre(Kunde endreKunde)
        {
            try
            {
                var endreObjekt = await _db.Kunder.FindAsync(endreKunde.Id);
                endreObjekt.Symbol = endreKunde.Symbol;
                endreObjekt.Open = endreKunde.Open;
                endreObjekt.High = endreKunde.High;
                endreObjekt.Low = endreKunde.Low;
                endreObjekt.Price = endreKunde.Price;
                endreObjekt.Volume = endreKunde.Volume;
                await _db.SaveChangesAsync();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
