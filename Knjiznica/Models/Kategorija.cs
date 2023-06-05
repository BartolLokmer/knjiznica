using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Knjiznica.Models;

namespace Knjiznica.Models
{
    public class Kategorija 
        {
            [Display(Name = "#")]
            public int Id { get; set; }
            [Required(ErrorMessage = "Polje {0} je obvezno.")]
            public string Naziv { get; set; }

            public List<Knjiga> Knjige { get; set; }
        }


    }
