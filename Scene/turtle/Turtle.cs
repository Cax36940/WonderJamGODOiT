using Godot;
using System;

public partial class Turtle : CharacterBody3D
{
	public float Speed = 20.0f;
	float direction ;
	
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
		
		
		if (MainScene.getInstance().getTimeAfterSound()> 0){
			MainScene.getInstance().setJauge(MainScene.getInstance().getJauge()+pointForJauge);
			GD.Print("Tuuuurrbooooooo!!!!");
		}else {
			GD.Print("Not the time");
		}
	}
	
	public void collideObject(Node3D area){
		GD.Print(area.Name);
		
		if (area.Name == "Bonus1"){
			MainScene.getInstance().addBonus(1);
			area.GetParent().QueueFree();
			
		}else if (area.Name == "Bonus2"){
			MainScene.getInstance().addBonus(2);
			area.GetParent().QueueFree();
			
		}else if(area.Name == "Bonus3"){
			MainScene.getInstance().addBonus(3);
			area.GetParent().QueueFree();
			
		}else{
			MainScene.getInstance().death();
		}
	}
	
}
