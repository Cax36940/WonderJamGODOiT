extends Node3D

var shader_material : ShaderMaterial
# Called when the node enters the scene tree for the first time.
func _ready():
	shader_material = $MeshInstance3D.material_override
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	shader_material.set_shader_parameter("translation_speed", get_node("/root/MainScene").getSpeed() * 0.4)
	pass
