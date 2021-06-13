using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class black_left_script : MonoBehaviour
{
    public bool isonscreen = false;

    public Animator anim;

    public float stopQtime;
    private bool canpressQ = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            if (Input.GetKeyDown(KeyCode.Q) && canpressQ)
            {
                isonscreen = !isonscreen;
                anim.SetBool("turnon", isonscreen);
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
