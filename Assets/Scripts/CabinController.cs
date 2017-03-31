using UnityEngine;
using System.Collections;

public class CabinController : MonoBehaviour
{
    public GameObject WhereIsTheCabin;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

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
    
