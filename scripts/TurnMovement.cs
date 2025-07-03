using Godot;

namespace FamilyMan;

public abstract partial class TurnMovement : Area2D
{
    [Export] public Vector2I StartPosition { get; private set; }
    [Export] public bool IsActive = true;
    
    private float _gridSize = -1; // -1 mean not init

    private bool _isMouseHover = false;
    private bool _selected = false;

    protected float GridSize => _gridSize;
    

    public override void _Ready()
    {
		_gridSize = GetParent<TileMapLayer>().TileSet.TileSize.X;

		SnapToGrid();
    }

    public override void _Process(double delta)
    {
	    if (Engine.IsEditorHint()) SnapToGrid(true);
    }

    public void SnapToGrid(bool safeGuard=false)
	{
		if (safeGuard && _gridSize < 0)
		{
			_gridSize = GetParent<TileMapLayer>().TileSet.TileSize.X;
		}
		
		Position = Vector2.Zero;
		var posOffset = ((Vector2)StartPosition) * _gridSize;
		var halfGridSize = new  Vector2(_gridSize / 2, _gridSize / 2);
		Position += posOffset - halfGridSize;
	}

	public override void _MouseEnter() => _isMouseHover = true;
	public override void _MouseExit() => _isMouseHover = false;


	public override void _Input(InputEvent e)
	{
		if (!IsActive) return;

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
		}
	}

	public Vector2I GetMousePositionOnGrid()
	{
		var globalMouse = GetGlobalMousePosition();
		var localMouse = globalMouse + GetParent<Node2D>().Position;

		// snap the localMousePosition to one of the grid position
		
	}
}
