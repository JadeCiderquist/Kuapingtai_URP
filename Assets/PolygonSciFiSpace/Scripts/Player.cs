using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public Camera cam;
    public GameObject Door01;
    public GameObject Globle;
    public GameObject Block;
    public UI UI;
    public Material Wall;
    public Material PlayerMat;
    public int playerSpeed = 1;
    public int Score = 0;
    public bool ifBlue = false;
    public bool ifRed = false; 
    public bool ifBlod = false;
    bool changeBlue = false;
    bool changeRed = true;
    public bool isFail = false;
    public bool UI_Shining = false;
    bool TwiceJump = false;
    public int jumpcount = 0;
    public AudioSource HitSoundPlay;
    public AudioSource BackgroundSound;
    Vector3 Loction_P;
    Vector3 Rotation_P;
    
    public bool isGrounded = true;
    // Start is called before the first frame update
    void Start()
    {
        rb.interpolation = RigidbodyInterpolation.Interpolate;//相机移动平滑
        Globle.gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        WallChangeColor();
        //失败后停止运动
        if(isFail)
        {
            rb.useGravity = false;
            this.transform.position = Loction_P;
            this.transform.eulerAngles = Rotation_P;
        }
        if ((Input.GetKeyDown(KeyCode.W) && jumpcount < 1 ))
        {
            jumpcount++;
            rb.AddForce(0, 230, 0);
        }
    }
    void FixedUpdate()
    {
        Contorl();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        
        //与地板发生碰撞则启用移动与跳跃
        if (collision.gameObject.tag == "Road")
        {
            this.isGrounded = true;
            jumpcount = 0;
        }
        //与方块碰撞加分
        if (collision.gameObject.tag == "Point_Red")
        {
            Score += 1;
            ifBlue = false;
            ifRed = true;
            ifBlod = false;
            HitSoundPlay.Play();
        }
        if (collision.gameObject.tag == "Point_Blod")
        {
            Score += 10;
            ifBlue = false;
            ifBlod = true;
            ifRed = false;
            HitSoundPlay.Play();
        }
        if (collision.gameObject.tag == "Point")
        {
            Score += 1;
            ifBlue = true;
            ifRed = false;
            ifBlod = false;
            HitSoundPlay.Play();
        }
        if (ifBlue && !ifRed && changeBlue)
        {
            Score += 5;
            changeBlue = false;
            changeRed = true;
        }
        if (!ifBlue && ifRed && changeRed)
        {
            Score += 5;
            changeBlue = true;
            changeRed = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
            if (collision.gameObject.tag == "Road")
            {
                this.isGrounded = false;
            }

        if (collision.gameObject.tag == "Point_Red" || collision.gameObject.tag == "Point_Blod" || collision.gameObject.tag == "Point")
        {
           
        }
    }

    //与门碰撞体重合则执行
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Box_door01")
        {
           this.Door01.GetComponent<Door_open>().ifin = true;
           UI_Shining = true;
        }
        if (other.gameObject.tag == "Death")
        {
            this.isFail = true;
            Loction_P = this.transform.position;
            Rotation_P = this.transform.eulerAngles;
            PauseBackgroundSound();
        }
    }

    public void Contorl()
    {
        if (!isFail)//判断是否失败
        {
            rb.useGravity = true;
            rb.AddForce(0, 0, 10);
            rb.AddForce(Input.acceleration.x * 30, 0, 0);//手机重力感应
            
            if (Input.GetKey("a"))
            {
                rb.AddForce(-30, 0, 0);
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(30, 0, 0);
            }
            if (Input.GetKey("s") && this.isGrounded)//ctrl下降
            {
                rb.AddForce(0, -20, 0);
            }
            if (Input.GetKey("left shift") || Input.GetKey("right shift"))
            {
                rb.AddForce(0, 0, 10);
            }
            if (Input.GetKey("escape"))
            {
                this.UI.GetComponent<UI>().PauseGame();
            }
        }
    }

    void WallChangeColor()
    {
        if (ifRed)
        {
            Wall.color = Color.Lerp(Wall.color, Color.red, Time.deltaTime * 10);
            Wall.SetColor("_EmissionColor", new Color(11.0f, 0.1f, 0.0f, 1.0f));
        }
        else if (ifBlod)
        {
            Wall.SetColor("_EmissionColor", Color.yellow * 10);
        }
        else
        {
            Wall.color = Color.Lerp(Wall.color, Color.white, Time.deltaTime * 10);
            Wall.SetColor("_EmissionColor", new Color(0.0f, 8.0f, 8.0f, 1.0f));
        }
    }

    public void ResetPlayer()
    {
        this.transform.position = new Vector3(-4.925f, 0.472f, 1.079f);
        this.isFail = false;
    }

    public void PauseBackgroundSound()
    {
        BackgroundSound.Pause();
    }
    public void PlayBackgroundSound()
    {
        BackgroundSound.Play();
    }

}
