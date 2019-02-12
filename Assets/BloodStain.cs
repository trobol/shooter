using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodStain : MonoBehaviour
{
	public int maxStains;
	GameObject stain;
	ParticleSystem part;
	List<ParticleCollisionEvent> collisionEvents;
	GameObject[] stainList;
	void Awake()
	{
		stain = Resources.Load<GameObject>("BloodStain");
		part = GetComponent<ParticleSystem>();
		collisionEvents = new List<ParticleCollisionEvent>();

	}

	void OnParticleCollision(GameObject c)
	{
		part.GetCollisionEvents(c, collisionEvents);
		foreach (ParticleCollisionEvent e in collisionEvents)
		{

			Vector3 p = e.intersection;
			p.y = 0.01f;
			Debug.Log(LayerMask.NameToLayer("BloodStain"));
			GameObject[] objects = GameObject.FindGameObjectsWithTag("bloodstain");
			foreach (GameObject go in objects)
			{
				float distanceSqr = (p - go.transform.position).sqrMagnitude;
				if (distanceSqr < 0.5)
					Destroy(go);
			}
			GameObject s = Instantiate(stain, p, stain.transform.rotation);
			s.transform.localScale = new Vector3(Random.Range(1f, 3f) * (1 + objects.Length * 0.1f), Random.Range(1f, 3f) * (1 + objects.Length * 0.1f), 1);
			s.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0.5f, 1f), 0, 0);

		}
	}
}
