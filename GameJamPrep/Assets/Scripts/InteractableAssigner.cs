using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InteractableAssigner : MonoBehaviour
{
    
    // public string interactableType;

    [HideInInspector]
    public int arrayIdx = 0;
    [HideInInspector]
    public string[] Type = new string[] { "Door", "Item","Npc"};


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
        if (arrayIdx == 0)
        {
            gameObject.GetComponentInParent<DoorController>().PlayAnimation();
        }
        if (arrayIdx == 1)
        {
            
            //call the item function
            gameObject.GetComponent<ItemPickUp>().PickedUp();
        }
        if (arrayIdx == 2)
        {
            gameObject.GetComponent<NpcDialogue>().playDialogue();
        }
    }


   
}
