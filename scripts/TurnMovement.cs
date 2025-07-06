using System;
using System.Collections.Generic;
using Godot;

namespace FamilyMan;

public abstract partial class TurnMovement : Area2D
{
    [Export] public Vector2I StartPosition { get; private set; }
    public Vector2I GridPosition { get; private set; }

    [Export] private PackedScene _actionButtons;
    
    private float _gridSize = -1; // -1 mean not init
    private float _gridScale;

    protected float GridSize => _gridSize;
    private float GridSizeWithScale => _gridSize * _gridScale;

    protected Action<TurnAction> ActionExecute;

    private List<TurnAction> _actions = new();
    
    public TurnAction[] Actions => _actions.ToArray();

    public override void _Ready()
    {
        var parent = GetParent<TileMapLayer>();
        _gridSize = parent.TileSet.TileSize.X;
        _gridScale = parent.Scale.X;
        SnapToGrid(StartPosition);
    }

    public override void _Process(double delta)
    {
        if (Engine.IsEditorHint()) SnapToGrid(StartPosition, true);
    }

    public void SnapToGrid(Vector2I position, bool safeGuard=false)
    {
        if (safeGuard && _gridSize < 0)
        {
            var parent = GetParent();
            if (parent is not TileMapLayer tileMap) return;
            _gridSize = tileMap.TileSet.TileSize.X;
        }

        Position = GetRealPos(position);
        GridPosition = position;
    }
    
    public Vector2 GetRealPos(Vector2I position)
    {
        var posOffset = ((Vector2)position) * _gridSize;
        var halfGridSize = new  Vector2(_gridSize / 2, _gridSize / 2);
        return posOffset - halfGridSize;
    }

    // --- Action Management ---
    public void AddAction(TurnAction action)
    {
        _actions.Add(action);
    }

    public void ClearActions()
    {
        _actions.Clear();
    }

    public void ExecuteActions()
    {
        foreach (var action in _actions)
        {
            ActionExecute(action);
        }
        _actions.Clear();
    }

    public Vector2I GetMousePositionOnGrid()
    {
        var globalMouse = GetGlobalMousePosition();
        var localMouse = globalMouse + GetParent<Node2D>().Position;
        var snapped = new Vector2I(
            Mathf.CeilToInt(localMouse.X / GridSizeWithScale),
            Mathf.CeilToInt(localMouse.Y / GridSizeWithScale)
        );
        return snapped;
    }

}
