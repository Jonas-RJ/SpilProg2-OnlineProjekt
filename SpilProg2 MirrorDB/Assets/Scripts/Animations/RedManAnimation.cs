using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RedManAnimation : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

        // Update is called once per frame
        void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RunAnim();
        }
    }

    public void RunAnim()
    {
        GetComponent<Animator>().Play("RedManAnim");
    }
}
