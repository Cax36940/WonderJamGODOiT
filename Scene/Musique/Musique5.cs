using Godot;
using System;

public partial class Musique5 : AudioStreamPlayer3D
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
		if(songTime < 25){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >30 && songTime <132){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(90);
		}if(songTime >132 && songTime <153){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >153 && songTime <237){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(90);
		}if(songTime >237 ){
			MainScene.getInstance().setIsBeat(false);
		}
	}
}
