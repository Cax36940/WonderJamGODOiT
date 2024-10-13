using Godot;
using System;

public partial class Musique2 : AudioStreamPlayer3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MainScene.getInstance().setBPM(180);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
