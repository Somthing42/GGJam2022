using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcLookAtPlayer : MonoBehaviour
{
    Vector3 playerPos;
    Vector3 npcPos;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
       

       
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        npcPos = transform.position;

        Vector3 delta = new Vector3(playerPos.x - npcPos.x, 0.0f, playerPos.z - npcPos.z);

        Quaternion rotation = Quaternion.LookRotation(delta);

        gameObject.transform.rotation = rotation;
    }
}
