using UnityEngine;

public class OnButtonHover : MonoBehaviour
{
    public GameObject hoverText;

    private void Start()
    {
        hoverText.SetActive(false);
    }
    public void OnHoverEnter()
    {
        hoverText.SetActive(true);
    }

    public void OnHoverExit()
    {
        hoverText.SetActive(false);
    }
}