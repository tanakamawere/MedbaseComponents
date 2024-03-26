using System.ComponentModel.DataAnnotations;

namespace MedbaseComponents.Models
{
    public class Question
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? QuestionMain { get; set; }

        [Required]
        public string? ChildA { get; set; }

        [Required]
        public string? ChildB { get; set; }

        [Required]
        public string? ChildC { get; set; }

        [Required]
        public string? ChildD { get; set; }

        [Required]
        public string? ChildE { get; set; }

        public bool AnswerA { get; set; }

        public bool AnswerB { get; set; }

        public bool AnswerC { get; set; }

        public bool AnswerD { get; set; }

        public bool AnswerE { get; set; }

        public string? ExplanationA { get; set; } = "";

        public string? ExplanationB { get; set; } = "";

        public string? ExplanationC { get; set; } = "";

        public string? ExplanationD { get; set; } = "";

        public string? ExplanationE { get; set; } = "";

        [Required]
        public int TopicRef { get; set; }
    }

}
