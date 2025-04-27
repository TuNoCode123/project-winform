namespace WinFormsApp3
{
    partial class ResultForm
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
            this.labelScore = new System.Windows.Forms.Label();
            this.labelDetails = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.panelDetailedResults = new System.Windows.Forms.Panel();
            this.labelDetailedResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.Location = new System.Drawing.Point(12, 20);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(142, 26);
            this.labelScore.TabIndex = 0;
            this.labelScore.Text = "Your Score: ";
            // 
            // labelDetails
            // 
            this.labelDetails.Location = new System.Drawing.Point(14, 60);
            this.labelDetails.Name = "labelDetails";
            this.labelDetails.Size = new System.Drawing.Size(574, 60);
            this.labelDetails.TabIndex = 1;
            this.labelDetails.Text = "Score details";
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(486, 508);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(100, 30);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // panelDetailedResults
            // 
            this.panelDetailedResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDetailedResults.AutoScroll = true;
            this.panelDetailedResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDetailedResults.Location = new System.Drawing.Point(12, 150);
            this.panelDetailedResults.Name = "panelDetailedResults";
            this.panelDetailedResults.Size = new System.Drawing.Size(576, 340);
            this.panelDetailedResults.TabIndex = 3;
            // 
            // labelDetailedResults
            // 
            this.labelDetailedResults.AutoSize = true;
            this.labelDetailedResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDetailedResults.Location = new System.Drawing.Point(12, 127);
            this.labelDetailedResults.Name = "labelDetailedResults";
            this.labelDetailedResults.Size = new System.Drawing.Size(143, 20);
            this.labelDetailedResults.TabIndex = 4;
            this.labelDetailedResults.Text = "Detailed Results";
            // 
            // ResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 550);
            this.Controls.Add(this.labelDetailedResults);
            this.Controls.Add(this.panelDetailedResults);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelDetails);
            this.Controls.Add(this.labelScore);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResultForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quiz Results";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelDetails;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel panelDetailedResults;
        private System.Windows.Forms.Label labelDetailedResults;
    }
}