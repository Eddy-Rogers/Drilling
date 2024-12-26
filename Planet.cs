using Godot;
using System;

public partial class Planet : Node2D
{

	private TileMapLayer _tilemap;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_tilemap = GetNode<TileMapLayer>("PlanetTilemap");
		GD.Print("Test");
		Generate(100,100);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void Generate(int x, int y)
	{
		int xStart = 0 - (x / 2);
		int xEnd = x / 2;
		
		GD.Print(xStart);
		GD.Print(xEnd);

		for (int currentX = xStart; currentX <= xEnd; currentX++)
		{
			GD.Print(currentX);
			for (int currentY = 0; currentY < y; currentY++)
			{
				GD.Print(currentY);
				_tilemap.SetCell(new Vector2I(currentX, currentY), 0, new Vector2I(0, 0), 0);
			}
		}
	}
	
}
