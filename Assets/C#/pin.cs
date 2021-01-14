using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pin : MonoBehaviour {

    public float speed = 15; 
    public bool isfly = false;
    public bool isreach = false;
    public Transform start;
    public Transform Circle;
    public Vector3 finallypostion;
	// Use this for initialization
	void Start () {
        start = GameObject.Find("start").transform;
        Circle = GameObject.Find("Circle").transform;
        finallypostion = Circle.position;
        finallypostion.y = finallypostion.y - 2f;
	}




	
	// Update is called once per frame
	void Update () {
		if(isfly==false)
        {
            if(isreach==false)
            {
                transform.position=Vector3.MoveTowards(transform.position, start.position, speed * Time.deltaTime);
                if(Vector3.Distance(transform.position,start.position)<=0.05f)
                {
                    isreach = true;
                }
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, finallypostion, speed * Time.deltaTime);
            if(Vector3.Distance(transform.position,finallypostion)<0.05f)
            {
                transform.position = finallypostion;
                transform.parent = Circle;
                isfly = false;
            }
        }
	}
    public void StartFly()
    {
        isfly = true;
        isreach = true;
    }



}
