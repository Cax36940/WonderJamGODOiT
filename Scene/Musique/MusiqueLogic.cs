using Godot;
using System;

public partial class MusiqueLogic : AudioStreamPlayer3D
{
	double songTime = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MainScene.getInstance().setBPM(85);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		songTime = this.GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix();
		songTime -= AudioServer.GetOutputLatency();
		if (songTime < 8){
			MainScene.getInstance().setIsBeat(false);
		}else if(songTime >55 && songTime <100){
			MainScene.getInstance().setIsBeat(false);
		}else {
			MainScene.getInstance().setIsBeat(true);
		}
	}
}
