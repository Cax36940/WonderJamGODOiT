using Godot;
using System;

public partial class Musique5 : AudioStreamPlayer3D
{
	double songTime;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		songTime = this.GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix();
		songTime -= AudioServer.GetOutputLatency();
		if(songTime < 10){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >10 && songTime <30){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(38);
		}if(songTime >30 && songTime <55){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >55 && songTime <75){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >75 && songTime <95){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >95 && songTime <130){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(80);
		}if(songTime >130 && songTime <140){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >140 && songTime <160){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >160 && songTime <180){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >180 && songTime <200){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >200 && songTime <222){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(80);
		}if(songTime >222 && songTime <245){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(80);
		}if(songTime >245){
			MainScene.getInstance().setIsBeat(false);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
