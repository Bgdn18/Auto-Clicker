namespace AutoClicker
{
    partial class AutoClicker
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoClicker));
            textBoxInterval = new TextBox();
            textBoxDuration = new TextBox();
            buttonStart = new Button();
            buttonStop = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // textBoxInterval
            // 
            textBoxInterval.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxInterval.Location = new Point(12, 12);
            textBoxInterval.Name = "textBoxInterval";
            textBoxInterval.PlaceholderText = "Speed (in milliseconds)";
            textBoxInterval.Size = new Size(226, 26);
            textBoxInterval.TabIndex = 0;
            textBoxInterval.Text = "1000";
            // 
            // textBoxDuration
            // 
            textBoxDuration.Font = new Font("Comic Sans MS", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBoxDuration.Location = new Point(12, 44);
            textBoxDuration.Name = "textBoxDuration";
            textBoxDuration.PlaceholderText = "Time (in seconds)";
            textBoxDuration.Size = new Size(226, 26);
            textBoxDuration.TabIndex = 1;
            textBoxDuration.Text = "5";
            // 
            // buttonStart
            // 
            buttonStart.Cursor = Cursors.Hand;
            buttonStart.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonStart.Location = new Point(12, 76);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(103, 54);
            buttonStart.TabIndex = 2;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonStop
            // 
            buttonStop.Cursor = Cursors.Hand;
            buttonStop.Enabled = false;
            buttonStop.Font = new Font("Comic Sans MS", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonStop.Location = new Point(135, 76);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(103, 54);
            buttonStop.TabIndex = 3;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold | FontStyle.Italic);
            label1.Location = new Point(12, 133);
            label1.Name = "label1";
            label1.Size = new Size(28, 22);
            label1.TabIndex = 4;
            label1.Text = "F6";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 11.25F, FontStyle.Bold | FontStyle.Italic);
            label2.Location = new Point(135, 133);
            label2.Name = "label2";
            label2.Size = new Size(28, 22);
            label2.TabIndex = 5;
            label2.Text = "F7";
            // 
            // AutoClicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(250, 165);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonStop);
            Controls.Add(buttonStart);
            Controls.Add(textBoxDuration);
            Controls.Add(textBoxInterval);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "AutoClicker";
            Text = "Auto Clicker";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxInterval;
        private TextBox textBoxDuration;
        private Button buttonStart;
        private Button buttonStop;
        private Label label1;
        private Label label2;
    }
}
