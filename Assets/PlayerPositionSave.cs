using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class PlayerPositionSave : MonoBehaviour 
{
    public Vector3 PlayerPosition = Vector3.zero;

    private float xpos;
    private float ypos;
    private float zpos;

    public GameObject Player;

	// Use this for initialization
	void Start ()
    {
        
        if (File.Exists(Application.persistentDataPath + "/" + gameObject.name + ".txt"))
        {
            StreamReader sr = File.OpenText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            string placeholder = " ";

            //while((placeholder = sr.ReadLine()) != null)
            //{
            //    print(placeholder);
            //}

            for(int i = 0; i <= 2; i++)
            {
                placeholder = sr.ReadLine();
               // print(placeholder);
                if(i == 0)
                {
                    xpos = float.Parse(placeholder);
                   // print(xpos);
                }
                if(i == 1)
                {
                    ypos = float.Parse(placeholder);
                 //   print(ypos);
                }
                if(i == 2)
                {
                    zpos = float.Parse(placeholder);
                 //   print(zpos);
                }
            }
            sr.Close();
            PlayerPosition = new Vector3(xpos, ypos, zpos);
            Player.transform.position = PlayerPosition;
        }
        

    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown("p"))
        {
            Save();
        }
	}

    public void Save()
    {
        //print(File.Exists(Application.persistentDataPath + "/" + gameObject.name + ".txt"));
        //if the file exists, open it and adjust
        if(File.Exists(Application.persistentDataPath + "/" + gameObject.name + ".txt"))
        {
            /*
           print("saving existing thing");
           FileStream save = File.Open(Application.persistentDataPath + "/" + gameObject.name + ".txt", FileMode.Open);
           save.Close();
           */
           // print("opening save file to save again");
           StreamWriter sw = File.CreateText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            sw.WriteLine(gameObject.GetComponentInParent<Transform>().position.x);
            sw.WriteLine(gameObject.GetComponentInParent<Transform>().position.y);
            sw.WriteLine(gameObject.GetComponentInParent<Transform>().position.z);
            sw.Close();

            
        }

        else
        {
            //print("making new file");
            StreamWriter save = File.CreateText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            save.WriteLine(gameObject.GetComponentInParent<Transform>().position.x);
            save.WriteLine(gameObject.GetComponentInParent<Transform>().position.y);
            save.WriteLine(gameObject.GetComponentInParent<Transform>().position.z);
            save.Close();
        }

    }
}
