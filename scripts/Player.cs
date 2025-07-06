using System;
using Godot;

namespace FamilyMan;

[Tool]
public partial class Player : TurnMovement
{
	private Timer _timer;
	private bool _isMouseHover = false;
	private bool _selected = false;

	[Export] public float Hp { get; private set; } = 100;
	[Export] public float AttackDmg { get; private set; } = 25;
	
	[Export] public bool IsTurnBased = true; // Toggle for movement mode
	
	[Export] private double _moveSpeed = 10.0f;
	[Export] private int _moveDistance = 1;

	[Export] private PackedScene _actionButtons;

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
		if (!IsTurnBased && !Engine.IsEditorHint())
			DirectMove();
	   
	}

	public override void _Input(InputEvent e)
	{
		if (!IsTurnBased) return;

		if (e.IsActionPressed("submit"))
		{
			ExecuteActions();
			return;
		}

		if (e is not InputEventMouseButton btn) return;
		if (btn.ButtonIndex != MouseButton.Left || !btn.Pressed) return;

		if (!_selected)
		{
			if (!_isMouseHover) return;
			_selected = true;
			GetNode<Sprite2D>("Sprite2D").Modulate = Colors.Blue;
		}
		else
		{
			GetNode<Sprite2D>("Sprite2D").Modulate = Colors.Red;
			var movePosition = GetMousePositionOnGrid();
			var mousePos = GetGlobalMousePosition();

			// Instantiate and show action buttons
			var actionButtons = (ActionButtons)_actionButtons.Instantiate();
			actionButtons.GlobalPosition = mousePos;
			actionButtons.SetDataPos(movePosition);
			actionButtons.OnAttackPressed += OnAttackPressed;
			actionButtons.OnMovePressed += OnMovePressed;
			GetNode("/root").AddChild(actionButtons);
			_selected = false;
		}
	}

	private void DirectMove()
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
			movement.Y += _moveDistance;
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

	private void OnAttackPressed(Vector2I pos)
	{
		AddAction(new TurnAction(ActionType.Attack, pos));
	}

	private void OnMovePressed(Vector2I pos)
	{
		AddAction(new TurnAction(ActionType.Move, pos));
	}

	private void ActionExecute(TurnAction action)
	{
		switch (action.Type)
		{
			case ActionType.Attack:
				// get enemy on tile
				break;
			
			case ActionType.Move:
				SnapToGrid(action.Tile);
				break;
			
			default: throw new NotSupportedException();
		}
	}

	public override void _MouseEnter() => _isMouseHover = true;
	public override void _MouseExit() => _isMouseHover = false;
}
