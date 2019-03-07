using UnityEngine;
using System.Collections;

public class TrexController : MonoBehaviour {

    public float anglePerSecond = 30;
    public float speed = 10;
    public Animation anim;
    public static bool getControl = false;
    public GameObject camera;

    private string animName;
	// Use this for initialization
	void Start () {
	    anim.CrossFade("idle");
    }
	
	// Update is called once per frame
	void Update () {
        if (getControl)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * anglePerSecond * Time.deltaTime, 0);
            this.gameObject.GetComponent<CharacterController>().SimpleMove(transform.forward * speed * Input.GetAxis("Vertical"));
            if (Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
            {
                if (animName != "walk_loop")
                {
                    anim.CrossFade("walk_loop");
                    animName = "walk_loop";
                }
            }
            else
            {
                if (animName != "idle")
                {
                    anim.CrossFade("idle");
                    animName = "idle";
                }
            }
            if (Input.GetKey("x"))
            {
                anim.CrossFade("Eat");
            }
        }
       
	}

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "TrexAttack" && Input.GetKeyDown("x"))
        {
            TrexAttack._instance.DestroyFence();
        }
    }
    public void GetControl()
    {
        camera.SetActive(true);
        getControl = true;
    }
    public void LoseControl()
    {
        camera.SetActive(false);
        getControl = false;
    }
}
