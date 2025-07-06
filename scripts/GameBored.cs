using System;
using Godot;

namespace FamilyMan.scenes;

public partial class GameBored : TileMapLayer
{
    public Vector2 GridSize => TileSet.TileSize;
    public float GridScale => Scale.X;
    
    public T GetNodeOnTile<T>(Vector2I tile) where T : class 
    {
        var children = GetChildren();
        foreach (var node in children)
        {
            if (node is TurnMovement tm )
            {
                if (tm.GridPosition != tile) continue;
                if (node is T t) return t;
                throw new InvalidCastException();
            }
            else if (node is Node2D n2d)
            {
                var tilePosition = CalculateTilePosition(n2d.GlobalPosition);
                if (tilePosition != tile) continue;
                if (node is T t) return t;
                throw new InvalidCastException();
            }
            else
            {
                throw new NotSupportedException("Must be a Node2D");
            }
        }

        return null;
    }

    public Vector2I CalculateTilePosition(Vector2 globalPos)
    {
        var localMouse = globalPos + Position;
        var snapped = new Vector2I(
            Mathf.CeilToInt(localMouse.X / (GridSize.X * GridScale)),
            Mathf.CeilToInt(localMouse.Y / (GridSize.Y * GridScale))
        );
        return snapped;
    }
}