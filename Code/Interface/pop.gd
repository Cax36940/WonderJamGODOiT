extends Node2D

var speed : float = 200
var init_posx : float = 700
var error : float = 50
var is_current : bool = false
var best : bool = false
var hue : float = 0.5
var await_fail : bool = false
# Called when the node enters the scene tree for the first time.
func _ready():
	$Icon.position.x = -init_posx
	$Icon2.position.x = init_posx
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if $Timer.is_stopped():
		$Icon.position.x += speed * delta
		$Icon2.position.x -= speed * delta
	
		if $Icon.position.x >= 0:
			$Icon.position.x = 0
			$Icon2.position.x = 0
			timed()
			return
		if $Icon2.position.x <= error:
			modulate = Color(1, 0, 1)
		
	if is_current and Input.is_action_just_pressed("ui_accept"):
		set_process(false)
		if !$Timer.is_stopped() :
			$Timer.stop()
			$AnimationPlayer.play("BestSuccess")
			best = true
		elif $Icon2.position.x <= error:
			$AnimationPlayer.play("Success")
		else :
			$AnimationPlayer.play("Fail")
		return
	
	pass

func _physics_process(delta):
	if best :
		modulate = Color.from_hsv(hue, 1, 1)
		hue += delta
	
func change_current():
	if await_fail:
		await get_tree().create_timer(0.4).timeout
	is_current = false
	get_parent().get_parent().change_current_pop()

func timed():
	modulate = Color(0, 1, 0)
	$Timer.start()


func _on_timer_timeout():
	set_process(false)
	await_fail = true
	$AnimationPlayer.play("Fail")
	pass # Replace with function body.
