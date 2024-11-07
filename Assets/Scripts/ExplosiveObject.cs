// ExplosiveObject.cs
using UnityEngine;

public class ExplosiveObject : MonoBehaviour
{
    public float timer = 5f;
    public float explosionForce = 500f;
    public float explosionRadius = 5f;

    private void Start()
    {
        Invoke("Explode", timer);
    }

    private void Explode()
    {
        // Explosi�n f�sica
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // Puedes agregar efectos visuales o de sonido aqu�

        // Destruir el objeto despu�s de la explosi�n
        Destroy(gameObject);
    }
}

