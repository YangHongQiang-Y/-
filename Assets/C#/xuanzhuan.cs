using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xuanzhuan : MonoBehaviour {

    public float speed = 200;
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0,0,-speed*Time.deltaTime));
	}
}
