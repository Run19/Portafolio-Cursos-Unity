using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogText;
    public bool dialogActive;

    public string[] dialogLine;
    public int currentLine=0;

    void Start()
    {
        dialogActive=false;          
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogActive && Input.GetKeyDown(KeyCode.Space)) {
            currentLine++;
        }
        if (currentLine >= dialogLine.Length)
        {
            dialogActive = false;
            dialogBox.SetActive(false);
            currentLine = 0;
        }
        else
        {
            dialogText.text = dialogLine[currentLine];
         

        }
    }

    public void ShowDialog(string[] lines) {
        dialogActive = true;
        dialogBox.SetActive(true);
        currentLine = 0;
        dialogLine=lines;
    }


}
