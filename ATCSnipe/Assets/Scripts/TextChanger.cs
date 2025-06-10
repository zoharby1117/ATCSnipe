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
    public TextMeshProUGUI timer;
    public static Timer t;
    public float time;
    int minutes;
    int seconds;
    bool countingDown = true;

    private GameObject image;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        image = GameObject.Find("CamFrame");
        viewingNumText.enabled = false;
        takenAmtText.text = "Photos Taken: " + takenAmt.ToString();
        timer.text = "Time Left: " + minutes.ToString() + ":0" + seconds.ToString();
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
    }
    void Update()
    {
        if (time <= 0 && !Ending.timerOver)
        {
            time = 0;
            countingDown = false;
            //SceneChanging.instance.changeScene();
            Ending.EndTimer();
        }

        if (Ending.timerOver)
        {
            disableTaking();
        }    
    }

    public void AddPhoto()
    {
        takenAmt += 1;
        takenAmtText.text = "Photos Taken: " + takenAmt.ToString();
    }

    public void disableTaking()
    {
        image.SetActive(false);
        takenAmtText.enabled = false;
        viewingNumText.enabled = true;
    }

    public void enableTaking()
    {
        image.SetActive(true);
        takenAmtText.enabled = true;
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
    public void decreaseTime()
    {
        if(time > 0 && countingDown)
            time -= Time.deltaTime;
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        if (seconds < 10)
            timer.text = "Time Left: " + minutes.ToString() + ":0" + seconds.ToString();
        else
            timer.text = "Time Left: " + minutes.ToString() + ":" + seconds.ToString();
    }
}
