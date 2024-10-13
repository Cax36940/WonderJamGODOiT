using Godot;
using System;

public partial class Musique3 : AudioStreamPlayer3D
{
	double songTime = 0;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		songTime = this.GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix();
		songTime -= AudioServer.GetOutputLatency();
		if(songTime < 12){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >12 && songTime <45){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(38);
		}if(songTime >45 && songTime <50){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >50 && songTime <95){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >95 && songTime <100){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >100 && songTime <153){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(80);
		}if(songTime >153 && songTime <180){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >180 && songTime <230){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >230 && songTime <255){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >255 && songTime <300){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >300 && songTime <305){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >305 && songTime <355){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(80);
		}
		
	}
}
