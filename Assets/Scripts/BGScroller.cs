using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

    public float scrollSpeed;
    private Vector3 startPosition;
    private float tittleSize;

	// Use this for initialization
	void Start () {

        startPosition = transform.position;
        tittleSize = transform.localScale.y;
		
	}
	
	// Update is called once per frame
	void Update () {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tittleSize);
        transform.position = startPosition + Vector3.forward * newPosition;
	}
}
