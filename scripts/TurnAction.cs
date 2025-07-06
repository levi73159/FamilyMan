using Godot;

namespace FamilyMan;

public readonly record struct TurnAction(ActionType Type, Vector2I Tile);

public enum ActionType
{
    Attack,
    Move,
}