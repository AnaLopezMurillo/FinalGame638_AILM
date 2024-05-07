using UnityEngine;
using TMPro;
using System.Collections;

public class CharacterInteraction : MonoBehaviour, IInteractable
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialogueBG;
    public GameObject interact;
    public string[] messages; // array
    public string[] itemPickedUpMessages; // string array
    public float typingSpeed = 0.1f;  
    public GameObject amelieSprite;
    public GameObject questItem;
    public static bool isDialogueActive = false;


    private bool hasSpoken = false;
    private bool hasSpokenItem = false;
    private SpriteRenderer spriteRenderer;
    private int currentMessageIndex = 0;
    private ItemPickUp itemScript;

    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            EndDialogue();
        }
        if (!dialogueText.gameObject.activeInHierarchy)
        {
            StartDialogue();
        }
        else
        {
            NextMessage();
        }
    }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // HAVE to define the itemscript or else we can't get the flag bool
        itemScript = questItem.GetComponent<ItemPickUp>();
    }

    private void StartDialogue()
    {
        questItem.SetActive(true);
        isDialogueActive = true;
        amelieSprite.SetActive(true);
        spriteRenderer.enabled = false;
        dialogueText.gameObject.SetActive(true);
        dialogueBG.gameObject.SetActive(true);
        currentMessageIndex = 0;

    
        // first messages
        if (itemScript.getRead())
        {
            StartCoroutine(TypeDialogue(itemPickedUpMessages[currentMessageIndex]));
        }
        // after item picked up
        else if (!hasSpoken)
        {
            StartCoroutine(TypeDialogue(messages[currentMessageIndex]));
        }
        // in between
        else
        {
            StartCoroutine(TypeDialogue(messages[messages.Length - 1]));
        }
        
    }

    private void NextMessage()
    {
        if (itemScript.getRead())
        {
            if (currentMessageIndex < itemPickedUpMessages.Length - 1)
            {
                currentMessageIndex++;
                StopAllCoroutines();  // Stop the previous typing coroutine
                StartCoroutine(TypeDialogue(itemPickedUpMessages[currentMessageIndex]));
            }
            else
            {
                // Once the last message in itemPickedUpMessages is reached
                EndDialogue();
            }
        }
        else
        {
            if (currentMessageIndex < messages.Length - 1)
            {
                currentMessageIndex++;
                StopAllCoroutines();  // Stop the previous typing coroutine
                StartCoroutine(TypeDialogue(messages[currentMessageIndex]));
            }
            else
            {
                hasSpoken = true;
                // Once the last message in messages is reached
                EndDialogue();
            }
        }
    }


    private void EndDialogue()
    {
        isDialogueActive = false;
        StopAllCoroutines();
        dialogueText.gameObject.SetActive(false);
        dialogueBG.gameObject.SetActive(false);
        amelieSprite.SetActive(false);
        spriteRenderer.enabled = true;
        currentMessageIndex = 0;  // Reset index for next interaction
    }

    private void OnTriggerEnter(Collider other)
    {
        interact.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
       
        interact.SetActive(false);
        amelieSprite.SetActive(false);
        StopAllCoroutines();  
        dialogueText.gameObject.SetActive(false);
        dialogueBG.gameObject.SetActive(false);
        spriteRenderer.enabled = true;
    }

    IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";  // clear existing
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);  
        }
    }
}
