using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	GameObject splatter;
	void Start()
	{
		splatter = Resources.Load<GameObject>("Splatter");
	}
	public int health = 100;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Bullet")
		{
			Destroy(c.gameObject);
			Instantiate(splatter, c.gameObject.transform.position, Quaternion.LookRotation((c.GetComponent<Rigidbody>().velocity * -1), Vector3.up));
			GetComponent<Rigidbody>().AddForce((c.gameObject.GetComponent<Rigidbody>().velocity * 5f));
		}
	}

}
