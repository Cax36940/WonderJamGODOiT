using Godot;
using System;

public partial class Spawner : Node
{
	
	int max_obstacle = 30; 
	int nb_obstacle = 0;
	int cycle_obstacle = 0;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		cycle_obstacle+=1;
		if (cycle_obstacle>20){
			spawnObstacle("res://Scene/Obstacle/obstacle_test.tscn");
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
