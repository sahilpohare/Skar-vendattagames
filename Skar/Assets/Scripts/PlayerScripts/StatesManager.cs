﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StatesManager : MonoBehaviour {
    public enum MoveState
{       
	     Idle,
		 isJumping,
		 isMoving,
		 isInDash,
		 isAttacking
}
    public bool CanMove;
	public bool isAttacking;
	public bool isGrounded;
	public MoveState moveState;
	AbilitesManager abilitesManager;
	PlayerMovement movl;
	Rigidbody rb ;
        // Use this for initialization
    void Start () {
        movl = GetComponent <PlayerMovement>();
		abilitesManager = GetComponent <AbilitesManager> ();
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () { 
		if(abilitesManager.isInDash){
			moveState = MoveState.isInDash;
		}  
		if(rb.velocity  == Vector3.zero && isGrounded && !isAttacking){
			moveState = MoveState.Idle;
		}
		if(rb.velocity.magnitude > 0 && !abilitesManager.isInDash && !isAttacking && isGrounded && CanMove){
			moveState = MoveState.isMoving;
		}
		if(!abilitesManager.isInDash && !isGrounded && !isAttacking){
			moveState = MoveState.isJumping;
		}
     
	}
 } 	


