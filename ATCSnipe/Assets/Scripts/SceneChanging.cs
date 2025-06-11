using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanging : MonoBehaviour
{
    public static SceneChanging instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
        if (i == 1)
        {
            Invoke("changeScene", 12.0f);
        }
        else if (i == 2)
        {
            Invoke("changeScene", 20.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void changeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("TimeUp");
        //SceneManager.MoveGameObjectToScene(GameObject.Find("TakePhotos"), SceneManager.GetSceneByName("TimeUp"));
    }
}
