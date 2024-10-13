extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	visible = false
	pass # Replace with function body.




func _on_quit_pressed():
	get_node("/root/MainScene").get_tree().quit()
	pass # Replace with function body.


func _on_replay_pressed():
	var main = get_node("/root/MainScene")
	for child in main.get_children():
		main.remove_child(child)
		child.queue_free()
	get_node("/root/MainScene").setup()
	visible = false
	get_node("/root/MainScene").set_process_mode(PROCESS_MODE_INHERIT)
	pass # Replace with function body.
