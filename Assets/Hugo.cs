using UnityEngine;
using System.Collections;

public class Hugo : MonoBehaviour {

    public float minX = -6;
    public float maxX = 6;
    public float speed = 3;
    public Rigidbody rb;

    public GameObject[] ICECREAMs;

    public float averageMoveTime = 1;
    public float moveTimeDiff = 0.5f;

    public float averageDropTime = 3;
    public float dropTimeDiff = 2;

    float nextDropTime = 3;
    float nextMoveTime = 1;
    float dropTimer = 0;
    float moveTimer = 0;
    bool movingRight = true;

	// Use this for initialization
	void Start () {
        nextMoveTime = averageMoveTime + Random.Range(-1, 1) * moveTimeDiff;
        moveTimer = 0;
        nextDropTime = averageDropTime + Random.Range(-1, 1) * dropTimeDiff;
        dropTimer = 0;
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameManager.GameRunning)
        {
            rb.velocity = Vector3.zero;
            this.enabled = false;
        }
        if(transform.position.x > maxX || transform.position.x < minX)
        {
            ChangeDirection();
        }
        dropTimer += Time.deltaTime;
        moveTimer += Time.deltaTime;
        if(dropTimer > nextDropTime)
        {
            Drop();
        }
        if (moveTimer > nextMoveTime)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if (movingRight)
        {
            movingRight = false;
            rb.velocity = Vector3.right * -speed;
        }
        else
        {
            rb.velocity = Vector3.right * speed;
            movingRight = true;
        }
        nextMoveTime = averageMoveTime + Random.Range(-1, 1) * moveTimeDiff;
        moveTimer = 0;
    }

    void Drop()
    {
        //DROP mechanics
        Instantiate(ICECREAMs[Random.Range(0,ICECREAMs.Length)], transform.position+Vector3.down, Quaternion.identity);
        nextDropTime = averageDropTime + Random.Range(-1, 1) * dropTimeDiff;
        dropTimer = 0;
    }

}
