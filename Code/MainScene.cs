using Godot;
using System;

public partial class MainScene : Node3D
{
	
	float speed;
	int score;
	int multiplier;
	int dimension;
	Godot.Collections.Array<string> dimensionBackground = new Godot.Collections.Array<string>();
	Godot.Collections.Array<string> dimensionRoad = new Godot.Collections.Array<string>();
	
	static MainScene instance; 
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		speed = 50;
		score =0;
		multiplier =1;
		dimension = 0;
		addScene("res://Scene/turtle/character_scene.tscn");
		addScene("res://Scene/road/road.tscn");
		addScene("res://Scene/Obstacle/spawner.tscn");
		instance = this;
		
	}
	
	public void loadDimensionList(){
		
		//To add a dimension, add a background file path and a road file path :
		
		//dim 1
		dimensionBackground.Add("res://Scene/background/background.tscn");
		dimensionRoad.Add("res://Scene/road/road.tscn");
		//dim 2
		dimensionBackground.Add("res://Scene/background/background.tscn");
		dimensionRoad.Add("res://Scene/road/road.tscn");
		//dim 3
		dimensionBackground.Add("res://Scene/background/background.tscn");
		dimensionRoad.Add("res://Scene/road/road.tscn");
		//dim 4
		dimensionBackground.Add("res://Scene/background/background.tscn");
		dimensionRoad.Add("res://Scene/road/road.tscn");
		//dim 5
		dimensionBackground.Add("res://Scene/background/background.tscn");
		dimensionRoad.Add("res://Scene/road/road.tscn");
		
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
		if (dimension >= dimensionBackground.Count | dimension >= dimensionRoad.Count){
			dimension =0 ;
		}else {
			dimension +=1 ;
		}
		clearScene();
		addScene(dimensionBackground[dimension]);
		addScene(dimensionBackground[dimension]);
		addScene("res://Scene/Obstacle/spawner.tscn");
		addScene("res://Scene/turtle/character_scene.tscn");
	}
	
	public float getSpeed(){
		return speed;	
	}
	
	public int getScore(){
		return score;	
	}
	
	public int getMultiplier(){
		return multiplier;	
	}
	
	public int getDimension(){
		return dimension;	
	}
	
	public static MainScene getInstance(){
		return instance;
	}
	
	
}
