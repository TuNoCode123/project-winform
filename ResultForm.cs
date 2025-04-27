using System;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class ResultForm : Form
    {
        public ResultForm(QuizResult result)
        {
            InitializeComponent();

            if (result != null)
            {
                labelScore.Text = $"Your Score: {result.score}";

                // Create a detailed results message
                string details = $"Correct Answers: {result.correctAnswers}\n" +
                                 $"Wrong Answers: {result.wrongAnswers}\n" +
                                 $"Unanswered Questions: {result.uncomplete}\n" +
                                 $"Completion: {result.percentageLack}%";

                labelDetails.Text = details;
            }
            else
            {
                labelScore.Text = "Quiz Completed!";
                labelDetails.Text = "No detailed results available.";
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}