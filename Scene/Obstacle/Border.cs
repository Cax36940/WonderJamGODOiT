using Godot;
using System;

public partial class Border : Node3D
{
	int current_dimension = -1;
	Godot.Collections.Array<PackedScene> borderScene = new Godot.Collections.Array<PackedScene>();
	Godot.Collections.Array<float> borderDist = new Godot.Collections.Array<float>();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		borderScene.Add(GD.Load<PackedScene>("res://Scene/road/fence.tscn"));
		borderScene.Add(GD.Load<PackedScene>("res://Scene/road/world_2_fence.tscn"));
		borderScene.Add(GD.Load<PackedScene>("res://Scene/road/fence.tscn"));
		borderScene.Add(GD.Load<PackedScene>("res://Scene/road/fence.tscn"));
		borderScene.Add(GD.Load<PackedScene>("res://Scene/road/fence.tscn"));
		
		borderDist.Add(4.3f);
		borderDist.Add(2.62f);
		borderDist.Add(4.3f);
		borderDist.Add(4.3f);
		borderDist.Add(4.3f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (MainScene.getInstance().getDimension() != current_dimension) {
			current_dimension = MainScene.getInstance().getDimension();
			clear();
			fill();
		}
	}
	
	public void clear(){
		foreach(Node child in this.GetChildren()){
			this.RemoveChild(child);
			child.QueueFree();
		}
		
	}
	
	public void fill(){
				Node3D wall;
		
		for(float posX = 0.0f; posX < 505.0f; posX+=borderDist[current_dimension]){
			wall =(Node3D)borderScene[current_dimension].Instantiate();
			wall.Set(Node3D.PropertyName.Position, new Vector3(8.0f,0.0f,-posX+5.0f));
			this.AddChild(wall);
			wall =(Node3D)borderScene[current_dimension].Instantiate();
			wall.Set(Node3D.PropertyName.Position, new Vector3(-8.0f,0.0f,-posX+5.0f));
			this.AddChild(wall);
		}
		
	}
}
