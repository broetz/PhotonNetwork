﻿using System.Collections;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

	PhotonView view;

	void Start ()
	{

		// Access PhotonView component of Player and store it
		view = GetComponent <PhotonView> ();
	}

	// Update is called once per frame
	void Update ()
	{

		if (view.isMine) {

			var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f;
			var z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f;

			transform.Rotate (0, x, 0);
			transform.Translate (0, 0, z);
		}
	}
}