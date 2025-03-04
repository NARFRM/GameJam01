using UnityEngine;

public class DroneFollow : MonoBehaviour
{
    public Transform player;       // Referencia al jugador
    public Transform pointA;
    public Transform pointB;
    public float patrolSpeed = 2f; // Velocidad de patrulla
    public float chaseSpeed = 4f;  // Velocidad de persecuci�n
    public float detectionRange = 5f;

    private Vector3 targetPosition; // Posici�n a la que se mueve
    private bool chasing = false;   // Estado de persecuci�n

    void Start()
    {
        targetPosition = pointA.position; // Inicia patrullando hacia A
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            // Si el jugador est� cerca, lo persigue
            chasing = true;
        }
        else if (chasing)
        {
            // Si el jugador se aleja, vuelve a patrullar
            chasing = false;
            targetPosition = GetClosestPatrolPoint();
        }

        if (chasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, patrolSpeed * Time.deltaTime);

        // Si llega al punto A, cambia hacia B
        if (Vector3.Distance(transform.position, pointA.position) < 0.1f)
        {
            targetPosition = pointB.position;
        }
        // Si llega al punto B, cambia hacia A
        else if (Vector3.Distance(transform.position, pointB.position) < 0.1f)
        {
            targetPosition = pointA.position;
        }
    }

    void ChasePlayer()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * chaseSpeed * Time.deltaTime;
        transform.LookAt(player); // Hace que el enemigo mire al jugador
    }

    Vector3 GetClosestPatrolPoint()
    {
        // Retorna el punto de patrulla m�s cercano 
        return Vector3.Distance(transform.position, pointA.position) < Vector3.Distance(transform.position, pointB.position)
            ? pointA.position : pointB.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController.instance.ReduceLife(10);
        }
    }
}

