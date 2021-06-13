using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum AgroState : uint {
    Low = 0,
    High = 1,
    Max = 2
}

public class guardscript : MonoBehaviour
{
    public GameObject playerCheck;
    public Transform start, end;
    public float speed;
    private bool movingRight = true;
    private AgroState state;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(state)
        {
            case 0: {
                AdjustDirection();
                CheckForPlayer();
                Move();
                break;
            }
        }
    }

    void CheckForPlayer()
    {

    }

    void AdjustDirection(){
        if(transform.position.x <= start.position.x && !movingRight){
            movingRight = !movingRight;
        }
        else if(transform.position.x >= end.position.x && movingRight){
            movingRight = !movingRight;
        }
    }

    void Move(){
        switch(movingRight)
        {
            case true: {
                transform.Translate(Vector2.right * speed);
                break;
            }
            case false: {
                transform.Translate(Vector2.left * speed);
                break;
            }
        }
    }
}
