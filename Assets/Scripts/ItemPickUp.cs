using TMPro;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public GameObject journalCanvas;
    public GameObject item;
    public GameObject interactText;
    public GameObject interactGoBack;
    public bool hasBeenRead = false;

    private bool inTrigger = false;

    public bool getRead()
    {
        return hasBeenRead;
    }

    private void OnTriggerEnter(Collider other)
    {
        interactText.SetActive(true);
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interactText.SetActive(false);
        inTrigger = false;
    }

    private void ReadJournal()
    {
        hasBeenRead = true;
        journalCanvas.gameObject.SetActive(true); 
    }

    private void IgnoreJournal()
    {
        journalCanvas.gameObject.SetActive(false);
        // turn off the ground item gameObject once it has been read and "picked up"
        item.SetActive(false);

    }

    private void Update()
    {
        if (inTrigger)
        {
            interactText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E) && !hasBeenRead)
            {
                interactText.SetActive(false);
                interactGoBack.SetActive(true);
                ReadJournal();
            }
            if (Input.GetKeyDown(KeyCode.Z))
            {
                interactGoBack.SetActive(false);
                interactText.SetActive(true);
                IgnoreJournal();
            }
        } else
        {
            interactText.SetActive(false);
        }
        
    }
}
