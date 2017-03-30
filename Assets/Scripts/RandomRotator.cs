using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {

	// Use this for initialization
    public float tumble;

	void Start ()
	{
	    UnityEngine.Rigidbody rb = GetComponent<Rigidbody>();
	    rb.angularVelocity =Random.insideUnitSphere * tumble;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
