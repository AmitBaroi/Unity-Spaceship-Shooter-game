﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamForward : MonoBehaviour {

    private float moveSpeed = 1f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 pos = transform.position;
        pos.y += moveSpeed * Time.deltaTime;
        transform.position = pos;
	}
}
