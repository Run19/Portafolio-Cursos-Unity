using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Mathematics;

public class correctCineMachine : MonoBehaviour
{
    CinemachineVirtualCamera CAM;
    private void Awake()
    {
        CAM = GetComponent<CinemachineVirtualCamera>();
    }
    public void restartPos()
    {
        CAM.ForceCameraPosition(new Vector3(4.369166f, 7.779163f), quaternion.Euler(Vector3.zero));
    }

}
