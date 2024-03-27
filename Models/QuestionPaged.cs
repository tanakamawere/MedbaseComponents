namespace MedbaseComponents.Models
{
    public class QuestionPaged
    {
        public IEnumerable<Question> Questions { get; set; } = Enumerable.Empty<Question>();
        public int Pages { get; set; }
        public int CurrentPage { get; set; } = 1;
    }

    public class QuestionPagedWithTopic
    {
        public QuestionsWithTopicDto QuestionsWithTopic { get; set; }
        public int Pages { get; set; }
        public int CurrentPage { get; set; } = 1;
    }
    public class QuestionWithTopicDto
    {
        public Question Question { get; set; }
        public string TopicName { get; set; }
    }
    public class QuestionsWithTopicDto
    {
        public IEnumerable<Question> Questions { get; set; } = Enumerable.Empty<Question>();
        public string TopicName { get; set; }
    }
}
