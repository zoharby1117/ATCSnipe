using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    void Update()
    {
        TextChanger.instance.decreaseTime();
    }
}
