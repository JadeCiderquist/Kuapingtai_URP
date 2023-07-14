using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Start : MonoBehaviour
{
    public Button Rules;
    public Button StartB;
    public Image select_Color;
    public GameObject color_Ball;

    public Button Blue;
    public Button Red;
    public Button Green;
    public Button Yellow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Rule()
    {
        Rules.gameObject.SetActive(true); 
        StartB.gameObject.SetActive(false);
    }
    public void StartGame()
    {
        Rules.gameObject.SetActive(false);
        select_Color.gameObject.SetActive(true);
        color_Ball.gameObject.SetActive(true);
    }

    public void SetBlue()
    {
        PlayerPrefs.SetInt("colorCount", 0);
        SceneManager.LoadScene("Game_Space");
    }
    public void SetRed()
    {
        PlayerPrefs.SetInt("colorCount", 1);
        SceneManager.LoadScene("Game_Space");
    }
    public void SetGreen()
    {
        PlayerPrefs.SetInt("colorCount", 2);
        SceneManager.LoadScene("Game_Space");
    }
    public void SetYellow()
    {
        PlayerPrefs.SetInt("colorCount", 3);
        SceneManager.LoadScene("Game_Space");
    }
}
