using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//font from: https://www.dafont.com/upheaval.font
public class HeathController : MonoBehaviour {

	public GameObject numE, anchor;

	public GameObject dmgE;
	public int currentValue;

	void Start()
	{
		dmgE = Resources.Load<GameObject>("dmg");
	}

	public void SetHealth(int val) {

	}
	public void Dmg(int val) {

	}
	[ContextMenu("Dmg")]
	public void Dmg() {
		Plane plane = new Plane(Vector3.up, Vector3.up * 3);
		Ray ray = Camera.main.ScreenPointToRay(anchor.transform.position);
		float distance;
		if (plane.Raycast(ray, out distance))
		{
			Vector3 hitPoint = ray.GetPoint(distance);
			Instantiate(dmgE, hitPoint, Quaternion.identity);
		}
		
	}
}
