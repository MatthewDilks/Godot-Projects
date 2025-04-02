using Godot;
using System;

public partial class RayScript : Node3D
{
	private RayCast3D raycast;
    [Export]
    public CollisionShape3D self;
    [Export]
    public MeshInstance3D sphere;

    public override void _Ready()
    {
        // Get the RayCast node
        raycast = GetNode<RayCast3D>("RayCast3D");
        raycast.ExcludeParent = true;
        // raycast.AddException(self);
        raycast.TargetPosition = -Transform.Basis.Z*100;
        // sphere = GetNode<MeshInstance3D>("MeshInstance3D");
        GD.Print();
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
        raycast.ForceRaycastUpdate();
        if (raycast.IsColliding())
        {
            sphere.Position = raycast.GetCollisionPoint();
        }
        GD.Print((-raycast.GetCollisionPoint()+self.Position).Length());
	}
}
