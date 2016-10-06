using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IcecreamManager : MonoBehaviour
{
    public static IcecreamManager _instance;

    private List<Icecream> icecreams = new List<Icecream>();

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("Multiple icecream instances found, destroying one.");
            Destroy(this);
        }
    }

    public void AddIcecream(Icecream icecream)
    {
        icecreams.Add(icecream);
    }

    public void RemoveIcecream(Icecream icecream)
    {
        icecreams.Remove(icecream);
    }
}
