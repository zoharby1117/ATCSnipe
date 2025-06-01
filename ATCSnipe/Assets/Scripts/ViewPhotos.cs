using UnityEngine;
using UnityEditor;
using System.Collections.Generic;//lets us use lists


public class ViewPhotos : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //private List<Transform[]> photoAlbum;
    //private GameObject[] objectsInPhoto;
    private int i;
    //private CharacterController cc;
    public Transform player;

    public static bool viewing;//uses bool not boolean apparently

    public bool activated = true;
    private float temp;

    private ObjInfo[] tempPositions;
    void Start()
    {
        i = 0;//starts at first photo
        viewing = false;
        //temp = player.GetComponent<CharacterController>().minMoveDistance;
        tempPositions = TakePhoto.generateArray();
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
                tempPositions = TakePhoto.generateArray();
                Time.timeScale = 0;//freeze physics
                
                
                viewPhoto();
            }
            else
            {
                //the following is copied code from viewphoto that is slightly modified.
                //if I have time later I will modify viewphoto so I dont have to copy code.
                GameObject[] objectsInPhoto = GameObject.FindGameObjectsWithTag("Photoable");
                //< ObjInfo[] > album = TakePhoto.photoAlbum;
                ObjInfo[] photo = tempPositions;
                for (int j = 0; j < objectsInPhoto.Length; j++)
                {
                    GameObject go = objectsInPhoto[j];//the object
                    ObjInfo info = photo[j];//its respective transform from the photo we took

                    go.transform.position = info.position;
                    go.transform.rotation = info.rotation;
                    go.transform.localScale = info.scale;

                    if (info.spr != null && go.GetComponent<SpriteRenderer>() != null)
                    { //if applicable
                        go.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(info.spr, typeof(Sprite));//the string path
                    }
                }
                GameObject[] makeInvisible = GameObject.FindGameObjectsWithTag("Player");
                foreach (GameObject go in makeInvisible)
                {
                    Renderer r = go.GetComponent<Renderer>();
                    if (r != null)
                    {
                        r.enabled = true;
                    }
                }

                //end of copied code
                //player.GetComponent<CharacterController>().minMoveDistance = temp;
                Time.timeScale = 1;
                TakenTextChanger.instance.enableTaking();
            }

        }
        if (viewing && album.Count > 1)
        {

            TakenTextChanger.instance.disableTaking();
            if (activated)
            {
                TakenTextChanger.instance.CurrentPhotoNum(0);
            }
            //player.GetComponent<CharacterController>().minMoveDistance = 999;

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (i < album.Count - 1)
                {
                    i++;
                    viewPhoto();
                    TakenTextChanger.instance.CurrentPhotoNum(i);
                    activated = false;
                }
                else
                {
                    i = 0;
                    viewPhoto();
                    TakenTextChanger.instance.CurrentPhotoNum(i);
                    activated = false;
                }


            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (i > 0)
                {
                    i--;
                    viewPhoto();
                    TakenTextChanger.instance.CurrentPhotoNum(i);
                    activated = false;
                }
                else
                {
                    i = album.Count - 1;
                    viewPhoto();
                    TakenTextChanger.instance.CurrentPhotoNum(i);
                    activated = false;
                }

            }
        }
    }



    public void viewPhoto()
    {
        GameObject[] makeInvisible = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject go in makeInvisible)//a list that should contain the player object and the held object
        {
            Renderer r = go.GetComponent<Renderer>();//works on both mesh (3d) and sprite (2d) renderers
            if (r != null)
            {
                r.enabled = false;
            }
        }
        //(Player)player.GetComponent(InputManager).OnFootDisable();
        GameObject[] objectsInPhoto = GameObject.FindGameObjectsWithTag("Photoable");
        List<ObjInfo[]> album = TakePhoto.photoAlbum;
        ObjInfo[] photo = album[i];
        Debug.Log(objectsInPhoto.Length);
        Debug.Log(photo.Length);
        for (int j = 0; j < photo.Length; j++)
        {
            GameObject go = objectsInPhoto[j];//the object
            ObjInfo info = photo[j];//its respective transform from the photo we took

            go.transform.position = info.position;
            go.transform.rotation = info.rotation;
            go.transform.localScale = info.scale;

            //now, the sprite. I don't believe we need to use the special changeSprite method in PersonClass because we already have localscale stored.
            if (info.spr != null && go.GetComponent<SpriteRenderer>() != null)
            { //if applicable
                Debug.Log(info.spr);
                go.GetComponent<SpriteRenderer>().sprite = (Sprite)AssetDatabase.LoadAssetAtPath(info.spr, typeof(Sprite));//the string path
                Debug.Log((Sprite)AssetDatabase.LoadAssetAtPath(info.spr, typeof(Sprite)));
            }


        }

    }
}



