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
        List<ObjInfo[]> album = TakePhoto.photoAlbum;
        if (Input.GetKeyDown(KeyCode.X) && album.Count > 0)
        {
            viewPhoto();
            //viewing = !viewing; //basically flips from true to false and vice versa.
            //if (viewing)
            //{
            //    viewPhoto();
            //}
        }



        //if (viewing)
        //{

        //if (Input.GetKeyDown(KeyCode.RightArrow) && i < album.Count - 1)
        //{
        //    i++;
        //    viewPhoto();
        //}
        //else if (Input.GetKeyDown(KeyCode.LeftArrow) && i > 0)
        //{
        //    i--;
        //    viewPhoto();
        //}
        //}
        //I need code that stores info from before the viewing photos otherwise we get locked here forever.
    }

    public void viewPhoto()
    {
        //PlayerInput.OnFoot.Disable();
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

            boolean viewing = true;
            while (viewing)//This keeps running, basically pausing the frames, until viewing is false in every run of viewphoto()
                           //this way things are paused easily
            {

                if (Input.GetKeyDown(KeyCode.RightArrow) && i < album.Count - 1)
                {
                    i++;
                    viewPhoto();
                    viewing = false;//after the above view terminates, this loop will terminate as well.
                                    //when the last loop terminates we go back to normal.
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) && i > 0)//might add a way to go back to beginning/end later
                {
                    i--;
                    viewPhoto();
                    viewing = false;
                }
                if (Input.GetKeyDown(KeyCode.X))
                {
                    viewing = false;//finish
                }
            }
        }

    }

}
}
