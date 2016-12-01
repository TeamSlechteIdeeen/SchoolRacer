 
var minPitch : float = 1.0;
var maxPitch : float = 2.0;
var maxSpeed : float = 20.0; //tweak to your vehicle
 
private var pitchModifier : float;
 
function Update(){
    var currentSpeed = GetComponent.<Rigidbody>().velocity.magnitude;
    pitchModifier = maxPitch - minPitch;
    GetComponent.<AudioSource>().pitch = minPitch + (currentSpeed/maxSpeed)*pitchModifier;
}
 