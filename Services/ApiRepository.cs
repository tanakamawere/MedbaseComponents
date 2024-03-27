using MedbaseComponents.Models;
using MedbaseComponents.MsalClient;
using System.Net.Http.Json;

namespace MedbaseComponents.Services
{
    public class ApiRepository : IApiRepository
    {
        private readonly HttpClient httpClient;

        public ApiRepository(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }

        public async Task<IEnumerable<Article>> GetArticlesNumbered(int num)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Article>>($"articles/select/{num}");
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Article>>("articles");
        }

        public async Task<Article> GetArticle(int id)
        {
            return await httpClient.GetFromJsonAsync<Article>($"/articles/{id}");
        }

        public async Task<IEnumerable<Topic>> GetTopics(string id)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Topic>>($"topics/{id}");
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Course>>($"courses");
        }

        public async Task<IEnumerable<Question>> GetQuestionsSimple(long id)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Question>>($"questions/{id}");
        }

        public async Task<QuestionPaged> GetPagedQuestions(int topic, int page, double numResults = 10f)
        {
            return await httpClient.GetFromJsonAsync<QuestionPaged>($"questions/{topic}/{numResults}/{page}");
        }
        public async Task<QuestionPaged> GetSearchPagedQuestions(int topic, int page, double numResults, string keyword)
        {
            return await httpClient.GetFromJsonAsync<QuestionPaged>($"questions/{topic}/{numResults}/{page}/{keyword}");
        }

        public async Task<IEnumerable<Topic>> GetAllTopics()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Topic>>("topics");
        }

        public async Task<Question> GetQuestion(int id)
        {
            return await httpClient.GetFromJsonAsync<Question>($"questions/select/{id}");
        }

        public async Task<Topic> GetTopic(int id)
        {
            return await httpClient.GetFromJsonAsync<Topic>($"topics/select/{id}");
        }

        public async Task<IEnumerable<Subscription>> GetSubscriptions()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Subscription>>($"subscriptions");
        }

        public async Task<Subscription> GetSubscription(string email)
        {
            return await httpClient.GetFromJsonAsync<Subscription>($"subscriptions/{email}");
        }

        public async Task<Course> GetCourse(int id)
        {
            return await httpClient.GetFromJsonAsync<Course>($"courses/{id}");
        }
        public async Task<List<Question>> GetAllQuestions()
        {
            //if (GlobalValues.AccessToken == null)
            //    return new();

            //var result = new List<Question>();

            //var message = new HttpRequestMessage(HttpMethod.Get, "questions");
            //message.Headers.Add("Authorization", $"Bearer {GlobalValues.AccessToken}");

            //var response = await httpClient.SendAsync(message);

            //var responseContent = await response.Content.ReadAsStringAsync();

            //var options = new System.Text.Json.JsonSerializerOptions
            //{
            //    PropertyNameCaseInsensitive = true
            //};

            //result = System.Text.Json.JsonSerializer.Deserialize<List<Question>>(responseContent, options);

            //if (response.IsSuccessStatusCode)
            //{
            //    return result;
            //}
            //else
            //{
            //    Console.WriteLine($"Error getting questions: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
            //    return result;
            //}

            return await httpClient.GetFromJsonAsync<List<Question>>("questions");
        }

        public async void PostArticle(Article article)
        {
            await httpClient.PostAsJsonAsync($"article/add", article);
        }

        public async void PostTopic(Topic topic)
        {
            await httpClient.PostAsJsonAsync($"topic/add", topic);
        }

        public async void PostCourse(Course course)
        {
            await httpClient.PostAsJsonAsync($"course/add", course);
        }
        public async Task<bool> PostQuestion(Question question)
        {
            var response = await httpClient.PostAsJsonAsync($"questions/add", question);

            // Check for successful HTTP status code (e.g., 200-299)
            if (response.IsSuccessStatusCode)
            {
                // Handle successful response (e.g., parse JSON data if necessary)
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Question posted successfully! Response: {responseContent}");
                return true; // Indicate successful posting
            }
            else
            {
                // Handle failed response with proper error handling
                Console.WriteLine($"Error posting question: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                return false; // Indicate posting failed
            }
        }
        public async void PostSubscription(Subscription subscription)
        {
            await httpClient.PostAsJsonAsync($"subscription/add", subscription);
        }

        public async void DeleteCourse(int id)
        {
            await httpClient.DeleteAsync($"courses/{id}");
        }

        public async void DeleteQuestion(int id)
        {
            await httpClient.DeleteAsync($"questions/{id}");
        }

        public async void DeleteTopic(int id)
        {
            await httpClient.DeleteAsync($"topics/{id}");
        }

        public async void DeleteArticle(int id)
        {
            await httpClient.DeleteAsync($"articles/{id}");
        }

        public async void DeleteSubscription(int id)
        {
            await httpClient.DeleteAsync($"subscriptions/{id}");
        }

        public async Task<bool> UpdateQuestion(int id, Question question)
        {
            var response = await httpClient.PutAsJsonAsync($"questions/{id}", question);

            // Check for successful HTTP status code (e.g., 200-299)
            if (response.IsSuccessStatusCode)
            {
                // Handle successful response (e.g., parse JSON data if necessary)
                var responseContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Question posted successfully! Response: {responseContent}");
                return true; // Indicate successful posting
            }
            else
            {
                // Handle failed response with proper error handling
                Console.WriteLine($"Error posting question: {response.StatusCode} - {await response.Content.ReadAsStringAsync()}");
                return false; // Indicate posting failed
            }
        }

        public async void UpdateTopic(int id, Topic topic)
        {
            await httpClient.PutAsJsonAsync($"topics/{id}", topic);
        }

        public async void UpdateCourse(int id, Course course)
        {
            await httpClient.PutAsJsonAsync($"courses/{id}", course);
        }

        public async void UpdateArticle(int id, Article article)
        {
            await httpClient.PutAsJsonAsync($"articles/{id}", article);
        }
        public async void UpdateSubscription(int id, Subscription subscription)
        {
            await httpClient.PutAsJsonAsync($"subscriptions/{id}", subscription);
        }

        public async Task<CourseArticlesDto> GetCourseArticlesDto()
        {
            return await httpClient.GetFromJsonAsync<CourseArticlesDto>("/dashboard/getall");
        }

        public async Task<IEnumerable<Corrections>> GetCorrections()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Corrections>>($"corrections");
        }
        public async Task<IEnumerable<Question>> GetQuizQuestions(int topic, int number)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Question>>($"questions/quiz/{topic}/{number}");
        }
        public async Task<bool> PostCorrection(Corrections corrections)
        {
            var response = await httpClient.PostAsJsonAsync($"corrections/{corrections}", corrections);
            if (response.IsSuccessStatusCode)
                return true;
            else
                return false;
        }

        public async Task DeleteCorrection(int id)
        {
            await httpClient.DeleteAsync($"corrections/deleteone/{id}");
        }

        public async Task MergeCorrections()
        {
            await httpClient.PostAsync("corrections/mergeall", null);
        }

        public async Task ClearAllCorrection()
        {
            await httpClient.DeleteAsync("corrections/clearall");
        }

        public async Task<bool> MergeOneCorrection(int id)
        {
            bool isSuccessful = false;
            var response = await httpClient.PostAsJsonAsync($"corrections/mergeone/{id}", id);
            if (response.IsSuccessStatusCode)
                isSuccessful = true;
            return isSuccessful;
        }

        public async Task<NoteDto> GetNoteDtoByReference(int topicReference)
        {
            return await httpClient.GetFromJsonAsync<NoteDto>($"notes/get/{topicReference}");
        }
        public async Task<Note> GetNoteByReferenceAsync(int topicReference)
        {
            return await httpClient.GetFromJsonAsync<Note>($"notes/get_with_reference/{topicReference}");
        }

        public async Task AddNoteAsync(Note note)
        {
            await httpClient.PostAsJsonAsync($"notes/post/{note}", note);
        }

        public async Task UpdateNoteAsync(Note note)
        {
            await httpClient.PutAsJsonAsync($"notes/put/{note}", note);
        }

        public async void DeleteNotes(int id)
        {
            await httpClient.DeleteAsync($"notes/delete/{id}");
        }

        public async Task<List<CourseTopicsDto>> GetListCourseTopicsDto()
        {
            return await httpClient.GetFromJsonAsync<List<CourseTopicsDto>>("notes/coursetopics/getall");
        }

        public async Task<CourseTopicsDto> GetCourseTopicsDto(string courseReference)
        {
            return await httpClient.GetFromJsonAsync<CourseTopicsDto>($"notes/coursetopics/get/{courseReference}");
        }

        public async Task<List<NoteDto>> GetAllNotesAsync()
        {
            return await httpClient.GetFromJsonAsync<List<NoteDto>>("notes/getall");
        }

        public async Task<IEnumerable<Question>> GetQuestionsByKeyword(string keyword)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Question>>($"questions/search/{keyword}");
        }

        public async Task<QuestionPagedWithTopic> GetPagedQuestionsWithTopic(int topic, int page, double numResults)
        {
            return await httpClient.GetFromJsonAsync<QuestionPagedWithTopic>($"/questions/pagedwithtopic/{topic}/{numResults}/{page}");
        }

        public async Task<QuestionsWithTopicDto> GetQuestionsWithTopic(int topic)
        {
            return await httpClient.GetFromJsonAsync<QuestionsWithTopicDto>($"questions/withtopic/{topic}");
        }
    }
}