﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReimuDodgeBullet : MonoBehaviour {

    [Header("How fast the bullet goes")]
    [SerializeField]
    private float speed = 1f;

    [Header("Firing delay in seconds")]
    [SerializeField]
    private float delay = 1f;

    // Stores the direction of travel for the bullet
    private Vector2 trajectory;
    private GameObject player;

    // Use this for initialization
    void Start () {
        // Find the player object in the scene and calculate a trajectory towards them
        Invoke("SetTrajectory", delay);
    }
	
	// Update is called once per frame
	void Update () {
        // Only start moving after the trajectory has been set
        if (trajectory != null)
        {
            // Move the bullet a certain distance based on trajectory speed and time
            //OPTIONAL: Uncomment below line for homing shots.
            //trajectory = (player.transform.position - transform.position).normalized;
            Vector2 newPosition = (Vector2)transform.position + (trajectory * speed * Time.deltaTime);
            transform.position = newPosition;
        }
    }

    void SetTrajectory()
    {
        // Find the player object in the scene and calculate a trajectory towards them
        player = GameObject.Find("Player");
        trajectory = (player.transform.position - transform.position).normalized;
    }
}
