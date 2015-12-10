using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public PlayerStateMachine stateMachine;
	public Logger logger;
	
	private KeyCode walkModeKeyCode = KeyCode.LeftShift;

	// Use this for initialization
	void Start () {
		stateMachine.state = PlayerState.IDLE;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(walkModeKeyCode) && stateMachine.moveMode != MoveMode.WALK) {
			stateMachine.moveMode = MoveMode.WALK;
			logger.log("setting MoveMode.WALK");	
		} else if (!Input.GetKey(walkModeKeyCode) && stateMachine.moveMode == MoveMode.WALK) {
			logger.log("setting MoveMode.RUN");
			stateMachine.moveMode = MoveMode.RUN;	
		}
		
		float input = Input.GetAxis("Horizontal");
		
		logger.addString("input="+input);
		logger.addString("mode="+stateMachine.moveMode);
		
		if(input != 0) {
			float translationForceX = 0;
		
			if(stateMachine.moveMode == MoveMode.WALK) {
				stateMachine.state = PlayerState.WALKING;
				translationForceX = input;
			} else {
				stateMachine.state = PlayerState.RUNNING;
				translationForceX = input*10;
			}
			
			Vector2 translationForce = new Vector2(translationForceX, 0);
			
			this.gameObject.GetComponent<Rigidbody2D>().AddForce(translationForce);
		} else if(stateMachine.state != PlayerState.IDLE) {
			stateMachine.state = PlayerState.IDLE;
		}
	}
}
