using UnityEngine;
using System.IO;//lets us use path
using System.Collections.Generic;
public class Ending : MonoBehaviour
{
    public static bool timerOver;

    private PlayerUI playerUI;

    private List<int> indexes;

    public void EndTimer()
    {
        timerOver = true;
        ViewPhotos vp = GetComponent<ViewPhotos>();
        ViewPhotos.i = 0;
        vp.playLoadSound();
        ViewPhotos.viewing = true;
        vp.startView();
        //make sure there is an option for if the timer ends and no photos are taken

    }

    private void Screenshot()
    {
        //the following code is ChatGPT generated but I will do my best to explain

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


        Debug.Log("Screenshot captured: " + Path.Combine(folder, filename));//log
        Debug.Log("Screenshot saved to: " + fullPath);
        indexes.Add(ViewPhotos.i);
        //System.Diagnostics.Process.Start("explorer.exe", folder);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timerOver = false;
        playerUI = GameObject.Find("Player").GetComponent<PlayerUI>();
        indexes = new List<int>();

        //Invoke("EndTimer", 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (timerOver)
        {
            //UI: Press Z to save a photo
            //when that key is pressed:
            if (Input.GetKeyDown(KeyCode.Z) && !indexes.Contains(ViewPhotos.i))
            {
                //hide all UI
                //screenshot, maybe play a sound
                Screenshot();
                //show all UI, display a saved! message
            }

            //UI depends on if the photo is saved or not
            if (indexes.Contains(ViewPhotos.i))
            {
                playerUI.UpdateText("Saved!");
            }
            else
            {
                playerUI.UpdateText("[Z] to save photo");
            }
        }
    }
}
