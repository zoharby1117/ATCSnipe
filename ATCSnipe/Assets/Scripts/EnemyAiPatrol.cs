using UnityEngine;
using UnityEngine.AI;

public class EnemyAiPatrol : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    [SerializeField] LayerMask groundLayer, playerLayer;
    Vector3 destPoint;
    bool walkpointSet;
    [SerializeField] float Walkrange;
    float moveSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = moveSpeed;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Patrol();
    }
    void Patrol() {
        SearchForDest();
        if (!walkpointSet) ;
        if (walkpointSet) agent.SetDestination(destPoint);
        if (Vector3.Distance(transform.position, destPoint) < 5) walkpointSet = false;
    }
    void SearchForDest() {
        float z = Random.Range(-Walkrange, Walkrange);
        float x = Random.Range(-Walkrange, Walkrange);
        destPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);
        if (Physics.Raycast(destPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
        }
    }
}
