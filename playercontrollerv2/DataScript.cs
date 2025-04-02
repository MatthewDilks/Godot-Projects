using Godot;
using System;

public partial class DataScript : RigidBody3D
{
	[Export]
	public float GroundHeight;
	public bool OnGround;
	public Node3D StandingOn;
	public bool moved;
	public float DistToGround;
	public float speed;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
