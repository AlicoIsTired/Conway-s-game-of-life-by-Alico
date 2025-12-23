namespace _25_12_19_game_of_life
{
    public partial class Form1 : Form
    {
        const int gridSize = 30; // 30x30 grid
        const int cellSize = 25; // cell size
        const int spacing = 5; // spacing between buttons/grid
        const int buttonSize = 100; // size of buttons, some may be double this horizontally
        private readonly Color live_col = Color.MistyRose;
        private readonly Color dead_col = Color.White;
        private Button[,] buttonArray = new Button[gridSize, gridSize];
        private bool[,] boolArray = new bool[gridSize, gridSize];
        public Form1()
        {
            InitializeComponent();
            ShowGrid.Location = new Point(spacing, spacing); // show grid button position and size
            ShowGrid.Width = 2 * buttonSize + spacing;
            ShowGrid.Height = buttonSize;

            StartButton.Location = new Point(spacing, 2 * spacing + buttonSize); // start button position and size
            StartButton.Width = buttonSize;
            StartButton.Height = buttonSize;

            StepButton.Location = new Point(2 * spacing + buttonSize, 2 * spacing + buttonSize); // step button position and size
            StepButton.Width = buttonSize;
            StepButton.Height = buttonSize;

            Width = cellSize * (gridSize + 1) + 2 * buttonSize + 4 * spacing; // form size, the plus one is since the grid's actual size is gridsize + 1
            Height = (cellSize + 1) * (gridSize + 1) + (2 * spacing); // don't question why its cellSize + 1, I don't freaking know why its needed

        } // move buttons around etc, initialise form
        private void ShowGridClick(object sender, EventArgs e)
        {
            if (ShowGrid.Text == "Show grid")
            {
                CreateGrid(sender, e);
                ShowGrid.Text = "Reset grid";
                StartButton.Enabled = true;
                StepButton.Enabled = true;
            }
            //else
            //{
            //    buttonArray = new Button[gridSize, gridSize];
            //    boolArray = new bool[gridSize, gridSize];
            //    CreateGrid(sender, e);
            //} // TODO:                                   ------------------------------------------------------------------------------
        }
        private void CreateGrid(object sender, EventArgs e)
        {
            int x = 3 * spacing + 2 * buttonSize;
            int y = spacing;

            for (int i = 0; i < gridSize; i++)
            {
                x = 3 * spacing + 2 * buttonSize;
                for (int j = 0; j < gridSize; j++)
                {
                    Button newb = new Button();
                    newb.Top = y;
                    newb.Left = x;
                    newb.Height = cellSize;
                    newb.Width = cellSize;
                    newb.Click += new EventHandler(AnyButtonClick);
                    newb.BackColor = dead_col;
                    newb.FlatStyle = FlatStyle.Flat;
                    buttonArray[i, j] = newb;
                    boolArray[i, j] = false;

                    Controls.Add(newb);
                    x += cellSize;
                }
                y += cellSize;
            } // create the cell grid

        } // create the grid of cells
        private void AnyButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int fx = -1;
            int fy = -1;
            for (int x = 0; x < gridSize; x++)
            {
                for (int y = 0; y < gridSize; y++)
                {
                    if (buttonArray[x, y] == btn)
                    {
                        fx = x;
                        fy = y;
                    }
                }
            } // find cell

            boolArray[fx, fy] = !boolArray[fx, fy];
            if (boolArray[fx, fy])
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
            if (x < 0 || x >= gridSize || y < 0 || y >= gridSize)
            {
                if (x < 0)
                {
                    x = gridSize - 1;
                }
                else if (x >= gridSize)
                {
                    x = 0;
                }
                if (y < 0)
                {
                    y = gridSize - 1;
                }
                else if (y >= gridSize)
                {
                    y = 0;
                }
            } // wrap around edges if needed
            if (buttonArray[x, y].BackColor == live_col)
            {
                return true;
            } // check if cell is alive or dead
            return false;
        } // see if cell is alive, by checking the visible (button) grid, also handles wrapping
        private void Next(object sender, EventArgs e)
        {
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
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
                        boolArray[i, j] = true;
                    } // spawn new cell
                    else if (liveNum < 2 || liveNum > 3)
                    {
                        boolArray[i, j] = false;
                    } // kill cell
                }
            } // deciding which cells to kill/resurrect
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    if (boolArray[i, j])
                    {
                        buttonArray[i, j].BackColor = live_col;
                    }
                    else
                    {
                        buttonArray[i, j].BackColor = dead_col;
                    }
                }
            } // update the visible grid to match the bool grid
        } // next generation, this is also used for the step button
        private void StartButtonClick(object sender, EventArgs e)
        {
            if (ShowGrid.Text != "Show grid")
            {
                if (timer1.Enabled == false)
                {
                    StartButton.BackColor = live_col;
                    timer1.Enabled = true;
                    StepButton.ForeColor = Color.LightGray;
                    StepButton.Enabled = false;
                } // start timer, disable step button
                else
                {

                    StartButton.BackColor = Color.White;
                    timer1.Enabled = false;
                    StepButton.ForeColor = Color.Black;
                    StepButton.Enabled = true;
                } // stop timer, enable step button
            } // check if grid is made, by checking if the grid making button is visible
        } // start button
    }
}
