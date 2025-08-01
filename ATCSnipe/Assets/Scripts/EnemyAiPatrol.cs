using UnityEngine;
using UnityEngine.AI;

public class EnemyAiPatrol : MonoBehaviour
{
    public Transform player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;
    public Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float Walkrange;
    float moveSpeed = 10f;
    float destTimer = 2f;
    bool satisfied;
    bool tooClose;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (destTimer > 0) destTimer -= Time.deltaTime;
        else destTimer = 0;
        agent.speed = moveSpeed;
        tooClose = Physics.CheckSphere(transform.position, 5f, playerLayer);
        if (satisfied) { 
            notTooClose();
            SearchForPlayer();
        }
        else
            Patrol();
        agent.SetDestination(destPoint);
    }
    void Patrol()
    {
        SearchForDest();
        if (!walkpointSet) ;
        if (walkpointSet && destTimer == 0) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 5) walkpointSet = false;
    }
    void SearchForDest()
    {
        float z = Random.Range(-Walkrange, Walkrange);
        float x = Random.Range(-Walkrange, Walkrange);
        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
    void SearchForPlayer()
    {
        destPoint = player.transform.position;
    }
    public void satisfy()
    {
        satisfied = true;
    }
    void notTooClose()
    {
        if (tooClose) moveSpeed = 0f;
        else moveSpeed = 5f;
    }
}
