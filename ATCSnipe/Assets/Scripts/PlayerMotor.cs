using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    public float speed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        //if you check inspector, Player has a CharacterController component added to it
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, 1.0f, transform.position.z); //I want y to be a fixed value of 1.07573
    }

    //receive the inputs from input manager, apply to character controller
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x; //sets the horizontal component of the 2d input vector (left and right arrow keys) to horizontal movement in 3D space
        moveDirection.z = input.y; //sets the vertical component of the 2d input vector (up and down) to forward/backward 3d movement
        controller.Move(transform.TransformDirection(moveDirection) * speed * Time.deltaTime);
        //Move takes a Vector3 as a parameter, moves the game object with an attached CharacterController component (which we added in its inspector)
        //delta time is seconds per frame, so different fps wont change your speed
    }

}
