using Godot;
using System;

public partial class MovementScript : CharacterBody3D
{
	[Export]
	public float Speed = 5.0f;
	[Export]
	public float maxSpeed = 20.0f;
	[Export]
	public float gravity;
	[Export]
	public float JumpVelocity = 4.5f;
	public float drag = 0.95f;
	public bool moved;

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta * gravity;
		}

		if (Input.IsActionJustPressed("jump") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
		}

		Vector2 inputDir = Input.GetVector("left", "right", "forward", "backward");
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		moved = false;
		if (direction != Vector3.Zero)
		{
			moved = true;
			velocity.X += direction.X * Speed;
			velocity.Z += direction.Z * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, Speed);
		}
		if (velocity.Length() > maxSpeed) {
			velocity = velocity.Normalized()*maxSpeed;
		}

		velocity.X *= drag;
		velocity.Y *= drag;
		velocity.Z *= drag;

		Velocity = velocity;
		MoveAndSlide();
	}
}
