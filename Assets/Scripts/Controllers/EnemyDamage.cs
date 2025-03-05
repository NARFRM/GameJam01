using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si toca al Player
        {
            HealthUI.Instance.TakeDamage();
        }
    }
}
