using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

    public Text HS;

    void Start()
    {
        HS.text = "Highscore: "+PlayerPrefs.GetInt("HIGHSCORE");
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

}
