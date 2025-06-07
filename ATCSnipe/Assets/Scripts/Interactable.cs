using UnityEngine;

public class Interactable : MonoBehaviour
{
    public string promptMessage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        promptMessage = gameObject.name;
        if (promptMessage.Equals("Sam_Basil"))
        {
            promptMessage = "Sam";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
