using System;
using System.Numerics;
using Godot;

namespace FamilyMan;

public partial class ActionButtons : Node2D
{
	// two events that can be called
	public event Action<Vector2I> OnAttackPressed;
	public event Action<Vector2I> OnMovePressed;
	
	// Data needed
	private Vector2I _position;

	public void SetDataPos(Vector2I position) => _position = position;

	private void AttackButtonPressed()
	{
		OnAttackPressed?.Invoke(_position);
		OnButtonPressed();
	}

	private void MoveButtonPressed()
	{
		OnMovePressed?.Invoke(_position);
		OnButtonPressed();
	}

	private void OnButtonPressed()
	{
		QueueFree();
	}
}