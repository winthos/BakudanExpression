using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[System.Serializable]

//put this on bomb
public class YoungGrassController : MonoBehaviour 
{
    private bool StopDoingThis = false;
	// Use this for initialization
	void Start ()
    {
        if (File.Exists(Application.persistentDataPath + "/" + gameObject.transform.parent.name + ".txt"))
        {
            StreamReader sr = File.OpenText(Application.persistentDataPath + "/" + gameObject.transform.parent.name + ".txt");
            string placeholder = " ";

            placeholder = sr.ReadLine();
            float whatState = float.Parse(placeholder);

            if (whatState == 1)
            {
                gameObject.GetComponentInChildren<Animator>().SetTrigger("DefaultToBaby");
                gameObject.GetComponentInChildren<Animator>().SetInteger("State", 1);
            }

           // if(whatState == 2)
           // {
          //      gameObject.GetComponentInChildren<Animator>().SetTrigger("BabyToYoung");
          //      gameObject.GetComponentInChildren<Animator>().SetInteger("State", 2);
          //  }

            if (whatState == 3)
            {
                gameObject.GetComponentInChildren<Animator>().SetTrigger("DefaultToOld");
                gameObject.GetComponentInChildren<Animator>().SetInteger("State", 3);
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
