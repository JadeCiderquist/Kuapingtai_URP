using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WASD_Shining : MonoBehaviour
{
    public float blinkSpeed;//闪烁速度
    private bool isAddAlpha = true;//是否增加透明度
    float TimeSpeed = 0;
    float TimeSpeed02 = 0;
    public Image Anjian;//指向自身图片
    bool ifPC = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ifPC)
        {
            PCAD();
        }
    }

    public void PCAD()
    {
        TimeSpeed += Time.deltaTime;
        if (TimeSpeed <= 6)//判断时间
        {
            if (isAddAlpha)
            {
                Anjian.color += new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
                if (Anjian.color.a >= 1)
                {
                    Anjian.color = new Color(1, 1, 1, 1);
                    isAddAlpha = false;
                }
            }
            else
            {
                Anjian.color -= new Color(0, 0, 0, Time.deltaTime * blinkSpeed);
                if (Anjian.color.a <= 0)
                {
                    Anjian.color = new Color(1, 1, 1, 0);
                    isAddAlpha = true;
                }
            }
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
