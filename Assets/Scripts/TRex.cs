using UnityEngine;
using System.Collections;

public class TRex : MonoBehaviour
{
    private enum Direction { LEFT, RIGHT }

    private Direction dir = Direction.LEFT;

    public GameObject model;
    public KeyCode actionButton = KeyCode.Space;
    public float force = 25, maxSpeed = 10, deathHeight = -10;

    public AudioSource run;
    public AudioSource death;
    public AudioSource eat;

    public void Update()
    {
        if (Input.GetKeyDown(actionButton) || Input.touchCount > 0)
        {
            run.Play();
            ToggleDirection();
        }
        if (transform.position.y <= deathHeight)
        {
            death.Play(); 
            Die();
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "iceCream")
        {
            eat.Play();
        }
               
            
    }

    public void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.transform.gameObject;
        Icecream icecream = other.GetComponent<Icecream>();
        if (icecream)
        {
            icecream.Die();
        }
    }

    public Vector3 GetDirectionVector()
    {
        if (dir == Direction.LEFT)
        {
            return Vector3.left;
        }
        else
        {
            return Vector3.right;
        }
    }

    public void FixedUpdate()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.AddForce(GetDirectionVector() * force);

        if (body.velocity.magnitude > maxSpeed)
        {
            body.velocity = body.velocity.normalized * maxSpeed;
        }

        /*
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
        */
    }

    public void ToggleDirection()
    {
        dir = (Direction)(((int)dir + 1) % 2);
        Vector3 scale = model.transform.localScale;
        model.transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
    }

    // Called whenever the trex dies.
    public void Die()
    {
        //TODO Gameover
        GameManager.instance.TRexDied();
        Destroy(gameObject);
    }
}
