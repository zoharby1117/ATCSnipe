using UnityEngine;
using System.Collections.Generic;//lets us use lists
public class TakePhoto : MonoBehaviour
{
    //define photoalbum instance var
    public static List<ObjInfo[]> photoAlbum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        photoAlbum = new List<ObjInfo[]>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {

            //Each photo is represented as a list of transforms. (I may change this later.)
            TakenTextChanger.instance.AddPhoto();
            photoAlbum.Add(generateArray()); //a new list of ObjInfo, aka a new photo, equal in length to the number of objects.
            

        }
    }

    public static ObjInfo[] generateArray()//generates an array that represents a state in space, or the photo
    {
        GameObject[] objectsInPhoto = GameObject.FindGameObjectsWithTag("Photoable"); //returns GameObject[]
                                                                                      //the list of game objects in the photo.
        ObjInfo[] photo = new ObjInfo[objectsInPhoto.Length];
        for (int i = 0; i < objectsInPhoto.Length; i++)
        {
            GameObject go = objectsInPhoto[i];//we dont use get
            //ObjInfo[] photo = photoAlbum[photoAlbum.Count - 1];//the photo we just took
            ObjInfo info = new ObjInfo(go.transform.position, go.transform.rotation, go.transform.localScale);//deep copy
            photo[i] = info;
        }
        return photo;
    }
}
