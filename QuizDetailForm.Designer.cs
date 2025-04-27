namespace WinFormsApp3
{
    partial class QuizDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelQuizTitle = new System.Windows.Forms.Label();
            this.labelQuizDescription = new System.Windows.Forms.Label();
            this.labelQuestionNumber = new System.Windows.Forms.Label();
            this.labelQuestionContent = new System.Windows.Forms.Label();
            this.panelOptions = new System.Windows.Forms.Panel();
            this.buttonPrevious = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.buttonAiSupport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelQuizTitle
            // 
            this.labelQuizTitle.AutoSize = true;
            this.labelQuizTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuizTitle.Location = new System.Drawing.Point(18, 14);
            this.labelQuizTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuizTitle.Name = "labelQuizTitle";
            this.labelQuizTitle.Size = new System.Drawing.Size(145, 32);
            this.labelQuizTitle.TabIndex = 0;
            this.labelQuizTitle.Text = "Quiz Title";
            // 
            // labelQuizDescription
            // 
            this.labelQuizDescription.Location = new System.Drawing.Point(20, 65);
            this.labelQuizDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuizDescription.Name = "labelQuizDescription";
            this.labelQuizDescription.Size = new System.Drawing.Size(1162, 62);
            this.labelQuizDescription.TabIndex = 1;
            this.labelQuizDescription.Text = "Quiz Description";
            // 
            // labelQuestionNumber
            // 
            this.labelQuestionNumber.AutoSize = true;
            this.labelQuestionNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestionNumber.Location = new System.Drawing.Point(20, 140);
            this.labelQuestionNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestionNumber.Name = "labelQuestionNumber";
            this.labelQuestionNumber.Size = new System.Drawing.Size(171, 25);
            this.labelQuestionNumber.TabIndex = 2;
            this.labelQuestionNumber.Text = "Question 1 of 10";
            // 
            // labelQuestionContent
            // 
            this.labelQuestionContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelQuestionContent.Location = new System.Drawing.Point(20, 180);
            this.labelQuestionContent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelQuestionContent.Name = "labelQuestionContent";
            this.labelQuestionContent.Size = new System.Drawing.Size(1162, 92);
            this.labelQuestionContent.TabIndex = 3;
            this.labelQuestionContent.Text = "Question content goes here";
            // 
            // panelOptions
            // 
            this.panelOptions.AutoScroll = true;
            this.panelOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOptions.Location = new System.Drawing.Point(24, 277);
            this.panelOptions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelOptions.Name = "panelOptions";
            this.panelOptions.Size = new System.Drawing.Size(1157, 307);
            this.panelOptions.TabIndex = 4;
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.Location = new System.Drawing.Point(24, 608);
            this.buttonPrevious.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(150, 46);
            this.buttonPrevious.TabIndex = 5;
            this.buttonPrevious.Text = "Previous";
            this.buttonPrevious.UseVisualStyleBackColor = true;
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(183, 608);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(150, 46);
            this.buttonNext.TabIndex = 6;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.BackColor = System.Drawing.Color.Green;
            this.buttonSubmit.ForeColor = System.Drawing.Color.White;
            this.buttonSubmit.Location = new System.Drawing.Point(1032, 608);
            this.buttonSubmit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(150, 46);
            this.buttonSubmit.TabIndex = 7;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = false;
            this.buttonSubmit.Visible = false;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // buttonAiSupport
            // 
            this.buttonAiSupport.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonAiSupport.ForeColor = System.Drawing.Color.White;
            this.buttonAiSupport.Location = new System.Drawing.Point(1032, 140);
            this.buttonAiSupport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonAiSupport.Name = "buttonAiSupport";
            this.buttonAiSupport.Size = new System.Drawing.Size(150, 46);
            this.buttonAiSupport.TabIndex = 8;
            this.buttonAiSupport.Text = "AI Support";
            this.buttonAiSupport.UseVisualStyleBackColor = false;
            this.buttonAiSupport.Click += new System.EventHandler(this.buttonAiSupport_Click);
            // 
            // QuizDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.buttonAiSupport);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.panelOptions);
            this.Controls.Add(this.labelQuestionContent);
            this.Controls.Add(this.labelQuestionNumber);
            this.Controls.Add(this.labelQuizDescription);
            this.Controls.Add(this.labelQuizTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "QuizDetailForm";
            this.Text = "Quiz Detail";
            this.Load += new System.EventHandler(this.QuizDetailForm_Load_2);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelQuizTitle;
        private System.Windows.Forms.Label labelQuizDescription;
        private System.Windows.Forms.Label labelQuestionNumber;
        private System.Windows.Forms.Label labelQuestionContent;
        private System.Windows.Forms.Panel panelOptions;
        private System.Windows.Forms.Button buttonPrevious;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button buttonAiSupport;
    }
}