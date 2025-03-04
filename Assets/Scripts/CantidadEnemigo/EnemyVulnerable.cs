using UnityEngine;

public class EnemyVulnerable : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Se destruye cuando el jugador lo toca
        }
    }
}
