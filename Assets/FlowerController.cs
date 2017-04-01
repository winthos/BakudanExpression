using UnityEngine;
using System.Collections;

public class FlowerController : MonoBehaviour 
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
        //default state is young flower at 0
        if (col.gameObject.tag == "FastForwardBomb")
        {
            if (gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 0)
            {
                gameObject.GetComponentInChildren<Animator>().SetTrigger("ToOld");
                gameObject.GetComponentInChildren<Animator>().SetInteger("State", 1);
            }
        }

        if (col.gameObject.tag == "RewindBomb")
        {
            if (gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 1)
            {
                gameObject.GetComponentInChildren<Animator>().SetTrigger("ToYoung");
                gameObject.GetComponentInChildren<Animator>().SetInteger("State", 0);
            }
        }
    }
}
