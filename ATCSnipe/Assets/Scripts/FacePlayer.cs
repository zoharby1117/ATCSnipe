using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform player;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }
}
