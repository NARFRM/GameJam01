using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 1; // Cu�ntos corazones quita por golpe

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si toca al Player
        {
            HealthUI healthUI = FindObjectOfType<HealthUI>(); // Busca la UI de salud
            if (healthUI != null)
            {
                healthUI.TakeDamage();  // Quita un coraz�n
       //         Debug.Log("El enemigo golpe� al jugador. Corazones restantes: " + healthUI.GetCurrentHeal());
            }
            else
            {
                Debug.LogError("No se encontr� el script HealthUI en la escena.");
            }
        }
    }
}
