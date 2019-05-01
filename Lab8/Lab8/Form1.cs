using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lab8
{
  public enum Item
  {
    None,
    Food,
    Obstacle
  }

  public partial class Form1 : Form
  {
    private static Random _random = new Random();
    private Timer _timer;
    private Pacman _pacman;
    private Image _food;
    private Image _obstacle;
    private Item[][] _foodWorld;
    private static readonly int _interval = 250;
    private static readonly int _worldWidth = 15;
    private static readonly int _worldHeight = 10;

    public Form1()
    {
      InitializeComponent();

      _food = Properties.Resources.orange_icon;
      _obstacle = Properties.Resources.obstacle;
      DoubleBuffered = true;

      NewGame();
    }

    public void NewGame()
    {
      _pacman = new Pacman();

      Width = _pacman.Radius * 2 * (_worldWidth + 1);
      Height = _pacman.Radius * 2 * (_worldHeight + 1) + 50;

      _timer = new Timer();
      _timer.Interval = _interval;
      _timer.Tick += new EventHandler(TimerTick);

      _foodWorld = new Item[_worldHeight][];

      for (int i = 0; i < _worldHeight; i++)
      {
        _foodWorld[i] = new Item[_worldWidth];

        for (int j = 0; j < _worldWidth; j++)
          _foodWorld[i][j] = Item.Food;
      }

      SetObstacles();
      InitProgressBar();

      _timer.Start();
    }

    private void SetObstacles()
    {
      int obstacles = 1;

      while (obstacles <= 8)
      {
        int x = _random.Next(0, _worldWidth);
        int y = _random.Next(0, _worldHeight - 2);

        int[] obstacle = new int[3];

        for (int i = 0; i < 3; i++)
          obstacle[i] = y + i;

        bool available = true;

        for (int j = y; j < y + 3; j++)
        {
          if (
            _foodWorld[j][x] == Item.Obstacle || 
            _foodWorld[j + 1 >= _worldHeight ? _worldHeight - 1 : j + 1][x] == Item.Obstacle || 
            _foodWorld[j - 1 < 0 ? 0 : j - 1][x] == Item.Obstacle || 
            _foodWorld[j][x + 1 >= _worldWidth ? _worldWidth - 1 : x + 1] == Item.Obstacle || 
            _foodWorld[j][x - 1 < 0 ? 0 : x - 1] == Item.Obstacle)
          {
            available = false;
            break;
          }
        }

        if (!available)
          continue;

        for (int i = y; i < y + 3; i++)
          _foodWorld[i][x] = Item.Obstacle;

        obstacles++;
      }
    }

    private void TimerTick(object sender, EventArgs e)
    {
      int i = _pacman.Position.Y;
      int j = _pacman.Position.X;

      switch (_pacman.Direction)
      {
        case Direction.Up:
          if (_foodWorld[i - 1 < 0 ? 0 : i - 1][j] != Item.Obstacle)
            MoveTo(i, j);
          break;
        case Direction.Down:
          if (_foodWorld[i + 1 >= _worldHeight ? _worldHeight - 1 : i + 1][j] != Item.Obstacle)
            MoveTo(i, j);
          break;
        case Direction.Left:
          if (_foodWorld[i][j - 1 < 0 ? 0 : j - 1] != Item.Obstacle)
            MoveTo(i, j);
          break;
        case Direction.Right:
          if (_foodWorld[i][j + 1 >= _worldWidth ? _worldWidth - 1 : j + 1] != Item.Obstacle)
            MoveTo(i, j);
          break;
      }        

      Invalidate();
    }

    private void MoveTo(int x, int y)
    {
      _foodWorld[x][y] = Item.None;
      _pacman.Move(_worldWidth, _worldHeight);
      textBox1.Text = _foodWorld.SelectMany(a => a).Count(i => i == Item.None).ToString();
    }

    private void InitProgressBar()
    {
      progressBar1.Step = 1;
      progressBar1.Value = 0;
      progressBar1.Minimum = 0;
      progressBar1.Visible = true;
      progressBar1.Maximum = _foodWorld.SelectMany(x => x).Count(x => x == Item.Food);
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Left:
          _pacman.ChangeDirection(Direction.Left);
          break;
        case Keys.Up:
          _pacman.ChangeDirection(Direction.Up);
          break;
        case Keys.Right:
          _pacman.ChangeDirection(Direction.Right);
          break;
        case Keys.Down:
          _pacman.ChangeDirection(Direction.Down);
          break;
      }

      Invalidate();
    }

    private void Form1_Paint(object sender, PaintEventArgs e)
    {
      Graphics graphics = e.Graphics;

      graphics.Clear(Color.White);

      for (int i = 0; i < _foodWorld.Length; i++)
      {
        for (int j = 0; j < _foodWorld[i].Length; j++)
        {
          var point = new Point(j * _pacman.Radius * 2 + (_food.Height / 2), i * _pacman.Radius * 2 + (_food.Width / 2));

          if (_foodWorld[i][j] == Item.Food)
            graphics.DrawImageUnscaled(_food, point);

          if (_foodWorld[i][j] == Item.Obstacle)
            graphics.DrawImageUnscaled(_obstacle, point);
        }
      }

      _pacman.Draw(graphics);
    }

    private void TextBox1_TextChanged(object sender, EventArgs e)
    {
      progressBar1.PerformStep();
    }
  }
}
