using Godot;
using System;

public partial class player : AnimatableBody2D
{
	[Export]
	public float Speed = 500;

	[Export]
	public bool ControlledByPlayer;

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (ControlledByPlayer)
			MoveByPlayer(delta);
		else
			MoveByAi(delta);
	}

	private void MoveByAi(double delta)
	{
		var rand = Random.Shared.Next(0, 100);
		int input = rand > 50 ? (rand > 75 ? 1 : -1) : 0;
		if (input != 0)
			MoveAndCollide(new Vector2(0, input * Speed * (float)delta));
	}

	private void MoveByPlayer(double delta)
	{
		var input = Input.GetAxis("up", "down");
		if (input != 0)
			MoveAndCollide(new Vector2(0, input * Speed * (float)delta));
	}
}
