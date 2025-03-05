using UnityEngine;
using UnityEngine.UI;

public class heal : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public AudioClip damageSound;  // Sonido de daño
    private AudioSource audioSource;

    private int currentHealth;

    void Start()
    {
        currentHealth = hearts.Length;
        audioSource = GetComponent<AudioSource>(); // Busca el AudioSource en el mismo objeto
        UpdateHearts();
    }

    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
            currentHealth--;
            UpdateHearts();

            // Reproducir sonido al recibir daño
            if (damageSound != null && audioSource != null)
            {
                audioSource.PlayOneShot(damageSound);
            }
        }

        if (currentHealth == 0)
        {
            Debug.Log("¡El jugador ha muerto!");
            // Aquí puedes agregar animaciones o reiniciar la escena
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = (i < currentHealth) ? fullHeart : emptyHeart;
        }
    }
}
