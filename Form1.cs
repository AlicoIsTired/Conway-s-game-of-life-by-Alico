namespace _25_12_19_game_of_life
{
    public partial class Form1 : Form
    {
        const int gridSize = 30; // 30x30 grid
        const int cellSize = 25; // cell size
        int cellPersistance = 50;
        private readonly Color live_col = Color.MistyRose;
        private readonly Button[,] buttonArray = new Button[gridSize, gridSize];
        private readonly int[,] aliveArray = new int[gridSize, gridSize];
        public Form1()
        {
            InitializeComponent();
            SpeedTimer.Interval = SpeedSlider.Value;

            CreateGrid();
        } // move buttons around etc, initialise form
        private void ResetGridClick(object sender, EventArgs e)
        {
            SpeedTimer.Enabled = false;
            StepButton.Enabled = true;
            StartButton.BackColor = Color.White;
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Controls.Remove(buttonArray[i, j]);
                }
            }
            CreateGrid();
        } // reset grid button
        private void CreateGrid()
        {
            int x = 215;
            int y = 5;

            for (int row = 0; row < gridSize; row++)
            {
                x = 215;
                for (int column = 0; column < gridSize; column++)
                {
                    Button newb = new()
                    {
                        Top = y,
                        Left = x,
                        Height = cellSize,
                        Width = cellSize
                    };
#pragma warning disable CS8622 
                    newb.Click += new EventHandler(AnyButtonClick);
#pragma warning restore CS8622 
                    newb.BackColor = Color.White;
                    newb.FlatStyle = FlatStyle.Flat;
                    buttonArray[row, column] = newb;
                    aliveArray[row, column] = 0;

                    Controls.Add(newb);
                    x += cellSize;
                }
                y += cellSize;
            } // create the cell grid

        } // create the grid of cells
        private void AnyButtonClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int btnRow = -1;
            int btnColumn = -1;
            for (int rowBeingChecked = 0; rowBeingChecked < gridSize; rowBeingChecked++)
            {
                for (int columnBeingChecked = 0; columnBeingChecked < gridSize; columnBeingChecked++)
                {
                    if (buttonArray[rowBeingChecked, columnBeingChecked] == btn)
                    {
                        btnRow = rowBeingChecked;
                        btnColumn = columnBeingChecked;
                    }
                }
            } // find cell

            if (aliveArray[btnRow, btnColumn] != cellPersistance)
            {
                aliveArray[btnRow, btnColumn] = cellPersistance;
                btn.BackColor = live_col;
            } // set cell alive
            else
            {
                aliveArray[btnRow, btnRow] = cellPersistance;
                DeadCellColor(btnRow, btnColumn, true);

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
            for (int row = 0; row < gridSize; row++)
            {
                for (int column = 0; column < gridSize; column++)
                {
                    int liveNum = 0;
                    liveNum += Convert.ToInt16(CheckSquareLives(row - 1, column - 1));
                    liveNum += Convert.ToInt16(CheckSquareLives(row - 1, column));
                    liveNum += Convert.ToInt16(CheckSquareLives(row - 1, column + 1));

                    liveNum += Convert.ToInt16(CheckSquareLives(row, column - 1));

                    liveNum += Convert.ToInt16(CheckSquareLives(row, column + 1));

                    liveNum += Convert.ToInt16(CheckSquareLives(row + 1, column - 1));
                    liveNum += Convert.ToInt16(CheckSquareLives(row + 1, column));
                    liveNum += Convert.ToInt16(CheckSquareLives(row + 1, column + 1));

                    if (liveNum == 3)
                    {
                        aliveArray[row, column] = cellPersistance;
                    } // spawn new cell
                    else if (aliveArray[row, column] == cellPersistance && (liveNum < 2 || liveNum > 3))
                    {
                        aliveArray[row, column] = cellPersistance - 1;
                    } // kill cell
                }
            } // deciding which cells to kill/resurrect
            for (int row = 0; row < gridSize; row++)
            {
                for (int column = 0; column < gridSize; column++)
                {
                    if (aliveArray[row, column] == cellPersistance)
                    {
                        buttonArray[row, column].BackColor = live_col;
                    }
                    else
                    {
                        DeadCellColor(row, column, true);
                    }
                }
            } // update the visible grid to match the bool grid
        } // next generation, this is also used for the step button

        private void DeadCellColor(int row, int column, bool decay)
        {
            int colorValue = 255 - (40 * aliveArray[row, column] / cellPersistance);
            buttonArray[row, column].BackColor = Color.FromArgb(colorValue, colorValue, colorValue);
            if (decay && aliveArray[row, column] > 0)
            {
                aliveArray[row, column]--;
            }
        }
        private void StartButtonClick(object sender, EventArgs e)
        {
            if (SpeedTimer.Enabled == false)
            {
                StartButton.BackColor = live_col;
                SpeedTimer.Enabled = true;
                StepButton.Enabled = false;
                StepButton.ForeColor = Color.Gray;
            } // start timer
            else
            {
                StartButton.BackColor = Color.White;
                SpeedTimer.Enabled = false;
                StepButton.Enabled = true;
                StepButton.ForeColor = Color.Black;
            } // stop timer
        } // start button
        private void AdjustSpeed(object sender, ScrollEventArgs e)
        {
            SpeedTimer.Interval = SpeedSlider.Value;
        } // speed adjusting slider

        private void AdjustDeadCellPersistance(object sender, ScrollEventArgs e)
        {
            
            if (PersistanceSlider.Value != cellPersistance)
            {
                int oldPersistance = cellPersistance;
                cellPersistance = PersistanceSlider.Value;
                for (int row = 0; row < gridSize; row++)
                {
                    for (int column = 0; column < gridSize; column++)
                    {
                        aliveArray[row, column] = aliveArray[row, column] * PersistanceSlider.Value / oldPersistance;
                    }
                }
            }
        }
    }
}
