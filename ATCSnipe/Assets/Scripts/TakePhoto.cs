using UnityEngine;
using System.Collections.Generic;//lets us use lists
public class TakePhoto : MonoBehaviour
{
    //define photoalbum instance var
    public static List<Transform[]> photoAlbum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        photoAlbum = new List<Transform[]>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject[] objectsInPhoto = GameObject.FindGameObjectsWithTag("Photoable"); //returns GameObject[]
                                                                                          //the list of game objects in the photo.

            //Each photo is represented as a list of transforms. (I may change this later.)
            photoAlbum.Add(new Transform[objectsInPhoto.Length]); //a new list of transforms, aka a new photo, equal in length to the number of objects.

            for (int i = 0; i < objectsInPhoto.Length; i++)
            {
                GameObject go = objectsInPhoto[i];//we dont use get
                Transform[] photo = photoAlbum[photoAlbum.Count - 1];//the photo we just took
                Transform newTransform = new Transform(go.transform.position, go.transform.rotation, go.transform.localScale);//deep copy
                photo[i] = newTransform;
            }
        }
    }
}
