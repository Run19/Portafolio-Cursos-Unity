using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasScripty : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goToBeatInsane()
    {
        SceneManager.LoadScene(1);
    }
    public void goToInfinite()
    {
        SceneManager.LoadScene(2);
    }


}
