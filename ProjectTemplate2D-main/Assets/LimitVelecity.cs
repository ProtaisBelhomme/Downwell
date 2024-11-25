using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class LimitVelecity : MonoBehaviour
{
    private Rigidbody2D body;
    [SerializeField] private float maxVelY = 10;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();    
    }

    private void FixedUpdate()
    {
        if(Mathf.Abs(body.velocity.y) > maxVelY)
        {
            body.velocity = new Vector2(body.velocity.x, maxVelY * Mathf.Sign(body.velocity.y));
        }
    }
}
