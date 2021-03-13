using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//單純製造背景
public class backGroundMaker : MonoBehaviour
{
    public GameObject block;//PREFAB
    private int dx, dy;
    
    void Start()
    {
        dx = 85;
        dy = 45;

        for(int x = -dx; x <= dx; x = x + 10)
        {
            for(int y = -dy; y <= dy; y = y + 10)
            {
                GameObject newBlock = Instantiate(block);
                newBlock.gameObject.transform.position = new Vector3(x, y, 0);
            }
        }
    }

}
