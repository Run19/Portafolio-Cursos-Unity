using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField]
    private GameObject followTarget;
    [SerializeField]
    private Vector3 targetPostion;
    [SerializeField]
    float cameraSpeed= 4.0f;


    private Camera TheCamera;

    private Vector3 minLimits, maxLimits;

    private float theWidthHalf,theHeightHalf;

    // Start is called before the first frame update
    void Start()
    {
       
      

        //Con esto la camara se vuelve proporcional a la pantalla
    }

    // Update is called once per frame
    void Update()
    {
        targetPostion = new Vector3(followTarget.transform.position.x,
                        followTarget.transform.position.y, this.transform.position.z);
        this.transform.position = Vector3.Lerp(this.transform.position, 
                                   targetPostion, Time.deltaTime * cameraSpeed);




        float clampX = Mathf.Clamp(this.transform.position.x,
                         minLimits.x + theWidthHalf,
                         maxLimits.x - theWidthHalf);
        float clampY = Mathf.Clamp(this.transform.position.y,
                                minLimits.y + theHeightHalf,
                                maxLimits.y - theHeightHalf);
        this.transform.position = new Vector3(clampX, clampY,
                             this.transform.position.z);
    }


    public void changeCameraLimits(BoxCollider2D camLimits) {
        minLimits = camLimits.bounds.min;
        maxLimits = camLimits.bounds.max;

        TheCamera = GetComponent<Camera>();

        theWidthHalf = TheCamera.orthographicSize;
        theHeightHalf = theWidthHalf / Screen.width * Screen.height;
    }
}
