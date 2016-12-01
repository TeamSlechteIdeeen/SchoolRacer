static var HalfwayPlayer : int = 0;
 
 
function OnTriggerEnter(HalfCounter:Collider){
    if (HalfCounter.gameObject.tag == "Bike")
    {
        HalfwayPlayer ++;
        print ("Halfway Lap Player:" + HalfwayPlayer);
        if(HalfwayPlayer > Lapcounter.LapNumberPlayer)
        {
            HalfwayPlayer = Lapcounter.LapNumberPlayer;
        }
    }
 
 
   
}