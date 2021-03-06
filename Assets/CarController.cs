﻿using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class CarController : MonoBehaviour 
{

    // Use this for initialization
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + gameObject.name + ".txt"))
        {
            StreamReader sr = File.OpenText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            string placeholder = " ";

            placeholder = sr.ReadLine();
            float whatState = float.Parse(placeholder);

            if(whatState == 1)
            {
                gameObject.GetComponentInChildren<Animator>().SetTrigger("ToNewCar");
                gameObject.GetComponentInChildren<Animator>().SetInteger("State", 1);
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
        }


        if (Input.GetKeyDown(KeyCode.O))
        {
            File.Delete(Application.persistentDataPath + "/" + gameObject.name + ".txt");
        }
    }

    void Save()
    {
        if (File.Exists(Application.persistentDataPath + "/" + gameObject.name + ".txt"))
        {
            //print("opening save file to save again");
            StreamWriter sw = File.CreateText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            sw.WriteLine(gameObject.GetComponentInChildren<Animator>().GetInteger("State"));
            sw.Close();
        }
 
        else
        {
            //print("making new file");
            StreamWriter save = File.CreateText(Application.persistentDataPath + "/" + gameObject.name + ".txt");
            save.WriteLine(gameObject.GetComponentInChildren<Animator>().GetInteger("State"));
            save.Close();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        //default state is busted and old
        if (col.gameObject.tag == "RewindBomb")
        {
            if(gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 0)
            {
                gameObject.GetComponentInChildren<Animator>().SetTrigger("ToNewCar");
                gameObject.GetComponentInChildren<Animator>().SetInteger("State", 1);
            }
        }

        if(col.gameObject.tag == "FastForwardBomb")
        {
            if (gameObject.GetComponentInChildren<Animator>().GetInteger("State") == 1)
            {
                gameObject.GetComponentInChildren<Animator>().SetTrigger("ToOldCar");
                gameObject.GetComponentInChildren<Animator>().SetInteger("State", 0);
            }
        }
    }
}
