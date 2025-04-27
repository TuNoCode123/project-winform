using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class ResultForm : Form
    {
        private QuizResult _result;

        public ResultForm(QuizResult result)
        {
            InitializeComponent();
            _result = result;

            if (result != null)
            {
                DisplayResults();
            }
            else
            {
                labelScore.Text = "Quiz Completed!";
                labelDetails.Text = "No detailed results available.";
            }
        }

        private void DisplayResults()
        {
            // Display summary
            labelScore.Text = $"Your Score: {_result.score}";

            string details = $"Correct Answers: {_result.correctAnswers}\n" +
                             $"Wrong Answers: {_result.wrongAnswers}\n" +
                             $"Unanswered Questions: {_result.uncomplete}\n" +
                             $"Completion: {_result.percentageLack}%";

            labelDetails.Text = details;

            // Display detailed results
            if (_result.result != null && _result.result.Count > 0)
            {
                // Clear any existing controls
                panelDetailedResults.Controls.Clear();

                int yPos = 10;

                for (int i = 0; i < _result.result.Count; i++)
                {
                    var questionResult = _result.result[i];

                    // Create a panel for this question
                    Panel questionPanel = new Panel
                    {
                        Width = panelDetailedResults.Width - 20,
                        Location = new Point(10, yPos),
                        BorderStyle = BorderStyle.FixedSingle,
                        Padding = new Padding(10)
                    };

                    // Question number and content
                    Label questionLabel = new Label
                    {
                        Text = $"Question {i + 1}: {questionResult.content}",
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        AutoSize = true,
                        Location = new Point(10, 10),
                        MaximumSize = new Size(questionPanel.Width - 20, 0),
                        AutoEllipsis = true
                    };

                    questionPanel.Controls.Add(questionLabel);

                    // Determine the status of this question
                    Color statusColor;
                    string statusText;

                    if (questionResult.yourAnswer == null)
                    {
                        // Unanswered
                        statusColor = Color.Gray;
                        statusText = "Not Answered";
                    }
                    else if (questionResult.yourAnswer.is_correct)
                    {
                        // Correct
                        statusColor = Color.Green;
                        statusText = "Correct";
                    }
                    else
                    {
                        // Incorrect
                        statusColor = Color.Red;
                        statusText = "Incorrect";
                    }

                    // Add status label
                    Label statusLabel = new Label
                    {
                        Text = statusText,
                        ForeColor = statusColor,
                        Font = new Font("Arial", 10, FontStyle.Bold),
                        AutoSize = true,
                        Location = new Point(questionPanel.Width - 100, 10)
                    };

                    questionPanel.Controls.Add(statusLabel);

                    // Add options
                    int optionY = questionLabel.Bottom + 10;

                    foreach (var option in questionResult.options)
                    {
                        // Determine the color for this option
                        Color optionColor = Color.Black;
                        string prefix = "○ ";

                        if (questionResult.yourAnswer != null && questionResult.yourAnswer.id == option.id)
                        {
                            // This is the user's answer
                            prefix = "● ";
                            optionColor = option.is_correct ? Color.Green : Color.Red;
                        }
                        else if (option.is_correct)
                        {
                            // This is the correct answer (but not selected)
                            prefix = "✓ ";
                            optionColor = Color.Green;
                        }

                        Label optionLabel = new Label
                        {
                            Text = $"{prefix}{option.option_text}",
                            ForeColor = optionColor,
                            AutoSize = true,
                            Location = new Point(20, optionY),
                            MaximumSize = new Size(questionPanel.Width - 40, 0)
                        };

                        questionPanel.Controls.Add(optionLabel);
                        optionY = optionLabel.Bottom + 5;
                    }

                    // Adjust the panel height to fit all content
                    questionPanel.Height = optionY + 10;

                    // Add the panel to the results panel
                    panelDetailedResults.Controls.Add(questionPanel);

                    // Update the position for the next question
                    yPos += questionPanel.Height + 10;
                }
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}