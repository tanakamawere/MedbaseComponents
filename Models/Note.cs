using System.ComponentModel.DataAnnotations;

namespace MedbaseComponents.Models;

public class Note
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Select topic reference")]
    public int TopicReference { get; set; }
    public DateTime DateUpdated { get; set; } = DateTime.Now;
    [Required(ErrorMessage = "Add text")]
    public string Text { get; set; } = string.Empty;
}

public class NoteDto
{
    public int Id { get; set; }
    public string TopicReferenceName { get; set; }
    public DateTime DateUpdated { get; set; }
    public string Text { get; set; } = string.Empty;
}