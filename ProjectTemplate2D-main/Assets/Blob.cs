using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(LifeSystem))]
public class Blob : MonoBehaviour
{
    public float randomMoveSpeed = 0.5f; // Vitesse des mouvements al�atoires
    public float followSpeed = 1f; // Vitesse de suivi du joueur
    public float detectionRadius = 7f; // Rayon de d�tection du joueur

    [SerializeField]
    private LayerMask LayerMask;

    private Vector2 randomDirection; // Direction al�atoire
    private Rigidbody2D rb; // R�f�rence au Rigidbody2D
    private Transform player; // R�f�rence au joueur
    private LifeSystem lifeSystem;
    private float changeDirectionTime = 1f; // Temps avant de changer de direction al�atoire
    private float directionTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lifeSystem = GetComponent<LifeSystem>();
        // Trouve le joueur par tag (assurez-vous que le joueur a le tag "Player")
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }

        ChangeRandomDirection(); // Initialise une premi�re direction al�atoire
        directionTimer = changeDirectionTime;
    }

    void Update()
    {
        directionTimer -= Time.deltaTime;

        if (directionTimer <= 0)
        {
            ChangeRandomDirection();
            directionTimer = changeDirectionTime;
        }
    }

    void FixedUpdate()
    {
        var result = Physics2D.Raycast(rb.position, rb.velocity.normalized, 2f, LayerMask);
        Debug.DrawLine(rb.position, rb.position + rb.velocity.normalized * 5f, result.collider == null ? Color.red : Color.green);
        if (result.collider != null)
        {
            Debug.Log("Collision d�tect�e avec");
            ChangeRandomDirection();
        }

        if (player != null && Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            // Suivre doucement le joueur
            Vector2 directionToPlayer = (player.position - transform.position).normalized;
            rb.velocity = directionToPlayer * followSpeed;
        }
        else
        {
            // Mouvement al�atoire
            rb.velocity = randomDirection * randomMoveSpeed;
        }
    }

    void ChangeRandomDirection()
    {
        // G�n�re une nouvelle direction al�atoire
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }

    private void OnDrawGizmosSelected()
    {
        // Dessine le rayon de d�tection dans l'�diteur
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 contactPoint = collision.GetContact(0).point; // Point de contact
            Vector2 blobPosition = transform.position;

            LifeSystem playerLife = collision.gameObject.GetComponent<LifeSystem>();
            if (playerLife != null)
            {
                // Si le joueur attaque par le haut
                if (contactPoint.y > blobPosition.y + 0.1f)
                {
                    lifeSystem.TakeDamage(1); // Le blob prend 1 d�g�t
                }
                else
                {
                    playerLife.TakeDamage(1); // Le joueur prend 1 d�g�t
                }
            }
        }
    }
    }
