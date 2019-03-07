using UnityEngine;
using System.Collections;

public class SkillController : MonoBehaviour {

    public int track = 3;
    private float magicTimer = 3f;

    void Start()
    {
        //使用协程控制技能销毁
        StartCoroutine(DestroyByTime(magicTimer));
        //Destroy本身支持停滞几秒后进行销毁
        // GameObject.Destroy(this.gameObject, magicTimer);
    }

    void Update()
    {
        //使用计时器控制技能销毁
   //     magicTimer -= Time.deltaTime;
   //     if (magicTimer <=0)
   //     {
   //          GameObject.Destroy(this.gameObject);
   //     }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<TrollController>().health -= track * Time.deltaTime;
        }
    }
    IEnumerator DestroyByTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}
