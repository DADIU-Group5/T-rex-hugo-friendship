using UnityEngine;
using System.Collections;

public class Icecream : MonoBehaviour
{
    public int pointValue = 1;
    public float deathHeight = -10;
    public AudioSource spawnSound;
    public AudioSource eatSound;
    public void Start()
    {
        IcecreamManager._instance.AddIcecream(this);
        spawnSound.Play; 
    }

    public void Update()
    {
        if (transform.position.y <= deathHeight)
        {
            Under();
        }
    }

    public void Die()
    {
        GameManager.instance.AddScore(pointValue);
        IcecreamManager._instance.RemoveIcecream(this);
        Destroy(gameObject);
    }

    void Under()
    {
        IcecreamManager._instance.RemoveIcecream(this);
        Destroy(gameObject);
        eatSound.Play; 
    }
}
