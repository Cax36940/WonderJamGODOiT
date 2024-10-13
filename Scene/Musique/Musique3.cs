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
		if(songTime < 11.5){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >11.5 && songTime <44.5){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(38);
		}if(songTime >44.5 && songTime <50){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >50.5 && songTime <90){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >90 && songTime <199.5){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >99.5 && songTime <180){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >180 && songTime <232){
			MainScene.getInstance().setIsBeat(false);
		}if(songTime >232.5 && songTime <338){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(75);
		}if(songTime >338 ){
			MainScene.getInstance().setIsBeat(false);
		
		}
		
	}
}
