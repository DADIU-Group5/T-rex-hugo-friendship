using UnityEngine;
using System.Collections;

public class ScrollingBG : MonoBehaviour {

    public float speed = 0.5f;
    float timer = 0;

    private Material mat;
    // Use this for initialization
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(timer * speed, 0);
        mat.mainTextureOffset = offset;
        timer += Time.deltaTime;
    }
}
