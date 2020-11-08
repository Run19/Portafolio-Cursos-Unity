using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScripty : MonoBehaviour
{
    public void goToBeatInsane()
    {
        SceneManager.LoadScene(1);
    }
    public void goToInfinite()
    {
        SceneManager.LoadScene(2);
    }
}
