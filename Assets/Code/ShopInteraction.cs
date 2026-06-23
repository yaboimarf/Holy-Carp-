using UnityEngine;

public class ShopInteraction : MonoBehaviour
{
    public GameObject shopCanvas;
    public GameObject pressEText;

    private bool playerInRange;

    public PlayerMovement2 playerMovement;

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
        }

        if (shopCanvas.activeSelf && Input.GetMouseButtonDown(1))
        {
            CloseShop();
        }
    }

    void OpenShop()
    {
        shopCanvas.SetActive(true);
        playerMovement.isShopCanvasOpen = true;
        playerMovement.canControl = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseShop()
    {
        shopCanvas.SetActive(false);
        playerMovement.isShopCanvasOpen = false;
        playerMovement.canControl = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            pressEText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            pressEText.SetActive(false);

            CloseShop();
        }
    }
}