using Godot;
using System;

public partial class Turtle : CharacterBody3D
{
	public float Speed = 20.0f;
	float direction ;

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
		
		this.Set(Node3D.PropertyName.Position, pos);
		
		direction = 0;
		
		
	}
	
	public void dimensionLeap(){
		
		MainScene.getInstance().setJauge(MainScene.getInstance().getJauge()+10);
		
	}
	
	public void collideObject(Node3D area){
		MainScene.getInstance().death();
	}
	
}
