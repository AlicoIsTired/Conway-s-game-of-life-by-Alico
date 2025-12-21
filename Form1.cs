namespace _25_12_19_game_of_life
{
    public partial class Form1 : Form
    {
        const int intsize = 30;
        const int intspace = 25;
        const int buttonwidth = 300;
        const int buttonheight = 90;
        private Color live_col = Color.Black;
        private Color dead_col = Color.White;
        private Button[,] bs = new Button[intsize, intsize];
        private bool[,] b = new bool[intsize, intsize];
        public Form1()
        {
            this.Width = 2;
            InitializeComponent();
            ShowGrid.Location = new Point(intspace, intspace); // spawn button to grid to be size
            ShowGrid.Width = intspace * intsize;
            ShowGrid.Height = intspace * intsize;

            StartButton.Location = new Point(intspace * (intsize + 2), intspace); // start button position and size
            StartButton.Width = buttonwidth;
            StartButton.Height = buttonheight;

            StepButton.Location = new Point(intspace * (intsize + 2), intspace * 2 + buttonheight); // step button position and size
            StepButton.Width = buttonwidth;
            StepButton.Height = buttonheight;

        } // move buttons around etc

        private void ResizeDetected(object sender, EventArgs e)
        {
            MessageBox.Show("Resize detected"); // temp
        } // TODO: resize cell grid with window, and toridal array is needed 
        private void ShowGrid_Click(object sender, EventArgs e)
        {
            int x = intspace;
            int y = intspace;

            for (int i = 0; i < intsize; i++)
            {
                x = intspace;
                for (int j = 0; j < intsize; j++)
                {
                    Button newb = new Button();
                    newb.Top = y;
                    newb.Left = x;
                    newb.Height = intspace;
                    newb.Width = intspace;
                    newb.Click += new EventHandler(AnyButtonClick);
                    newb.BackColor = dead_col;
                    newb.FlatStyle = FlatStyle.Flat;
                    bs[i, j] = newb;
                    b[i, j] = false;
                    this.Controls.Add(newb);
                    x += intspace;
                }
                y += intspace;
            } // create the cell grid

            ShowGrid.Visible = false; // remove the buttton that creates the grid
        } // create the grid of cells
        private void AnyButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int fx = -1;
            int fy = -1;
            for (int x = 0; x < intsize; x++)
            {
                for (int y = 0; y < intsize; y++)
                {
                    if (bs[x, y] == btn)
                    {
                        fx = x;
                        fy = y;
                    }
                }
            } // find cell

            b[fx, fy] = !b[fx, fy];
            if (b[fx, fy])
            {
                btn.BackColor = live_col;
            } // set cell alive
            else
            {
                btn.BackColor = dead_col;
                
            } // kill cell
        } // player killing/resurrecting cells

        private bool CheckSquareLives(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < intsize && y < intsize)
            {
                if (bs[x, y].BackColor == live_col)
                {
                    return true;
                }
            } 
            return false;
        } // see if cell is alive, by checking the visible (button) grid

        private void Next(object sender, EventArgs e)
        {
            for (int i = 0; i < intsize; i++)
            {
                for (int j = 0; j < intsize; j++)
                {
                    int liveNum = 0;
                    liveNum += Convert.ToInt16(CheckSquareLives(i - 1, j - 1));
                    liveNum += Convert.ToInt16(CheckSquareLives(i - 1, j));
                    liveNum += Convert.ToInt16(CheckSquareLives(i - 1, j + 1));

                    liveNum += Convert.ToInt16(CheckSquareLives(i, j - 1));

                    liveNum += Convert.ToInt16(CheckSquareLives(i, j + 1));

                    liveNum += Convert.ToInt16(CheckSquareLives(i + 1, j - 1));
                    liveNum += Convert.ToInt16(CheckSquareLives(i + 1, j));
                    liveNum += Convert.ToInt16(CheckSquareLives(i + 1, j + 1));

                    if (liveNum == 3)
                    {
                        b[i, j] = true;
                    } // spawn new cell
                    else if (liveNum < 2 || liveNum > 3)
                    {
                        b[i, j] = false;
                    } // kill cell
                }
            } // deciding which cells to kill/resurrect
            for (int i = 0; i < intsize; i++)
            {
                for (int j = 0; j < intsize; j++)
                {
                    if (b[i, j])
                    {
                        bs[i, j].BackColor = live_col;
                    }
                    else
                    {
                        bs[i, j].BackColor = dead_col;
                    }
                }
            } // update the visible grid to match the bool grid
        } // next generation

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (ShowGrid.Visible == false) 
            {
                if (timer1.Enabled == false)
                {
                    StartButton.BackColor = Color.LightGray;
                    timer1.Enabled = true;
                } // start timer
                else
                {

                    StartButton.BackColor = Color.White;
                    timer1.Enabled = false;
                } // stop timer
            } // check if grid is made, by checking if the grid making button is visible
        } // start button
        private void StepOnce(object sender, EventArgs e)
        {
            if (ShowGrid.Visible == false) 
            {
                Next(sender, e);
            } // check if grid is made, by checking if the grid making button is visible. Made, step once

        } // step once button
    }
}
