using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image[] hearts;  // Corazones en la UI
    public Sprite fullHeart;  // Imagen del corazón lleno
    public Sprite emptyHeart; // Imagen del corazón vacío

    [SerializeField] private int currentHealth;  // Cantidad actual de vidas

    void Start()
    {
        currentHealth = hearts.Length; // Inicia con la cantidad total de corazones
        UpdateHearts(); // Actualiza la UI
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--; // Reduce una vida
            UpdateHearts();  // Actualiza los corazones en pantalla
        }

        if (currentHealth == 0)
        {
            Debug.Log("¡El jugador ha muerto!");
            // Aquí puedes agregar una animación o reiniciar la escena
        }
    }

    void UpdateHearts()
    {
        // Recorre cada corazón y lo cambia a vacío si ha perdido vida
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = (i < currentHealth) ? fullHeart : emptyHeart;
        }
    }

    public int GetCurrentHealth()
    {
        return currentHealth; // Devuelve la vida actual
    }
}
