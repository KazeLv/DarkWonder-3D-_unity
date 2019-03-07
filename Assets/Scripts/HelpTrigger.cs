using UnityEngine;
using System.Collections;

public class HelpTrigger : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"&&!TrexAttack._instance.destroyFence)
        {
            Message._instance.ShowMessage("你的力量无法打开铁门，你可能需要恐龙的帮助", 5f);
        }
    }
}
