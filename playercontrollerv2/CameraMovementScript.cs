using Godot;
using System;
using System.Numerics;

public partial class CameraMovementScript : Camera3D
{
	[Export]
	public float turnSpeed;
	RigidBody3D parent;
	Godot.Vector2 mousePos;
	Godot.Vector2 windowSize;
	public bool mouseVisible;
	public override void _Ready()
	{
		mouseVisible = false;
		windowSize = DisplayServer.WindowGetSize();
		parent = GetParent<RigidBody3D>();
		Input.SetMouseMode(Input.MouseModeEnum.Captured);
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionJustPressed("quit")) {
			if (!mouseVisible) {
				Input.SetMouseMode(Input.MouseModeEnum.Visible);
			}
			else {
				Input.SetMouseMode(Input.MouseModeEnum.Captured);
			}
			mouseVisible = !mouseVisible;
		}
		
		float currentX = this.Rotation.X;
		currentX += -mousePos.Y*(float)delta*turnSpeed;
		
		float currentY = parent.Rotation.Y;
		currentY += -mousePos.X*(float)delta*turnSpeed;
		
		parent.Rotation = new Godot.Vector3(0,currentY,0);
		this.Rotation = new Godot.Vector3(currentX,0,0);
		
		mousePos = Godot.Vector2.Zero;
	}
	public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseMotion mouseMotion)
        {
            mousePos = mouseMotion.Relative;
        }
    }
}
