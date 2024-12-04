using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class LifeSystem : MonoBehaviour
{
    public int life = 0;
    public int maxLife = 3;
    public GameObject[] vie;

    public UnityEvent onDie;

    public Renderer playerRenderer;  // Référence au Renderer du joueur pour modifier la couleur
    public Color damageColor = Color.red; // Couleur à appliquer lors des dégâts
    public Color normalColor = Color.white;

    private void Start()
    {
        FullHeal();
        UpdateVieUI();
        if (playerRenderer == null)
            playerRenderer = GetComponent<Renderer>();
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

        StartCoroutine(DamageFlash());

        if (life <= 0 )
        {
            Die();
        }
    }

    private IEnumerator DamageFlash()
    {
        // Changer la couleur à rouge
        playerRenderer.material.color = damageColor;

        // Attendre un petit moment (0.2 secondes par exemple)
        yield return new WaitForSeconds(0.2f);

        // Revenir à la couleur normale
        playerRenderer.material.color = normalColor;
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
