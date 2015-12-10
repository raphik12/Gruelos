using UnityEngine;
using System.Collections;

public enum PlayerState {
	IDLE,
	RUNNING,
	WALKING,
	DEFAULT
}

public enum MoveMode {
	RUN,
	WALK
}
	
public class PlayerStateMachine : MonoBehaviour {
	
	public Logger logger;
	
	public PlayerState state;
	
	private MoveMode _moveMode;
	public MoveMode moveMode {
		get {
			return _moveMode;
		}
		set {
			_moveMode = value;	
		}
	}
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		logger.addString("state="+state);
	}
}
