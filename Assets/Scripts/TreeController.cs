using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour 
{
    public GameObject WhereIsTheAnimator;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter (Collider col)
    {
        print("something touched me");
        //   print("something is touching me");
        if (col.gameObject.tag == "FastForwardBomb")
        {
            //print("big tree");
            if(WhereIsTheAnimator.GetComponent<Animator>().GetInteger("State") == 1)
            {
                WhereIsTheAnimator.GetComponent<Animator>().SetTrigger("ToBigTree");
                WhereIsTheAnimator.GetComponent<Animator>().SetInteger("State", 0);
            }
            
        }

        if (col.gameObject.tag == "RewindBomb")
        {
            //print("small tree");
            if(WhereIsTheAnimator.GetComponent<Animator>().GetInteger("State") == 0)
            {
                WhereIsTheAnimator.GetComponent<Animator>().SetTrigger("ToSmallTree");
                WhereIsTheAnimator.GetComponent<Animator>().SetInteger("State", 1);
            }
           
        }
    }
}
