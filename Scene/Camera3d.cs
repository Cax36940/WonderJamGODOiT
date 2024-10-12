using Godot;
using System;

public partial class Camera3d : Camera3D
{
	Vector3 initialPosition = new Vector3(0,4.5f,3.8f) ;
	
	float fovInitial = 100;
	float minFov = 60;
		
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Set(Camera3D.PropertyName.Position, initialPosition);
		this.Set(Camera3D.PropertyName.Fov, fovInitial);
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Set(Camera3D.PropertyName.Fov, minFov + 0.4f*(100/(MainScene.getInstance().getSpeed()/10)));
		
		
				
	}
	
	
}
