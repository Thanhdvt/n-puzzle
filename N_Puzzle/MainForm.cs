using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using N_Puzzle.Algorithms;
using System.Diagnostics;

namespace N_Puzzle
{
    public partial class MainForm : Form
    {
        private PictureBox[] myPictureBoxes;
        private Image[] myImages;
        private Controller controller;
        private int[] lastShufferState;
        public long LastMemoryUsage;

        public MainForm()
        {
            InitializeComponent();
            CenterToParent();
            controller = new Controller(this);
            cbSolveType.DataSource = Enum.GetValues(typeof(SolverType));
            InitGameView(3);
            Settings.OnSizeChanged += InitGameView;
            Control.CheckForIllegalCrossThreadCalls = false;
            trackBarSpeed.Maximum = Settings.DelayMoveArray.Length - 1;
            trackBarSpeed.Value = 2;
        }


        private Image[] SplitImageIntoGrid(Image source, int numRow, int numCol)
        {
            var res = new Image[numRow * numCol + 1];
            res[0] = Properties.Resources.black;
            Size imgSize = new Size(source.Size.Width / numCol, source.Size.Height / numRow);
            for (int i = 0; i < numRow; i++)
            {
                for (int j = 0; j < numCol; j++)
                {
                    int index = i * numRow + j + 1;
                    res[index] = new Bitmap(imgSize.Width, imgSize.Height);
                    var graphics = Graphics.FromImage(res[index]);
                    graphics.DrawImage(source, new Rectangle(new Point(0, 0), imgSize),
                        new Rectangle(new Point(j * imgSize.Width, i * imgSize.Height), imgSize), GraphicsUnit.Pixel);
                    graphics.Dispose();
                }
            }

            return res;
        }

        private void InitGameView(int gridSize)
        {
            grbGameView.Controls.Clear();

            myImages = SplitImageIntoGrid(Properties.Resources.original, gridSize, gridSize);
            myImages[myImages.Length - 1] = Properties.Resources.black;

            myPictureBoxes = new PictureBox[gridSize * gridSize];
            int imgSize = Settings.GameViewSize / gridSize;
            for (int i = 0; i < myPictureBoxes.Length; i++)
            {
                myPictureBoxes[i] = new PictureBox();
                grbGameView.Controls.Add(myPictureBoxes[i]);
                myPictureBoxes[i].Location = new Point((i % gridSize) * imgSize + 13, (i / gridSize) * imgSize + 15);
                myPictureBoxes[i].Size = new Size(imgSize - 2, imgSize - 2);
                myPictureBoxes[i].TabIndex = 0;
                myPictureBoxes[i].SizeMode = PictureBoxSizeMode.StretchImage;
                myPictureBoxes[i].TabStop = false;
            }

            lastShufferState = Settings.StartState;
            UpdateGameView(Settings.StartState);
        }

        private void UpdateGameView(int[] array)
        {
            controller.CurrentState = array;
            for (int i = 0; i < array.Length && i < myPictureBoxes.Length; i++)
            {
                myPictureBoxes[i].Image = myImages[array[i]];
            }
        }

        public void PerformMoves(List<int[]> moves)
        {
            for (int i = 0; i < moves.Count; i++)
            {
                UpdateGameView(moves[i]);
                Thread.Sleep(Settings.DelayMove);
            }
        }

        private void StartSolving()
        {
            panel1.Enabled = false;
            btnStopSolving.Enabled = true;
            LastMemoryUsage = GetMemoryUsage();
            controller.Solve((SolverType)cbSolveType.SelectedItem, controller.CurrentState, Settings.DefaultGoalState, () => EndSolving());
        }

        private void EndSolving()
        {
            panel1.Enabled = true;
            GC.Collect();
            btnStopSolving.Enabled = false;
            UpdateGameView(Settings.StartState);
        }

        private void StopSolving()
        {
            controller.StopSolving();
        }

        public void Log(string log)
        {
            //Console.WriteLine(log);
            label4.Text = log;
        }

        public long GetMemoryUsage()
        {
            Process proc = Process.GetCurrentProcess();
            proc.Refresh();
            return proc.PrivateMemorySize64;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.W:
                    MoveUp();
                    break;
                case Keys.S:
                    MoveDown();
                    break;
                case Keys.A:
                    MoveLeft();
                    break;
                case Keys.D:
                    MoveRight();
                    break;
            }
            //Utils.Print(controller.CurrentState);
            UpdateGameView(controller.CurrentState);
        }

        public void MoveUp()
        {
            if (Utils.TryMove(new Node(controller.CurrentState), MoveDirection.Up, out Node nextNode))
            {
                controller.CurrentState = nextNode.state;
            }
        }

        public void MoveDown()
        {
            if (Utils.TryMove(new Node(controller.CurrentState), MoveDirection.Down, out Node nextNode))
            {
                controller.CurrentState = nextNode.state;
            }
        }

        public void MoveLeft()
        {
            if (Utils.TryMove(new Node(controller.CurrentState), MoveDirection.Left, out Node nextNode))
            {
                controller.CurrentState = nextNode.state;
            }
        }

        public void MoveRight()
        {
            if (Utils.TryMove(new Node(controller.CurrentState), MoveDirection.Right, out Node nextNode))
            {
                controller.CurrentState = nextNode.state;
            }
        }

        private void trackBarSpeed_Scroll(object sender, EventArgs e)
        {
            var trackBar = (TrackBar)sender;
            if (trackBar.Value >= 0 && trackBar.Value < Settings.DelayMoveArray.Length)
            {
                Settings.DelayMove = Settings.DelayMoveArray[trackBar.Value];
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var memUsage = GetMemoryUsage() / 1024 / 1024;
            if (memUsage > 500)
            {
                Log("Out of memory! Can not solve");
                controller.StopSolving();
            }
            label3.Text = $"Ram: {memUsage} MB";
        }

        private void btnShuffer_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbShufferItters.Text, out int num))
            {
                var state = Settings.DefaultGoalState;
                var newState = Utils.Shuffle(state, num);
                lastShufferState = newState;
                UpdateGameView(newState);
            }
        }

        private void btnLastShufferState_Click(object sender, EventArgs e)
        {
            if (lastShufferState != null)
            {
                UpdateGameView(lastShufferState);
            }
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            StartSolving();
        }

        private void btnSetSize_Click(object sender, EventArgs e)
        {
            if (int.TryParse(tbGridSize.Text, out int num) && num <= Settings.MaxSize && num > 1)
            {
                Settings.Size = num;
            }
        }

        private void btnStopSolving_Click(object sender, EventArgs e)
        {
            StopSolving();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GC.Collect();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    var state = Utils.Shuffle(Settings.DefaultGoalState, 1000);
                    for (int j = 0; j < state.Length; j++)
                    {
                        Console.Write(state[j] + ",");
                    }
                    Console.WriteLine();


                    for (int j = 0; j < 5; j++)
                    {
                        SolverType solverType = (SolverType)j;
                        Console.WriteLine(solverType.ToString());
                        controller.Solve(solverType, state, Settings.DefaultGoalState, showMove: false);
                        Thread.Sleep(2000);
                    }

                    //Console.WriteLine();
                    //Console.WriteLine("AStar_Manhattan");
                    //controller.Solve(SolverType.AStar_Manhattan, state, Settings.DefaultGoalState, showMove: false);
                    //Thread.Sleep(1000);
                    //Console.WriteLine("AStar_MisplacedTiles");
                    //controller.Solve(SolverType.AStar_MisplacedTiles, state, Settings.DefaultGoalState, showMove: false);
                    //Thread.Sleep(1000);
                    //Console.WriteLine("BFS");
                    //controller.Solve(SolverType.BFS, state, Settings.DefaultGoalState, showMove: false);
                    //Thread.Sleep(3000);
                    //Console.WriteLine("DFS");
                    //controller.Solve(SolverType.DFS, state, Settings.DefaultGoalState, showMove: false);
                    //Thread.Sleep(3000);
                    //Console.WriteLine("DLS");
                    //controller.Solve(SolverType.DLS, state, Settings.DefaultGoalState, showMove: false);
                    //Thread.Sleep(3000);
                }
            })
            { IsBackground = true }.Start();
        }
    }
}
