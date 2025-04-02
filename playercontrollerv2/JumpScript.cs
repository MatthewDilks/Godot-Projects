using Godot;
using System;

public partial class JumpScript : Node3D
{
	RigidBody3D parent;
	[Export]
	public float JumpForce;
	[Export]
	public float JumpThreshold;
	[Export]
	public float forwardsjumpForce;
	public double TimeSinceLastJump;
	GroundDetectionScript GroundLocFetch;
	public override void _Ready()
	{
		parent = GetParent<RigidBody3D>();
		// RayCast3D sibling = parent.GetNode<RayCast3D>("groundDetector");
		GroundLocFetch = parent.GetNode<GroundDetectionScript>("GroundDetector");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		TimeSinceLastJump -= delta;

		Godot.Vector3 forward = -parent.Transform.Basis.Z;

		// GD.Print((GroundLocFetch.ClosestPointBelow-parent.Position).Length());
		
		float distToGround = (GroundLocFetch.ClosestPointBelow-parent.Position).Length();

		if (distToGround < JumpThreshold) {
			// parent.GravityScale = 0;
			parent.LinearVelocity = new Vector3(parent.LinearVelocity.X, 0,parent.LinearVelocity.Z);
		}
		else {
			parent.ApplyCentralForce(new Vector3(0,-10,0));
		}

		if (distToGround < JumpThreshold && Input.IsActionJustPressed("jump")) {
			parent.ApplyCentralForce(new Vector3(0,JumpForce,0));
			parent.ApplyCentralForce(forward * forwardsjumpForce);
		}
		
	}
}
