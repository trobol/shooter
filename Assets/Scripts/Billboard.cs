﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
	//from unity forums (DaveA)
	void Update()
	{
		transform.LookAt(Camera.main.transform.position, -Vector3.up);
	}
}
