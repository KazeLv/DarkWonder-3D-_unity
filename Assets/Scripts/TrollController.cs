using UnityEngine;
using System.Collections;

public class TrollController : MonoBehaviour {

    private Animator anim;
    private CharacterController controller;
    private float rotation;
    private float destroyTimer=1.5f;
    
    public bool idle;
    public bool run;
    public float timer;
    public int speed=4;
    public float health=10f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        idle = true;
        timer = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            die();
        }else
        {
            timer -= Time.deltaTime;
            if (idle)
            {
                ToIdle();
            }
            else
            {
                ToWalk();
            }
            if (timer <= 0)
            {
                if (idle)
                {
                    idle = false;
                    timer = 5;
                    //transform.Rotate(new Vector3(0, Random.Range(0, 360), 0));
                    rotation = Random.Range(-180f, 180f);
                }
                else
                {
                    idle = true;
                    timer = 3;
                }
            }
        }
	}

    void ToIdle()
    {
        anim.SetFloat("idle", 1F);
        anim.SetFloat("walk", 0.0F);
        anim.SetFloat("run", 0F);
    }
    void ToWalk()
    {
        if (Mathf.Abs(rotation) > 0.2f)
        {
            transform.Rotate(new Vector3(0, rotation*0.05f, 0));
            rotation -= rotation * 0.05f;
        }
        //transform.position += transform.forward *Time.deltaTime* speed;
        controller.SimpleMove(transform.forward * speed);
        anim.SetFloat("idle", 0F);
        anim.SetFloat("walk", 1F);
        anim.SetFloat("run", 0F);
    }
    public void die()
    {
        anim.SetFloat("death", 1F);
        destroyTimer -= Time.deltaTime;
        if (destroyTimer <= 0)
        {
            TrollSpawn.count--;
            GameObject.Destroy(this.gameObject);
            if (Random.Range(1, 5) <= 4)
            {
                GameManager.meatCount++;
                GameManager._instance.PlayGetMeat();
            }
        }
    }
}
