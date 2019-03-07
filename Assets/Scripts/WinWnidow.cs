using UnityEngine;
using System.Collections;

public class WinWnidow : MonoBehaviour {

    public bool isWin=false;

    void OnGUI()
    {
        if (isWin)
        {
            GUI.Label(new Rect(Screen.width / 2 - 80, Screen.height / 2 + 30, 250, 50), "你成功啦！");
            if (GUI.Button(new Rect(Screen.width / 2, Screen.height / 2 + 50, 100, 20), "退出游戏"))
            {
                Application.Quit();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isWin = true;
        }
    }

	
}
