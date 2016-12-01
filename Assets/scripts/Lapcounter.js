static var LapNumberPlayer : int = 1;
 
 
//What lap are the bike on
var PlayerBikeLap: int = (LapNumberPlayer);
 
 
 
//What GameObject are gonna get collided with the lapcounter/Halfway
var PlayerBike : GameObject;
 
 
//finish camera
var PlayerCamera : GameObject;
var CameraFinish : GameObject;
 
 
 
function OnTriggerEnter(LapCounter:Collider){
    //PlayerBike LapCounter
    if (lapcounter2halfway.HalfwayPlayer == LapNumberPlayer){
        if (LapCounter.gameObject == (PlayerBike))
        {
            LapNumberPlayer ++;
            print ("Current Lap Player:" + LapNumberPlayer);
        }
    }
   
   
   
    //detects who won and \camera finish  
    if (lapcounter2halfway.HalfwayPlayer == 3){
        if (LapCounter.gameObject == (PlayerBike))
        {
            if(PlayerBikeLap == 3)
            {
                //CameraFinishWin();
            }
        }
    }
}