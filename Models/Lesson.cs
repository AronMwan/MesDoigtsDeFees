using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MesDoigtsDeFees.Models
{
    public class Lesson
    {
        public int Id { get; set; }
        [Display(Name = "Naam")]
        public string Name { get; set; }
        [Display(Name = "Beschrijving")]
        public string Description { get; set; }
        public string Type { get; set; }
        public List<string> TypeList { get; } = new List<string> { "Theorie", "Praktijk" };
        [ForeignKey("Group")]
        public int GroupId { get; set; }
        [Display(Name = "Groep")]
        public Group? Group { get; set; }
        //public List<Group>? Groups { get; set; }
        //public List<Traject>? Trajects { get; set; }
        [Display(Name = "Les aangemaakt")]
        public DateTime Started { get; set; } = DateTime.Now;
        [Display(Name = "Les gestopt")]
        public DateTime Ended { get; set; } = DateTime.MaxValue;

        [ForeignKey("Richting")]
        public int? RichtingId { get; set; }

        [Display(Name = "Richting")]
        public Richting? Richting { get; set; } 
        public string? RichtingName { get; set; }



    }

    public class LessonIndexViewModel
    {
        public List<Lesson> Lessons { get; set; }
        public string SelectedType { get; set; } = "Alle";
        public SelectList TypeList { get; set; }

        
        public LessonIndexViewModel()
        {
            TypeList = new SelectList(new List<string> { "Theorie", "Praktijk" });
        }
    }



   
}
