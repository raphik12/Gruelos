using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Logger : MonoBehaviour {

	public Text loggerText;

	public enum MessageLevel {
		DEBUG,
		WARNING,
		ERROR,
		DEFAULT
	}

	private string _currentMessage;
	public void addString(string message) {
		_currentMessage = string.IsNullOrEmpty(_currentMessage) ? message : _currentMessage + "\n" + message;
	}
	
	public void log(string message, MessageLevel level = MessageLevel.DEFAULT) {
		switch (level)
		{
			case MessageLevel.DEBUG:
				Debug.Log(message);
				break;
			case MessageLevel.WARNING:
				Debug.LogWarning(message);
				break;
			case MessageLevel.ERROR:
				Debug.LogError(message);
				break;
			case MessageLevel.DEFAULT:
				Debug.Log(message);
				break;
			default:
				Debug.Log(message);
				break;
		}
	}

	// Update is called once per frame
	void Update () {
		loggerText.text = _currentMessage;
		_currentMessage = null;
	}
}
