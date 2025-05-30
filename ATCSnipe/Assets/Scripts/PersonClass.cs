using UnityEngine;
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
        gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
        float currentHeight = GetComponent<SpriteRenderer>().sprite.rect.height;

        float ScaleFactor = person.height / currentHeight;
        transform.localScale = new Vector3(ScaleFactor, ScaleFactor, ScaleFactor);

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


        }


        //instantiating people

        if (gameObject.name.Equals("Sam_Basil"))
        {
            Sprite[] basilSprites = Resources.LoadAll<Sprite>("ATCS Sprites/Basil");//uploads the folder as an array of sprites. Awesome.
            person = new Person(basilSprites, basilSprites[0].rect.height);//sprite height somewhere
        }

        GetComponent<SpriteRenderer>().sprite = person.PersonSprites[0];//first sprite in the folder




    }
    void Update()
    {
        //responsible for sprite changes
        GameObject thrown = PickUpController.thrown;
        if (thrown != null)
        {
            Vector3 distanceToObject = transform.position - thrown.GetComponent<Transform>().position;//these are two transforms
            float valueDistance = distanceToObject.magnitude;//float value for vector magnitude
            if (valueDistance <= 10 && thrownObjects.Contains(thrown) && thrownObjects.IndexOf(thrown) < person.PersonSprites.Length)//range of 10
            {
                int i = thrownObjects.IndexOf(thrown);
                changeSprite(person.PersonSprites[i]);
                //change sprite to the one whose folder position corresponds to the position of the object in the list
            }
        }
    }

}
