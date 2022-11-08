using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    Transform player;
    public Transform receiver;

    bool playerIsPassing;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Kolizja portal");
            playerIsPassing = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsPassing = false;
        }
    }

    private void FixedUpdate()
    {
        Vector3 portalToPlayer = player.position - transform.position;

        Debug.DrawRay(transform.position, portalToPlayer);
        Debug.DrawRay(transform.position, transform.up, Color.red);

        if (playerIsPassing)
        {
            float dotProduct = Vector3.Dot(portalToPlayer, transform.up);
            if (dotProduct < 0)
            {
                player.position = receiver.position;
                player.forward = receiver.up;
            }
        }
    }
}
