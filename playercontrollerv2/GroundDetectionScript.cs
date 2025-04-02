using Godot;
using System;

public partial class GroundDetectionScript : RayCast3D
{
	public DataScript parentScript;
	public Vector3 ClosestPointBelow;
	public override void _Ready()
	{
		parentScript = GetParent<DataScript>();
		Enabled = true;
        TargetPosition = new Vector3(0, -1, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (IsColliding()) {
			ClosestPointBelow = GetCollisionPoint();
			parentScript.DistToGround = ClosestPointBelow.Length();
		}
	}
}
