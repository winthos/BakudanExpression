using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class TreeController : MonoBehaviour 
{

    //public bool SmallTree = false;

    public GameObject WhereIsTheAnimator;
	// Use this for initialization
	void Start ()
    {
	   // if(SmallTree == true)
      //  {
      //      WhereIsTheAnimator.GetComponent<Animator>().SetTrigger("ToSmallTree");
       //     WhereIsTheAnimator.GetComponent<Animator>().SetInteger("State", 1);
      //  }

        if (File.Exists(Application.persistentDataPath + "/" + WhereIsTheAnimator.name + ".txt"))
        {
           // print("opening tree file" + Application.persistentDataPath + "/" + WhereIsTheAnimator.name+ ".txt");
            StreamReader sr = File.OpenText(Application.persistentDataPath + "/" + WhereIsTheAnimator.name + ".txt");
            string placeholder = " ";

            placeholder = sr.ReadLine();
            float whatState = float.Parse(placeholder);
            //print(WhereIsTheAnimator + "state is:" + placeholder);
            if (whatState == 1)
            {
                WhereIsTheAnimator.GetComponent<Animator>().SetTrigger("ToSmallTree");
                WhereIsTheAnimator.GetComponent<Animator>().SetInteger("State", 1);
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
            File.Delete(Application.persistentDataPath + "/" + WhereIsTheAnimator.name + ".txt");
        }
    }

    void Save()
    {
       // print("tree saveing");
        if (File.Exists(Application.persistentDataPath + "/" + WhereIsTheAnimator.name + ".txt"))
        {
           // print("opening save file to save again");
          //  print("the state i'm saving for" + WhereIsTheAnimator.name + "is " + WhereIsTheAnimator.GetComponent<Animator>().GetInteger("State"));
            StreamWriter sw = File.CreateText(Application.persistentDataPath + "/" + WhereIsTheAnimator.name + ".txt");
            sw.WriteLine(WhereIsTheAnimator.GetComponent<Animator>().GetInteger("State"));
            //sw.WriteLine("what the hell");
            sw.Close();
        }

        else
        {
            // print("making new file");
            StreamWriter save = File.CreateText(Application.persistentDataPath + "/" + WhereIsTheAnimator.name + ".txt");
            save.WriteLine(WhereIsTheAnimator.GetComponent<Animator>().GetInteger("State"));

            //print( WhereIsTheAnimator.name + "is in state:" + WhereIsTheAnimator.GetComponent<Animator>().GetInteger("State"));

            save.Close();
        }
    }

    void OnTriggerEnter (Collider col)
    {
      //  print("something touched me");
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
