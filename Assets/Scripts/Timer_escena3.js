var tiempo_start : float = 0.0; 
var tiempo_end : float = 0.0; 
var escena : String; 
var Player : GameObject;



function Update (){
    tiempo_start += Time.deltaTime;
    if (tiempo_start>=tiempo_end || Input.anyKeyDown)
	{



		Instantiate(Player, new Vector2(-5f, 0f), Quaternion.identity);


        Application.LoadLevel(escena); 
    }

}
