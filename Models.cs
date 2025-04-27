using System;
using System.Collections.Generic;

namespace WinFormsApp3
{
    public class ApiResponse
    {
        public int EC { get; set; }
        public string EM { get; set; }
        public List<Quizz> DT { get; set; }
    }

    public class Quizz
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class ApiResponseQuizzDetail
    {
        public int EC { get; set; }
        public string EM { get; set; }
        public QuizzDetail DT { get; set; }
    }

    public class QuizzDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }
    }

    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public List<Option> Options { get; set; }
        public int? SelectedOptionId { get; set; }
    }

    public class Option
    {
        public int Id { get; set; }
        public string option_text { get; set; }
    }
    public class QuizResult
    {
        public int correctAnswers { get; set; }
        public int wrongAnswers { get; set; }
        public int score { get; set; }
        public int percentageLack { get; set; }
        public int uncomplete { get; set; }
        public List<QuestionResult> result { get; set; }
    }

    public class QuestionResult
    {
        public string content { get; set; }
        public List<OptionResult> options { get; set; }
        public OptionResult yourAnswer { get; set; }
    }

    public class OptionResult
    {
        public int id { get; set; }
        public string option_text { get; set; }
        public bool is_correct { get; set; }
    }
    public class ApiResponseSubmit
    {
        public int EC { get; set; }
        public string EM { get; set; }
        public QuizResult DT { get; set; }
    }

    public class QuizSubmission
    {
        public int userId { get; set; }
        public int quizzId { get; set; }
        public List<QuizAnswer> answers { get; set; }
    }

    public class QuizAnswer
    {
        public int questionId { get; set; }
        public int optionId { get; set; }
    }

    public class AiSupportRequest
    {
        public string content { get; set; }
        public List<AiSupportOption> options { get; set; }
    }

    public class AiSupportOption
    {
        public string option_text { get; set; }
        public int is_correct { get; set; }
    }

    public class AiSupportResponse
    {
        public int EC { get; set; }
        public string EM { get; set; }
        public string DT { get; set; }  // Assuming the API returns a string response
    }
}