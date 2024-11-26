using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(LifeSystem))]
public class BulletBehaviour : MonoBehaviour { 

    private Rigidbody2D body;
    public GameObject projectilePrefab; // Le prefab de la munition
    public Transform spawnPoint;        // Le point de spawn de la munition
    public float shootForce = 10f;
    

    private LifeSystem lifeSystem;
    public float knockbackForce = 5f;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

        }
     

    }
}
