using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    private CharacterController controller;
    private float coldTimer;
    private float coldTimeReset = 2f;
    private bool getBelieved=false;
    private bool isNearTrex = false;
    private bool yes;
    private bool no;
    private bool sendMessage = false;

    public bool getControl = true;
    public int needMeatCount=3;
    public int speed=10;
    public bool trainingEnd = false;
    public GameObject skill;
    public GameObject camera;
    public GameObject Trex;

	// Use this for initialization
	void Start () {
        controller = this.GetComponent<CharacterController>();
        coldTimer = coldTimeReset;
	}
	
	// Update is called once per frame
	void Update () {
        if (getControl)
        {
            controller.SimpleMove(new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed));
           // controller.SimpleMove(new Vector3());
            if (trainingEnd)
            {
                coldTimer -= Time.deltaTime;
                if ((coldTimer <= 0) && Input.GetKey("x"))
                {
                    GameObject.Instantiate(skill, transform.position, Quaternion.identity);
                    coldTimer = coldTimeReset;
                }
            }
            if (needMeatCount <= 0&&!sendMessage)
            {
                Message._instance.ShowMessage("你得到了恐龙的信任，按下Q来切换控制！", 4f);
                sendMessage = true;
                GameManager._instance.PlayGetTrex();
            }
        }
        if (needMeatCount <= 0 &&Input.GetKeyDown(KeyCode.Q))
        {
            if (getControl)
            {
                Trex.SendMessage("GetControl");
                this.LoseControl();
            }else
            {
                Trex.SendMessage("LoseControl");
                this.GetControl();
            }
        }
    }

    void OnGUI()
    {
        if (!getBelieved && isNearTrex)
        {
            if (GameManager.meatCount == 0)
            {
                GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height/2 + 50, 250, 50), "恐龙饿坏了，你能帮它找点吃的吗？");
            }
            else
            {
                GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 50, 250, 50), "你愿意把巨魔肉喂给恐龙吃吗？");
                yes=GUI.Button(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 100, 50, 20), "是");
                no=GUI.Button(new Rect(Screen.width / 2 + 50, Screen.height / 2 + 100, 50, 20), "否");
            }
            if (yes)
            {
                isNearTrex = false;
                needMeatCount -= GameManager.meatCount;
                GameManager.meatCount = 0;
            }
            if (no)
            {
                isNearTrex = false;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trex")
        {
            print("neartrex");
            isNearTrex = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trex")
        {
            isNearTrex = false;
        }
    }
    void GetControl()
    {
        camera.SetActive(true);
        getControl = true;
    }
    void LoseControl()
    {
        camera.SetActive(false);
        getControl = false;
    }
}
