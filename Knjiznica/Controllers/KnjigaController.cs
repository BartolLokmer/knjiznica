using Knjiznica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Knjiznica.Controllers
{
    public class KnjigaController : Controller
    {
        private readonly IRepozitorijUpita _repozitorijUpita;
        public KnjigaController(IRepozitorijUpita repozitorijUpita)
        {
            _repozitorijUpita = repozitorijUpita;
        }

        public IActionResult Index()
        {
            return View(_repozitorijUpita.PopisKnjiga());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv");
            int sljedeciId = _repozitorijUpita.SljedeciId();
            Knjiga knjiga = new Knjiga() { Id = sljedeciId };
            return View(knjiga);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Naziv,Autor,DatumIzlaska,Cijena,SlikaUrl,KategorijaId")]Knjiga knjiga)
        {
            ModelState.Remove("Kategorija");

            if (ModelState.IsValid)
            {
                _repozitorijUpita.Create(knjiga);
                return RedirectToAction("Index");
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", knjiga.KategorijaId);
            return View(knjiga);
        }
        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = _repozitorijUpita.DohvatiKnjiguSIdom(Convert.ToInt32(id));

            if (knjiga == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", knjiga.KategorijaId);
            return View(knjiga);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(int id, [Bind("Id,Naziv,Autor,DatumIzlaska,Cijena,SlikaUrl,KategorijaId")] Knjiga knjiga)
        {
            if (id != knjiga.Id)
            {
                return NotFound();
            }
            ModelState.Remove("Kategorija");
            if (ModelState.IsValid)
            {
                _repozitorijUpita.Update(knjiga);
                return RedirectToAction("Index");
            }
            ViewData["KategorijaId"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Id", "Naziv", knjiga.KategorijaId);
            return View(knjiga);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var knjiga = _repozitorijUpita.DohvatiKnjiguSIdom(Convert.ToInt32(id));
            if (knjiga == null)
            {
                return NotFound();
            }
            return View(knjiga);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var knjiga = _repozitorijUpita.DohvatiKnjiguSIdom(id);
            _repozitorijUpita.Delete(knjiga);
            return RedirectToAction("Index");
        }
        public ActionResult SearchIndex(string knjigaZanr, string searchString)
        {
            var zanr = new List<string>();

            var zanrUpit = _repozitorijUpita.PopisKategorija();

            ViewData["knjigaZanr"] = new SelectList(_repozitorijUpita.PopisKategorija(), "Naziv", "Naziv", zanrUpit);

            var knjige = _repozitorijUpita.PopisKnjiga();

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                knjige = knjige.Where(s => s.Naziv.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            if (string.IsNullOrWhiteSpace(knjigaZanr))
                return View(knjige);
            else
            {
                return View(knjige.Where(x => x.Kategorija.Naziv == knjigaZanr));
            }

        }






    }
}




    
