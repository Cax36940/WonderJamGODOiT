extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	get_node("/root/MainScene").set_process_mode(PROCESS_MODE_DISABLED)
	pass # Replace with function body.

func _on_play_pressed():
	get_node("/root/MainScene").set_process_mode(PROCESS_MODE_INHERIT)
	queue_free()
	pass # Replace with function body.


func _on_quit_pressed():
	get_tree().quit()
	pass # Replace with function body.
