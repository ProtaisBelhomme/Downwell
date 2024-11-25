using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LifeSystem))]
public class playercontrollerenlegende : MonoBehaviour
{
    private Rigidbody2D body;
    private LifeSystem lifeSystem;
    public float knockbackForce = 5f;
  
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        lifeSystem = GetComponent<LifeSystem>();
        lifeSystem.onDie.AddListener(() =>
        {
            Destroy(gameObject); // Détruit l'objet blob
        });

        
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ennemie"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            Vector2 knockbackDirection = Vector2.up;

            if (contactPoint.y < transform.position.y + 0.1f) 
            {
                body.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                Debug.Log("Knockback appliqué : " + knockbackDirection * knockbackForce);
                

            }
            else
            {
                lifeSystem.TakeDamage(1);

            }

           

            // Applique la force d'impulsion pour repousser le joueur vers le haut
            

            // Pour le débogage : Afficher dans la console le résultat de la force appliquée
            
        }
    
    }
}
