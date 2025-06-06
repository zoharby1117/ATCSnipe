using UnityEngine;
using System.IO;//lets us use path

public class Ending : MonoBehaviour
{
    public void EndTimer()
    {

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
        //System.Diagnostics.Process.Start("explorer.exe", folder);
        
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
            
    }
}
