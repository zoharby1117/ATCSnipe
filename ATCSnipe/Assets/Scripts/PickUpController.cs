using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //The tutorial writes public ProjectileGyn gunScript; but this will be replaced by throwable (might make that an interface or superclass)
    public Rigidbody rb; //A rigidbody is an object affected by unity physics
    public BoxCollider coll; //basically a 3d hitbox
}
