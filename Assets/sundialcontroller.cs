using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class sundialcontroller : MonoBehaviour
{
    public GameObject TaiyoNoEnergi;

    public GameObject Point1;
    public GameObject Point2;

    public bool Sunset = false;

    // Use this for initialization
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + gameObject.name + ".txt"))
        {
            StreamReader sr = File.OpenText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            string placeholder = " ";

            placeholder = sr.ReadLine();

            if(placeholder == "False")
            {
                Sunset = false;
            }

            if(placeholder == "True")
            {
                Sunset = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Sunset == false)
        {
            TaiyoNoEnergi.transform.LookAt(Point2.transform);
        }

        if(Sunset == true)
        {
            TaiyoNoEnergi.transform.LookAt(Point1.transform);
        }

        if (Input.GetKeyDown("p"))
        {
            Save();
            //gameObject.transform.parent.name
        }
    }

    void Save()
    {
        if (File.Exists(Application.persistentDataPath + "/" + gameObject.name + ".txt"))
        {
            //  print("opening save file to save again");
            StreamWriter sw = File.CreateText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            sw.WriteLine(Sunset);
            sw.Close();
        }

        else
        {
            // print("making new file");
            StreamWriter save = File.CreateText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            save.WriteLine(Sunset);
            save.Close();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //rotate x from 50 to like 180
        if (col.gameObject.tag == "FastForwardBomb")
        {
            Sunset = true;
        }

        if (col.gameObject.tag == "RewindBomb")
        {
            Sunset = false;
        }
    }
}
