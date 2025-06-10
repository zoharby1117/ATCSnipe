using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField]
    private float distance = 7f;
    [SerializeField]
    private LayerMask mask; //all interactables will be added to one layer
    private PlayerUI playerUI;

    private bool instructions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        instructions = true;
        playerUI = GetComponent<PlayerUI>();
        playerUI.UpdateText("Arrow Keys: move\n[Z]: take photos\n[x] + arrow keys: view photos\n[E]: pick up/throw");
        Invoke("RemoveInstructions", 5);

    }

    private void RemoveInstructions()
    {
        instructions = false;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("this one" + PickUpController.stopDisappearing);
        if (!Ending.timerOver && !instructions && !PickUpController.stopDisappearing)
        {

            playerUI.UpdateText(string.Empty);//if there is no interaction then no text
            //create a ray shooting out from the camera
            Ray ray = new Ray(cam.transform.position, cam.transform.forward);
            RaycastHit hitInfo;//collision info
            if (Physics.Raycast(ray, out hitInfo, distance, mask))
            {
                if (hitInfo.collider.GetComponent<Interactable>() != null && !ViewPhotos.viewing)//is an interactable
                {
                    playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promptMessage);
                }
            }
        }
    }
}
