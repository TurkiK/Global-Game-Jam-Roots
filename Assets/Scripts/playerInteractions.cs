using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerInteractions : MonoBehaviour
{
    [Header("Interaction")]
    public LayerMask interactables;
    public float radius = 5f;

    [Header("Prompts")]
    public TMP_Text promptText;

    private void Update()
    {
        Collider[] hitCollider = Physics.OverlapSphere(transform.position, radius, interactables);
        if (hitCollider.Length > 0 && DialogueManager.instance.inConversation == false)
        {
            Transform nearestInteractable = hitCollider[0].transform;
            float dist = Vector3.Distance(transform.position, nearestInteractable.position);
            foreach (var item in hitCollider)
            {
                float tempDist = Vector3.Distance(transform.position, item.transform.position);
                if (tempDist < dist)
                    nearestInteractable = item.transform;
            }
            Interactable areaInteract = nearestInteractable.GetComponent<Interactable>();

            promptText.text = areaInteract.promptMessage;

            if (Input.GetKey(KeyCode.Space))
            {
                areaInteract.BaseInteract();
            }
        }
        else
            promptText.text = "";
    }
}
