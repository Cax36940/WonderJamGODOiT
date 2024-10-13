extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	visible = true
	get_node("/root/MainScene").set_process_mode(PROCESS_MODE_DISABLED)
	pass # Replace with function body.

func _process(delta):
	if get_node("/root/MainScene").isDead() :
		get_node("../Death").visible = true
		get_node("/root/MainScene").set_process_mode(PROCESS_MODE_DISABLED)
		get_node("/root/MainScene").clearScene()
		get_node("/root/MainScene").setDead(false)
		

func _on_play_pressed():
	get_node("/root/MainScene").set_process_mode(PROCESS_MODE_INHERIT)
	visible = false
	pass # Replace with function body.


func _on_quit_pressed():
	get_parent().get_tree().quit()
	pass # Replace with function body.
