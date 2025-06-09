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
    float moveSpeed = 20f;
    public bool satisfied;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        satisfied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (satisfied)
            SearchForPlayer();
        else
            Patrol();
        agent.SetDestination(destPoint);
    }
    void Patrol()
    {
        SearchForDest();
        if (!walkpointSet) ;
        if (walkpointSet) agent.SetDestination(destPoint);
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
}
