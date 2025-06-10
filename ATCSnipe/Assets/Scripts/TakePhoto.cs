using UnityEngine;
using System.Collections.Generic;//lets us use lists

public class TakePhoto : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;

    private AudioSource audioSource;
        //define photoalbum instance var
        public static List<ObjInfo[]> photoAlbum;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        photoAlbum = new List<ObjInfo[]>();

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && !ViewPhotos.viewing && !Ending.timerOver)
        {

            //Each photo is represented as a list of transforms. (I may change this later.)
            audioSource.clip = clickSound;
            audioSource.Play();
            TextChanger.instance.AddPhoto();
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

            //here we will check if a sprite is applicable

            ObjInfo info = null;//otherwise photo[i] = info gives a compiler error

            if (go.GetComponent<SpriteRenderer>() == null || go.GetComponent<PersonClass>() == null)
            {
                //sprite not applicable
                info = new ObjInfo(go.transform.position, go.transform.rotation, go.transform.localScale);//deep copy
            }
            else
            {
                Sprite ogSprite = go.GetComponent<SpriteRenderer>().sprite;

                string spr = "ATCS Sprites/" + go.GetComponent<PersonClass>().person.name + "/" + ogSprite.name;//string is immutable
                Debug.Log(spr);

                info = new ObjInfo(go.transform.position, go.transform.rotation, go.transform.localScale, spr);//deep copy
            }
            photo[i] = info;
        }
        return photo;
    }
}
