using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput; //player input is the c# class version of the inputs we defined in the inputs folder
    private PlayerInput.OnFootActions onFoot; //onFoot action map

    private PlayerMotor motor; //will have the PlayerMotor component of the object

    void Awake() //awake is while the game is initialized, i.e. before start
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot; //this is what we use for our on foot actions.
        motor = GetComponent<PlayerMotor>(); //the playermotor component we dragged into the inspector of the Player object
        OnFootEnable();
    }

    void FixedUpdate() //not sure what the difference between this and update is
    {
        //tell the playermotor to move using the value from our movement action
        //playermotor uses its ProcessMove method to move
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        //Movement is an action in the actionmap that outputs a value

    }

    //the following code enables or disables the onFoot action map, useful in situations when you shouldnt be moving
    //such as when looking at photos
    private void OnFootEnable()
    {
        onFoot.Enable();
    }

    private void OnFootDisable()
    {
        onFoot.Disable();
    }
}
