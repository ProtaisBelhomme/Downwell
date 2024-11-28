using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LifeSystem))]
public class playercontrollerenlegende : MonoBehaviour
{
    private Rigidbody2D body;
    private bool isGrounded;
    public GameObject projectilePrefab; // Le prefab de la munition
    public Transform spawnPoint;        // Le point de spawn de la munition
    public float shootForce = 10f;
    private int ammo = 8;

    private LifeSystem lifeSystem;
    public float knockbackForce = 5f;
  
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        lifeSystem = GetComponent<LifeSystem>();
        lifeSystem.onDie.AddListener(() =>
        {
            Destroy(gameObject); // D�truit l'objet blob
        });

        
    }

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void Jump(float force)
    {
        if (isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            isGrounded = false;
            Debug.Log("jump");
        }
        else
        {
            if (ammo > 0) {
                body.velocity = new Vector2(body.velocity.x, 0);
                body.AddForce(Vector2.up * force / 8, ForceMode2D.Impulse);

                // Instancie la munition au point de spawn
                GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
                Debug.Log("Tag du projectile : " + projectile.tag);

                // Applique une force vers le bas
                Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
                if (projectileRb != null)
                {
                    projectileRb.AddForce(Vector2.down * shootForce, ForceMode.Impulse);
                }
               

                Debug.Log(ammo);
                ammo = ammo - 1;
                Destroy(projectile, 0.5f);
            }
            else
            {
                Debug.Log("no more ammo");
            }
        }
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
                ammo = 8;

            }
            else
            {
                lifeSystem.TakeDamage(1);

            }

           

            // Applique la force d'impulsion pour repousser le joueur vers le haut
            

            // Pour le d�bogage : Afficher dans la console le r�sultat de la force appliqu�e
            
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            ammo = 8;
            Debug.Log("true");
        }

    }
}
