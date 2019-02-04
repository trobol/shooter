using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	GameObject breifcase;
	void Start()
	{
		breifcase = Resources.Load<GameObject>("breifcase");
	}
	float throwRot, throwTime, throwTimeMax;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.L))
		{
			Instantiate(breifcase);
		}

	}
}
