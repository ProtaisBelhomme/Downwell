using UnityEngine;

public class JumpAndShoot : MonoBehaviour
{
    public GameObject projectilePrefab; // Le prefab de la munition
    public Transform spawnPoint;        // Le point de spawn de la munition
    public float shootForce = 10f;      // La force du tir vers le bas

    private Rigidbody rb;
    public float jumpForce = 5f;        // Force du saut
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Détection du saut
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
            Shoot();
        }
    }

    void Jump()
    {
        // Applique une force vers le haut
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        isGrounded = false; // Le personnage n'est plus au sol
    }

    void Shoot()
    {
        // Instancie la munition au point de spawn
        GameObject projectile = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

        // Applique une force vers le bas
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
        if (projectileRb != null)
        {
            projectileRb.AddForce(Vector3.down * shootForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le personnage touche le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
