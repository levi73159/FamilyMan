using System.Transactions;
using Godot;

namespace FamilyMan;

[Tool]
public partial class Player : TurnMovement
{
	private Timer _timer;

	[Export] private double _moveSpeed = 10.0f;
	[Export] private int _moveDistance = 1;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer = new Timer()
		{
			WaitTime = _moveSpeed,
			OneShot = true,
		};
		this.AddChild(_timer);

		base._Ready();
	}

	public override void _Process(double dt)
	{
		base._Process(dt);
		if (Engine.IsEditorHint()) return;
		Move();
	}


	private void Move()
	{
		if (_timer.TimeLeft != 0) return;
		_timer.Start();

		var movement = new Vector2();
		
		if (Input.IsActionPressed("up"))
		{
			movement.Y -= _moveDistance;
		} 
		
		if (Input.IsActionPressed("down"))
		{
			movement.Y  += _moveDistance;
		}

		if (Input.IsActionPressed("left"))
		{
			movement.X -= _moveDistance;
		}

		if (Input.IsActionPressed("right"))
		{
			movement.X += _moveDistance;
		}

		var actualMovement = movement * GridSize;
		Position += actualMovement;
	}
}
