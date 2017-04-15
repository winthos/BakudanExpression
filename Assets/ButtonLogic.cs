using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour 
{
    public Canvas QuitScreen;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //make appear
	    if(Input.GetKeyDown(KeyCode.Escape) && QuitScreen.GetComponent<CanvasGroup>().interactable == false)
        {
            QuitScreen.GetComponent<CanvasGroup>().alpha = 1;
            QuitScreen.GetComponent<CanvasGroup>().interactable = true;
            QuitScreen.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && QuitScreen.GetComponent<CanvasGroup>().interactable == true)
        {
            QuitScreen.GetComponent<CanvasGroup>().alpha = 0;
            QuitScreen.GetComponent<CanvasGroup>().interactable = false;
            QuitScreen.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        if(QuitScreen.GetComponent<CanvasGroup>().interactable == true)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                QuitGame();
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
