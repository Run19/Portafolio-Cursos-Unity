using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class LvlGenerator : MonoBehaviour
{
    public static LvlGenerator SI;
    [SerializeField]
    private List<GameObject> AllLvls = new List<GameObject>();
    [SerializeField]
    private List<GameObject> AllPoties = new List<GameObject>();
    private List<GameObject> CurrentLvls = new List<GameObject>();


    private void Awake()
    {
        if (SI == null)
        {
            SI = this;
        }
    }
    public void addLvl()
    {
        var lastChild = CurrentLvls[CurrentLvls.Count - 1].transform.GetChild(CurrentLvls[CurrentLvls.Count - 1].transform.childCount - 2);
        var currentLvl = Instantiate(AllLvls[Random.Range(0, AllLvls.Count)],
            new Vector3(lastChild.transform.position.x + lastChild.GetComponent<SpriteRenderer>().size.x, 0f, 0f),
            Quaternion.Euler(Vector3.zero)); ;
        CurrentLvls.Add(currentLvl);

        //Obtiene un hijo aleatorio y en el instancia la poti a la mitad del tamaño de su sprite en X y sobre su sprite en Y
        int childPos = Random.Range(0, currentLvl.transform.childCount - 1);
        Transform child = currentLvl.transform.GetChild(childPos);
        SpriteRenderer childSprite = child.gameObject.GetComponent<SpriteRenderer>();

        var poti = Instantiate(AllPoties[Random.Range(0, AllPoties.Count)],
            new Vector3(child.position.x, childSprite.size.y + child.position.y, 0),
            Quaternion.Euler(Vector3.zero));
        currentLvl.transform.SetParent(this.transform);

    }
    public void destroyLastLvl()
    {
        if (CurrentLvls.Count > 2)
        {
            Destroy(CurrentLvls[0]);
            CurrentLvls.RemoveAt(0);
        }
    }
    public void destroyAllLvl()
    {
        foreach (GameObject lvl in CurrentLvls)
        {
            Destroy(lvl);
        }
        foreach (GameObject poti in GameObject.FindGameObjectsWithTag("poti"))
        {
            Destroy(poti.gameObject);
        }
        CurrentLvls.Clear();
    }
    public void generateInitialLvl()
    {
        var initialBlock = Instantiate(AllLvls[0], Vector3.zero, Quaternion.Euler(Vector3.zero));
        CurrentLvls.Add(initialBlock);
        addLvl();
    }
}
