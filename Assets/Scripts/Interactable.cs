using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Message to be displayed when hovered on
    public string promptMessage;

    //To be called from playerInteraction script
    public void BaseInteract()
    {
        Interact();
    }

    protected virtual void Interact()
    {
        //Function here
    }
}
