using Godot;
using System;

public partial class Turtle : CharacterBody3D
{
	public float Speed = 20.0f;
	float direction ;
	float timingForSpace = 0.5f ;
	float timeAfterSound = 0;
	float timingBPM = 3;
	float timeSinceLastSound = 0;
	int pointForJauge = 10;

	public override void _Process(double delta){
			
		
			
		if (Input.IsActionPressed("ui_right")){
			direction = 1;
		}
		if (Input.IsActionPressed("ui_left")){
			direction = -1;
		}
		if (Input.IsActionJustPressed("leap")){
			dimensionLeap();
		}
		
		if (timeSinceLastSound > timingBPM){
			timeAfterSound = timingForSpace;
			timeSinceLastSound=0;
			GD.Print("Space");
		}
		
		if (timeAfterSound > 0 ) {
			timeAfterSound-= (float)delta;
		}
		
		timeSinceLastSound+=(float)delta;
		
	}

	public override void _PhysicsProcess(double delta)
	{
		
		
		
		Vector3 pos =(Vector3) this.Get(Node3D.PropertyName.Position);

		pos.X += direction*Speed*(float) delta;
		
		if (pos.X > 6){
			pos.X =6;
		}else if (pos.X < -6){
			pos.X =-6;
		}
		
		this.Set(Node3D.PropertyName.Position, pos);
		
		direction = 0;
		
	}
	
	public void dimensionLeap(){
		
		
		if (timeAfterSound > 0){
			MainScene.getInstance().setJauge(MainScene.getInstance().getJauge()+pointForJauge);
			GD.Print("Tuuuurrbooooooo!!!!");
		}else {
			GD.Print("Not the time");
		}
	}
	
	public void collideObject(Node3D area){
		MainScene.getInstance().death();
	}
	
}
