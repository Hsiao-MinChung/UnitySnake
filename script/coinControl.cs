using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinControl : MonoBehaviour
{
    public bool coinIsExsit;//場景中只存在一個coin
    GameObject coinMaker;
    
    void Start()
    {
        coinMaker = GameObject.Find("coinMaker");//coin被製造出來就去找coinMaker
        coinMaker.GetComponent<coinMakerControl>().coinExsit = true;//告知coinMaker coin存在
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "player")
        {
            scoreControler.score++;
            coinMaker.GetComponent<coinMakerControl>().coinExsit = false;
            Destroy(this.gameObject);
        }
    }

}
