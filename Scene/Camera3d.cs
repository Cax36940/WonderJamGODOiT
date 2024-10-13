using Godot;
using System;

public partial class Camera3d : Camera3D
{
	Vector3 ReferencePoint = new Vector3(0, 2.6f, 0); 
	
	float fovInitial = 100;
	float minFov = 60;
		
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Set(Camera3D.PropertyName.Fov, fovInitial);
		this.Far = 10000.0f;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Set(Camera3D.PropertyName.Fov, minFov + 0.4f*(100/(MainScene.getInstance().getBaseSpeed()/8)));
		
		
		Vector3 pos =(Vector3) this.Get(Node3D.PropertyName.Position);		
		
		Vector3 diff = pos - ReferencePoint;
		
		if(pos.Z <= 11.5){
			pos.Z += 0.00005f*(MainScene.getInstance().getBaseSpeed());
		}else if(pos.Y >= 2.6){
			pos.Y -= 0.00001f*(MainScene.getInstance().getBaseSpeed());
		}
		
			
		this.Set(Node3D.PropertyName.Position, pos);
		
		Vector3 rot = (Vector3) this.Get(Node3D.PropertyName.Rotation);
		
		rot.X = (float)Math.Asin(-(diff.Y / diff.Z));
		
		this.Set(Node3D.PropertyName.Rotation, rot);
	}
	
	
}
