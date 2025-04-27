using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl = "http://localhost:8888/api/v1"; // Replace with your actual API URL
        private readonly int _userId = 1; // This should come from user authentication in a real app
        public ApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ApiResponse> GetQuizzesAsync()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}/quizzs");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ApiResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching quizzes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new ApiResponse { EC = -1, EM = ex.Message, DT = new List<Quizz>() };
            }
        }

        public async Task<ApiResponseQuizzDetail> GetQuizzDetailAsync(int quizzId)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"{_baseUrl}/quizzs/{quizzId}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<ApiResponseQuizzDetail>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching quiz details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new ApiResponseQuizzDetail { EC = -1, EM = ex.Message, DT = null };
            }
        }

        public async Task<ApiResponseSubmit> SubmitQuizzAnswersAsync(int quizzId, List<Question> questions)
        {
            try
            {
                // Create the submission object in the required format
                var submission = new QuizSubmission
                {
                    userId = _userId,
                    quizzId = quizzId,
                    answers = new List<QuizAnswer>()
                };

                // Add only the answered questions
                foreach (var question in questions)
                {
                    if (question.SelectedOptionId.HasValue)
                    {
                        submission.answers.Add(new QuizAnswer
                        {
                            questionId = question.Id,
                            optionId = question.SelectedOptionId.Value
                        });
                    }
                }

                // Serialize the submission object to JSON
                var content = new StringContent(
                    JsonSerializer.Serialize(submission),
                    System.Text.Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync($"{_baseUrl}/submit-quizz", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine(responseBody);

                // Deserialize to the specific response format
                return JsonSerializer.Deserialize<ApiResponseSubmit>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error submitting answers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new ApiResponseSubmit { EC = 1, EM = ex.Message, DT = null };
            }
        }

        public async Task<AiSupportResponse> GetAiSupportAsync(Question question)
        {
            try
            {
                // Convert the Question to the format expected by the AI support API
                var aiRequest = new AiSupportRequest
                {
                    content = question.Content,
                    options = question.Options.Select(o => new AiSupportOption
                    {
                        option_text = o.option_text,
                        // We don't know which option is correct, so we'll set all to 0
                        // In a real app, you might have this information
                        is_correct = 0
                    }).ToList()
                };

                // If we know the correct answer, set it
                if (question.SelectedOptionId.HasValue)
                {
                    var selectedOption = aiRequest.options.FirstOrDefault(o =>
                        question.Options.FirstOrDefault(qo => qo.Id == question.SelectedOptionId)?.option_text == o.option_text);

                    if (selectedOption != null)
                    {
                        selectedOption.is_correct = 1;
                    }
                }

                // Serialize the request object to JSON
                var content = new StringContent(
                    JsonSerializer.Serialize(aiRequest),
                    System.Text.Encoding.UTF8,
                    "application/json");

                HttpResponseMessage response = await _httpClient.PostAsync("http://localhost:8888/api/v1/support-with-ai", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Deserialize to the specific response format
                return JsonSerializer.Deserialize<AiSupportResponse>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting AI support: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new AiSupportResponse { EC = -1, EM = ex.Message, DT = null };
            }
        }

    }
}