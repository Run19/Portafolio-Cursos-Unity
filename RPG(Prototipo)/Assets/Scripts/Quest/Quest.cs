using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public int questId;
    private QuetManager managerQ;
    public string TextQuest;
    public string TextComplete;
    void Start()
    {
        managerQ = FindObjectOfType<QuetManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startQuest() {
        managerQ.showQuestText(TextQuest); 
    }

    public void completeQuest() {
        managerQ.questCompleted[questId] = true;
        managerQ.showQuestText(TextComplete);

        gameObject.SetActive(false);
    }
}
