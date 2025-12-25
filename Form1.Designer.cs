namespace _25_12_19_game_of_life
{
    partial class Form1
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


        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ResetGridButton = new Button();
            SpeedTimer = new System.Windows.Forms.Timer(components);
            StartButton = new Button();
            StepButton = new Button();
            SpeedSlider = new HScrollBar();
            PersistanceSlider = new HScrollBar();
            label1 = new Label();
            SuspendLayout();
            // 
            // ResetGridButton
            // 
            ResetGridButton.BackColor = Color.White;
            ResetGridButton.Font = new Font("Calibri", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ResetGridButton.ForeColor = Color.Black;
            ResetGridButton.Location = new Point(5, 5);
            ResetGridButton.Name = "ResetGridButton";
            ResetGridButton.Size = new Size(205, 100);
            ResetGridButton.TabIndex = 0;
            ResetGridButton.Text = "Reset grid";
            ResetGridButton.UseVisualStyleBackColor = false;
            ResetGridButton.Click += ResetGridClick;
            // 
            // SpeedTimer
            // 
            SpeedTimer.Tick += Next;
            // 
            // StartButton
            // 
            StartButton.BackColor = Color.White;
            StartButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartButton.ForeColor = Color.Black;
            StartButton.Location = new Point(5, 110);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(100, 100);
            StartButton.TabIndex = 1;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = false;
            StartButton.Click += StartButtonClick;
            // 
            // StepButton
            // 
            StepButton.BackColor = Color.White;
            StepButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StepButton.ForeColor = Color.Black;
            StepButton.Location = new Point(110, 110);
            StepButton.Name = "StepButton";
            StepButton.Size = new Size(100, 100);
            StepButton.TabIndex = 2;
            StepButton.Text = "Step once";
            StepButton.UseVisualStyleBackColor = false;
            StepButton.Click += Next;
            // 
            // SpeedSlider
            // 
            SpeedSlider.LargeChange = 0;
            SpeedSlider.Location = new Point(5, 215);
            SpeedSlider.Maximum = 500;
            SpeedSlider.Minimum = 1;
            SpeedSlider.Name = "SpeedSlider";
            SpeedSlider.RightToLeft = RightToLeft.Yes;
            SpeedSlider.Size = new Size(205, 100);
            SpeedSlider.SmallChange = 0;
            SpeedSlider.TabIndex = 3;
            SpeedSlider.Value = 250;
            SpeedSlider.Scroll += AdjustSpeed;
            // 
            // PersistanceSlider
            // 
            PersistanceSlider.LargeChange = 0;
            PersistanceSlider.Location = new Point(5, 360);
            PersistanceSlider.Maximum = 16;
            PersistanceSlider.Minimum = 1;
            PersistanceSlider.Name = "PersistanceSlider";
            PersistanceSlider.Size = new Size(205, 100);
            PersistanceSlider.SmallChange = 0;
            PersistanceSlider.TabIndex = 4;
            PersistanceSlider.Value = 5;
            PersistanceSlider.Scroll += AdjustDeadCellPersistance;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.ForeColor = Color.Black;
            label1.Location = new Point(5, 325);
            label1.Name = "label1";
            label1.Size = new Size(204, 27);
            label1.TabIndex = 5;
            label1.Text = "/\\ Speed | persistance \\/";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(1231, 704);
            Controls.Add(label1);
            Controls.Add(PersistanceSlider);
            Controls.Add(SpeedSlider);
            Controls.Add(StepButton);
            Controls.Add(StartButton);
            Controls.Add(ResetGridButton);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Conway's game of life";
            ResumeLayout(false);
            PerformLayout();
            // this.MinimizeBox = false;
        }


        private Button ResetGridButton;
        private System.Windows.Forms.Timer SpeedTimer;
        private Button StartButton;
        private Button StepButton;
        private HScrollBar SpeedSlider;
        private HScrollBar PersistanceSlider;
        private Label label1;
    }
}
