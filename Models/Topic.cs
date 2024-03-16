using System.ComponentModel.DataAnnotations;

namespace MedbaseComponents.Models
{
    public class Topic
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Select a course reference")]
        public string CourseRef { get; set; }
        [Required(ErrorMessage = "Enter a topic reference")]
        public int TopicRef { get; set; }
        [Required(ErrorMessage = "Enter a course name")]
        public string Name { get; set; }
    }

    public class CourseTopicsDto
    {
        public string Course { get; set; }
        public string CourseImage { get; set; }
        public List<Topic>? Topics { get; set; } 
    }
}
