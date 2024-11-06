using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//exemple of a projectile behavior disappering after a certain time or on hit
public class Exemple_Projectile : MonoBehaviour
{
    public float lifeTime = 5;
    public float damage = 1;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the projectile hit a damagable object, deal damage
        var damagable = collision.GetComponent<IDamagable>();
        if (damagable != null)
        {
            damagable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }
}

public interface IDamagable
{
    void TakeDamage(float damage);
}
