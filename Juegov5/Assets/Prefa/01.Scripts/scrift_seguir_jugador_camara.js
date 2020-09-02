#pragma strict
varjugador: Transform;
var distancia : float;

function Start(){
	jugador = GameObject.FindGameObjecWithTag("player").transform;
}
function Update(){
	transform.position.x=jugador.position.x+distancia;
}