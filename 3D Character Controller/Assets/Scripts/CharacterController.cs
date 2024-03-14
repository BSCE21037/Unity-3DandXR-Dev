using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    //public variables
    public Animator playerAnim;
	public Rigidbody playerRigid;
	public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed;
	public bool walking;    //walikng check
	public Transform playerTrans;
	
	
	void FixedUpdate(){
        //move forward
		if(Input.GetKey(KeyCode.W)){
			playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
		}
        //move backward
		if(Input.GetKey(KeyCode.S)){
			playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
		}
	}
	void Update(){
        //FORWARD & BACKWARD MOVEMENT
		if(Input.GetKeyDown(KeyCode.W)){
            //walking
			playerAnim.SetTrigger("Walk");
			playerAnim.ResetTrigger("Idle");
			walking = true;
		}
		if(Input.GetKeyUp(KeyCode.W)){
            //Stopped walking
			playerAnim.ResetTrigger("Walk");
			playerAnim.SetTrigger("Idle");
			walking = false;
		}
		if(Input.GetKeyDown(KeyCode.S)){
            //walking backwards
			playerAnim.SetTrigger("ReverseWalk");
			playerAnim.ResetTrigger("Idle");
		}
		if(Input.GetKeyUp(KeyCode.S)){
            //Stopped walking backwards
			playerAnim.ResetTrigger("ReverseWalk");
			playerAnim.SetTrigger("Idle");
		}
        //ROTATION MOVEMENT
		if(Input.GetKey(KeyCode.A)){
            //rotate left on the Y axis
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if(Input.GetKey(KeyCode.D)){
            //rotate right on the Y axis
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}
        //SPRINTING
		if(walking == true){				
			if(Input.GetKeyDown(KeyCode.LeftShift)){
                //Player sprints rather than walking
				w_speed = w_speed + rn_speed;
				playerAnim.SetTrigger("Sprint");
				playerAnim.ResetTrigger("Walk");
			}
			if(Input.GetKeyUp(KeyCode.LeftShift)){
				//Player stops sprinting and goes back to walking
				w_speed = olw_speed;
				playerAnim.ResetTrigger("Sprint");
				playerAnim.SetTrigger("Walk");
			}
		}
	}
}


