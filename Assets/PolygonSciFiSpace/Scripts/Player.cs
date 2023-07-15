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
        rb.interpolation = RigidbodyInterpolation.Interpolate;//����ƶ�ƽ��
        Globle.gameObject.SetActive(true);
    }

    // Update is called once per frame
    private void Update()
    {
        WallChangeColor();
        //ʧ�ܺ�ֹͣ�˶�
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
        //����

        if (this.transform.position.y <= 0)
        {
            this.isFail = true;
            Loction_P = this.transform.position;
            Rotation_P = this.transform.eulerAngles;
            PauseBackgroundSound();
        }
    }
    void FixedUpdate()
    {
        Contorl();
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        //������б����
        if (collision.gameObject.tag == "Accelerate")
        {
            rb.AddForce(0, 400, 400);
        }
        //��ڴ�
        if (collision.gameObject.tag == "BaiChui")
        {
            rb.AddForce(-400, 500, 0);
        }

        if (collision.gameObject.tag == "Left_Box")
        {
            rb.AddForce(400, 300, 0);
        }
        if (collision.gameObject.tag == "Right_Box")
        {
            rb.AddForce(-400, 300, 0);
        }
        //��ذ巢����ײ�������ƶ�����Ծ
        if (collision.gameObject.tag == "Road")
        {
            this.isGrounded = true;
            jumpcount = 0;
        }
        //�뷽����ײ�ӷ�
        if (collision.gameObject.tag == "Point_Red")
        {
            Score += 1;
            ifBlue = false;
            ifRed = true;
            ifBlod = false;
            //�ƹ�
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Light");//����tag��ͬ����������
            foreach (GameObject target in targets)
            {
                target.GetComponent<Light>().color = Color.red;
            }
            Handheld.Vibrate();//�ֻ���
            HitSoundPlay.Play();
        }
        if (collision.gameObject.tag == "Point_Blod")
        {
            Score += 10;
            ifBlue = false;
            ifBlod = true;
            ifRed = false;
            //�ƹ�
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Light");//����tag��ͬ����������
            foreach (GameObject target in targets)
            {
                target.GetComponent<Light>().color = new Vector4(1, 1, 0, 1);
            }
            Handheld.Vibrate();//�ֻ���
            HitSoundPlay.Play();
        }
        if (collision.gameObject.tag == "Point")
        {
            Score += 1;
            ifBlue = true;
            ifRed = false;
            ifBlod = false;
            //�ƹ�
            GameObject[] targets = GameObject.FindGameObjectsWithTag("Light");//����tag��ͬ����������
            foreach (GameObject target in targets)
            {
                target.GetComponent<Light>().color = new Vector4(0, 1, 0.9f, 1);
            }
            Handheld.Vibrate();//�ֻ���
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

    //������ײ���غ���ִ��
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Box_door01")
        {
           this.Door01.GetComponent<Door_open>().ifin = true;
           UI_Shining = true;
        }
    }

    public void Contorl()
    {
        if (!isFail)//�ж��Ƿ�ʧ��
        {
            rb.useGravity = true;
            rb.AddForce(0, 0, 10);
            rb.AddForce(Input.acceleration.x * 30, 0, 0);//�ֻ�������Ӧ
            
            if (Input.GetKey("a"))
            {
                rb.AddForce(-30, 0, 0);
            }
            if (Input.GetKey("d"))
            {
                rb.AddForce(30, 0, 0);
            }
            if (Input.GetKey("s") && this.isGrounded)//ctrl�½�
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
            //Wall.color = Color.Lerp(Wall.color, Color.red, Time.deltaTime * 10);
            Wall.SetColor("_EmissionColor", new Color(10.0f, 0.0f, 0.0f, 1.0f));
        }
        else if (ifBlod)
        {
            Wall.SetColor("_EmissionColor", Color.yellow * 10);
        }
        else
        {
            //Wall.color = Color.Lerp(Wall.color, Color.white, Time.deltaTime * 10);
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
