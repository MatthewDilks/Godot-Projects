using Godot;
using System;
using System.Collections.Generic;

public partial class SnakeListScript : Node2D
{
	bool dead;
	public List<Vector2I> snakeQueue;
	public int[,] grid;
	public Vector2I gridSize;
	public override void _Ready()
	{
		dead = false;
		Node2D parent = GetParent<Node2D>();
		GridScript gridScript = parent as GridScript;
		grid = gridScript.grid;
		gridSize = gridScript.gridSize;
		snakeQueue = new List<Vector2I>();
		snakeQueue.Add(gridSize/2);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
		Vector2I getInput() {
		Vector2I result = new Vector2I();
		if (Input.IsActionPressed("up")) {
			result.Y -= 1;
		}
		if (Input.IsActionPressed("down")) {
			result.Y += 1;
		}
		if (Input.IsActionPressed("left")) {
			result.X -= 1;
		}
		if (Input.IsActionPressed("right")) {
			result.X += 1;
		}
		return result;
	}
	void moveSnake(Vector2I dir) {
		snakeQueue.Add(snakeQueue[snakeQueue.Count-1]+dir); // 1 is snake, 2 is apple, 0 is empty
		int newPoint = grid[snakeQueue[snakeQueue.Count-1].X,snakeQueue[snakeQueue.Count-1].Y];
		if (newPoint == 0) {
			snakeQueue.RemoveAt(0);
		}
		else if (newPoint == 1) {
			dead = true;
		}
	}
}
