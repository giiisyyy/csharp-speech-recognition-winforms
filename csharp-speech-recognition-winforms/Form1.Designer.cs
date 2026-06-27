namespace csharp_speech_recognition_winforms
{

    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();

            this.lblWord = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // Labels for Checkboxes
            string[] headers = { "Shift (+)", "Ctrl (^)", "Alt (%)" };
            for (int i = 0; i < headers.Length; i++)
            {
                var lbl = new System.Windows.Forms.Label
                {
                    Text = headers[i],
                    Location = new System.Drawing.Point(300 + (i * 70), 30),
                    AutoSize = true
                };
                this.Controls.Add(lbl);
            }

            // Setup 5 rows of controls
            for (int i = 0; i < 5; i++)
            {
                int yPos = 50 + (i * 30);

                var txtWord = new System.Windows.Forms.TextBox { Name = "txtWord" + i, Location = new System.Drawing.Point(20, yPos), Size = new System.Drawing.Size(120, 20) };
                var txtKey = new System.Windows.Forms.TextBox { Name = "txtKey" + i, Location = new System.Drawing.Point(160, yPos), Size = new System.Drawing.Size(120, 20) };

                var chkShift = new System.Windows.Forms.CheckBox { Name = "chkShift" + i, Location = new System.Drawing.Point(310, yPos), Size = new System.Drawing.Size(20, 20) };
                var chkCtrl = new System.Windows.Forms.CheckBox { Name = "chkCtrl" + i, Location = new System.Drawing.Point(380, yPos), Size = new System.Drawing.Size(20, 20) };
                var chkAlt = new System.Windows.Forms.CheckBox { Name = "chkAlt" + i, Location = new System.Drawing.Point(450, yPos), Size = new System.Drawing.Size(20, 20) };

                this.Controls.AddRange(new System.Windows.Forms.Control[] { txtWord, txtKey, chkShift, chkCtrl, chkAlt });
            }

            // Buttons (Adjusted position for wider form)
            this.btnStart.Location = new System.Drawing.Point(20, 220);
            this.btnStart.Size = new System.Drawing.Size(75, 30);
            this.btnStart.Text = "Inicia";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            this.btnStop.Location = new System.Drawing.Point(105, 220);
            this.btnStop.Size = new System.Drawing.Size(75, 30);
            this.btnStop.Text = "Para";
            this.btnStop.Enabled = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // Labels
            this.lblWord.Text = "Ordre de veu";
            this.lblWord.Location = new System.Drawing.Point(20, 30);
            this.lblKey.Text = "Tecla";
            this.lblKey.Location = new System.Drawing.Point(160, 30);

            // Form
            this.ClientSize = new System.Drawing.Size(550, 280);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.btnStart, this.btnStop, this.lblWord, this.lblKey });
            this.Text = "Reconeixement de veu";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblWord;
        private System.Windows.Forms.Label lblKey;
    }
}

