using UnityEngine;
using UnityEditor; //lets us use assetsdatabase
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
        if (Input.GetKeyDown(KeyCode.Z) && !ViewPhotos.viewing)
        {

            //Each photo is represented as a list of transforms. (I may change this later.)
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

            if (go.GetComponent<SpriteRenderer>() == null)
            {
                //sprite not applicable
                info = new ObjInfo(go.transform.position, go.transform.rotation, go.transform.localScale);//deep copy
            }
            else
            {
                //first I need to make a deep copy of the sprite
                Sprite ogSprite = go.GetComponent<SpriteRenderer>().sprite;

                //deep copy (credit ai mostly)
                //Texture2D ogTexture = ogSprite.texture;
                //Texture2D newTexture = new Texture2D(ogTexture.width, ogTexture.height, ogTexture.format, false);
                //newTexture.CopyPixels(ogTexture);
                //newTexture.Apply();
                //Sprite newSprite = Sprite.Create(newTexture, new Rect(go.transform.position.x, go.transform.position.y, newTexture.width, newTexture.height), ogSprite.pivot);

                string spr = AssetDatabase.GetAssetPath(ogSprite);//string is immutable
                Debug.Log(spr);

                info = new ObjInfo(go.transform.position, go.transform.rotation, go.transform.localScale, spr);//deep copy
            }
            photo[i] = info;
        }
        return photo;
    }
}
