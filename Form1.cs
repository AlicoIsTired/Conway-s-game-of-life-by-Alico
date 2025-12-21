namespace _25_12_19_game_of_life
{
    public partial class Form1 : Form
    {
        const int intsize = 30;
        const int intspace = 25;
        private Color live_col = Color.Black;
        private Color dead_col = Color.White;
        private Button[,] bs = new Button[intsize, intsize];
        private bool[,] b = new bool[intsize, intsize];
        public Form1()
        {
            InitializeComponent();
            ShowGrid.Location = new Point(intspace, intspace); // spawn button to grid to be size
            ShowGrid.Width = intspace * intsize;
            ShowGrid.Height = intspace * intsize;
            StartButton.Location = new Point(intspace*(intsize + 2), intspace);
            StartButton.Width = intspace * 10;
            StartButton.Height = intspace * 3;

        }
        private void ShowGrid_Click(object sender, EventArgs e) // make grid
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
            }
            ShowGrid.Visible = false;
        }
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
            }

            if (fx == -1 || fy == -1)
            {
                MessageBox.Show("BUTTON NOT FOUND!!!");
            }
            else
            {
                b[fx, fy] = !b[fx, fy];
                if (b[fx, fy])
                {
                    btn.BackColor = live_col;
                }
                else
                {
                    btn.BackColor = dead_col;
                }
            }
        }

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
        }

        private void timer1_Tick(object sender, EventArgs e)
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
                    }
                    else if (liveNum < 2 || liveNum > 3)
                    {
                        b[i, j] = false;
                    }
                }
            }
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
        }   }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (ShowGrid.Visible == false)
            {
                if (timer1.Enabled == false)
                {
                    StartButton.BackColor = Color.LightGray;
                    timer1.Enabled = true; 
                }
                else
                {

                    StartButton.BackColor = Color.White;
                    timer1.Enabled = false; 
                }
            }
        }
    }
}
