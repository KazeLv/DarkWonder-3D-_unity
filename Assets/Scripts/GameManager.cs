using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public static GameManager _instance;
    public static int meatCount;
    public GameObject Meat;
    public AudioClip getMeat;
    public AudioClip getTrex;

	// Use this for initialization
	void Start () {
        _instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        if (meatCount > 0)
        {
            AwakeTexture();
        }
        Meat.GetComponent<GUIText>().text = meatCount + "";
	}
    public void AwakeTexture()
    {
        Meat.SetActive(true);
    }

    public void PlayGetMeat()
    {
        this.GetComponent<AudioSource>().PlayOneShot(getMeat);
    }

    public void PlayGetTrex()
    {
        this.GetComponent<AudioSource>().PlayOneShot(getTrex);
    }
}
