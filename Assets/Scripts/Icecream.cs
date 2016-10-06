using UnityEngine;
using System.Collections;

public class Icecream : MonoBehaviour
{
    //public int pointValue = 1;
    public float deathHeight = -10;

    public void Die()
    {
        Destroy(gameObject);
    }
}
