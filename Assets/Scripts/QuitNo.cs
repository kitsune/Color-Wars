using UnityEngine;
using System.Collections;

public class QuitNo : MonoBehaviour {

	public GameObject confirmBox;

	public void OnClick() {
		confirmBox.SetActive (false);
		Debug.Log ("test");
	}
}
