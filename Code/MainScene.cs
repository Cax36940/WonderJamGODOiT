using Godot;
using System;

public partial class MainScene : Node3D
{
	
	float speed;
	float score;
	float accelerationMultiplier;
	int multiplier;
	int dimension;
	int jauge;
	Godot.Collections.Array<string> dimensionBackground = new Godot.Collections.Array<string>();
	Godot.Collections.Array<string> dimensionRoad = new Godot.Collections.Array<string>();
	
	static MainScene instance; 
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("ready");
		speed = 20;
		score =0;
		jauge = 0;
		multiplier =1;
		dimension = 0;
		accelerationMultiplier = 0.5f;
		addScene("res://Scene/turtle/character_scene.tscn");
		addScene("res://Scene/road/road.tscn");
		addScene("res://Scene/Obstacle/spawner.tscn");
		addScene("res://Scene/environnement.tscn");
		addScene("res://Scene/Obstacle/border.tscn");
		instance = this;
		loadDimensionList();
		
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
		score = (float)delta*speed*multiplier;
		speed+= (float)delta*accelerationMultiplier;
		
		if (jauge>=100){
			GD.Print("jauge : ",jauge);
			changeDimension();
			jauge = 0;
			GD.Print("jauge : ",jauge);
		}
		
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
		
		if (dimension >= dimensionBackground.Count-1 | dimension >= dimensionRoad.Count-1){
			dimension = 0 ;
		}else {
			dimension +=1 ;
		}
		clearScene();
		
		GD.Print("Dimension : ",dimension);
		addScene(dimensionBackground[dimension]);
		addScene(dimensionRoad[dimension]);
		addScene("res://Scene/Obstacle/spawner.tscn");
		addScene("res://Scene/turtle/character_scene.tscn");
		addScene("res://Scene/environnement.tscn");
		addScene("res://Scene/Obstacle/border.tscn");
		
		score+=1000;
		multiplier+=1;
	}
	
	public void death(){
		GD.Print("Now you're dead you filthy casual ");
	}
	
	public float getSpeed(){
		return speed;	
	}
	
	public float getScore(){
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
	
	public int getJauge(){
		return jauge;
	}
	
	public void setJauge(int njauge){
		jauge = njauge;
	}
	
	
	
}
