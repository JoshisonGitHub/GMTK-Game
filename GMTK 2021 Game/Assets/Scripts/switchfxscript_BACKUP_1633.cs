using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchfxscript : MonoBehaviour
{
    public AudioClip switchClip;
    public Transform cameraTransform;
    public shake_camera shake_Camera;

    public float stopQtime;
    private bool canpressQ = true;

    void Start()
    {
        
    }

    void Update()
    {
<<<<<<< HEAD
        
            if (Input.GetKeyDown(KeyCode.Q) && canpressQ)
            {
                AudioSource.PlayClipAtPoint(switchClip, cameraTransform.position);
                canpressQ = false;
                StartCoroutine(Reset());            
            }
        
    }

    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(stopQtime);
        canpressQ = true;
=======
        if(Input.GetKeyDown(KeyCode.Q))
        {
            AudioSource.PlayClipAtPoint(switchClip, cameraTransform.position);
            shake_Camera.CamShake();
        }
>>>>>>> screen-shake
    }
}
