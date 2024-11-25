using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class playercontrollerenlegende : MonoBehaviour
{
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Jump(float force)
    {
        body.velocity = new Vector2 (body.velocity.x, 0);
        body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        Debug.Log("shoot");
    }

    public void MoveLateral(float force)
    {
        body.velocity = new Vector2(0, body.velocity.y);
        body.AddForce(Vector2.right * force, ForceMode2D.Impulse);
    }
}
