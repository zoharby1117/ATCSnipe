using UnityEngine;
using System.IO;//lets us use path
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    public static bool timerOver;

    private PlayerUI playerUI;

    private List<int> indexes;

    private GameObject canvas;
    [SerializeField] private Image timeUpImage;
    [SerializeField] private Image skillIssueImage;
    [SerializeField] private Image nonSkillIssueVid;
    private float timeTU = 30; //amount of time the TimeUp image is being popped up
    private bool overTU = false;

    
    public static void EndTimer()
    {
        timerOver = true;
        //TextChanger.disableTaking();
        ViewPhotos vp = GameObject.Find("TakePhotos").GetComponent<ViewPhotos>();
        ViewPhotos.i = 0;
        vp.playLoadSound();
        ViewPhotos.viewing = true;
        vp.startView();
        //make sure there is an option for if the timer ends and no photos are taken

    }

    private void Screenshot()
    {
        StartCoroutine(CaptureScreenshotCoroutine());
    }
    IEnumerator CaptureScreenshotCoroutine()
    {
        //hide all UI

        canvas.SetActive(false);

        //the following code is ChatGPT generated but I will do my best to explain


        yield return new WaitForEndOfFrame();//waits for end of frame when screenshot is taken

        string folder = Path.Combine(Directory.GetCurrentDirectory(), "Screenshots");//special concatenation for paths. 
                                                                                     // It will end up like(Path directory of game)/Screenshots.

        if (!Directory.Exists(folder))//if there isn't already a screenshots folder, a new one is made.
        {
            Directory.CreateDirectory(folder);
        }
        string timestamp = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");//each new screenshot will have a unique name
                                                                               //the wont override each other

        //if I decide to change the name BeautifulSnipe, maybe by selecting randomly from a list, here is the place to do it

        string filename = $"BeautifulSnipe_{timestamp}.png";//$ and {} is a special notation that helps to add variables without making breaks
                                                            //not sure if this is in regular java

        string relativePath = Path.Combine("Screenshots", filename);//makes a path specifically for the screenshot
                                                                    //to be used as param in the next line

        ScreenCapture.CaptureScreenshot(relativePath);//takes the screenshot
        string fullPath = Path.Combine(folder, filename);//now we have (GameDirectory path)/Screenshots/BeautifulSnipe_(datetime).png

        //show all UI, display a saved! message
        //Invoke("ShowCanvas", 1.0f);//need to wait a frame
        //System.Diagnostics.Process.Start("explorer.exe", folder);
        Debug.Log("Screenshot captured: " + Path.Combine(folder, filename));//log
        Debug.Log("Screenshot saved to: " + fullPath);

        canvas.SetActive(true);

        indexes.Add(ViewPhotos.i);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void ShowCanvas()
    {
        canvas.SetActive(true);

        indexes.Add(ViewPhotos.i);
    }
    void Start()
    {
        timerOver = false;
        playerUI = GameObject.Find("Player").GetComponent<PlayerUI>();
        canvas = GameObject.Find("Canvas");
        indexes = new List<int>();
        nonSkillIssueVid.gameObject.SetActive(false);
        skillIssueImage.gameObject.SetActive(false);
        timeUpImage.gameObject.SetActive(false);

        //Invoke("EndTimer", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOver)
        {
            
            if (!overTU) //if the time for time up is not over
            {
                timeUpImage.gameObject.SetActive(true);
                timeTU--;
                if(timeTU < 0)
                {
                    overTU = true;
                    timeUpImage.gameObject.SetActive(false);
                }
            }

            //UI: Press Z to save a photo
            //when that key is pressed:
            if (overTU)
            {
                if (Input.GetKeyDown(KeyCode.Z) && !indexes.Contains(ViewPhotos.i))
                {

                    //screenshot, maybe play a sound
                    Screenshot();

                }

                //UI depends on if the photo is saved or not
                if (indexes.Contains(ViewPhotos.i))
                {
                    playerUI.UpdateText("Saved!\n\n\n\n\n\n\n\n\n\n\n\n[Enter] to finish");
                }
                else
                {
                    playerUI.UpdateText("[Z] to save photo\n\n\n\n\n\n\n\n\n\n\n\n[Enter] to finish");
                }

                if (TextChanger.instance.getTakenAmt() < 1)
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        skillIssueImage.gameObject.SetActive(true);
                    }
                }
                else
                {
                    if (Input.GetKeyDown(KeyCode.Return))
                    {
                        nonSkillIssueVid.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
