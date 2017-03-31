using UnityEngine;
using System.Collections;


//put this on bomb
public class YoungGrassController : MonoBehaviour 
{
    private bool StopDoingThis = false;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    void OnTriggerEnter(Collider col)
    {

           // print("grass touched?");
           //
           //state of the grass is 0 for idle, untouched by bomb
           // 1 for baby
           // 2 for young
           // 3 for old and dying

            if(col.gameObject.tag == "FastForwardBomb")
            {
                //go from default Idle to Old State
                if(gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 0 && StopDoingThis == false)
                {
                    gameObject.GetComponentInChildren<Animator>().SetTrigger("DefaultToOld");
                    gameObject.GetComponentInChildren<Animator>().SetInteger("State", 3);
                   // StopDoingThis = true;
                    //Destroy(col.gameObject);
                }

                //go from baby to Young State
                else if (gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 1 && StopDoingThis == false)
                {
                    //print("baby to young");
                    gameObject.GetComponentInChildren<Animator>().SetTrigger("BabyToYoung");
                    gameObject.GetComponentInChildren<Animator>().SetInteger("State", 2);
                   // StopDoingThis = true;
                   // Destroy(col.gameObject);

                }

                // gop from young to Old State
                else if(gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 2 && StopDoingThis == false)
                {
                    //print("Young to Old");
                    gameObject.GetComponentInChildren<Animator>().SetTrigger("YoungToOld");
                    gameObject.GetComponentInChildren<Animator>().SetInteger("State", 3);
                  //  StopDoingThis = true;
                   // Destroy(col.gameObject);
                }

            }

            if(col.gameObject.tag == "RewindBomb")
            {
           // print("rewindbomb touched me");
                //go from default Idle to Young Baby Grass state
                if (gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 0 && StopDoingThis == false)
                {
                    gameObject.GetComponentInChildren<Animator>().SetTrigger("DefaultToBaby");
                    gameObject.GetComponentInChildren<Animator>().SetInteger("State", 1);
                   // StopDoingThis = true;
                    //Destroy(col.gameObject);
                }

                //go from old to Young
                else if (gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 3 && StopDoingThis == false)
                {
                   // print("baby to young");
                    gameObject.GetComponentInChildren<Animator>().SetTrigger("OldToYoung");
                    gameObject.GetComponentInChildren<Animator>().SetInteger("State", 2);
                   // StopDoingThis = true;
                   // Destroy(col.gameObject);
                }

                // gop from young to Old State
                else if (gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 2 && StopDoingThis == false)
                {
                   // print("Young to Old");
                    gameObject.GetComponentInChildren<Animator>().SetTrigger("YoungToBaby");
                    gameObject.GetComponentInChildren<Animator>().SetInteger("State", 1);
                  //  StopDoingThis = true;
                   // Destroy(gameObject);
                }

            

         
        }
    }
}
