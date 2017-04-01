using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlowlyFadeOut : MonoBehaviour 
{
    public float HowLongDoIWait = 5.0f;

    private float OtherTimer = 5.0f;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        HowLongDoIWait -= Time.deltaTime;
        if(HowLongDoIWait <= 0)
        {
            gameObject.GetComponent<RawImage>().CrossFadeAlpha(0, 5.00f, false);
            OtherTimer -= Time.deltaTime;

            if(OtherTimer <= 0)
            {
                gameObject.SetActive(false);
            }
        }

	}
}
