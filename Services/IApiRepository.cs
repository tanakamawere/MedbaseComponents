using MedbaseComponents.Models;

namespace MedbaseComponents.Services
{
    public interface IApiRepository
    {
        Task<IEnumerable<Article>> GetArticlesNumbered(int num);
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(int id);
        Task<IEnumerable<Topic>> GetTopics(string id);
        Task<Topic> GetTopic(int id);
        Task<IEnumerable<Topic>> GetAllTopics();
        Task<IEnumerable<Course>> GetCourses();
        Task<Course> GetCourse(int id);
        Task<IEnumerable<Question>> GetQuestionsSimple(long id);
        Task<Question> GetQuestion(int id);
        Task<QuestionPaged> GetPagedQuestions(int topic, int page, double numResults);
        Task<QuestionPagedWithTopic> GetPagedQuestionsWithTopic(int topic, int page, double numResults);
        Task<QuestionsWithTopicDto> GetQuestionsWithTopic(int topic);
        Task<QuestionPaged> GetSearchPagedQuestions(int topic, int page, double numResults, string keyword);
        Task<IEnumerable<Subscription>> GetSubscriptions();
        Task<Subscription> GetSubscription(string email);
        Task<List<Question>> GetAllQuestions();
        Task<CourseArticlesDto> GetCourseArticlesDto();
        Task<IEnumerable<Question>> GetQuizQuestions(int topic, int number);
        Task<IEnumerable<Corrections>> GetCorrections();
        Task<IEnumerable<Question>> GetQuestionsByKeyword(string keyword);

        void PostArticle(Article article);
        void PostTopic(Topic topic);
        void PostCourse(Course course);
        Task<bool> PostQuestion(Question question);
        void PostSubscription(Subscription subscription);

        void DeleteCourse(int id);
        void DeleteQuestion(int id);
        void DeleteTopic(int id);
        void DeleteArticle(int id);
        void DeleteSubscription(int id);

        Task<bool> UpdateQuestion(int id, Question question);
        void UpdateTopic(int id, Topic topic);
        void UpdateCourse(int id, Course course);
        void UpdateArticle(int id, Article article);
        void UpdateSubscription(int id, Subscription subscription);
        Task<bool> PostCorrection(Corrections corrections);
        Task DeleteCorrection(int id);
        Task MergeCorrections();
        Task<bool> MergeOneCorrection(int id);
        Task ClearAllCorrection();

        Task<NoteDto> GetNoteDtoByReference(int topicReference);
        Task<Note> GetNoteByReferenceAsync(int topicReference);
        Task AddNoteAsync(Note note);
        Task UpdateNoteAsync(Note note);
        void DeleteNotes(int id);
        Task<List<CourseTopicsDto>> GetListCourseTopicsDto();
        Task<CourseTopicsDto> GetCourseTopicsDto(string courseReference);
        Task<List<NoteDto>> GetAllNotesAsync();
    }
}
