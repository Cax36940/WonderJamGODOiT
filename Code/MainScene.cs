using Godot;
using System;

public partial class MainScene : Node3D
{
	
	float speed;
	int score;
	int multiplier;
	int dimension;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		speed = 10;
		score =0;
		multiplier =1;
		dimension = 0;
		addScene("res://Scene/turtle/character_scene.tscn");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void addScene(string path){
		var newScene = GD.Load<PackedScene>(path).Instantiate();
		this.AddChild(newScene);
	}
	
	public void clearScene(){
		foreach(Node child in this.GetChildren()){
			this.RemoveChild(child);
			child.QueueFree();
		}
	}
	
	public void changeDimension(){
		
	}
	
	
}
