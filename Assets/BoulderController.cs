using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
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

        if (File.Exists(Application.persistentDataPath + "/" + gameObject.transform.parent.name + ".txt"))
        {
            StreamReader sr = File.OpenText(Application.persistentDataPath + "/" + gameObject.transform.parent.name + ".txt");
            string placeholder = " ";

            placeholder = sr.ReadLine();
            float whatState = float.Parse(placeholder);

            if(whatState == 0)
            {
                gameObject.GetComponent<Animator>().SetTrigger("ToSmall");
                gameObject.GetComponent<Animator>().SetInteger("State", 0);
            }

            if (whatState == 1)
            {
                gameObject.GetComponent<Animator>().SetTrigger("ToBig");
                gameObject.GetComponent<Animator>().SetInteger("State", 1);
            }

            sr.Close();

        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown("p"))
        {
            Save();
            //gameObject.transform.parent.name
        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            File.Delete(Application.persistentDataPath + "/" + gameObject.transform.parent.name + ".txt");
        }
    }

    void Save()
    {
        if (File.Exists(Application.persistentDataPath + "/" + gameObject.transform.parent.name + ".txt"))
        {
            //  print("opening save file to save again");
            StreamWriter sw = File.CreateText(Application.persistentDataPath + "/" + gameObject.transform.parent.name + ".txt");
            sw.WriteLine(gameObject.GetComponentInChildren<Animator>().GetInteger("State"));
            sw.Close();
        }

        else
        {
            // print("making new file");
            StreamWriter save = File.CreateText(Application.persistentDataPath + "/" + gameObject.transform.parent.name + ".txt");
            save.WriteLine(gameObject.GetComponentInChildren<Animator>().GetInteger("State"));
            save.Close();
        }
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
