using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //The tutorial writes public ProjectileGyn gunScript; but this will be replaced by throwable (might make that an interface or superclass)
    public Rigidbody rb; //A rigidbody is an object affected by unity physics
    public BoxCollider coll; //basically a 3d hitbox

    public Transform player, container, cam, transform; //stores info on their positions, etc.

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;//checks if this specific object is equipped
    public static bool slotFull;//checks if the player is holding anything, same bool for all objects

    public static GameObject thrown = null;

    public static bool stopDisappearing = false;//for playerInteract


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<BoxCollider>();
        //disable script
        rb.isKinematic = false;
        coll.isTrigger = false;

        container.localScale = Vector3.one;
        //extra = GameObject.Find("ExtraPhotoable");
        //extra.tag = "Untagged";


    }
    private void Update()
    {
        stopDisappearing = false;
    }
    private void LateUpdate()
    {
        if (!ViewPhotos.viewing && !Ending.timerOver)
        {
            Vector3 distanceToPlayer = player.position - transform.position;//these are two transforms
            float valueDistance = distanceToPlayer.magnitude;//float value for vector magnitude
            if (!equipped && valueDistance <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull)
            {
                PickUp();
            }
            else if (equipped && Input.GetKeyDown(KeyCode.E))
            {
                Drop();
            }

            //stopDisappearing = false;
            if (!stopDisappearing)
            {
                if (valueDistance <= pickUpRange && !equipped && !gameObject == thrown)//shows UI
                {
                    stopDisappearing = true;
                    GameObject player = GameObject.Find("Player");
                    string displayName = gameObject.name;
                    //special names
                    if (displayName.Equals("Megaman"))
                    {
                        displayName = "Mega Man";
                    }
                    if (displayName.Equals("Soccer"))
                    {
                        displayName = "Soccer Ball";
                    }
                    if (displayName.Equals("RubberDuck_Yellow"))
                    {
                        displayName = "Rubber Duck";
                    }
                    if (displayName.Equals("TurkeyFlag"))
                    {
                        displayName = "Turkey Flag";
                    }
                    if (displayName.Equals("Herb_GreenPot"))
                    {
                        displayName = "Mysterious Herb";
                    }
                    player.GetComponent<PlayerUI>().UpdateText(displayName + " [E]");
                    Debug.Log(gameObject.name);
                }
                else
                {
                    stopDisappearing = false;
                }
            }

        }
        if (ViewPhotos.viewing)
        {
            if (GetComponent<Renderer>() != null)
            {
                if (container.position.Equals(transform.position) && container.localRotation.Equals(transform.localRotation))
                {
                    GetComponent<Renderer>().enabled = false;
                }
            }
        }
        else
        {
            if (GetComponent<Renderer>() != null)
            {
                GetComponent<Renderer>().enabled = true;
            }
        }
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make object a child of the camera so it moves with it
        container.localScale = transform.localScale;

        transform.SetParent(container);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //make rigid body kinematic so it stops moving
        rb.isKinematic = true;
        coll.isTrigger = true;

        //enable other script here

        //should turn invisible in photos
        //gameObject.tag = "Player";

        //maintains length of photoable list to not cause bugs
        //extra.tag = "Photoable";
    }

    private void Drop()
    {
        //false everything
        equipped = false;
        slotFull = false;

        rb.isKinematic = false;
        coll.isTrigger = false;

        //transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.SetParent(null);

        container.localScale = Vector3.one;
        //disable other script here

        //new thrown object
        thrown = gameObject;//self



        //add force: vector, mode
        rb.linearVelocity = player.GetComponent<CharacterController>().velocity;
        if (GetComponent<SpriteRenderer>() == null)
        {//3d
            rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);//based on mass
            rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);
        }
        else
        {
            //2d
            if (transform.position.y < 0.72f)
            {//so it doesnt sink into the ground
                transform.position = new Vector3(transform.position.x, 0.72f, transform.position.z);
            }
            rb.linearDamping = 2f;
            rb.AddForce(cam.forward * dropForwardForce, ForceMode.Impulse);
            rb.AddForce(cam.up * dropUpwardForce, ForceMode.Impulse);
        }


        Invoke("resetThrown", 2.9f);
    }

    private void resetThrown()
    {
        thrown = null;
    }
}
