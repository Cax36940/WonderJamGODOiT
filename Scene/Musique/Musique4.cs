using Godot;
using System;

public partial class Musique4 : AudioStreamPlayer3D
{
	double songTime;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		songTime = this.GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix();
		songTime -= AudioServer.GetOutputLatency();
		if(songTime < 13){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 13 && songTime< 27){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime >27 && songTime< 80){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime >80 && songTime< 90){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime > 90 && songTime< 105){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 105){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
			
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
