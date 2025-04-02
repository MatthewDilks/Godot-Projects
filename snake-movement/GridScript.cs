using Godot;
using System;

public partial class GridScript : Node2D
{
	public int[,] grid;
	public int[,] lastGrid;
	[Export] public Sprite2D snakeQuad;
	[Export] public Sprite2D appleQuad;
	[Export] public Sprite2D emptyQuad;
	[Export] public Vector2I gridSize;
	public override void _Ready()
	{
		grid = new int[gridSize.X,gridSize.Y];
		lastGrid = new int[gridSize.X,gridSize.Y];
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (grid != lastGrid) {
			for (int i = 0; i < gridSize.X; i++) {
				for (int j = 0; j < gridSize.Y; j++) {
					int current = grid[i,j];
					
				}
			}
		}
	}
}
