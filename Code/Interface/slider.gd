extends Control

var timer_init : float = 1
var timer : float = 1
var lastSound : float = 0;

var pop_speed : float = 200

var pop_scene : Resource = preload("res://Scene/Interface/pop.tscn")

# Called when the node enters the scene tree for the first time.
func _ready():
	
	pass # Replace with function body.
	

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if MainScene.getInstance().getTimeMusic()<lastSound:
		lastSound = 0;
	
	timer -= delta
	if (MainScene.getInstance().getTimeMusic()-lastSound) >= 60/MainScene.getInstance().getBPM() :
		if MainScene.getInstance().getIsBeat() :
			lastSound = MainScene.getTimeMusic()
			create_pop()
	pass

func create_pop():
	var pop : Node2D = pop_scene.instantiate()
	pop.speed = pop_speed
	pop.position = Vector2(640, 654)
	$Spawner.add_child(pop)
	$Spawner.get_child(0).is_current = true


func change_current_pop():
	$Spawner.get_child(0).reparent(self)
	if !$Spawner.get_children().is_empty():
		$Spawner.get_child(0).is_current = true
		
func resetSong():
	lastSound = 0
