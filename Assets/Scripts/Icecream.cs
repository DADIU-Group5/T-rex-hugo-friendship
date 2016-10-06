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
            Die();
        }
    }

    public void Die()
    {
        IcecreamManager._instance.RemoveIcecream(this);
        Destroy(gameObject);
        eatSound.Play; 
    }
}
