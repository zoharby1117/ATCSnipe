using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class TextChanger : MonoBehaviour
{
    public static TextChanger instance;
    public TextMeshProUGUI takenAmtText;
    int takenAmt = 0;
    public TextMeshProUGUI viewingNumText;
    int viewingNum = 0;

    public GameObject image;


    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        viewingNumText.enabled = false;
        takenAmtText.text = "Photos Taken: " + takenAmt.ToString();
        image = GameObject.Find("CamFrame");
    }

    public void AddPhoto()
    {
        takenAmt += 1;
        takenAmtText.text = "Photos Taken: " + takenAmt.ToString();
    }

    public void disableTaking()
    {
        takenAmtText.enabled = false;
        image.SetActive(false);
        viewingNumText.enabled = true;
    }

    public void enableTaking()
    {
        takenAmtText.enabled = true;
        image.SetActive(true);
        viewingNumText.enabled = false;
    }


    public void CurrentPhotoNum(int i)
    {
        viewingNum = i;
        viewingNumText.text = "Viewing: " + viewingNum.ToString() + "/" + takenAmt.ToString();
    }

    public void firstView()
    {
        viewingNumText.text = "Viewing mode activated: 0";
    }
}
