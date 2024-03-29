﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {

	public float MaxForce;
	public string cntrlx;
	public string jump;
	public float jumpSpeed;
	public LayerMask layer;
	private Ray2D ray;
	private RaycastHit2D rayhit;
	public bool ifJump;

	//The Direction and Speed Information
	private Vector2 velocity;
	private Vector2 force;

	// Use this for initialization
	void Start () {
		ray = new Ray2D(transform.position, Vector2.down);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Jumping Code ----Start
		ray = new Ray2D(transform.position, Vector2.down);
		rayhit = Physics2D.Raycast(ray.origin, ray.direction, 0.7f, layer);
		Debug.Log (rayhit.collider);
		if(rayhit.collider != null)
		{
			ifJump = true;
		}
		else
		{
			ifJump = false;
		}

		if(Input.GetButtonDown(jump) && ifJump)
		{
			GetComponent<Rigidbody2D>().velocity += Vector2.up * jumpSpeed;
		}
		//Jumping Code ----End

		//Change Color ----Start
		//Color playerColor = new Color(1,1,1,GetComponent<Rigidbody2D>().velocity.magnitude/Maxspeed);
		//GetComponent<SpriteRenderer>().color =  playerColor;
		//Change Color -----End

		Debug.DrawLine(ray.origin, ray.origin + ray.direction * 0.5f);
		Move();
	}

	void Move(){
		//Vector2 targetVelocity = new Vector2(Input.GetAxis(cntrlx), velocity.y)*Maxspeed;
		//velocity = Vector2.Lerp(velocity, targetVelocity, 0.1f);
		//GetComponent<Rigidbody2D>().velocity = new Vector3(velocity.x, GetComponent<Rigidbody2D>().velocity.y, 0) ;

		force = new Vector2(Input.GetAxis(cntrlx), velocity.y)*MaxForce;
		GetComponent<Rigidbody2D>().AddForce(force,ForceMode2D.Impulse);
	}
}
