#pragma strict
 
 
private var targets : GameObject[];
private var navigation : UnityEngine.AI.NavMeshAgent;
private var i : int = 0;
      
      
function Start () 
{
    navigation = GetComponent(UnityEngine.AI.NavMeshAgent);
    targets = GameObject.FindGameObjectsWithTag("NavTarget");
         
    //set first target
    navigation.destination = targets[i].transform.position;     
}
      
function Update () 
{
    var dist = Vector3.Distance(targets[i].transform.position,transform.position);
    //currentTarget = targets[i].transform;
    //if npc reaches its destination (or gets close)...
    if (dist < 2)
    {                
        i++; //change next target      
        if (i < targets.Length )
        { 
            navigation.destination = targets[i].transform.position; //go to next target by setting it as the new destination
        }
               
        //check if at end of cycle, then reset to beginning of cycle
        if (i == targets.Length )
        {
            Debug.Log("NAVIGATION FINISHED. RESET.");
            i = 0;
            navigation.destination = targets[i].transform.position;
        }
    }
}