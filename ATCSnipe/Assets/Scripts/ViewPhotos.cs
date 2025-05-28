using UnityEngine;
using System.Collections.Generic;//lets us use lists


public class ViewPhoto : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private List<Transform[]> photoAlbum;
    //private GameObject[] objectsInPhoto;
    private int i;
    //private CharacterController cc;
    public Transform player;

    private bool viewing;//uses bool not boolean apparently

    private float temp;
    void Start()
    {
        i = 0;//starts at first photo
        viewing = false;
        temp = player.GetComponent<CharacterController>().minMoveDistance;
    }

    // Update is called once per frame
    void Update()
    {
        List<ObjInfo[]> album = TakePhoto.photoAlbum;
        if (Input.GetKeyDown(KeyCode.X) && album.Count > 0)
        {
            //viewPhoto();
            viewing = !viewing; //basically flips from true to false and vice versa.
            if (viewing)
            {
                viewPhoto();
            }
            else
            {
                player.GetComponent<CharacterController>().minMoveDistance = temp;
            }
        }



        if (viewing)
        {

            player.GetComponent<CharacterController>().minMoveDistance = 999;

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
        //(Player)player.GetComponent(InputManager).OnFootDisable();
        GameObject[] objectsInPhoto = GameObject.FindGameObjectsWithTag("Photoable");
        List<ObjInfo[]> album = TakePhoto.photoAlbum;
        ObjInfo[] photo = album[i];
        for (int i = 0; i < objectsInPhoto.Length; i++)
        {
            GameObject go = objectsInPhoto[i];//the object
            ObjInfo info = photo[i];//its respective transform from the photo we took

            go.transform.position = info.position;
            go.transform.rotation = info.rotation;
            go.transform.localScale = info.scale;


        }

    }

}

