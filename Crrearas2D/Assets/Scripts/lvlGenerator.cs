using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;


public enum gameState
{
    inGame,
    GameOver
}

public class lvlGenerator : MonoBehaviour
{
    public List<GameObject> allLvls = new List<GameObject>();
    public List<GameObject> currentLvls = new List<GameObject>();
    Camera myCam;

    [SerializeField]
    float speed;
    float timeInGame;
    float heightStreet;
    Vector3 cameraSize;
    public gameState currentGameState;

    private void Awake()
    {

        myCam = FindObjectOfType<Camera>();
        cameraSize = new Vector3(0, FindObjectOfType<Camera>().ScreenToWorldPoint(new Vector3(0, 0, 0)).y - 0.5f, 0);

    }
    void Start()
    {
        currentGameState = gameState.inGame;
        insLvls();
    }


    void Update()
    {
        if (currentGameState == gameState.inGame)
        {
            foreach (GameObject lvl in currentLvls)
            {
                if (lvl.transform.rotation.z == 0)
                    lvl.transform.Translate(Vector3.down * speed * Time.deltaTime);
                else
                    lvl.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        if (currentLvls.Count != 0 && currentLvls[0].transform.position.y < -35)
        {
                destroyLvl();
                insLvls();
        }
        
    }



    void setGameStat(gameState newGameState)
    {
        currentGameState = newGameState;
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
                new Vector3(0f, heightStreet + currentLvls[currentLvls.Count - 1].transform.position.y),
                Quaternion.Euler(Vector3.zero));

            currentLvls.Add(lvl);

            lvl.transform.SetParent(this.transform);


        }
        else if (currentLvls.Count == 0)
        {
            var lvl = Instantiate(allLvls[Random.Range(0, allLvls.Count)]);
            currentLvls.Add(lvl);
            lvl.transform.SetParent(this.transform);
        }
    }



    void destroyLvl()
    {
        Destroy(currentLvls[0].gameObject);
        currentLvls.RemoveAt(0);
    }

}
