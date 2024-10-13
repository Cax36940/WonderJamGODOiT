extends Control

@onready var bar_left = $AccelerationBar/AccelerationBarFillHFlip
@onready var bar_right = $AccelerationBar2/AccelerationBarFillHFlip

var target_jauge : float
var jauge : float
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	target_jauge = get_node("/root/MainScene").getJauge()
	
	if jauge != target_jauge :
		if target_jauge == 0.0 :
			jauge = 0
		jauge = move_toward(jauge, target_jauge, delta * 0.1)
	
	bar_left.region_rect.size.y = jauge * 720
	bar_left.offset.y = 50 - jauge * 360
	bar_right.region_rect.size.y = jauge * 720
	bar_right.offset.y = 50 - jauge * 360
	pass
