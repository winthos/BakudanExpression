using UnityEngine;
using System.Collections;

public class LargeClockHandController : MonoBehaviour 
{
    [SerializeField]
    public bool Forward = false;

    [SerializeField]
    public bool Backward = false;

    [SerializeField]
    float rotationsperminute = 10.0f;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Forward == true && Backward == false)
        {
            //transform.Rotate(0, 6.0f, 0);
            transform.Rotate(0, 0, -400 * Time.deltaTime);
        }

        if (Backward == true && Forward == false)
        {
            //  transform.Rotate(0, -6.0f, 0);
            transform.Rotate(0, 0, 400 * Time.deltaTime);
        }
    }
}
