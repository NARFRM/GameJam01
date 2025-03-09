using UnityEngine;

public class NPCDisappear : MonoBehaviour
{
    public AudioClip sound;  // Asigna el sonido en el Inspector
    public float delayBeforeDestroy = 1.0f; // Tiempo antes de desaparecer

    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlaying)
        {
            isPlaying = true;
            audioSource.Play();
            Invoke("Disappear", sound.length + delayBeforeDestroy);
        }
    }

    void Disappear()
    {
        Destroy(gameObject); // Destruir solo después de que termine el sonido
    }
}