using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ObjectiveUpdater : MonoBehaviour
{
    private Inventory inventory;
    public TextMeshProUGUI currentObjectiveText;
    public TextMeshProUGUI newObjectiveText;

    public Image dialogueImage;
    public TextMeshProUGUI dialogueText;
    private bool openDialogue = true;

    public GameObject openDoor;
    private SpriteRenderer openDoorSpriteRenderer;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();

        dialogueImage.enabled = false;
        dialogueText.gameObject.SetActive(false);

        openDoorSpriteRenderer = openDoor.GetComponent<SpriteRenderer>();
        openDoorSpriteRenderer.enabled = false;
    }

    void Update()
    {
        if (inventory.isFull[0] && inventory.isFull[1] && inventory.isFull[2] && inventory.isFull[3] && openDialogue)
        {
            currentObjectiveText.gameObject.SetActive(false);
            newObjectiveText.gameObject.SetActive(true);

            dialogueImage.enabled = true;
            dialogueText.gameObject.SetActive(true);

            openDialogue = false;
            openDoorSpriteRenderer.enabled = true;

            StartCoroutine(UpdateObjective());
        }
    }

    private IEnumerator UpdateObjective()
    {
        WaitForSeconds wait = new WaitForSeconds(5f);
        yield return wait;

        dialogueImage.enabled = false;
        dialogueText.gameObject.SetActive(false);
    }
}
