using Godot;
using System;

public partial class portal : Sprite3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Set(Node3D.PropertyName.Position, new Vector3(0,1,-200));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Vector3 pos =(Vector3) this.Get(Node3D.PropertyName.Position);		
			
		pos.Z =((5-MainScene.getInstance().getTransitionTime())*40)-200;
		
		this.Set(Node3D.PropertyName.Position,pos);
		
		Vector3 rotation =(Vector3)this.Get(Node3D.PropertyName.Rotation);
		
		rotation.Z-=3*(float)delta ;
		
		this.Set(Node3D.PropertyName.Rotation, rotation);
		
	}
}
