using UnityEngine;
using System.Collections;

public class CheatMove : MonoBehaviour 
{
    public GameObject pos1;

    public GameObject pos2;

    public GameObject pos3;

    public GameObject pos4;


	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown("1"))
        {
            gameObject.transform.position = pos1.transform.position;
        }

        if (Input.GetKeyDown("2"))
        {
            gameObject.transform.position = pos2.transform.position;
        }

        if (Input.GetKeyDown("3"))
        {
            gameObject.transform.position = pos3.transform.position;
        }

        if (Input.GetKeyDown("4"))
        {
            gameObject.transform.position = pos4.transform.position;
        }
    }
}
