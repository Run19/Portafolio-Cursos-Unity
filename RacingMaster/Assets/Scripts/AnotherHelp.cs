using UnityEngine;
using System.Collections;
public class AnotherHelp : MonoBehaviour
{

    public HELP motorCarreterasScript;
    public void OnTriggerenter2D(Collider2D cInfo)
    {
        if (cInfo.gameObject.tag == "LimiteCalles")
        {
            Destroy(cInfo.transform.parent.gameObject);
            motorCarreterasScript.CreaCalles();
        }
    }
}