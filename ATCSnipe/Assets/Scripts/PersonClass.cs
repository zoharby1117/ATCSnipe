using UnityEngine;
//using UnityEditor;//lets us use AssetDatabase to upload specific sprites
using System.Collections.Generic;//lets us use lists

public class PersonClass : MonoBehaviour
{
    public static List<GameObject> thrownObjects;
    public Person person;
    private EnemyAiPatrol ai;

    public class Person
    {
        public float height;
        public Sprite[] PersonSprites;
        //Sprite[0] by default

        public string name;//used for folder pathfinding

        public Person(Sprite[] sprites, float height, string name)
        {
            PersonSprites = sprites;
            this.height = height;
            this.name = name;
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
            if (GetComponent<SpriteRenderer>().sprite.name.Equals("Laptop") && gameObject.name.Equals("Ryan"))
            {
                Invoke("changeToRyanLaptop", 3.0f);
                //Invoke(changeSprite((Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/ATCS Sprites/Basil/Herb2.png"), typeof(Sprite)), 3.0f);
                //Invoke delays the calling of the method
            }

            if (GetComponent<SpriteRenderer>().sprite.name.Equals("Phone") && gameObject.name.Equals("Tommy"))
            {
                Invoke("changeToTommyPhone", 3.0f);
            }

            if (GetComponent<SpriteRenderer>().sprite.name.Equals("Chair") && gameObject.name.Equals("Tommy"))
            {
                Invoke("changeToTommyChair", 3.0f);

            }
            if (GetComponent<SpriteRenderer>().sprite.name.Equals("TurkeyFlag") && gameObject.name.Equals("Serra"))
            {
                Invoke("changeToSerraFlag", 3.0f);

            }
        }
    }

    public void changeToBasil()//honestly this isnt the best coding practice
    {
        //changeSprite((Sprite)AssetDatabase.LoadAssetAtPath("Assets/Resources/ATCS Sprites/Basil/Herb2.png", typeof(Sprite)));
        changeSprite(Resources.Load<Sprite>("ATCS Sprites/Basil/Herb2"));
        ai.satisfy();
    }

    public void changeToRyanLaptop()
    {
        changeSprite(Resources.Load<Sprite>("ATCS Sprites/Ryan/Laptop2"));
    }

    public void changeToTommyChair()
    {
        changeSprite(Resources.Load<Sprite>("ATCS Sprites/Tommy/Chair2"));
    }
    public void changeToTommyPhone()
    {
        changeSprite(Resources.Load<Sprite>("ATCS Sprites/Tommy/Phone2"));
    }
    public void changeToSerraFlag()
    {
        changeSprite(Resources.Load<Sprite>("ATCS Sprites/Serra/TurkeyFlag2"));
    }


    void Awake()
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
            thrownObjects.Add(GameObject.Find("Chair"));
            thrownObjects.Add(GameObject.Find("Baseball"));
            thrownObjects.Add(GameObject.Find("Soccer"));
            thrownObjects.Add(GameObject.Find("Weezer"));



        }


        //instantiating people

        if (gameObject.name.Equals("Sam_Basil"))
        {
            Sprite[] basilSprites = Resources.LoadAll<Sprite>("ATCS Sprites/Basil");//uploads the folder as an array of sprites. Awesome.
            person = new Person(basilSprites, basilSprites[0].rect.height, "Basil");//sprite height somewhere
        }

        if (gameObject.name.Equals("Dharma"))
        {
            Sprite[] Sprites = Resources.LoadAll<Sprite>("ATCS Sprites/Dharma");
            person = new Person(Sprites, Sprites[0].rect.height * 0.05f, "Dharma");
        }
        if (gameObject.name.Equals("Ryan"))
        {
            Sprite[] Sprites = Resources.LoadAll<Sprite>("ATCS Sprites/Ryan");
            person = new Person(Sprites, Sprites[0].rect.height * 0.03293264f, "Ryan");
        }
        if (gameObject.name.Equals("Tommy"))
        {
            Sprite[] Sprites = Resources.LoadAll<Sprite>("ATCS Sprites/Tommy");
            person = new Person(Sprites, Sprites[0].rect.height * 0.04f, "Tommy");
        }
        if (gameObject.name.Equals("Pranav"))
        {
            Sprite[] Sprites = Resources.LoadAll<Sprite>("ATCS Sprites/Pranav");
            person = new Person(Sprites, Sprites[0].rect.height * 0.04f, "Pranav");
        }
        if (gameObject.name.Equals("Serra"))
        {
            Sprite[] Sprites = Resources.LoadAll<Sprite>("ATCS Sprites/Serra");
            person = new Person(Sprites, Sprites[0].rect.height * 0.145487f, "Serra");
        }
        if (gameObject.name.Equals("Miguel"))
        {
            Sprite[] Sprites = Resources.LoadAll<Sprite>("ATCS Sprites/Miguel");
            person = new Person(Sprites, Sprites[0].rect.height * 0.045f, "Miguel");
        }
        if (gameObject.name.Equals("Nick"))
        {
            Sprite[] Sprites = Resources.LoadAll<Sprite>("ATCS Sprites/Nick");
            person = new Person(Sprites, Sprites[0].rect.height * 0.045f, "Nick");
        }

        GetComponent<SpriteRenderer>().sprite = person.PersonSprites[0];




    }
    void Start()
    {
        ai = GetComponent<EnemyAiPatrol>();
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
