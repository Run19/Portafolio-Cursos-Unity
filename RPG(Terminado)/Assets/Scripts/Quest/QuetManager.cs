using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuetManager : MonoBehaviour
{
    public Quest[] quest;
    public bool[] questCompleted;
    private DialogManager managerD;


    void Start()
    {
        managerD = FindObjectOfType<DialogManager>();        
        questCompleted = new bool[quest.Length];
    }

   
    void Update()
    {
        
    }
    public void showQuestText(string QuestText) {
        string[] dialogLines = new string[] {
             QuestText
            };
        managerD.ShowDialog(dialogLines);
    }
}
