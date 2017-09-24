var tiempo_start : float = 0.0; 
var tiempo_end : float = 0.0; 
var escena : String; 
var Player : GameObject;

function Update (){
    tiempo_start += Time.deltaTime;
    if (tiempo_start>=tiempo_end || Input.anyKey)
	{

		Instantiate(Player, new Vector2(-22.74f, -0.04f), Quaternion.identity);
        Application.LoadLevel(escena); 
    }

}