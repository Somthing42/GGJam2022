using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tombstone : MonoBehaviour
{

    public GameObject littleGirlObj;

    
    public void TombstoneInteract()
    {
        littleGirlObj.SetActive(true);
        GameManager.instance.questsCompleated += 1;
    }

}
