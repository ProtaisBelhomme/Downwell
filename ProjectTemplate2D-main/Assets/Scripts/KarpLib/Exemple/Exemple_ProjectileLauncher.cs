using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//exemple of a projectile launcher
public class Exemple_ProjectileLauncher : MonoBehaviour
{
    [SerializeField]
    private Exemple_Projectile projectilePrefab;

    public float launchForce = 10;
    public float launchRate = 1;

    private float lastLaunchTime = 0;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            TryLaunchProjectile();
        }
    }

    public void TryLaunchProjectile()
    {
        if (projectilePrefab == null)
        {
            Debug.LogError("No projectile prefab set on the launcher", this);
            return;
        }

        if (Time.time - lastLaunchTime < launchRate)
        {
            Debug.Log("In cooldown", this);
            return;
        }

        LaunchProjectile();
        lastLaunchTime = Time.time;
    }

    public void LaunchProjectile()
    {
        var projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        var body = projectile.GetComponent<Rigidbody2D>();
        body.AddForce(transform.up * launchForce, ForceMode2D.Impulse);
    }

}
