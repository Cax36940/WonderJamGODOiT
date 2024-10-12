extends Node3D

@onready var road_sprite = $RoadSprite
const coef_meter_to_pixel : float = 100
# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _physics_process(delta):
	road_sprite.region_rect.position.y -= delta * get_node("/root/MainScene").getSpeed() * coef_meter_to_pixel
	pass
