using UnityEngine;
using System.Collections;

//this spawns the explosion particle and hitbox once that is in
public class BombThrow : MonoBehaviour 
{
    public float ForwardSpeed = 10f;
    public GameObject PreFabToSpawn;

    public GameObject ArrowToSpawn;

   // public Vector3 ForwardDirection;
    public float DespawnTimer = 0.7f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        DespawnTimer -= Time.deltaTime;
        if(DespawnTimer <= 0)
        {
            //play a sound?
            //despawn the thing
            //spawn in the explosion and the hitbox associated with it
            //destroy this projectile
            GameObject Bakudan = (GameObject)Instantiate(PreFabToSpawn, transform.position, transform.rotation);
            GameObject Arrow = (GameObject)Instantiate(ArrowToSpawn, transform.position, transform.rotation);
            /*Arrow.GetComponent<lookatme>().Forward = true;
            if(PreFabToSpawn.name == "RWBakudan")
            {
                Arrow.GetComponent<lookatme>().Forward = false;
                Arrow.GetComponent<lookatme>().Backward = true;
            }
            */
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter (Collision col)
    {
        //whenever I touch anything, spawn the thing
        if(col.gameObject.tag == "Bomb")
        {
            GameObject Bakudan = (GameObject)Instantiate(PreFabToSpawn, transform.position, transform.rotation);
            GameObject Arrow = (GameObject)Instantiate(ArrowToSpawn, transform.position, transform.rotation);
           /* Arrow.GetComponent<lookatme>().Forward = true;
            if (PreFabToSpawn.name == "RWBakudan")
            {
                Arrow.GetComponent<lookatme>().Forward = false;
                Arrow.GetComponent<lookatme>().Backward = true;
            }
            */
            Destroy(gameObject);
        }

    }
}
