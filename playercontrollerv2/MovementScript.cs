using Godot;
using System;
using System.Numerics;

public partial class MovementScript : Node3D
{
	public RigidBody3D parentToMove;
	DataScript parentScript;
	[Export]
	public float speed;
	[Export]
	public float maxSpeed;
	[Export]
	public float threshold;
	public bool moved;
	public float currentSpeed;
	public override void _Ready()
	{
		parentScript = GetParent<DataScript>();
		parentToMove = GetParent<RigidBody3D>();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		moved = false;
		Godot.Vector2 movement = wasdInput();
		parentToMove.ApplyCentralForce(new Godot.Vector3(movement.X*speed, 0, movement.Y*speed));
		currentSpeed = parentToMove.LinearVelocity.Length();
		if (currentSpeed > maxSpeed) {
			parentToMove.LinearVelocity = parentToMove.LinearVelocity.Normalized() * maxSpeed;
		}
		else if (moved == false && currentSpeed < threshold) {
			parentToMove.LinearVelocity = Godot.Vector3.Zero;
		}
		parentScript.moved = moved;
		GD.Print(1/delta);

	}
	private Godot.Vector2 wasdInput() {
		Godot.Vector2 output = Godot.Vector2.Zero;
		Godot.Vector3 forward = -parentToMove.Transform.Basis.Z;
		Godot.Vector3 left = -parentToMove.Transform.Basis.X;
		
		Godot.Vector2 forward2 = new Godot.Vector2(forward.X,forward.Z);
		Godot.Vector2 left2 = new Godot.Vector2(left.X,left.Z);
		
		if (Input.IsActionPressed("forward")) {
			output += forward2;
			moved = true;
		}
		if (Input.IsActionPressed("left")) {
			output += left2;
			moved = true;
		}
		if (Input.IsActionPressed("backward")) {
			output -= forward2;
			moved = true;
		}
		if (Input.IsActionPressed("right")) {
			output -= left2;
			moved = true;
		}
		return output.Normalized();
	}
}
