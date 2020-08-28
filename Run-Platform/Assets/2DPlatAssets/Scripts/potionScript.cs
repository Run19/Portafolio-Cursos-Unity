using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum potiType
{
    health,
    energy
}
public class potionScript : MonoBehaviour
{

    [SerializeField]
    private potiType currentType;
    [SerializeField]
    private int value;
    public potiType getPotiType()
    {
        return currentType;
    }
    public int getPotiValue()
    {
        return value;
    }
}
