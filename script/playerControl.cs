using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float velocity;//一次走的距離(一格)
    private Vector3 movement;//控制方向
    private string state;//現在方向的狀態

    private List <GameObject> bodyList =new List<GameObject>();//蛇的List
    private int counter ;//用來接list.count的值
    public GameObject body;//prefab

    public gameManagerControl gameManager;//死掉要呼叫

    void Start()
    {
        //初始化
        velocity = 10;
        movement = new Vector3(velocity, 0, 0);
        state = "right";

        bodyList.Add(this.gameObject);

        //創造一個初始身體做為緩衝
        GameObject newBody = Instantiate(body);
        newBody.gameObject.transform.position = bodyList[0].gameObject.transform.position + new Vector3(-10, 0, 0);
        bodyList.Add(newBody);
 
        InvokeRepeating(nameof(snakeMove), 1f, 0.2f);//在一秒後呼叫snakeMove，之後每0.2秒呼叫一次

    }

    
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow) && state != "down")//不能直接折返
        {
            movement = new Vector3(0, velocity, 0);
            state = "up";
        }
        else if (Input.GetKey(KeyCode.DownArrow) && state != "up")
        {
            movement = new Vector3(0, -1*velocity, 0);
            state = "down";
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && state != "right")
        {
            movement = new Vector3(-1*velocity, 0, 0);
            state = "left";
        }
        else if (Input.GetKey(KeyCode.RightArrow) && state != "left")
        {
            movement = new Vector3(velocity, 0, 0);
            state = "right";
        }

    }
    
    private void snakeMove()
    {
        Vector3 tmpFront,tmp;//tmpFront儲存現在body的位置，tmp儲存要給現在這個body的新位置

        tmpFront = bodyList[0].gameObject.transform.position;
        bodyList[0].gameObject.transform.position += movement;

        switch (state)//轉頭
        {
            case "up":
                bodyList[0].gameObject.transform.localEulerAngles = new Vector3(0, 0, 90);
                break;
            case "down":
                bodyList[0].gameObject.transform.localEulerAngles = new Vector3(0, 0, -90);
                break;
            case "left":
                bodyList[0].gameObject.transform.localEulerAngles = new Vector3(0, 0, 180);
                break;
            case "right":
                bodyList[0].gameObject.transform.localEulerAngles = new Vector3(0, 0, 0);
                break;
            default:
                break;
        }

        counter = bodyList.Count;//移動整個身體，讓body去繼承上一個body的位置
        for(int i = 1; i < counter; i++)
        {
            tmp = tmpFront;
            tmpFront = bodyList[i].gameObject.transform.position;
            bodyList[i].gameObject.transform.position = tmp;
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)//吃到coin
    {
        if (collision.tag == "coin")
        {
            counter = bodyList.Count-1;//注意List是從0開始，count是回傳有幾個，不是最後一個的編號
            GameObject newBody = Instantiate(body);
            newBody.gameObject.transform.position = bodyList[counter].gameObject.transform.position;
            bodyList.Add(newBody);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)//死掉了
    {
        if(collision.gameObject .tag == "wall" || collision.gameObject.tag == "body")
        {
            gameManager.GameOver();
        }
    }

}
