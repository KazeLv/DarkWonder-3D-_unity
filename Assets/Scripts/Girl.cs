using UnityEngine;
using System.Collections;

public class Girl : MonoBehaviour {

	// Use this for initialization
	void Start () {
        this.GetComponent<Animation>().wrapMode = WrapMode.Loop;
        this.GetComponent<Animation>().CrossFade("Sad");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
