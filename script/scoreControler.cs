using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scoreControler : MonoBehaviour
{
    public static int score = 0;
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = score.ToString();
    }
}
