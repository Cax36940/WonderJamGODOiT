using Godot;
using System;

public partial class Musique4 : AudioStreamPlayer3D
{
	double songTime;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		songTime = this.GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix();
		songTime -= AudioServer.GetOutputLatency();
		if(songTime < 10.2){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >10.2 && songTime< 77){	
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(74);
		}if(songTime > 77 && songTime< 94){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >94 && songTime< 107){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(36);
		}if(songTime >107 && songTime< 135){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(74);
		}
	}
}
