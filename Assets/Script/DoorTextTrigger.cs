using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DoorTextTrigger : MonoBehaviour
{

    //public GameObject doorText;
    private SpriteRenderer doorTextSpriteRenderer;

    public TextMeshProUGUI currentObjectiveText;
    public TextMeshProUGUI newObjectiveText;

    public Image dialogueImage;
    public TextMeshProUGUI dialogueText;

    // Start is called before the first frame update
    void Start()
    {
        //doorTextSpriteRenderer = doorText.GetComponent<SpriteRenderer>();
        //doorTextSpriteRenderer.enabled = false;

        newObjectiveText.gameObject.SetActive(false);
        dialogueImage.enabled = false;
        dialogueText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("COLLISION!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //doorTextSpriteRenderer.enabled = true;
            currentObjectiveText.gameObject.SetActive(false);
            newObjectiveText.gameObject.SetActive(true);
            dialogueImage.enabled = true;
            dialogueText.gameObject.SetActive(true);

            StartCoroutine(UpdateObjective());
        }
    }

    private IEnumerator UpdateObjective()
    {
        WaitForSeconds wait = new WaitForSeconds(5f);
        yield return wait;

        //doorText.SetActive(false);
        dialogueImage.enabled = false;
        dialogueText.gameObject.SetActive(false);
    }
}
