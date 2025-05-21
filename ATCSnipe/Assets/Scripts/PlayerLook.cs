using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;//I assigned this in the inspector
    private float xRotation = 0f;
    public float xSensitivity = 10f;
    public float ySensitivity = 10f;

    public void ProcessLook(Vector2 input)//we will give it the vector from the deltamouse in look action
    {
        //calculate up/down rotation
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitivity;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); //this gives us a min -80 and max 80
                                                       //transform camera
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0); //takes a 3d vector and rotates camera.

        //rotate player left/right
        transform.Rotate(Vector3.up * (mouseX * Time.deltaTime * xSensitivity));
    }

}
