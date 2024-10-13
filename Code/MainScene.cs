using Godot;
using System;

public partial class MainScene : Node3D
{
	float accelerationMultiplier;
	float speed;
	float score_buffer;
	int multiplier;
	int fact;
	int dimension;
	int jauge;
	int hsuccess = 10;
	int lsuccess = 5;
	int failure = -2;
	int bpm = 85;
	double songTime = 0;
	
	float transitionTime = 0;
	bool isTransition = false;
	bool isBeat = true;
	
	
	Godot.Collections.Array<string> dimensionRoad = new Godot.Collections.Array<string>();
	Godot.Collections.Array<Godot.Collections.Array<string>> dimensionMusic = new Godot.Collections.Array<Godot.Collections.Array<string>>();
	
	static MainScene instance; 
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GD.Print("ready");
		GD.Print(bpm/60);
		speed = 20;
		score_buffer = 0;
		jauge = 0;
		multiplier = 1;
		fact = 2;
		dimension = 0;
		accelerationMultiplier = 0.5f;
		addScene("res://Scene/Musique/musiqueLogic.tscn");
		addScene("res://Scene/turtle/character_scene.tscn");
		addScene("res://Scene/road/road.tscn");
		addScene("res://Scene/Obstacle/spawner.tscn");
		addScene("res://Scene/environnement.tscn");
		addScene("res://Scene/Obstacle/border.tscn");
		addScene("res://Scene/Interface/hud.tscn");
		
		instance = this;
		loadDimensionList();
		
	}
	
	public void loadDimensionList(){
		
		//To add a dimension, add a road file path :
		
		//dim 1
		dimensionRoad.Add("res://Scene/road/road.tscn");
		//dim 2
		dimensionRoad.Add("res://Scene/road/road.tscn");
		//dim 3
		dimensionRoad.Add("res://Scene/road/road.tscn");
		//dim 4
		dimensionRoad.Add("res://Scene/road/road.tscn");
		//dim 5
		dimensionRoad.Add("res://Scene/road/road.tscn");
		
		//Musique
		
		//dim 1
		Godot.Collections.Array<string> dimMusic = new Godot.Collections.Array<string>();
		dimMusic.Add("res://Scene/Musique/musiqueLogic.tscn");
		dimMusic.Add("Musique");
		dimensionMusic.Add(dimMusic);
		//dim 2
		dimMusic = new Godot.Collections.Array<string>();
		dimMusic.Add("res://Scene/Musique/musiqueLogic.tscn");
		dimMusic.Add("Musique");
		dimensionMusic.Add(dimMusic);
		//dim 3
		dimMusic = new Godot.Collections.Array<string>();
		dimMusic.Add("res://Scene/Musique/musiqueLogic.tscn");
		dimMusic.Add("Musique");
		dimensionMusic.Add(dimMusic);
		//dim 4
		dimMusic = new Godot.Collections.Array<string>();
		dimMusic.Add("res://Scene/Musique/musiqueLogic.tscn");
		dimMusic.Add("Musique");
		dimensionMusic.Add(dimMusic);
		//dim 5
		dimMusic = new Godot.Collections.Array<string>();
		dimMusic.Add("res://Scene/Musique/musiqueLogic.tscn");
		dimMusic.Add("Musique");
		dimensionMusic.Add(dimMusic);
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		score_buffer += (float)delta*speed*multiplier;
		speed+= (float)delta*accelerationMultiplier;
	
		
		if (jauge>=100){	
			startTransition();
			jauge = 0;
			}
		
		if (isTransition){
			if (transitionTime <= 0){
				changeDimension();
				isTransition = false;
				isBeat=true;
			}else {
				transitionTime-= (float)delta;
			}
			
		}
		calculMusique();
		
	}
	
	public void calculMusique(){
		songTime = ((AudioStreamPlayer3D)this.GetNode(dimensionMusic[dimension][1])).GetPlaybackPosition() + AudioServer.GetTimeSinceLastMix();
		songTime -= AudioServer.GetOutputLatency();
	}
	
	public void addScene(string path){
		var newScene = GD.Load<PackedScene>(path).Instantiate();
		this.AddChild(newScene);
	}
	
	public void startTransition(){
		isBeat=false;
		isTransition=true;
		transitionTime=5;
		addScene("res://Scene/background/portal.tscn");
	}
	
	public void clearScene(){
		this.RemoveChild(this.GetNode("./Road"));
		this.RemoveChild(this.GetNode("./Spawner"));
		this.RemoveChild(this.GetNode("./Portal"));
		this.RemoveChild(this.GetNode(dimensionMusic[dimension][1]));
	}
	
	
	public void highSuccess(){
		jauge+=hsuccess;
		score_buffer+=50*multiplier;
		GD.Print("High Success");
		
	}
	
	public void success(){
		jauge+=lsuccess;
		score_buffer+=50*2*multiplier;
		GD.Print("Low Success");
	}
	
	public void fail(){
		jauge+=failure;
		GD.Print("Failure");
	}
	
	public void addBonus(int type){
		if(type == 1){
			score_buffer+=50*multiplier;
		}
		if(type == 2){
			score_buffer+=50*2*multiplier;
		}
		if(type == 3){
			score_buffer+=50*3*multiplier;
		}
	}
	
	
	public void changeDimension(){
		
		if (dimension >= dimensionRoad.Count-1){
			dimension = 0 ;
		}else {
			dimension +=1 ;
		}
		clearScene();
		
		addScene(dimensionRoad[dimension]);
		addScene("res://Scene/Obstacle/spawner.tscn");
		addScene(dimensionMusic[dimension][0]);
		
		score_buffer += 1000.0f * multiplier;
		multiplier *= fact;
		fact += 1;
	}
	
	public void death(){
		GD.Print("Now you're dead you filthy casual ");
	}
	
	public float getSpeed(){
		return speed;	
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
	
	public void setScoreBuffer(float nscore){
		score_buffer = nscore;
	}
	
	public float getScoreBuffer(){
		return score_buffer;
	}
	
	public float getTransitionTime(){
		return transitionTime;
	}
	public double getTimeMusic(){
		
		return songTime;
	}
	public float getBPM(){
		return (float)bpm;
	}
	
	public bool getIsBeat(){
		return isBeat;
	}
	
	public void setIsBeat(bool itIs){
		if(!isTransition){
			isBeat = itIs;
		}
	}
	
	
}
