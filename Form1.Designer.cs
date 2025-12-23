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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ShowGrid = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            StartButton = new Button();
            StepButton = new Button();
            SuspendLayout();
            // 
            // ShowGrid
            // 
            ShowGrid.Font = new Font("Calibri", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ShowGrid.Location = new Point(5, 5);
            ShowGrid.Name = "ShowGrid";
            ShowGrid.Size = new Size(205, 100);
            ShowGrid.TabIndex = 0;
            ShowGrid.Text = "Reset grid";
            ShowGrid.UseVisualStyleBackColor = true;
            ShowGrid.Click += ResetGridClick;
            // 
            // timer1
            // 
            timer1.Tick += Next;
            // 
            // StartButton
            // 
            StartButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StartButton.ForeColor = SystemColors.ControlText;
            StartButton.Location = new Point(5, 110);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(100, 100);
            StartButton.TabIndex = 1;
            StartButton.Text = "Start";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButtonClick;
            // 
            // StepButton
            // 
            StepButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            StepButton.ForeColor = SystemColors.ControlText;
            StepButton.Location = new Point(110, 110);
            StepButton.Name = "StepButton";
            StepButton.Size = new Size(100, 100);
            StepButton.TabIndex = 2;
            StepButton.Text = "Step once";
            StepButton.UseVisualStyleBackColor = true;
            StepButton.Click += Next;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightCyan;
            ClientSize = new Size(1231, 704);
            Controls.Add(StepButton);
            Controls.Add(StartButton);
            Controls.Add(ShowGrid);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Conway's game of life";
            ResumeLayout(false);
            // this.MinimizeBox = false;
        }

        #endregion

        private Button ShowGrid;
        private System.Windows.Forms.Timer timer1;
        private Button StartButton;
        private Button StepButton;
    }
}
