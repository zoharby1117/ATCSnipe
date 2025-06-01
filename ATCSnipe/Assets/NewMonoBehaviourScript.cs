//using System;
//using Unity.VisualScripting;
//using UnityEngine;
//using UnityEngine.Rendering.Universal;

//public class chair : MonoBehaviour
//{
//    public bool interactable, sitting;
//    // Start is called once before the first execution of Update after the MonoBehaviour is created
//    void OnTriggerStay(Collider other)
//    {
//        if (other.CompareTag("MainCamera"))
//        {
//            intText.SetActive(true);
//            interactable = true;
//        }
//    }

//    private void OnTriggerExit(Collider other)
//    {
//        if (other.CompareTag("MainCamera"))
//        {
//            intText.SetActive(false);
//            interactable = false;
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (interactable == true)
//        {
//            if (Input.GetKeyDown(KeyCode.E))
//            {
//                intText.setActive(false);
//                standText.setActive(true);
//                playerSitting.SetActive(true);
//                sitting = true;
//                playerStanding.SetActive(false);
//                interactable = false;
//            }
//        }
//        if(sitting == true)
//        {
//            if (Input.GetKeyDown(KeyCode.Q){
//                playerSitting.SetActive(false);
//                standText.setActive(false);
//                playerStanding.SetActive(true);
//                sitting = false;
//            }
//        }
//    }
//}
