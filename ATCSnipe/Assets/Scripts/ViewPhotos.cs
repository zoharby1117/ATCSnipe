using UnityEngine;
using System.Collections.Generic;//lets us use lists


public class ViewPhoto : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private List<Transform[]> photoAlbum;
    //private GameObject[] objectsInPhoto;
    private int i;

    private bool viewing;//uses bool not boolean apparently
    void Start()
    {
        i = 0;
        viewing = false;
    }

    // Update is called once per frame
    void Update()
    {
        List<Transform[]> album = TakePhoto.photoAlbum;
        if (Input.GetKeyDown(KeyCode.X) && album.Count > 0)
        {
            viewing = !viewing; //basically flips from true to false and vice versa.
            if (viewing)
            {
                viewPhoto();
            }
        }

        if (viewing)
        {

            if (Input.GetKeyDown(KeyCode.RightArrow) && i < album.Count - 1)
            {
                i++;
                viewPhoto();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && i > 0)
            {
                i--;
                viewPhoto();
            }
        }
        //I need code that stores info from before the viewing photos otherwise we get locked here forever.
    }

    public void viewPhoto()
    {
        //PlayerInput.OnFoot.Disable();
        GameObject[] objectsInPhoto = GameObject.FindGameObjectsWithTag("Photoable");
        List<Transform[]> album = TakePhoto.photoAlbum;
        Transform[] photo = album[i];//this is a transform[]
        for (int i = 0; i < objectsInPhoto.Length; i++)
        {
            GameObject go = objectsInPhoto[i];//the object
            Transform t = photo[i];//its respective transform from the photo we took

            go.transform.position = t.position;
            go.transform.rotation = t.rotation;
            go.transform.localScale = t.localScale;

        }

    }
}
