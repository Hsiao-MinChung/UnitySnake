using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinMakerControl : MonoBehaviour
{
    public GameObject coin;//prefab

    public float dx,dy;//場景範圍
    float xlocation;
    float ylocation;

    public bool coinExsit=false;//場上是有coin存在

    void Start()
    {
        dx = 83.2f;
        dy = 44.5f;
    }
 
    void Update()
    {
        if( !coinExsit )//IF COIN NOT EXSIT
        {
            xlocation = Random.Range((-1 * dx - 5) / 10, (dx - 5) / 10);
            ylocation = Random.Range((-1 * dy - 5) / 10, (dy - 5) / 10);
            xlocation = ((int)(xlocation) * 2 + 1) * 5;//做標固定要在尾數是5的座標上....-15,-5,5,15,25...
            ylocation = ((int)(ylocation) * 2 + 1) * 5;

            GameObject newCoin = Instantiate(coin);
            newCoin.gameObject.transform.position = new Vector3(xlocation, ylocation,0);
            coinExsit=true;
        }

    }
}
