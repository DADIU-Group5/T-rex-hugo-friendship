using UnityEngine;
using System.Collections;

public class Icecream : MonoBehaviour
{
    public int pointValue = 1;
    public float deathHeight = -10;

    public void Start()
    {
        IcecreamManager._instance.AddIcecream(this);
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
    }
}
