using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	GameObject splatter, briefcase;
	public GameObject shootpoint;
	float walkTime = 0;
	Rigidbody rb;
	void Start()
	{
		splatter = Resources.Load<GameObject>("Splatter");
		rb = GetComponent<Rigidbody>();
	}
	void Update()
	{
		if (walkTime > 0)
		{

		}
	}
	public int health = 100;

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag == "Bullet")
		{
			Destroy(c.gameObject);
			Instantiate(splatter, c.gameObject.transform.position, Quaternion.LookRotation((c.GetComponent<Rigidbody>().velocity * -1), Vector3.up));
			GetComponent<Rigidbody>().AddForce((c.gameObject.GetComponent<Rigidbody>().velocity * 5f));
			health -= 10;
			if (health <= 0)
			{
				Dead();
			}
		}
	}
	void Dead()
	{
		rb.constraints = RigidbodyConstraints.None;
	}
	void Shoot()
	{
		Instantiate(briefcase, shootpoint.transform);
	}
}
