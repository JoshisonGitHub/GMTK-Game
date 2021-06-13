using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door_Button_script : MonoBehaviour
{

    public GameObject button, door;
    public Collider2D buttonCollider; 
    
    public KeyCode interactionKey;
    public bool buttonFacingRight; //given that the objects must be retracted into something, they need a direction to retract into
    public float buttonRetractDistance;
    private bool buttonPressed = false;

    private Collider2D playerleftCollider;
    private GameObject playerleft;
    void Start()
    {
        playerleft = GameObject.FindWithTag("PlayerLeft");
        playerleftCollider = playerleft.GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!buttonPressed && Input.GetKeyDown(interactionKey) && buttonCollider.IsTouching(playerleftCollider))
        {
            this.buttonPressed = true;
            RunPairAnimation();
        }
    }

    void RunPairAnimation()
    {
        switch (buttonFacingRight)
        {
            case true:
                {
                    button.transform.Translate(buttonRetractDistance, 0, 0);
                    break;
                }

            case false:
                {
                    button.transform.Translate(-buttonRetractDistance, 0, 0);
                    break;
                }
        }

        door.GetComponent<Animator>().SetBool("open_door", true);
    }
}
