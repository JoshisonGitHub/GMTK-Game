using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform_script : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startpos;

    private Vector3 nextPos;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startpos.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position == pos1.position)
        {
            StartCoroutine(MovePlatform1());
        }
        if (transform.position == pos2.position)
        {
            StartCoroutine(MovePlatform2());
        }
        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(pos1.position, pos2.position);
    }


    private IEnumerator MovePlatform1()
    {
        yield return new WaitForSeconds(timer);
        nextPos = pos2.position;
    }
    private IEnumerator MovePlatform2()
    {
        yield return new WaitForSeconds(timer);
        nextPos = pos1.position;
    }
}
