using Godot;
using System;
using System.Linq;

public partial class ball : RigidBody2D
{
	[Export] public float Speed;

	public Vector2 Motion;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ApplyCentralImpulse(new Vector2(-1 * Speed, -1 * Speed));
	}

	public override void _PhysicsProcess(double delta)
	{
		var collid = MoveAndCollide(Vector2.Zero);
		var collider = collid?.GetCollider();
		if (collider is not null)
		{
			ApplyForce(-LinearVelocity);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
