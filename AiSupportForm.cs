using System;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class AiSupportForm : Form
    {
        public AiSupportForm(string aiResponse)
        {
            InitializeComponent();
            textBoxAiResponse.Text = aiResponse;
        }
    }
}