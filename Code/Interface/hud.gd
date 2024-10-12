extends Control

var list_score : Array[int] = []
var str_i : String
var score_label_scene : Resource = preload("res://Scene/Interface/score_label.tscn")

var speed : int = 100

func _ready():
	add_score_label()
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	list_score[0] += speed
	for i in range(len(list_score)-1):
		if(list_score[i] >= 1000):
			list_score[i+1] += list_score[i] / 1000
			list_score[i] = list_score[i] % 1000
	if list_score[len(list_score)-1] >= 1000 :
		add_score_label()
			
	for i in range(len(list_score)):
		get_node("ScoreLabel" + str(i + 1)).text = str(list_score[i])
	pass

func add_score_label():
	list_score.append(0)
	var label : Label = score_label_scene.instantiate()
	label.position.x = size.x - label.size.x * (list_score.size()) - 20
	label.position.y = label.size.y / 2 - 15
	label.name = "ScoreLabel" + str(len(list_score))
	add_child(label)
