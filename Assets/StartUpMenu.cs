using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class StartUpMenu : MonoBehaviour {

	int x_center = Screen.width/2;
	int y_center = Screen.height/2;

	string email = string.Empty;
	string password = string.Empty;

	//WWW www = null;

	void Start () {
	
	}

	void OnGUI() {
		GUI.Label (new Rect((x_center - 50), (y_center - 15) - 100, 100, 30), "Email");
		email = GUI.TextField (new Rect((x_center - 100), (y_center - 10) - 60, 200, 20), email, 40);

		GUI.Label (new Rect((x_center - 50), (y_center - 15) - 20, 100, 30), "Password");
		password = GUI.PasswordField (new Rect((x_center - 100), (y_center - 10) + 20, 200, 20), password, "*"[0], 25);

		if (GUI.Button (new Rect ((x_center - 50), (y_center - 10) + 60, 100, 20), "LOG IN")) {
			StartCoroutine(SendLoginForm());
		}
	}

	void Update () {
	
	}

	IEnumerator SendLoginForm() {
		string url = "http://104.131.35.232/api/1/auth/token";

		string form = "{\"email\": \"valkrysa@gmail.com\", \"password\": \"password\" }";
		byte[] formBytes = Encoding.ASCII.GetBytes(form.ToCharArray());

		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add("Content-Type", "application/json");

		WWW www = new WWW(url, formBytes, headers);

		yield return www;

		if (www.error != null) {
			Debug.Log("error case");
			Debug.Log("'" + www.error + "'");
		} else {
			Debug.Log("success log");
			Debug.Log(www.text);
		}
	}

}
