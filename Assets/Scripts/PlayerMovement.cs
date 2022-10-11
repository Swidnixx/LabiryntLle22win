using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    CharacterController controller;
    float velocityY;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        Movement();
        GroundSensor();
    }

    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Debug.Log(new Vector2(inputX, inputY));

        Vector3 movement = inputX * transform.right + inputY * transform.forward;
        controller.Move(movement * speed * Time.deltaTime);
    }
    void GroundSensor()
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(transform.position + Vector3.down, Vector3.down, out hit, 0.5f);

        if(didHit)
        {
            velocityY = 0;
        }
        else
        {
            Gravity();
        }
    }

    void Gravity()
    {
        if (velocityY < 55)
        {
            velocityY += 10 * Time.deltaTime; 
        }

        controller.Move( Vector3.down * velocityY * Time.deltaTime );
    }
}
