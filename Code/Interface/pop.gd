extends Node2D

var speed : float = 200
var init_posx : float = 700
var error : float = 50
var is_current : bool = false
var best : bool = false
var hue : float = 0.5
var await_fail : bool = false


var enter_x1 : float = -630
var enter_x2 : float = 660
# Called when the node enters the scene tree for the first time.
func _ready():
	$Icon.position.x = -init_posx
	$Icon/Notes.region_rect.position.x = 125
	$Icon/Notes.region_rect.size.x = 0
	$Icon2/Notes2.region_rect.position.x = 125
	$Icon2/Notes2.region_rect.size.x = 0
	$Icon2.position.x = init_posx
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if $Icon.position.x <= enter_x1 + 125 and $Icon.position.x > enter_x1:
		$Icon/Notes.region_rect.position.x = 125 - ($Icon.position.x - enter_x1)
		$Icon/Notes.region_rect.size.x = ($Icon.position.x - enter_x1) * 2
	elif $Icon.position.x > enter_x1:
		$Icon/Notes.region_rect.position.x = 0
		$Icon/Notes.region_rect.size.x = 250

	if $Icon2.position.x >= enter_x2 - 125 and $Icon2.position.x < enter_x2:
		$Icon2/Notes2.region_rect.position.x = 125 - (enter_x2 - $Icon2.position.x)
		$Icon2/Notes2.region_rect.size.x = (enter_x2 - $Icon2.position.x) * 2
	elif $Icon2.position.x < enter_x2:
		$Icon2/Notes2.region_rect.size.x = 250
	
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
			get_node("/root/MainScene").highSuccess()
			$AnimationPlayer.play("BestSuccess")
			best = true
		elif $Icon2.position.x <= error:
			get_node("/root/MainScene").success()
			$AnimationPlayer.play("Success")
		else :
			get_node("/root/MainScene").fail()
			$AnimationPlayer.play("Fail")
		return
	
	pass

func _physics_process(delta):
	if best :
		modulate = Color.from_hsv(hue, 1, 1, 1 - (hue * 2 - 1))
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
	get_node("/root/MainScene").fail()
	$AnimationPlayer.play("Fail")
	pass # Replace with function body.
