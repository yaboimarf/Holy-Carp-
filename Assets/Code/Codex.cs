using UnityEngine;

public class Codex : MonoBehaviour
{
    [Header("Beach")]
    public bool flounder;
    public GameObject flounderCanvas;
    public bool remora;
    public GameObject remoraCanvas;
    public bool tuna;
    public GameObject tunaCanvas;
    [Header("Cave")]
    public bool beardfish;
    public GameObject beardfishCanvas;
    public bool catfish;
    public GameObject catfishCanvas;
    public bool olm;
    public GameObject olmCanvas;
    [Header("Lake")]
    public bool carp;
    public GameObject carpCanvas;
    public bool goldfish;
    public GameObject goldfishCanvas;
    public bool pike;
    public GameObject pikeCanvas;
    public int codexCount;
    public GameObject codexButtonLeft;
    public GameObject codexButtonRight;
    // Update is called once per frame
    void Update()
    {
        if(codexCount > 8)
        {
            codexCount = 8;
        }
        if(codexCount < 0)
        {
            codexCount = 0;
        }
        CodexStuff();
    }
    public void CodexStuff()
    {
        if(codexCount == 0)
        {
            codexButtonLeft.SetActive(false);
            codexButtonRight.SetActive(true);
            RemoveAllFish();
            if (flounder == true)
            {
                flounderCanvas.SetActive(true);
            }
        }
        if(codexCount == 1)
        {
            codexButtonLeft.SetActive(true);
            codexButtonRight.SetActive(true);
            RemoveAllFish();
            if (remora == true)
            {
                remoraCanvas.SetActive(true);
            }
        }
        if(codexCount == 2)
        {
            codexButtonLeft.SetActive(true);
            codexButtonRight.SetActive(true);
            RemoveAllFish();
            if(tuna == true)
            {
                tunaCanvas.SetActive(true);
            }
        }
        if(codexCount == 3)
        {
            codexButtonLeft.SetActive(true);
            codexButtonRight.SetActive(true);
            RemoveAllFish();
            if (beardfish == true)
            {
                beardfishCanvas.SetActive(true);
            }
        }
        if(codexCount == 4)
        {
            codexButtonLeft.SetActive(true);
            codexButtonRight.SetActive(true);
            RemoveAllFish();
            if(catfish == true)
            {
                catfishCanvas.SetActive(true);
            }
        }
        if(codexCount == 5)
        {
            codexButtonLeft.SetActive(true);
            codexButtonRight.SetActive(true);
            RemoveAllFish();
            if (olm == true)
            {
                olmCanvas.SetActive(true);
            }
        }
        if(codexCount == 6)
        {
            codexButtonLeft.SetActive(true);
            codexButtonRight.SetActive(true);
            RemoveAllFish();
            if(carp == true)
            {
                carpCanvas.SetActive(true);
            }
        }
        if(codexCount == 7)
        {
            codexButtonLeft.SetActive(true);
            codexButtonRight.SetActive(true);
            RemoveAllFish();
            if (goldfish == true)
            {
                goldfishCanvas.SetActive(true);
            }
        }
        if(codexCount == 8)
        {
            codexButtonLeft.SetActive(true);
            codexButtonRight.SetActive(false);
            RemoveAllFish();
            if (pike == true)
            {
                pikeCanvas.SetActive(true);
            }
        }
    }
    public void UpdateCodexCountPositive()
    {
        codexCount += 1;
    }
    public void UpdateCodexCountNegative()
    {
        codexCount -= 1;
    }
    public void RemoveAllFish()
    {
        flounderCanvas.SetActive(false);
        remoraCanvas.SetActive(false);
        tunaCanvas.SetActive(false);
        beardfishCanvas.SetActive(false);
        catfishCanvas.SetActive(false);
        olmCanvas.SetActive(false);
        carpCanvas.SetActive(false);
        goldfishCanvas.SetActive(false);
        pikeCanvas.SetActive(false);
    }
}