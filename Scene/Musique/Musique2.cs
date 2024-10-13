using Godot;
using System;

public partial class Musique2 : AudioStreamPlayer3D
{
	double songTime;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		songTime = this.GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix();
		songTime -= AudioServer.GetOutputLatency();
		if(songTime < 20){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 20 && songTime< 43){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime >43 && songTime< 65){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime >65 && songTime< 88){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 88 && songTime< 106){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 106 && songTime< 130){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 130 && songTime< 150){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 150 && songTime< 173){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 173 && songTime< 197){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 197 && songTime< 218){
			MainScene.getInstance().setIsBeat(true);
			MainScene.getInstance().setBPM(85);
		}if(songTime > 218){
			MainScene.getInstance().setIsBeat(false);
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
