using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

	bool triggerDown;
	float triggerTime = 0;
	public float chargeTime = 2f;
	public int bulletCount = 5;
	public float maxSpread = 15f;
	public GameObject indicatorL, indicatorR;
	GameObject bullet;
	public GameObject gun;
	float reloadTime = 0;
	void Start()
	{
		bullet = Resources.Load<GameObject>("Bullet");
	}
	void Update()
	{
		if (triggerTime < chargeTime)
		{
			if (Input.GetMouseButtonDown(0))
			{
				indicatorL.SetActive(true);
				indicatorR.SetActive(true);
			}
			if (Input.GetMouseButtonUp(0))
			{
				Shoot();
				triggerTime = 0;
			}
			if (Input.GetMouseButton(0))
			{
				triggerTime += Time.deltaTime;
			}
		}
		else
		{
			Shoot();
		}
		RenderIndicators();
	}
	void Shoot()
	{

		indicatorL.SetActive(false);
		indicatorR.SetActive(false);
		for (int i = 0; i < bulletCount; i++)
		{
			Quaternion rot = gun.transform.rotation * Quaternion.Euler(0, ((((float)i / (float)bulletCount) * 2f) - 1f) * (maxSpread - (maxSpread * (triggerTime / chargeTime))), 0);
			rot.x = 0;
			rot.z = 0;
			GameObject g = Instantiate(bullet, gun.transform.position + (gun.transform.forward), rot);
			g.GetComponent<Rigidbody>().velocity = g.transform.forward * 20;
			Destroy(g, 1);
		}
		triggerTime = 0;
	}
	void RenderIndicators()
	{

		float angle = maxSpread - (maxSpread * (triggerTime / chargeTime));
		indicatorL.transform.localEulerAngles = new Vector3(90, 0, angle);
		indicatorR.transform.localEulerAngles = new Vector3(90, 0, -angle);
	}

}
