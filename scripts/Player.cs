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
			// Snaps the mouse position to the grid and moves the player there
	public void GetMousePositionOnGridAndMove()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;
		int x = Mathf.RoundToInt(localMouse.X / GridSize);
		int y = Mathf.RoundToInt(localMouse.Y / GridSize);
		var snappedPosition = new Vector2(x * GridSize, y * GridSize);
		Position = snappedPosition;
	}
};
		this.AddChild(_timer);

		base._Ready();
		// Snaps the mouse position to the grid and moves the player there
	public void GetMousePositionOnGridAndMove()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;
		int x = Mathf.RoundToInt(localMouse.X / GridSize);
		int y = Mathf.RoundToInt(localMouse.Y / GridSize);
		var snappedPosition = new Vector2(x * GridSize, y * GridSize);
		Position = snappedPosition;
	}
}

	public override void _Process(double dt)
	{
		base._Process(dt);
		if (Engine.IsEditorHint()) return;
		Move();
		// Snaps the mouse position to the grid and moves the player there
	public void GetMousePositionOnGridAndMove()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;
		int x = Mathf.RoundToInt(localMouse.X / GridSize);
		int y = Mathf.RoundToInt(localMouse.Y / GridSize);
		var snappedPosition = new Vector2(x * GridSize, y * GridSize);
		Position = snappedPosition;
	}
}


	private void Move()
	{
		if (_timer.TimeLeft != 0) return;
		_timer.Start();

		var movement = new Vector2();
		
		if (Input.IsActionPressed("up"))
		{
			movement.Y -= _moveDistance;
			// Snaps the mouse position to the grid and moves the player there
	public void GetMousePositionOnGridAndMove()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;
		int x = Mathf.RoundToInt(localMouse.X / GridSize);
		int y = Mathf.RoundToInt(localMouse.Y / GridSize);
		var snappedPosition = new Vector2(x * GridSize, y * GridSize);
		Position = snappedPosition;
	}
} 
		
		if (Input.IsActionPressed("down"))
		{
			movement.Y  += _moveDistance;
			// Snaps the mouse position to the grid and moves the player there
	public void GetMousePositionOnGridAndMove()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;
		int x = Mathf.RoundToInt(localMouse.X / GridSize);
		int y = Mathf.RoundToInt(localMouse.Y / GridSize);
		var snappedPosition = new Vector2(x * GridSize, y * GridSize);
		Position = snappedPosition;
	}
}

		if (Input.IsActionPressed("left"))
		{
			movement.X -= _moveDistance;
			// Snaps the mouse position to the grid and moves the player there
	public void GetMousePositionOnGridAndMove()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;
		int x = Mathf.RoundToInt(localMouse.X / GridSize);
		int y = Mathf.RoundToInt(localMouse.Y / GridSize);
		var snappedPosition = new Vector2(x * GridSize, y * GridSize);
		Position = snappedPosition;
	}
}

		if (Input.IsActionPressed("right"))
		{
			movement.X += _moveDistance;
			// Snaps the mouse position to the grid and moves the player there
	public void GetMousePositionOnGridAndMove()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;
		int x = Mathf.RoundToInt(localMouse.X / GridSize);
		int y = Mathf.RoundToInt(localMouse.Y / GridSize);
		var snappedPosition = new Vector2(x * GridSize, y * GridSize);
		Position = snappedPosition;
	}
}

		var actualMovement = movement * GridSize;
		Position += actualMovement;
		// Snaps the mouse position to the grid and moves the player there
	public void GetMousePositionOnGridAndMove()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;
		int x = Mathf.RoundToInt(localMouse.X / GridSize);
		int y = Mathf.RoundToInt(localMouse.Y / GridSize);
		var snappedPosition = new Vector2(x * GridSize, y * GridSize);
		Position = snappedPosition;
	}
}
	// Snaps the mouse position to the grid and moves the player there
	public void GetMousePositionOnGridAndMove()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;
		int x = Mathf.RoundToInt(localMouse.X / GridSize);
		int y = Mathf.RoundToInt(localMouse.Y / GridSize);
		var snappedPosition = new Vector2(x * GridSize, y * GridSize);
		Position = snappedPosition;
	}
}
