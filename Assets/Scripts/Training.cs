using UnityEngine;
using System.Collections;

public class Training : MonoBehaviour {

    private bool isTraining = false;
    private bool isTrainingEnd = false;
    private float resetTime;

    public GameObject skill;
    public GUIText text; 
    public float timer = 5;

	// Use this for initialization
	void Start () {
        resetTime = timer;
	}
	
	// Update is called once per frame
	void Update () {
        if (isTrainingEnd == true)
        {
            skill.SetActive(true);
        }
        if (isTraining && isTrainingEnd == false)
        {
            timer -= Time.deltaTime;
            text.gameObject.SetActive(true);
         //   Message._instance.ShowMessage("修炼时间还剩下：" + (int)timer + "秒");
            text.text = "修炼时间还剩下：" + (int)timer + "秒";
            if (timer <= 0)
            {
                isTrainingEnd = true;
                text.text = "神功修炼完成！";
                GameObject.FindWithTag("Player").GetComponent<Player>().trainingEnd = true;
            }
        }
	}

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (isTrainingEnd == false)
            {
                timer = resetTime;
            }
            isTraining = true;
        }
       
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            isTraining = false;
            Message._instance.EndMessage();
        }
    }
}
