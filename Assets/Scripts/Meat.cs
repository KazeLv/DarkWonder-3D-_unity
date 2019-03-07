using UnityEngine;
using System.Collections;

public class Meat : MonoBehaviour {

    public static Meat _instance;
    public static int count;

    void Awake()
    {
        _instance = this;
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
