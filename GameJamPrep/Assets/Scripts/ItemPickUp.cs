using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private GameObject player;

    public bool littleGirlObj;

    public GameObject littleGirl;

    public GameObject tombstone;

   public void PickedUp()
    {
       player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Inventory>().items.Add(gameObject.name);

        if (littleGirlObj == true)
        {
            littleGirl.SetActive(false);
            tombstone.SetActive(true);
            
        }

        Destroy(gameObject);
    } 
   
}
