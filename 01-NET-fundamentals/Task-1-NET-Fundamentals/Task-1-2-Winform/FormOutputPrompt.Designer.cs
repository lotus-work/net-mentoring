namespace Task_1_2_Winform
{
    partial class FormOutputPrompt
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
            this.labelFromClassLibrary = new System.Windows.Forms.Label();
            this.labelOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFromClassLibrary
            // 
            this.labelFromClassLibrary.AutoSize = true;
            this.labelFromClassLibrary.Location = new System.Drawing.Point(323, 205);
            this.labelFromClassLibrary.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFromClassLibrary.Name = "labelFromClassLibrary";
            this.labelFromClassLibrary.Size = new System.Drawing.Size(44, 16);
            this.labelFromClassLibrary.TabIndex = 3;
            this.labelFromClassLibrary.Text = "label1";
            // 
            // labelOutput
            // 
            this.labelOutput.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(309, 163);
            this.labelOutput.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(75, 16);
            this.labelOutput.TabIndex = 2;
            this.labelOutput.Text = "labelOutput";
            this.labelOutput.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormOutputPrompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelFromClassLibrary);
            this.Controls.Add(this.labelOutput);
            this.Name = "FormOutputPrompt";
            this.Text = "FormOutputPrompt";
            this.Load += new System.EventHandler(this.FormOutputPrompt_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFromClassLibrary;
        private System.Windows.Forms.Label labelOutput;
    }
}