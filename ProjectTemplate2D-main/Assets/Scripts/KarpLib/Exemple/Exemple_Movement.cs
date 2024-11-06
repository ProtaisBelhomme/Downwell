using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exemple_Movement : MonoBehaviour
{
    public float speed = 5f;
    public float deadzone = .1f;

    public void Update()
    {
        //Use the GetAxis function to get the input from the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);

        if(movement.magnitude > 1)
        {
            movement.Normalize();
        }

        if(movement.magnitude > deadzone)
        {
            //Move the object
            transform.position += new Vector3(movement.x, movement.y, 0) * speed * Time.deltaTime;
            //Rotate the object
            var moveRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, moveRotation, Time.deltaTime * 2.5f);
        }
    }
}
