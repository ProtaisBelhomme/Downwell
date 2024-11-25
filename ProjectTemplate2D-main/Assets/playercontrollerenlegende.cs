using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class playercontrollerenlegende : MonoBehaviour
{
    private Rigidbody2D body;
    private bool isGrounded;
    public GameObject projectilePrefab; // Le prefab de la munition
    public Transform spawnPoint;        // Le point de spawn de la munition
    public float shootForce = 10f;

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
        if (isGrounded)
        {
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(Vector2.up * force, ForceMode2D.Impulse);
            isGrounded = false;
            Debug.Log("jump");
        }
        else
        {
            body.velocity = new Vector2(body.velocity.x, 0);
            body.AddForce(Vector2.up * force/5, ForceMode2D.Impulse);

            // Instancie la munition au point de spawn
            GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

            // Applique une force vers le bas
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            if (projectileRb != null)
            {
                projectileRb.AddForce(Vector2.down * shootForce, ForceMode.Impulse);
            }
            Debug.Log("shoot");
            Destroy(projectile, 0.1f);
        }
    }

    public void MoveLateral(float force)
    {
        body.velocity = new Vector2(0, body.velocity.y);
        body.AddForce(Vector2.right * force, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Vérifie si le personnage touche le sol
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            Debug.Log("true");
        }
    }
}
