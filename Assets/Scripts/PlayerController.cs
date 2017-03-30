﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Xml;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource audioSource;
    public float speed;
    public Boundary boundary;
    public float tilt;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	    audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (Input.GetButton("Fire1") && Time.time > nextFire)
	    {
	       nextFire = Time.time + fireRate;
	       Instantiate(shot, shotSpawn.position, shotSpawn.rotation) ;
	        audioSource.Play();
	    }
	    
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = movement* speed;
        rb.position = new Vector3
        (
            Mathf.Clamp( rb.position.x,boundary.xMin, boundary.xMax )
            ,0.0f
            ,Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );

        rb.rotation = Quaternion.Euler(0.0f,0.0f, rb.velocity.x * -tilt);
    }
}