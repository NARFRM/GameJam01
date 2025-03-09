using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject player;
    public float enemyDistanceToRun = 4.0f;
    private Animator movementAnimation;
    private AudioSource audioSource;
    public AudioClip disappearSound; // Asigna el sonido en el Inspector
    private bool isPlaying = false;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 6.0f;
        movementAnimation = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>(); // Obtener el AudioSource

        if (audioSource == null)
        {
            Debug.LogError("No se encontró un AudioSource en " + gameObject.name);
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < enemyDistanceToRun)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;
            Vector3 newPosition = transform.position + dirToPlayer;
            _agent.SetDestination(newPosition);
        }

        movementAnimation.SetBool("isFleeing", _agent.velocity.magnitude != 0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isPlaying)
        {
            isPlaying = true;
            EnemyCounterUI.Instance.EnemyDefeated();

            if (audioSource != null && disappearSound != null)
            {
                audioSource.PlayOneShot(disappearSound); // Reproduce el sonido
                Invoke("DestroyNPC", disappearSound.length); // Espera a que termine el sonido
            }
            else
            {
                DestroyNPC(); // Si no hay sonido, destruye inmediatamente
            }
        }
    }

    void DestroyNPC()
    {
        Destroy(gameObject);
    }
}
