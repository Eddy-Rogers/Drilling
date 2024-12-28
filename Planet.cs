using Godot;
using System;

public partial class Planet : Node2D
{
	private float _maxLayers = 3f;

	private int _maxX;
	private int _maxY;
	private TileMapLayer _tilemap;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_maxX = (int)GetMeta("MaxX");
		_maxY = (int)GetMeta("MaxY");
		
		_tilemap = GetNode<TileMapLayer>("PlanetTilemap");
		Generate();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Generate()
	{
		int xStart = 0 - (_maxX / 2);
		int xEnd = _maxX / 2;

		for (int currentX = xStart; currentX <= xEnd; currentX++)
		{
			for (int currentY = 0; currentY < _maxY; currentY++)
			{
				_tilemap.SetCell(new Vector2I(currentX, currentY), 0, DetermineTile(currentY), 0);
			}
		}
	}

	private Vector2I DetermineTile(int y)
	{
		// Upper: 0,0
		// Middle: 0,1
		// Lower: 0,2
		int currentLayer = (int)Math.Truncate(((float)y / (float)_maxY) * _maxLayers);
		
		return new Vector2I(0, currentLayer);
	}
	
}
