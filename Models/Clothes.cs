using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MesDoigtsDeFees.Models
{
    public class Clothes
    {
        public int Id { get; set; }
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Beschrijving")]
        public string Description { get; set; }

        [Display(Name = "Maat")]
        public string Size { get; set; }

        public List<string> SizeList { get; } = new List<string> { "XS", "S", "M", "L", "XL" };

        [Display(Name = "Kledingstuk aangemaakt")]
        [DataType(DataType.Date)]
        public DateTime Started { get; set; } = DateTime.Now;


        [Display(Name = "Kledingstuk gestopt")]
        [DataType(DataType.Date)]
        public DateTime Ended { get; set; } = DateTime.MaxValue;
    }

    public class ClothesIndexViewModel
    {
        public List<Clothes> Clothes { get; set; }
        public string SelectedSize { get; set; } = "Alle";
        public SelectList SizeList { get; set; }

        public ClothesIndexViewModel()
        {
            SizeList = new SelectList(new List<string> { "XS", "S", "M", "L", "XL" });
        }
    }
}