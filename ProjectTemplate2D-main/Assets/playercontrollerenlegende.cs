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
    public int ammo = 8;
    public GameObject[] bullets;
    private LifeSystem lifeSystem;
    public float knockbackForce = 5f;

    public AudioClip shootSound;  // Le son que tu veux jouer lorsqu'on tire
    public AudioClip ecrasementSound;
    public AudioClip dmgSound;
    public AudioClip groundSound;
    private AudioSource audioSource;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        lifeSystem = GetComponent<LifeSystem>();
        UpdateAmmoUI();
        lifeSystem.onDie.AddListener(() =>
        {
            Destroy(gameObject); // D�truit l'objet blob
        });
        if (audioSource == null)
        {
            // Si pas d'AudioSource attaché, en créer un
            audioSource = gameObject.AddComponent<AudioSource>();
        }

    }

    private void UpdateAmmoUI()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            // Si l'indice de l'élément est plus grand ou égal au nombre de munitions, désactiver l'image
            if (i >= ammo)
            {
                bullets[i].SetActive(false);  // Désactive l'image de munition
            }
            else
            {
                bullets[i].SetActive(true);   // Active l'image de munition
            }
        }
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
                if (audioSource != null && shootSound != null)
                {
                    audioSource.PlayOneShot(shootSound);  // Joue le son du tir
                }

                Debug.Log(ammo);
                ammo = ammo - 1;
                UpdateAmmoUI();
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
                if (audioSource != null && ecrasementSound != null)
                {
                    audioSource.PlayOneShot(ecrasementSound);  
                }
                body.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                Debug.Log("Knockback appliqué : " + knockbackDirection * knockbackForce);
                ammo = 8;

            }
            else
            {
                
                if (audioSource != null && dmgSound != null)
                {
                    audioSource.PlayOneShot(dmgSound);  
                }
                lifeSystem.TakeDamage(1);
            }

           

            // Applique la force d'impulsion pour repousser le joueur vers le haut
            

            // Pour le d�bogage : Afficher dans la console le r�sultat de la force appliqu�e
            
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Vector2 contactPoint = collision.GetContact(0).point; // Point de contact
            Vector2 playerPosition = transform.position;

            if (contactPoint.y < playerPosition.y + 0.1f)
            {
                isGrounded = true;
                ammo = 8;
                if (audioSource != null && groundSound != null)
                {
                    audioSource.PlayOneShot(groundSound);
                }
                UpdateAmmoUI();
                Debug.Log("sooool");
            }
        }

    }
}
