using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 10;
    CharacterController controller;
    float velocityY;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        Movement();
        GroundSensor();
    }
    private void OnControllerColliderHit(ControllerColliderHit other)
    {
        if(other.collider.CompareTag("Pickup"))
        {
            other.gameObject.GetComponent<Pickup>().Pick();
        }
    }

    void Movement()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        //Debug.Log(new Vector2(inputX, inputY));

        Vector3 movement = inputX * transform.right + inputY * transform.forward;
        controller.Move(movement * speed * Time.deltaTime);
    }
    void GroundSensor()
    {
        RaycastHit hit;
        bool didHit = Physics.Raycast(transform.position + Vector3.down, Vector3.down, out hit, 0.5f, LayerMask.GetMask("Ground"));

        if(didHit)
        {
            switch(hit.collider.tag)
            {
                case "FastFloor":
                    speed = 20;
                    break;

                case "SlowFloor":
                    speed = 4;
                    break;

                default:
                    speed = 10;
                    break;
            }
        }
        else
        {
            //speed = 10;
        }

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
