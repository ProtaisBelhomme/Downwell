using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LifeSystem))]
public class escargot : MonoBehaviour
{

    public int maxLife = 1;
    public int life;
    public float speed = 2f; // Vitesse de d�placement de l'escargot
    private Vector2 moveDirection; // Direction de d�placement actuelle
    [SerializeField]
    private LayerMask LayerMask;

    private Rigidbody2D rb; // R�f�rence au Rigidbody2D
    // Start is called before the first frame update
    void Start()
    {
        life = maxLife;
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.down;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = moveDirection * speed;
    }

    public void FixedUpdate()
    {
        var result = Physics2D.Raycast(rb.position, rb.velocity.normalized, 1f, LayerMask);
        Debug.DrawLine(rb.position, rb.position + rb.velocity.normalized * 1f, result.collider == null ? Color.red : Color.green);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            // Inverse la direction horizontale
            moveDirection = -moveDirection;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            // Inflige 1 d�g�t au joueur
            LifeSystem playerLife = collision.gameObject.GetComponent<LifeSystem>();
            if (playerLife != null)
            {
                playerLife.TakeDamage(1);
            }
        }
    }
}
