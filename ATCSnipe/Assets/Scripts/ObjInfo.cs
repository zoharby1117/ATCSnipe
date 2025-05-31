using UnityEngine;

public class ObjInfo
{
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;

    public string spr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public ObjInfo(Vector3 pos, Quaternion rot, Vector3 sc, string s)//if sprite is applicable
    {
        position = pos;
        rotation = rot;
        scale = sc;
        spr = s;
    }

    public ObjInfo(Vector3 pos, Quaternion rot, Vector3 sc)//if sprite is not applicable
    {
        position = pos;
        rotation = rot;
        scale = sc;
        spr = null;
    }
}

