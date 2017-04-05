using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

[System.Serializable]
public class CabinController : MonoBehaviour
{
    public GameObject WhereIsTheCabin;
    // Use this for initialization
    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/" + WhereIsTheCabin.name + ".txt"))
        {
            StreamReader sr = File.OpenText(Application.persistentDataPath + "/" + WhereIsTheCabin.name + ".txt");
            string placeholder = " ";

            placeholder = sr.ReadLine();
            float whatState = float.Parse(placeholder);

            if (whatState == 1)
            {
                WhereIsTheCabin.GetComponent<Animator>().SetTrigger("ToNewCabin");
                WhereIsTheCabin.GetComponent<Animator>().SetInteger("State", 1);
            }

        }
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            Save();
            //gameObject.transform.parent.name
        }
    }

    void Save()
    {
        if (File.Exists(Application.persistentDataPath + "/" + WhereIsTheCabin.name + ".txt"))
        {
            //  print("opening save file to save again");
            StreamWriter sw = File.CreateText(Application.persistentDataPath + "/" + WhereIsTheCabin.name + ".txt");
            sw.WriteLine(WhereIsTheCabin.GetComponent<Animator>().GetInteger("State"));
            sw.Close();
        }

        else
        {
            // print("making new file");
            StreamWriter save = File.CreateText(Application.persistentDataPath + "/" + WhereIsTheCabin.name + ".txt");
            save.WriteLine(WhereIsTheCabin.GetComponent<Animator>().GetInteger("State"));
            save.Close();
        }
    }

    void OnTriggerEnter(Collider col)
    {
        print("something touched me");
        if (col.gameObject.tag == "RewindBomb")
        {
            //if we are the destroyed cabin
            if (WhereIsTheCabin.GetComponent<Animator>().GetInteger("State") == 0)
            {
                print("fast forward");
                WhereIsTheCabin.GetComponent<Animator>().SetTrigger("ToNewCabin");
                WhereIsTheCabin.GetComponent<Animator>().SetInteger("State", 1);
            }

        }

        if (col.gameObject.tag == "FastForwardBomb")
        {
            //if we are the new cabin
            if (WhereIsTheCabin.GetComponent<Animator>().GetInteger("State") == 1)
            {
                print("rewind");
                WhereIsTheCabin.GetComponent<Animator>().SetTrigger("ToDestroyedCabin");
                WhereIsTheCabin.GetComponent<Animator>().SetInteger("State", 0);
            }

        }
    }
}
    
