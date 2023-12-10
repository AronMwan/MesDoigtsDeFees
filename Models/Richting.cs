using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MesDoigtsDeFees.Models
{
    public class Richting
    {
        public int Id { get; set; }
        [Display(Name = "Naam")]
        public string Name { get; set; }

        [Display(Name = "Beschrijving")]
        public string Description { get; set; }
        [Display(Name = "Richting aangemaakt")]
        [DataType(DataType.Date)]
        public DateTime Started { get; set; } = DateTime.Now;


        [Display(Name = "Richting gestopt")]
        [DataType(DataType.Date)]
        public DateTime Ended { get; set; } = DateTime.MaxValue;
        
    }

    
}
