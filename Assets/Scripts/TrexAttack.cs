using UnityEngine;
using System.Collections;

public class TrexAttack : MonoBehaviour {

    public GameObject Fence1;
    public GameObject Fence2;
    public GameObject Fence3;
    public GameObject Fence4;
    public GameObject Fence5;
    public static TrexAttack _instance;
    public bool destroyFence = false;

    private bool isTrex = false;

    void Start()
    {
        _instance = this;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Trex")
        {
            isTrex = false;
            Message._instance.EndMessage();
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Trex"&&TrexController.getControl&&!destroyFence)
        {
            Message._instance.ShowMessage("恐龙可以破坏这些栅栏，按下 x 来攻击栅栏！",5f);
            isTrex = true;
        }
    }
    public void DestroyFence()
    {
        if (Fence1 != null)
        {
            GameObject.Destroy(Fence1);
            destroyFence = true;
        }else if (Fence2 != null)
        {
            GameObject.Destroy(Fence2);
        }else if (Fence3 != null)
        {
            GameObject.Destroy(Fence3);
        }else if (Fence4 != null)
        {
            GameObject.Destroy(Fence4);
        }else if (Fence5 != null)
        {
            GameObject.Destroy(Fence5);
        }
    }
}
