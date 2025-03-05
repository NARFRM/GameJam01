using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public static HealthUI Instance { get; private set; }
    public Image[] hearts;  // Corazones en la UI
    public Sprite fullHeart;  // Imagen del coraz�n lleno
    public Sprite emptyHeart; // Imagen del coraz�n vac�o

    [SerializeField] private int currentHealth;  // Cantidad actual de vidas

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
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
            Debug.Log("�El jugador ha muerto!");
            // Aqu� puedes agregar una animaci�n o reiniciar la escena
        }
    }

    void UpdateHearts()
    {
        // Recorre cada coraz�n y lo cambia a vac�o si ha perdido vida
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
