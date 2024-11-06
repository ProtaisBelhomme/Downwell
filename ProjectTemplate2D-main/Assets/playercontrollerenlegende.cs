using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class playercontrollerenlegende : MonoBehaviour
{
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Jump(float force)
    {
        body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
    }

    public void MoveLateral(float force)
    {
        body.AddForce(Vector2.right *  force * Time.deltaTime , ForceMode2D.Force);
    }
}
