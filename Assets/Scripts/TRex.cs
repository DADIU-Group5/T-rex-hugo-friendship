using UnityEngine;
using System.Collections;

public class TRex : MonoBehaviour
{
    private enum Direction { LEFT, RIGHT }

    private Direction dir = Direction.LEFT;

    public KeyCode actionButton = KeyCode.Space;
    public float speed = 4, deathHeight = -10;

    public void Update()
    {
        if (Input.GetKeyDown(actionButton))
        {
            ToggleDirection();
        }
        if (transform.position.y <= deathHeight)
        {
            Die();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision!");
        GameObject other = collision.transform.gameObject;
        Icecream icecream = other.GetComponent<Icecream>();
        if (icecream)
        {
            //TODO Add score.
            icecream.Die();
        }
    }

    public void FixedUpdate()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        Vector3 vel = body.velocity;
        float velX;
        if (dir == Direction.LEFT)
        {
            velX = -speed;
        }
        else
        {
            velX = speed;
        }
        body.velocity = new Vector3(velX, vel.y, 0f);
    }

    public void ToggleDirection()
    {
        dir = (Direction)(((int)dir + 1) % 2);
    }

    // Called whenever the trex dies.
    public void Die()
    {
        //TODO Gameover
        Destroy(gameObject);
    }
}
