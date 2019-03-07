using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {

    public static Message _instance;
    private bool startTimer = false;
    private float timer;

	// Use this for initialization
	void Start () {
        _instance = this;

        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (startTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                EndMessage();
                startTimer = false;
            }
        }
    }

    public void ShowMessage(string message)
    {
        this.gameObject.SetActive(true);
        this.GetComponent<GUIText>().text = message;
    }
    public void ShowMessage(string message,float time)
    {
        startTimer = true;
        timer = time;
        this.GetComponent<GUIText>().text = message;
        this.gameObject.SetActive(true);
    }
    public void EndMessage()
    {
        this.gameObject.SetActive(false);
    }
}
