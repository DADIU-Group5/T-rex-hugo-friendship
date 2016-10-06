using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

    public Text HS;

    void Start()
    {
        SceneManager.UnloadScene(1);
        HS.text = "HIGHSCORE: "+PlayerPrefs.GetInt("HIGHSCORE");
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

}
