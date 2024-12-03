using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LifeSystem : MonoBehaviour
{
    public int life = 0;
    public int maxLife = 3;
    public GameObject[] vie;

    public UnityEvent onDie;


    private void Start()
    {
        FullHeal();
        UpdateVieUI();
    }


    private void UpdateVieUI()
    {
        for (int i = 0; i < vie.Length; i++)
        {
            // Si l'indice de l'élément est plus grand ou égal au nombre de munitions, désactiver l'image
            if (i >= life)
            {
                vie[i].SetActive(false);  // Désactive l'image de munition
            }
            else
            {
                vie[i].SetActive(true);   // Active l'image de munition
            }
        }
    }

    public bool CheckAlive()
    {
        return life > 0;
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        UpdateVieUI();
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
