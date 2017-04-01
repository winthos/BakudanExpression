﻿using UnityEngine;
using System.Collections;

public class BoulderController : MonoBehaviour 
{
    public bool BigBoulder = false;


	// Use this for initialization
	void Start ()
    {
	    if(BigBoulder == true)
        {
            gameObject.GetComponent<Animator>().SetTrigger("ToBig");
            gameObject.GetComponent<Animator>().SetInteger("State", 1);
        }

        if (BigBoulder == false)
        {

        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider col)
    {
        //default state is tiny pebbles at 0
        if (col.gameObject.tag == "FastForwardBomb")
        {
            if (gameObject.GetComponent<Animator>().GetInteger("State") == 1)
            {
                gameObject.GetComponent<Animator>().SetTrigger("ToSmall");
                gameObject.GetComponent<Animator>().SetInteger("State", 0);
            }
        }

        if (col.gameObject.tag == "RewindBomb")
        {
            if (gameObject.GetComponent<Animator>().GetInteger("State") == 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("ToBig");
                gameObject.GetComponent<Animator>().SetInteger("State", 1);
            }
        }
    }
}
