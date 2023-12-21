using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MesDoigtsDeFees.Models
{


    public class Group
    {
        public int Id { get; set; }
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Beschrijving")]
        public string Description { get; set; }

        [Display(Name = "Categorie")]
        public string Categorie { get; set; }
        public List<string> CategorieList { get; } = new List<string> { "Avond", "Dag" };

        [Display(Name = "Groep aangemaakt")]
        [DataType(DataType.Date)]
        public DateTime Started { get; set; } = DateTime.Now;


        [Display(Name = "Groep gestopt")]
        [DataType(DataType.Date)]
        public DateTime Ended { get; set; } = DateTime.MaxValue;


    }







    public class ListItem
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}
