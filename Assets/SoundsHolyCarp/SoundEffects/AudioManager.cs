using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject buttonHover;
    public GameObject sandWalking;
    public GameObject splash;
    public GameObject coins;
    public GameObject turnPage;


    public void ButtonHover()
    { 
        buttonHover.GetComponent<AudioSource>().Play();
    }
    public void SandWalking() 
    { 
        sandWalking.GetComponent<AudioSource>().Play(); 
    }

    public void Splash()
    {
        splash.GetComponent<AudioSource>().Play();
    }

    public void Coins()
    {
        coins.GetComponent<AudioSource>().Play();
    }
    public void TurnPage()
    {
        turnPage.GetComponent<AudioSource>().Play();
    }

}
