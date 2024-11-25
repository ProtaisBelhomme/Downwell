using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour
{
    public int life = 0;
    public int maxLife = 3;

    public UnityEvent onDie;

    private void Start()
    {
        FullHeal();
    }

    public bool CheckAlive()
    {
        return life > 0;
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        life = Mathf.Clamp(life, 0, maxLife);

        if(life <= 0 )
        {
            Die();
        }
    }

    private void Die()
    {
        life = 0;
        Debug.Log("MORT");
        onDie?.Invoke();
    }

    public void Heal(int healValue)
    {
        life += healValue;
        life = Mathf.Clamp(life, 0, maxLife);

    }
    public void FullHeal()
    {
        life = maxLife;
    }
}
