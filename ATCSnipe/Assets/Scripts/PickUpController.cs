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

    private void Start()
    {
        //disable script
        rb.isKinematic = false;
        coll.isTrigger = false;
    }
    private void Update()
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
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make object a child of the camera so it moves with it
        transform.SetParent(container);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        //make rigid body kinematic so it stops moving
        rb.isKinematic = true;
        coll.isTrigger = true;

        //enable other script here
    }

    private void Drop()
    {
        //false everything
        equipped = false;
        slotFull = false;

        rb.isKinematic = false;
        coll.isTrigger = false;

        transform.SetParent(null);

        //disable other script here
    }
}
