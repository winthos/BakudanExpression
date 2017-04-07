using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class DamController : MonoBehaviour 
{

	// Use this for initialization
	void Start ()
    {
        if (File.Exists(Application.persistentDataPath + "/" + gameObject.name + ".txt"))
        {
            StreamReader sr = File.OpenText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            string placeholder = " ";

            placeholder = sr.ReadLine();
            float whatState = float.Parse(placeholder);

            if (whatState == 1)
            {
                gameObject.GetComponent<Animator>().SetTrigger("ToOld");
                gameObject.GetComponent<Animator>().SetInteger("State", 1);
            }

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

        if(Input.GetKeyDown(KeyCode.O))
        {
            File.Delete(Application.persistentDataPath + "/" + gameObject.name + ".txt");
        }
    }

    void Save()
    {
        if (File.Exists(Application.persistentDataPath + "/" + gameObject.name + ".txt"))
        {
            //  print("opening save file to save again");
            StreamWriter sw = File.CreateText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            sw.WriteLine(gameObject.GetComponent<Animator>().GetInteger("State"));
            sw.Close();
        }

        else
        {
            // print("making new file");
            StreamWriter save = File.CreateText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            save.WriteLine(gameObject.GetComponent<Animator>().GetInteger("State"));
            save.Close();
        }
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
