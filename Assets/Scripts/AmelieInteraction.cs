using UnityEngine;
using TMPro;
using System.Collections;

public class CharacterInteraction : MonoBehaviour
{
    // some sort of destroyed dialogueText error happening i should figure out where this is coming from
    public TextMeshProUGUI dialogueText;
    public GameObject interact;
    public string message = "Text to display goes here!";  
    public float typingSpeed = 0.1f;  
    public GameObject amelieSprite;
    private SpriteRenderer spriteRenderer;
    private bool isInTrigger;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.E)) {
            amelieSprite.SetActive(true);
            spriteRenderer.enabled = false;
            dialogueText.gameObject.SetActive(true);
            StartCoroutine(TypeDialogue(message));
        }
        if (!isInTrigger)
        {
            amelieSprite.SetActive(false);
            spriteRenderer.enabled = true;
            StopAllCoroutines();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInTrigger = true;
        interact.SetActive(true);
        Debug.Log("entered collider");
    }

    private void OnTriggerExit(Collider other)
    {
        isInTrigger = false;
        interact.SetActive(false);
        Debug.Log("exited collider");
        amelieSprite.SetActive(false);
        StopAllCoroutines();  // Stop the typing coroutine
        dialogueText.gameObject.SetActive(false);
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
