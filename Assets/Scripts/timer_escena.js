var tiempo_start : float = 0.0; 
var tiempo_end : float = 0.0; 
var escena : String; 
function Update (){
    tiempo_start += Time.deltaTime;
    if (tiempo_start>=tiempo_end || Input.GetKeyDown(KeyCode.Mouse0)) 
	{
        Application.LoadLevel(escena); 
    }

}