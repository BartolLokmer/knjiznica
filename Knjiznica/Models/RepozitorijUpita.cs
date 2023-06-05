using Knjiznica.Data;
using Microsoft.EntityFrameworkCore;

namespace Knjiznica.Models
{
    public class RepozitorijUpita : IRepozitorijUpita
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public RepozitorijUpita(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public void Create(Knjiga knjiga)
        {
            _applicationDbContext.Add(knjiga);
            _applicationDbContext.SaveChanges();

        }

        public void Create(Kategorija kategorija)
        {
            _applicationDbContext.Add(kategorija);
            _applicationDbContext.SaveChanges();

        }

        public void Delete(Knjiga knjiga)
        {
            _applicationDbContext.Knjige.Remove(knjiga); 
            _applicationDbContext.SaveChanges();

        }

        public void Delete(Kategorija kategorija)
        {
            _applicationDbContext.Kategorija.Remove(kategorija);
            _applicationDbContext.SaveChanges();
        }

        public Knjiga DohvatiKnjiguSIdom(int id)
        {
            return _applicationDbContext.Knjige.Include(k => k.Kategorija).FirstOrDefault(f => f.Id == id);
        }

        public Kategorija DohvatiKategorijuSIdom(int id)
        {
            return _applicationDbContext.Kategorija.Find(id);
        }

        public int KategorijaSljedeciId()
        {
            int zadnjiId = _applicationDbContext.Kategorija
               .Count();

            int sljedeciId = zadnjiId + 1;
            return sljedeciId;
        }

        public IEnumerable<Knjiga> PopisKnjiga()    
        {
            return _applicationDbContext.Knjige.Include(k => k.Kategorija);
        }

        public IEnumerable<Kategorija> PopisKategorija()
        {
            return _applicationDbContext.Kategorija;
        }

        public int SljedeciId()
        {
            int zadnjiId = _applicationDbContext.Knjige.Include(k => k.Kategorija).Max(x => x.Id);
            int sljedeciId = zadnjiId + 1;
            return sljedeciId;

        }

        public void Update(Knjiga knjiga)
        {
            _applicationDbContext.Knjige.Update(knjiga);
            _applicationDbContext.SaveChanges();

        }

        public void Update(Kategorija kategorija)
        {
            _applicationDbContext.Kategorija.Update(kategorija);
            _applicationDbContext.SaveChanges();

        }
    }

}

