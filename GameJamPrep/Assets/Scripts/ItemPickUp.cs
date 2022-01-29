using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    private GameObject player;
   public void PickedUp()
    {
       player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<Inventory>().items.Add(gameObject.name);
        Destroy(gameObject);
    } 
   
}
