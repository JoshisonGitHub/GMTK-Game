using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressure_plate_manager_script : MonoBehaviour
{

    public GameObject pressureplateleft;
    public GameObject pressureplateright;

    private pressure_plate_left_script scriptleft;
    private pressure_plate_right_script scriptright;

    public GameObject door;
    private Animator dooranim;
    // Start is called before the first frame update
    void Start()
    {
        dooranim = door.GetComponent<Animator>();
        scriptleft = pressureplateleft.GetComponent<pressure_plate_left_script>();
        scriptright = pressureplateright.GetComponent<pressure_plate_right_script>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scriptleft.isstepedon && scriptright.isstepedon)
        {
            dooranim.SetBool("open_door", true);
            Debug.Log("open door");
        }
    }
}
