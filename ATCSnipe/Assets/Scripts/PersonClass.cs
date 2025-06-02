using UnityEngine;
//using UnityEditor;//lets us use AssetDatabase to upload specific sprites
using System.Collections.Generic;//lets us use lists

public class PersonClass : MonoBehaviour
{
    public static List<GameObject> thrownObjects;
    public Person person;

    public class Person
    {
        public float height;
        public Sprite[] PersonSprites;
        //Sprite[0] by default

        public Person(Sprite[] sprites, float height)
        {
            PersonSprites = sprites;
            this.height = height;
        }

    }

    //make a change sprite method that changes sprite, resizes, and adds and special behaviors
    public void changeSprite(Sprite newSprite)
    {
        if (!ViewPhotos.viewing)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            float currentHeight = GetComponent<SpriteRenderer>().sprite.rect.height;

            float ScaleFactor = person.height / currentHeight;
            transform.localScale = new Vector3(ScaleFactor, ScaleFactor, ScaleFactor);

            //special behaviors will be something like if sprite == special sprite name, do something special like change sprite again, move, etc.
            if (GetComponent<SpriteRenderer>().sprite.name.Equals("Herb_GreenPot") && gameObject.name.Equals("Sam_Basil"))
            {
                Invoke("changeToBasil", 3.0f);
                //Invoke(changeSprite((Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/ATCS Sprites/Basil/Herb2.png"), typeof(Sprite)), 3.0f);
                //Invoke delays the calling of the method
            }
        }
    }

    public void changeToBasil()//honestly this isnt the best coding practice
    {
        //changeSprite((Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/ATCS Sprites/Basil/Herb2.png", typeof(Sprite)));
        changeSprite(Resources.Load<Sprite>("ATCS Sprites/Basil/Herb2"));
    }


    void Start()
    {
        if (thrownObjects == null)
        {
            thrownObjects = new List<GameObject>();
            thrownObjects.Add(GameObject.Find("RubberDuck_Yellow"));
            thrownObjects.Add(GameObject.Find("Basketball"));
            thrownObjects.Add(GameObject.Find("Herb_GreenPot"));
            thrownObjects.Add(GameObject.Find("Laptop"));
            thrownObjects.Add(GameObject.Find("Phone"));
            thrownObjects.Add(GameObject.Find("TurkeyFlag"));
            thrownObjects.Add(GameObject.Find("Sigma"));
            thrownObjects.Add(GameObject.Find("Pig"));
            thrownObjects.Add(GameObject.Find("Megaman"));
            thrownObjects.Add(GameObject.Find("Prawn"));
            thrownObjects.Add(GameObject.Find("Boba"));
            thrownObjects.Add(GameObject.Find("Kirby"));
            thrownObjects.Add(GameObject.Find("Rickroll"));
            thrownObjects.Add(GameObject.Find("Tea"));
            thrownObjects.Add(GameObject.Find("Cat"));


        }


        //instantiating people

        if (gameObject.name.Equals("Sam_Basil"))
        {
            Sprite[] basilSprites = Resources.LoadAll<Sprite>("ATCS Sprites/Basil");//uploads the folder as an array of sprites. Awesome.
            person = new Person(basilSprites, basilSprites[0].rect.height);//sprite height somewhere
        }

        if (gameObject.name.Equals("Dharma"))
        {
            Sprite[] Sprites = Resources.LoadAll<Sprite>("ATCS Sprites/Dharma");
            person = new Person(Sprites, Sprites[0].rect.height * 0.05f);
        }

        GetComponent<SpriteRenderer>().sprite = person.PersonSprites[0];




    }
    void Update()
    {
        //responsible for sprite changes
        GameObject thrown = PickUpController.thrown;
        if (thrown != null && !ViewPhotos.viewing)
        {
            Vector3 distanceToObject = transform.position - thrown.GetComponent<Transform>().position;//these are two transforms
            float valueDistance = distanceToObject.magnitude;//float value for vector magnitude
            //if (valueDistance <= 10 && thrownObjects.Contains(thrown) && thrownObjects.IndexOf(thrown) < person.PersonSprites.Length)//range of 10
            if (valueDistance <= 10 && thrownObjects.Contains(thrown))
            {
                //int i = thrownObjects.IndexOf(thrown);
                //changeSprite(person.PersonSprites[i]);
                //change sprite to the one whose folder position corresponds to the position of the object in the list.
                //the folder sprites are stored alphabetically so we need to rename them to match each one with the object.

                //scrapped code above. I think this will be more convenient.
                foreach (Sprite s in person.PersonSprites)
                {
                    if (s.name.Equals(thrown.name))//finds the sprite of the same name as the gameObject
                    {
                        changeSprite(s);
                        return;
                    }
                }
            }
        }
    }

}
