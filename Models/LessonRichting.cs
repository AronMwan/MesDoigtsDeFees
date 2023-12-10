using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MesDoigtsDeFees.Models
{
    public class LessonRichting
    {
        public int Id { get; set; }
        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        [Display(Name = "Les")]
        public string LessonName { get; set; }

        [ForeignKey("Richting")]
        public int RichtingId { get; set; }
        public Richting Richting { get; set; }
        [Display(Name = "Richting")]
        public string RichtingName { get; set; }

        public DateTime Started { get; set; } = DateTime.Now;
        public DateTime Ended { get; set; } = DateTime.MaxValue;
    }

    public class LessonRichtingViewModel
    {
        [Display(Name = "Les")]
        public string LessonName { get; set; }
        public int LessonId { get; set; }
        [Display(Name = "Richting")]
        public string RichtingName { get; set; }
        public int RichtingId { get; set; }
    }
}
