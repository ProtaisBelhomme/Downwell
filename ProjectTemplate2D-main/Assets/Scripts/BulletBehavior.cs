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
       
            Destroy(gameObject);
        
        
        

    }
}
