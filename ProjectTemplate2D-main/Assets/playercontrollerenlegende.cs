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
        if (Mathf.Approximately(body.velocity.y, 0))
        {
            body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
        }
        else
        {
            body.AddForce(Vector2.up * force/2, ForceMode2D.Impulse);
            Debug.Log("attack");
        }
        
    }

    public void MoveLateral(float force)
    {
        body.AddForce(Vector2.right *  force * Time.deltaTime , ForceMode2D.Force);
    }
}
