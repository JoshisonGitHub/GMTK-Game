using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

enum AgroState : uint {
    Low = 0,
    High = 1,
    Max = 2
}

public class guardscript : MonoBehaviour
{
    public GameObject player;
    public Transform start, end;
    public float speed;
    private bool movingRight = true;
    private AgroState state;

    private bool hasseenplayer = false;
    private float originalspeed;
    void Start()
    {
        originalspeed = speed;
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

        CheckForPlayer();
    }

    void CheckForPlayer()
    {
        if (hasseenplayer)
        {
            speed = 4;
            StartCoroutine(Slowdown());
        }
        if(hasseenplayer == false)
        {
            speed = 2;
        }
    }

    void AdjustDirection(){
        if(transform.position.x <= start.position.x && !movingRight){
            movingRight = !movingRight;
            transform.eulerAngles = new Vector2(0, 0);
        }
        else if(transform.position.x >= end.position.x && movingRight){
            movingRight = !movingRight;
            transform.eulerAngles = new Vector2(0, -180);
        }
    }

    void Move(){
        
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    
    }

    private void OnTriggerEnter2D(Collider2D cap)
    {
        if (cap.gameObject.Equals(player))
        {
            Debug.Log("found player");
            hasseenplayer = true;
        }
    }
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.Equals(player))
        {
#pragma warning disable CS0618 // Type or member is obsolete
            Application.LoadLevel(Application.loadedLevel);
#pragma warning restore CS0618 // Type or member is obsolete
        }
    }


    private IEnumerator Slowdown()
    {
        yield return new WaitForSeconds(2);
        hasseenplayer = false;
    }

}
