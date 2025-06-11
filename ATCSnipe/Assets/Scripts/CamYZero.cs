using UnityEngine;

public class CamYZero : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        //if (transform.position.y != 1.0f)
        //{
            transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z);
        //}
    }
}
