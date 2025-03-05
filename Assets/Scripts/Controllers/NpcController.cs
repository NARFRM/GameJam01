using UnityEngine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    private NavMeshAgent _agent;
    public GameObject player;
    public float enemyDistanceToRun = 4.0f;
    private Animator movementAnimation;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.speed = 6.0f;
        movementAnimation = GetComponent<Animator>();
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
        if (_agent.velocity.magnitude != 0f)
        {
            movementAnimation.SetBool("isFleeing", true);
        }
        else
        {
            movementAnimation.SetBool("isFleeing", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            EnemyCounterUI.Instance.EnemyDefeated();
            Destroy(gameObject);
        }
    }
}