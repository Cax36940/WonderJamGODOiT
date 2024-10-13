using Godot;
using System;

public partial class Musique2 : AudioStreamPlayer3D
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
		if(songTime < 18.1){
			MainScene.getInstance().setIsBeat(false);			
		}if(songTime > 18.1 && songTime< 114){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(90);
		}if(songTime >114 && songTime< 150){
			MainScene.getInstance().setIsBeat(false);				
		}if(songTime > 150 && songTime< 153){
			MainScene.getInstance().setIsBeat(false);		
		}if(songTime > 153 && songTime <195){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(90);
		}
	}
}
