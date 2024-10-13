using Godot;
using System;

public partial class Border : Node3D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Node3D wall;
		
		for(int posX = 0; posX < 505; posX+=5){
			wall =(Node3D)GD.Load<PackedScene>("res://Scene/road/fence.tscn").Instantiate();
			wall.Set(Node3D.PropertyName.Position, new Vector3(8,0,-posX+5));
			this.AddChild(wall);
			wall =(Node3D)GD.Load<PackedScene>("res://Scene/road/fence.tscn").Instantiate();
			wall.Set(Node3D.PropertyName.Position, new Vector3(-8,0,-posX+5));
			this.AddChild(wall);
		}
		
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
