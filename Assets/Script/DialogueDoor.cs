using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueDoor : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public GameObject dialogueBox;
    public string[] lines;
    public float textSpeed;

    private int index;

    void Start()
    {
        dialogueBox.gameObject.SetActive(false);
        textComponent.text = string.Empty;
    }

   void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartDialogue();
        }
    }
    
    void StartDialogue()
    {
        if(dialogueBox.gameObject.activeInHierarchy == false)
        {
            dialogueBox.gameObject.SetActive(true);
            index = 0;
            StartCoroutine(TypeLine());
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    

    void NextLine()
    {
        if(index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        } 
        else
        {
            gameObject.SetActive(false);
        } 
    }
}
