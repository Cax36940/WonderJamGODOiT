using Godot;
using System;

public partial class Spawner : Node
{
	
	int max_obstacle = 15; 
	int nb_obstacle = 0;
	float cycle_obstacle = 0;
	Godot.Collections.Array<Godot.Collections.Array<string>> dimensionObstacle = new Godot.Collections.Array<Godot.Collections.Array<string>>();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		loadObstacleFile();
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
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		obstacleForDimension.Add("res://Scene/Obstacle/obstacle_test.tscn");
		
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
		if (cycle_obstacle>1){
			spawnObstacle(dimensionObstacle[MainScene.getInstance().getDimension()].PickRandom());
			cycle_obstacle = 0;
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
			
			
			if (obstacle.Position.Z >= 5){
				this.RemoveChild(obstacle);
				obstacle.QueueFree();
				nb_obstacle-=1;		
			}
			
		}
		
	}
}
