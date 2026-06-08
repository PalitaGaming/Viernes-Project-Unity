using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] private float lifetime = 5f;

    [Header("Layers")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask hittableLayer;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        int otherLayer = other.gameObject.layer;

        if ((groundLayer.value & (1 << otherLayer)) != 0)
        {
            Destroy(gameObject);
            return;
        }

        if ((hittableLayer.value & (1 << otherLayer)) != 0)
        {
            // TODO: Damage logic

            Destroy(gameObject);
            return;
        }
    }
}