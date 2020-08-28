using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;


public enum gameState
{
    mainMenu,
    inGame,
    GameOver
}

public class lvlGenerator : MonoBehaviour
{


    public static lvlGenerator SI;
    public List<GameObject> allLvls = new List<GameObject>();
    public List<GameObject> currentLvls = new List<GameObject>();
    Camera myCam;
    float heightStreet;
    Vector3 cameraSize;
    private float streetSize;
    private void Awake()
    {
        SI = SI == null ? this : SI;
        streetSize = allLvls[0].transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.y;
        myCam = FindObjectOfType<Camera>();
        cameraSize = new Vector3(0, FindObjectOfType<Camera>().ScreenToWorldPoint(new Vector3(0, 0, 0)).y, 0);
        insLvls();
    }

    void Update()
    {
        if (currentLvls.Count != 0 && currentLvls[0].transform.GetChild(currentLvls[0].transform.childCount - 1).transform.position.y < cameraSize.y - streetSize)
        {
            destroyLvl();
            insLvls();
        }
    }
    void insLvls()
    {
        heightStreet = 0;
        if (currentLvls.Count <= 2 && currentLvls.Count != 0)
        {
            for (int i = 0; i < currentLvls[currentLvls.Count - 1].transform.childCount; i++)
            {
                heightStreet += currentLvls[currentLvls.Count - 1].transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
            }
            var lvl = Instantiate(allLvls[Random.Range(0, allLvls.Count)],
                new Vector3(0f, heightStreet + currentLvls[currentLvls.Count - 1].transform.position.y - .05f),
                Quaternion.Euler(Vector3.zero));
            currentLvls.Add(lvl);
            lvl.transform.SetParent(this.transform);
        }
        else if (currentLvls.Count == 0)
        {
            var lvl = Instantiate(allLvls[Random.Range(0, allLvls.Count)]);
            currentLvls.Add(lvl);
            lvl.transform.SetParent(this.transform);
            insLvls();
        }
    }
    void destroyLvl()
    {
        Destroy(currentLvls[0].gameObject);
        currentLvls.RemoveAt(0);
    }
}
