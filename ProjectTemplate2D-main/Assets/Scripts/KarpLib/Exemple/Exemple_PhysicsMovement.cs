using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Exemple_PhysicsMovement : MonoBehaviour
{
    private Rigidbody2D _body;
    private CircleCollider2D _collid;

    public float speed = 5f;
    public float deadzone = .1f;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collid = GetComponent<CircleCollider2D>();
    }

    public void Update()
    {
        //Use the GetAxis function to get the input from the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);
        if (movement.magnitude > 1)
        {
            movement.Normalize();
        }

        if (movement.magnitude > deadzone)
        {
            //Move the object
            _body.velocity = movement * speed;

            //Rotate the object
            var moveRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, moveRotation, Time.deltaTime * 2.5f);
        }
    }

}
