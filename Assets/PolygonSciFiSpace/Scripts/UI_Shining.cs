using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Shining : MonoBehaviour
{
    public float blinkSpeed;//闪烁速度
    private bool isAddAlpha = true;//是否增加透明度

    public Image img;//指向自身图片
    public Text text0;
    public bool iftext = false;
    private bool play = false;
    public Player player;
    bool isPC = false;

    float TimeSpeed = 0;
    bool doonce = true;

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private void Update()
    {
        if (this.player.GetComponent<Player>().UI_Shining && !isPC)
        {
            PhoneAlpha();
        }
    }

    public void PhoneAlpha()
    {
        TimeSpeed += Time.deltaTime;
        if (TimeSpeed <= 6)//判断时间
        {
            if (!iftext)
            {
                if (isAddAlpha)
                {
                    img.color += new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
                    if (img.color.a >= 0.2)
                    {
                        img.color = new Color(img.color.r, img.color.g, img.color.b, 0.2f);
                        isAddAlpha = false;
                    }
                }
                else
                {
                    img.color -= new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
                    if (img.color.a <= 0)
                    {
                        img.color = new Color(img.color.r, img.color.g, img.color.b, 0);
                        isAddAlpha = true;
                    }
                }
            }
            else
            {
                if (isAddAlpha)
                {
                    text0.color += new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
                    if (text0.color.a >= 0.8)
                    {
                        text0.color = new Color(text0.color.r, text0.color.g, text0.color.b, 0.8f);
                        isAddAlpha = false;
                    }
                }
                else
                {
                    text0.color -= new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
                    if (text0.color.a <= 0)
                    {
                        text0.color = new Color(text0.color.r, text0.color.g, text0.color.b, 0);
                        isAddAlpha = true;
                    }
                }
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

   
}

