using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinFormsApp3
{
    public partial class QuizDetailForm : Form
    {
        private readonly ApiService _apiService;
        private readonly int _quizId;
        private QuizzDetail _quizDetail;
        private int _currentQuestionIndex = 0;

        public QuizDetailForm(ApiService apiService, int quizId)
        {
            InitializeComponent();
            _apiService = apiService;
            _quizId = quizId;
            Load += QuizDetailForm_Load;
        }

        private async void QuizDetailForm_Load(object sender, EventArgs e)
        {
            await LoadQuizDetailAsync();
        }

        private async Task LoadQuizDetailAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var response = await _apiService.GetQuizzDetailAsync(_quizId);

                if (response.EC == 0 && response.DT != null)
                {
                    _quizDetail = response.DT;
                    labelQuizTitle.Text = _quizDetail.Title;
                    labelQuizDescription.Text = _quizDetail.Description;
                    DisplayCurrentQuestion();
                }
                else
                {
                    MessageBox.Show($"Error: {response.EM}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void DisplayCurrentQuestion()
        {
            if (_quizDetail.Questions.Count == 0)
            {
                MessageBox.Show("This quiz has no questions.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
                return;
            }

            var question = _quizDetail.Questions[_currentQuestionIndex];
            labelQuestionNumber.Text = $"Question {_currentQuestionIndex + 1} of {_quizDetail.Questions.Count}";
            labelQuestionContent.Text = question.Content;

            panelOptions.Controls.Clear();
            int optionY = 10;

            foreach (var option in question.Options)
            {
                var radioButton = new RadioButton
                {
                    Text = option.option_text,
                    Tag = option.Id,
                    Location = new System.Drawing.Point(10, optionY),
                    Width = panelOptions.Width - 20,
                    Checked = question.SelectedOptionId == option.Id
                };

                radioButton.CheckedChanged += (s, e) =>
                {
                    if (radioButton.Checked)
                    {
                        question.SelectedOptionId = (int)radioButton.Tag;
                    }
                };

                panelOptions.Controls.Add(radioButton);
                optionY += 30;
            }

            // Update navigation buttons
            buttonPrevious.Enabled = _currentQuestionIndex > 0;
            buttonNext.Enabled = _currentQuestionIndex < _quizDetail.Questions.Count - 1;
            buttonSubmit.Visible = _currentQuestionIndex == _quizDetail.Questions.Count - 1;
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            if (_currentQuestionIndex > 0)
            {
                _currentQuestionIndex--;
                DisplayCurrentQuestion();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_currentQuestionIndex < _quizDetail.Questions.Count - 1)
            {
                _currentQuestionIndex++;
                DisplayCurrentQuestion();
            }
        }

        private async void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Check if all questions have been answered
            bool allAnswered = _quizDetail.Questions.All(q => q.SelectedOptionId.HasValue);

            if (!allAnswered)
            {
                var result = MessageBox.Show("Not all questions have been answered. Do you want to submit anyway?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    return;
                }
            }

            try
            {
                Cursor = Cursors.WaitCursor;

                // Pass the quiz ID and questions to the API service
                var response = await _apiService.SubmitQuizzAnswersAsync(_quizId, _quizDetail.Questions);

                if (response.EC == 0)
                {
                    // Show the results in the ResultForm
                    var resultForm = new ResultForm(response.DT);
                    resultForm.ShowDialog();

                    Close();
                }
                else
                {
                    MessageBox.Show($"Error11: {response.EM}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private async void buttonAiSupport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // Get the current question
                var currentQuestion = _quizDetail.Questions[_currentQuestionIndex];

                // Call the AI support API
                var response = await _apiService.GetAiSupportAsync(currentQuestion);

                if (response.EC == 0)
                {
                    // Show the AI support response in a new form
                    var aiSupportForm = new AiSupportForm(response.DT);
                    aiSupportForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show($"Error: {response.EM}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting AI support: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void QuizDetailForm_Load_1(object sender, EventArgs e)
        {

        }

        private void QuizDetailForm_Load_2(object sender, EventArgs e)
        {

        }

        
    }
}