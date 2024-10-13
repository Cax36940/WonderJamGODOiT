using Godot;
using System;

public partial class Spawner : Node
{
	
	int max_obstacle = 15; 
	int nb_bonus = 0;
	float cycle_bonus = 0.5f;
	int max_bonus = 15;
	int nb_obstacle = 0;
	float cycle_obstacle = 0;
	Godot.Collections.Array<Godot.Collections.Array<string>> dimensionObstacle = new Godot.Collections.Array<Godot.Collections.Array<string>>();
	Godot.Collections.Array<string> bonus = new Godot.Collections.Array<string>();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		loadBonusFile();
		loadObstacleFile();
	}
	
	public void loadBonusFile(){
		bonus.Add("res://Scene/bonus/bonus_1.tscn");
		bonus.Add("res://Scene/bonus/bonus_2.tscn");
		bonus.Add("res://Scene/bonus/bonus_3.tscn");
	}
	
	public void loadObstacleFile(){
		
		//liste d'obstacle :
		Godot.Collections.Array<string> obstacleForDimension = new Godot.Collections.Array<string>();
		
		//Ajout 4 obstacles pour dim1:
		obstacleForDimension.Add("res://Scene/Obstacle/obs_plage_1.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obs_plage_2.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obs_plage_3.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obs_plage_4.tscn");
		
		dimensionObstacle.Add(new Godot.Collections.Array<string>(obstacleForDimension));
		obstacleForDimension.Clear();
		
		//Ajout 4 obstacles pour dim 2:
		obstacleForDimension.Add("res://Scene/Obstacle/obs_mer_1.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obs_mer_2.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obs_mer_3.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obs_mer_4.tscn");
		
		dimensionObstacle.Add(new Godot.Collections.Array<string>(obstacleForDimension));
		obstacleForDimension.Clear();
		
		//Ajout 4 obstacles pour dim 3:
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		
		dimensionObstacle.Add(new Godot.Collections.Array<string>(obstacleForDimension));
		obstacleForDimension.Clear();
		
		//Ajout 4 obstacles pour dim 4:
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		
		dimensionObstacle.Add(new Godot.Collections.Array<string>(obstacleForDimension));
		obstacleForDimension.Clear();
		
		//Ajout 4 obstacles pour dim 5:
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		
		dimensionObstacle.Add(new Godot.Collections.Array<string>(obstacleForDimension));
		obstacleForDimension.Clear();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		cycle_obstacle+= (float)delta;
		cycle_bonus+= (float)delta;
		if(!MainScene.getInstance().istransition()){
			if (cycle_obstacle>1){
				spawnObstacle(dimensionObstacle[MainScene.getInstance().getDimension()].PickRandom());
				cycle_obstacle = 0;
			}if (cycle_bonus>2.5f){
				spawnBonus(bonus.PickRandom());
				cycle_bonus = 0.5f;
			}
		}	
	}
	
	public override void _PhysicsProcess(double delta){
		moveObstacle(delta);
	}
	
	
	
	public void clearObstacle(){
		foreach(Node child in this.GetChildren()){
			this.RemoveChild(child);
			child.QueueFree();
			nb_obstacle = 0;
		}
	}
	
	public void spawnBonus(string path){
		Random rnd = new Random();
		
		if (nb_bonus < max_bonus){
			Node3D bonus = (Node3D)GD.Load<PackedScene>(path).Instantiate();
			bonus.Set(Node3D.PropertyName.Position, new Vector3(rnd.Next(-6,6),0,-200));
			this.AddChild(bonus);
			nb_bonus+=1;
		}
	}
	
	public void spawnObstacle(string path){
		
		Random rnd = new Random();
		
		if (nb_obstacle < max_obstacle){
			Node3D obstacle = (Node3D)GD.Load<PackedScene>(path).Instantiate();
			obstacle.Set(Node3D.PropertyName.Position, new Vector3(rnd.Next(-6,6),0,-200));
			this.AddChild(obstacle);
			nb_obstacle+=1;
		}
		
	}
	
	public void moveObstacle(double delta){
		
		foreach( Node3D obstacle in this.GetChildren()){
			
			float velocity = MainScene.getInstance().getSpeed() ;
			
			Vector3 pos =(Vector3) obstacle.Get(Node3D.PropertyName.Position);		
			
			pos.Z += velocity*(float) delta;	
			
			obstacle.Set(Node3D.PropertyName.Position, pos);
			
			
			if (obstacle.Position.Z >= 10){
				this.RemoveChild(obstacle);
				if ((obstacle.Name == "Bonus1") | (obstacle.Name == "Bonus2") | (obstacle.Name =="Bonus3")){
					nb_bonus-=1;
				}else {
					nb_obstacle-=1;
				}
				obstacle.QueueFree();
						
			}
			
		}
		
	}
}
