extends Control

var list_score : Array[int] = []
var score_label_scene : Resource = preload("res://Scene/Interface/score_label.tscn")

var score_buffer : float = 0

func _ready():
	add_score_label()
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	add_score(get_node("/root/MainScene").getScoreBuffer())
	get_node("/root/MainScene").setScoreBuffer(0.0)
	pass

func add_score_label():
	list_score.append(0)
	var label : Label = score_label_scene.instantiate()
	label.position.x = size.x - label.size.x * (list_score.size()) - 20
	label.position.y = label.size.y / 2 - 15
	label.name = "ScoreLabel" + str(len(list_score))
	add_child(label)

func add_score(score_value : float):
	score_buffer += score_value
	list_score[0] += int(score_buffer)
	score_buffer -= int(score_buffer)
	for i in range(len(list_score)-1):
		if(list_score[i] >= 1000):
			list_score[i+1] += list_score[i] / 1000
			list_score[i] = list_score[i] % 1000
	if list_score[len(list_score)-1] >= 1000 :
		add_score_label()
		
	for i in range(len(list_score)):
		get_node("ScoreLabel" + str(i + 1)).text = str(list_score[i])
		if i < len(list_score) - 1:
			var num_zero = 3 - get_node("ScoreLabel" + str(i + 1)).text.length()
			var tmp_str = ""
			for k in range(num_zero):
				tmp_str += "0"
			get_node("ScoreLabel" + str(i + 1)).text = tmp_str + get_node("ScoreLabel" + str(i + 1)).text
