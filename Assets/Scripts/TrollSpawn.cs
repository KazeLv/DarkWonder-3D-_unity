using UnityEngine;
using System.Collections;

public class TrollSpawn : MonoBehaviour {

    public GameObject trollPrefab;
    public int maxCount=10;
    public static int count;

    private float timer;
    private float resetTimer = 5;

	// Use this for initialization
	void Start () {
        timer = resetTimer;
	}
	
	// Update is called once per frame
	void Update () {
        if (count < maxCount)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GameObject.Instantiate(trollPrefab, transform.position, Quaternion.identity);
                count++;
                timer = resetTimer;
            }
        }
	}
}
