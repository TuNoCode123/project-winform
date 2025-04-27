using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace WinFormsApp3
{
    public partial class MainForm : Form
    {
        private readonly ApiService _apiService;
        private List<Quizz> _quizzes;

        public MainForm()
        {
            InitializeComponent();
            _apiService = new ApiService();
            Load += MainForm_Load;
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            await LoadQuizzesAsync();
        }

        private async Task LoadQuizzesAsync()
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                var response = await _apiService.GetQuizzesAsync();

                if (response.EC == 0)
                {
                    _quizzes = response.DT;
                    DisplayQuizzes();
                }
                else
                {
                    MessageBox.Show($"Error: {response.EM}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void DisplayQuizzes()
        {
            // Clear existing controls
            flowLayoutPanelQuizzes.Controls.Clear();

            foreach (var quiz in _quizzes)
            {
                var quizPanel = new Panel
                {
                    Width = flowLayoutPanelQuizzes.Width - 25,
                    Height = 100,
                    BorderStyle = BorderStyle.FixedSingle,
                    Margin = new Padding(5)
                };

                var titleLabel = new Label
                {
                    Text = quiz.Title,
                    Font = new Font("Arial", 12, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                var descriptionLabel = new Label
                {
                    Text = quiz.Description,
                    Location = new Point(10, 40),
                    Width = quizPanel.Width - 20,
                    Height = 40
                };

                var dateLabel = new Label
                {
                    Text = $"Created: {quiz.CreatedAt.ToShortDateString()}",
                    Location = new Point(quizPanel.Width - 150, 10),
                    AutoSize = true,
                    ForeColor = Color.Gray
                };

                quizPanel.Controls.Add(titleLabel);
                quizPanel.Controls.Add(descriptionLabel);
                quizPanel.Controls.Add(dateLabel);

                // Store the quiz ID in the Tag property
                quizPanel.Tag = quiz.Id;
                quizPanel.Click += QuizPanel_Click;

                // Make sure child controls also trigger the click event
                foreach (Control control in quizPanel.Controls)
                {
                    control.Click += (s, e) => QuizPanel_Click(quizPanel, e);
                }

                flowLayoutPanelQuizzes.Controls.Add(quizPanel);
            }
        }

        private void QuizPanel_Click(object sender, EventArgs e)
        {
            if (sender is Panel panel && panel.Tag is int quizId)
            {
                var quizDetailForm = new QuizDetailForm(_apiService, quizId);
                quizDetailForm.ShowDialog();
            }
        }

        private void MainForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}