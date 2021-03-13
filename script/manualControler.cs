using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manualControler : MonoBehaviour
{
    public GameObject manual;

    void Start()
    {
        manual.SetActive(false);
    }
    void OnMouseOver()
    {
        manual.SetActive(true);
    }
    void OnMouseExit()
    {
        manual.SetActive(false);
    }
}
