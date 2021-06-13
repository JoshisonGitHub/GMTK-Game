using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource outside, inside;
    public black_left_script shadowLeft;
    void Start()
    {
        outside.volume = 1;
        inside.volume = 0;
        outside.Play();
        inside.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(shadowLeft.isonscreen){
            outside.volume = 0;
            inside.volume = 1;
        }
        else{
            outside.volume = 1;
            inside.volume = 0;
        }
        
    }
}
