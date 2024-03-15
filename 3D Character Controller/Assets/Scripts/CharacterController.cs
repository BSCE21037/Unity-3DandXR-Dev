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

	[SerializeField] private float xRange = 45f;
	[SerializeField] private float zRange = 45f;
	
	
	void FixedUpdate(){
        //move forward
		if(Input.GetKey(KeyCode.W)){
			playerRigid.velocity = playerTrans.forward * w_speed * Time.deltaTime;
		}
        //move backward
		if(Input.GetKey(KeyCode.S)){
			playerRigid.velocity = -playerTrans.forward * wb_speed * Time.deltaTime;
		}
		if(Input.GetKey(KeyCode.A)){
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
        //move backward
		if(Input.GetKey(KeyCode.D)){
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
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
		if(Input.GetKeyDown(KeyCode.A)){
            //rotate left on the Y axis
			
			playerAnim.SetTrigger("Left");
			playerAnim.ResetTrigger("Idle");
			
		}
		if(Input.GetKeyUp(KeyCode.A)){
			//Stopped rotating left
			playerAnim.ResetTrigger("Left");
			playerAnim.SetTrigger("Idle");
		}
		if(Input.GetKeyDown(KeyCode.D)){
            //rotate right on the Y axis
			
			playerAnim.SetTrigger("Right");
			playerAnim.ResetTrigger("Idle");
			
		}
		if(Input.GetKeyUp(KeyCode.D)){
			//Stopped rotating right
			playerAnim.ResetTrigger("Right");
			playerAnim.SetTrigger("Idle");
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
		//CLAMPING
		transform.position = new Vector3(Mathf.Clamp(transform.position.x, -xRange, xRange), transform.position.y, Mathf.Clamp(transform.position.z, -zRange, zRange));
	}
}