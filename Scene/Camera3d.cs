using Godot;
using System;

public partial class Camera3d : Camera3D
{
	Vector3 ReferencePoint = new Vector3(0, 2.6f, 0);
	Vector3 StartPoint = new Vector3(0, 4.5f, 3.8f);
	
	float CurrentSpeed;
	float Increment;
	
	float fovInitial = 100;
	float minFov = 60;
		
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Increment = 0;
		this.Set(Camera3D.PropertyName.Fov, fovInitial);
		this.Far = 10000.0f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if((MainScene.getInstance().istransition()) && (MainScene.getInstance().getTransitionTime() <= 0)){
			GD.Print("Dit mention !");
			this.Set(Node3D.PropertyName.Position, StartPoint);
		}else{
			
		}
		Increment += MainScene.getInstance().getSpeed() - CurrentSpeed;
		CurrentSpeed = MainScene.getInstance().getSpeed();
		
		this.Set(Camera3D.PropertyName.Fov, minFov + 0.4f*(100/((Increment)/8)));
		
		
		Vector3 pos =(Vector3) this.Get(Node3D.PropertyName.Position);		
		GD.Print(pos.X + " " + pos.Y + " " + pos.Z + " " + Increment);
		
		Vector3 diff = pos - ReferencePoint;
		
		if(pos.Z <= 11.5){
			pos.Z += 0.00005f*(Increment);
		}else if(pos.Y >= 2.6){
			pos.Y -= 0.00001f*(Increment);
		}
		
			
		this.Set(Node3D.PropertyName.Position, pos);
		
		Vector3 rot = (Vector3) this.Get(Node3D.PropertyName.Rotation);
		
		rot.X = (float)Math.Asin(-(diff.Y / diff.Z));
		
		this.Set(Node3D.PropertyName.Rotation, rot);
	}
	
	
}
