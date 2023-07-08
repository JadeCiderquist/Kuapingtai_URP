using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Start : MonoBehaviour
{
    public Button Rules;
    public Button StartB;
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
        SceneManager.LoadScene("Game_Space");
    }
}
