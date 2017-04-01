using UnityEngine;
using System.Collections;

public class DamController : MonoBehaviour 
{

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
        //default state is old n stuff, old is state 0
        if (col.gameObject.tag == "FastForwardBomb")
        {
            if (gameObject.GetComponent<Animator>().GetInteger("State") == 1)
            {
                gameObject.GetComponent<Animator>().SetTrigger("ToNew");
                gameObject.GetComponent<Animator>().SetInteger("State", 0);
            }
        }

        if (col.gameObject.tag == "RewindBomb")
        {
            if (gameObject.GetComponent<Animator>().GetInteger("State") == 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("ToOld");
                gameObject.GetComponent<Animator>().SetInteger("State", 1);
            }
        }
    }
}
