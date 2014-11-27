﻿using UnityEngine;


public class Spaceship : Enemy {
	
	private int Direction=1;
	public float AdVel = 0.001f;
	float StartPosition;

	// Use this for initialization
	private void Start() {
		StartPosition = gameObject.transform.position.x;
		rigidbody2D.velocity = new Vector2(HSpeed, VSpeed);


		
	}



	// Update is called once per frame
	private void Update() {

		UpdateMovement();
	}
	
	private void UpdateMovement() {
		gameObject.transform.position+=new Vector3 (HSpeed,VSpeed,0);
		VSpeed += AdVel*Direction;
		//if (VSpeed > 0.05f) Direction *= -1;
		//if (VSpeed < -0.05f) Direction *= -1;
		if (gameObject.transform.position.y > Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y)
			gameObject.transform.position =
				new Vector3(StartPosition,Camera.main.ScreenToWorldPoint(new Vector3(0,Screen.height,0)).y*(-1), gameObject.transform.position.z);
	}
}