using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    [SerializeField] float sensivity = 500;
    Transform player;
    float xRot;

    void Start()
    {
        player = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        player.Rotate(new Vector3(0, mouseX, 0));

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -70, 50);
        transform.localRotation = Quaternion.Euler(new Vector3(xRot, 0, 0));
    }
}
