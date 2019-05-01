using System.Drawing;

namespace Lab8
{
  public enum Direction
  {
    Up,
    Down,
    Left,
    Right
  }

  public class Pacman
  {
    private const int _radius = 20;
    private Direction _direction { get; set; }
    public Position _position { get; private set; }
    private readonly int _velocity;
    private bool _mouthOpen { get; set; } = false;
    private Brush _brush = new SolidBrush(Color.Yellow);

    public Pacman()
    {
      _velocity = _radius;
      _direction = Direction.Right;
      _position = new Position { X = 7, Y = 5 };
    }

    public void ChangeDirection(Direction direction)
    {
      _direction = direction;
    }

    public void Move(int x, int y)
    {
      switch (_direction)
      {
        case Direction.Down:
          _position.Y = _position.Y == y - 1 ? 0 : _position.Y + 1;
          break;
        case Direction.Up:
          _position.Y = _position.Y == 0 ? y - 1 : _position.Y - 1;
          break;
        case Direction.Right:
          _position.X = _position.X == x - 1 ? 0 : _position.X + 1;
          break;
        case Direction.Left:
          _position.X = _position.X == 0 ? x - 1 : _position.X - 1;
          break;
      }

      _mouthOpen = !_mouthOpen;
    }

    public void Draw(Graphics graphics)
    {
      var rec = new Rectangle(Position.X * (_velocity * 2), Position.Y * (_velocity * 2), _radius * 2, _radius * 2);

      if (_mouthOpen)
      {
        switch (_direction)
        {
          case Direction.Left:
            graphics.FillPie(_brush, rec, 225, 270);
            break;
          case Direction.Right:
            graphics.FillPie(_brush, rec, 45, 270);
            break;
          case Direction.Up:
            graphics.FillPie(_brush, rec, 315, 270);
            break;
          case Direction.Down:
            graphics.FillPie(_brush, rec, 135, 270);
            break;
        }
      }
      else
      {
        graphics.FillEllipse(_brush, rec);
      }
    }

    public int Radius => _radius;

    public Position Position => _position;

    public Direction Direction => _direction;
  }
}
