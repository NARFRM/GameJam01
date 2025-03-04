using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int vidas = 3; // N�mero de vidas del jugador
    private VidasManager vidasManager;

    void Start()
    {
        // Buscar el VidasManager para actualizar la UI
        vidasManager = FindObjectOfType<VidasManager>();
    }

    public void RecibirDa�o()
    {
        vidas--; // Resta una vida

        if (vidasManager != null)
        {
            vidasManager.PerderVida(); // Actualizar corazones en la UI
        }

        if (vidas <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        Debug.Log("�El jugador ha muerto!");
        // Aqu� puedes agregar la pantalla de "Game Over"
    }

    void OnTriggerEnter(Collider other)
    {
        // Si toca a un enemigo peligroso, pierde vida
        if (other.CompareTag("EnemigoPeligroso"))
        {
            RecibirDa�o();
        }

        // Si toca a un enemigo vulnerable, lo mata
        if (other.CompareTag("EnemigoVulnerable"))
        {
            Destroy(other.gameObject); // El enemigo vulnerable muere
        }
    }
}
