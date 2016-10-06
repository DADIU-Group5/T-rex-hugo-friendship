using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class IcecreamManager : MonoBehaviour
{
    private List<Icecream> icecreams = new List<Icecream>();

    public void AddIcecream(Icecream icecream)
    {
        icecreams.Add(icecream);
    }

    public void RemoveIcecream(Icecream icecream)
    {
        icecreams.Remove(icecream);
    }
}
