using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchfxscript : MonoBehaviour
{
    public AudioClip switchClip;
    public Transform cameraTransform;
    public shake_camera shake_Camera;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            AudioSource.PlayClipAtPoint(switchClip, cameraTransform.position);
            shake_Camera.CamShake();
        }
    }
}
