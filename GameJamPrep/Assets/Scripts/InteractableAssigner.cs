using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractableAssigner : MonoBehaviour
{
    
    public string interactableType;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //selects the function to do based on what the object is
    public void ItemFunction()
    {
        if (interactableType == "Door")
        {
            gameObject.GetComponentInParent<DoorController>().PlayAnimation();
        }
        if (interactableType == "Item")
        {
            
            //call the item function
            gameObject.GetComponent<ItemPickUp>().PickedUp();
        }
        if (interactableType == "Npc")
        {
            gameObject.GetComponent<NpcDialogue>().playDialogue();
        }
    }


   
}
