using UnityEngine;
using TMPro; // Include the TextMesh Pro namespace
using System.Collections;

public class CharacterInteraction : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;  
    public string message = "Hello, welcome to our world!";  
    public float typingSpeed = 0.05f;  
    public GameObject amelieSprite;
    private SpriteRenderer spriteRenderer;  

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        dialogueText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entered collider");
        amelieSprite.SetActive(true);
        spriteRenderer.enabled = false; 
        dialogueText.gameObject.SetActive(true); 
        StartCoroutine(TypeDialogue(message));  
    }

    private void OnTriggerExit2D(Collider2D other)
    {
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
