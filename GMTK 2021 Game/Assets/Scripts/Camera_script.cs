using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Camera_script : MonoBehaviour
{
   
   
    public CinemachineVirtualCamera leftcam;
    public CinemachineVirtualCamera rightcam;
    private bool canpressQ;
    public float stopQtime;

    private bool left = true;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (left)
        {
            leftcam.Priority = 1;
            rightcam.Priority = 0;
        }
        else
        {
            leftcam.Priority = 0;
            rightcam.Priority = 1;
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && canpressQ)
        {
            left = !left;
            canpressQ = false;
            StartCoroutine(Reset());
        }
       
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(stopQtime);
        canpressQ = true;
    }
}
