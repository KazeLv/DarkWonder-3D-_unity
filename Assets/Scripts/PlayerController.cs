using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private Animator anim;		//获取玩家模型的动画对象，进行播放控制
	private CharacterController controller;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("w")){
			anim.SetFloat("walk",0.0f);
		}else{
			anim.SetFloat("idle",1.0f);
		}
	}
}
