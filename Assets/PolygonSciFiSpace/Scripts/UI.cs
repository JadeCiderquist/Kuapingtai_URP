using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text num_dis;
    public Text num_score;
    public Text num_Pingjia;
    public Text num_TopPingjia;
    public GameObject player;
    public Button Pause_Button;
    public Image Left;
    public Image Right;
    public Image Pause;
    public Image Final;

    int pingjia = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        num_dis.text = player.transform.position.z.ToString("0");//距离变化数值
        num_score.text = player.GetComponent<Player>().Score.ToString("0");//获取player中的Score变量赋值
        pingjia = int.Parse(player.transform.position.z.ToString("0")) + player.GetComponent<Player>().Score * 20;//总评成绩
        num_Pingjia.text = pingjia.ToString("0");

        //最高分储存
        if(pingjia > PlayerPrefs.GetInt("Top_Score"))
        {
            PlayerPrefs.SetInt("Top_Score", pingjia);
        }
        num_TopPingjia.text = PlayerPrefs.GetInt("Top_Score").ToString("0");

        if (player.GetComponent<Player>().isFail)
        {
            Final.gameObject.SetActive(true);
            Pause_Button.gameObject.SetActive(false);
        }
    }

    public void jump()
    {
        if (player.GetComponent<Player>().jumpcount < 1)
        {
            player.GetComponent<Player>().jumpcount++;
            player.GetComponent<Player>().rb.AddForce(0, 230, 0);
        }
    }

    public void run()
    {
        player.GetComponent<Player>().rb.AddForce(0, 0, 50);
    }

    public void StartGame()
    {
        Pause.gameObject.SetActive(false);
        Time.timeScale = 1;
        Final.gameObject.SetActive(false);
        this.player.GetComponent<Player>().ResetPlayer();
        Invoke("ReplaceLevel", 0.18f);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Pause_Button.gameObject.SetActive(false);
        Pause.gameObject.SetActive(true);
        this.player.GetComponent<Player>().PauseBackgroundSound();
    }
    public void ContinueGame()
    {
        Pause_Button.gameObject.SetActive(true);
        Pause.gameObject.SetActive(false);
        Time.timeScale = 1;
        this.player.GetComponent<Player>().PlayBackgroundSound();
    }
    public void ReturnMenu()
    {
        SceneManager.LoadScene("Demo_Exterior");
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void ReplaceLevel()
    {
        SceneManager.LoadScene("Game_Space");
    }
}
