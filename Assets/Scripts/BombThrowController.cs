using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//this causes the player to throw a bomb when we click

public class BombThrowController : MonoBehaviour 
{
    public GameObject BombToSpawn;
    public GameObject RewindBombToSpawn;
    public float Cooldown = 5.0f;
    private float CoolDownTimer;

    private bool ReadyToActivate = true;

    public float speed = 10f;
    // Use this for initialization
    void Start ()
    {
        CoolDownTimer = Cooldown;
	}
	
	// Update is called once per frame
	void Update ()
    {
      //  print(CoolDownTimer);
        if (ReadyToActivate == false)
        {
            CoolDownTimer -= Time.deltaTime;

            if(CoolDownTimer <= 0)
            {
                CoolDownTimer = Cooldown;
                ReadyToActivate = true;
            }
        }

	    if (Input.GetMouseButtonDown(0) && ReadyToActivate == true)
        {
            ReadyToActivate = false;
            GameObject Bakudan = (GameObject)Instantiate(BombToSpawn, transform.position, transform.rotation);
            Bakudan.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }

        if (Input.GetMouseButton(1) && ReadyToActivate == true)
        {
            ReadyToActivate = false;
            GameObject Baitsadasuto = (GameObject)Instantiate(RewindBombToSpawn, transform.position, transform.rotation);
            Baitsadasuto.GetComponent<Rigidbody>().velocity = transform.forward * speed;
        }
	}
}
