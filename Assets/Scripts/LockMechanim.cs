using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMechanim : MonoBehaviour
{
    public DoorMechanim[] doorToOpen;
    public KeyColor keyColor;

    bool playerInRange;
    bool alreadyOpen;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Player in range");
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player out of range");
            playerInRange = false;
        }
    }

    private void Update()
    {
        if (playerInRange && !alreadyOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (GameManager.Instance.CheckTheKey(keyColor))
                {
                    alreadyOpen = true;
                    animator.SetTrigger("open");
                }
            } 
        }
    }

    public void Open()
    {
        foreach(var d in doorToOpen)
        {
            d.open = true;
        }
    }
}
