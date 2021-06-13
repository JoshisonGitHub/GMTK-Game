using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressure_plate_right_script : MonoBehaviour
{
    public GameObject player;

    private Animator anim;

    public bool isstepedon = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {

            anim.SetBool("ison", true);
            isstepedon = true;

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.Equals(player))
        {

            anim.SetBool("ison", false);
            isstepedon = false;

        }
    }
}
