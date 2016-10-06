using UnityEngine;
using System.Collections;

public class platformsound : MonoBehaviour {

    public AudioSource iceDrop; 
	// Use this for initialization
	void Start () {
	
	}
    void OnTriggerEnter(Collider coll)
    {
        if (coll.tag =="iceCream")
        {
            iceDrop.Play();
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
