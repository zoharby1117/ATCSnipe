using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    public Transform player;//set this to player in the inspector

    private float constantX;//will lock the X rotation
    void Start()
    {
        constantX = transform.rotation.x;
    }

    // Update is called once per frame
    void Update()
    {
        //It was moving around for some reason so I had to lock its position
        //Vector3 temp = transform.position; this doesnt work because it is a shallow copy
        //Vector3 temp = new Vector3(transform.position.x, transform.position.y, transform.position.z); also doesnt work
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        //floats are immutable so they will work for our deepcopy
        Vector3 temp = new Vector3(x, y, z);
        transform.LookAt(player);
        Vector3 rot = transform.eulerAngles;
        transform.eulerAngles = new Vector3(constantX, rot.y, rot.z);//rotates with locked X value
        transform.position = temp;
    }
}
