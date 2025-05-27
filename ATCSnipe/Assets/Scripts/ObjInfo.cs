using UnityEngine;

public class ObjInfo : MonoBehaviour
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    //this is where I would put sprite or whatever

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ObjInfo(Vector3 pos, Quaternion rot, Vector3 sc)
    {
        position = pos;
        rotation = rot;
        scale = sc;
    }
}

