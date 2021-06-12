using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchfxscript : MonoBehaviour
{
    public AudioClip switchClip;
    public Transform cameraTransform;
    public shake_camera shake_Camera;
    private bool canpressQ;
    public float stopQtime;

    void Start()
    {
        
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Q) && canpressQ)
            {
                AudioSource.PlayClipAtPoint(switchClip, cameraTransform.position);
                shake_Camera.CamShake();
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
