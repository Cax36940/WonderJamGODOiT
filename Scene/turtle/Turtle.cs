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
		
	
	}

	public override void _PhysicsProcess(double delta)
	{
		
		
		
		Vector3 pos =(Vector3) this.Get(Node3D.PropertyName.Position);

		pos.X += direction*Speed*(float) delta;
		
		int margin = 7;
		if (pos.X > margin){
			pos.X = margin;
		}else if (pos.X < -margin){
			pos.X =-margin;
		}
		
		this.Set(Node3D.PropertyName.Position, pos);
		
		direction = 0;
		
	}
	
	
	
	public void collideObject(Node3D area){
		GD.Print(area.Name);
		
		if (area.Name == "Bonus1"){
			MainScene.getInstance().addBonus(1);
			area.GetParent().Set(Node3D.PropertyName.Visible, false);
			
		}else if (area.Name == "Bonus2"){
			MainScene.getInstance().addBonus(2);
			area.GetParent().Set(Node3D.PropertyName.Visible, false);
			
		}else if(area.Name == "Bonus3"){
			MainScene.getInstance().addBonus(3);
			area.GetParent().Set(Node3D.PropertyName.Visible, false);
			
		}else{
			MainScene.getInstance().death();
		}
	}
	
}
