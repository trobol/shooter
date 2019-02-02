using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Move move = new Move();
	Rigidbody rb;
	public Camera cam;
	Vector3 camOffset;
	public float camSpeed = 1;
	public float speed = 1;
	public float rotSpeed = 1;
	Animator animator;
	public GameObject o;
	GameObject projectile;
	float stunTime;
	public bool grounded = false;
	void Start()
	{
		animator = GetComponent<Animator>();
		camOffset = cam.transform.position - transform.position;
		rb = GetComponent<Rigidbody>();
		projectile = Resources.Load<GameObject>("Projectile");
	}
	void Update()
	{
		MoveUpdate();
		if (Input.GetMouseButtonDown(1))
		{
			Shoot();
		}
	}

	void Shoot()
	{
		GameObject g = Instantiate(projectile, transform.position, Quaternion.identity);
		g.GetComponent<Rigidbody>().velocity = transform.forward * 20;

	}
	void MoveUpdate()
	{
		move.Update();
		Vector3 pos = transform.position;
		pos.y = 0;
		Plane plane = new Plane(Vector3.up, pos);
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		float distance;
		if (plane.Raycast(ray, out distance))
		{
			Vector3 hitPoint = ray.GetPoint(distance);
			o.transform.position = hitPoint;
			hitPoint.y = transform.position.y;
			transform.LookAt(hitPoint);
		}
		animator.SetFloat("speed", Mathf.Abs(move.magnitude));
		animator.SetBool("move", move.raw.magnitude != 0);


		stunTime -= Time.deltaTime;
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (grounded)
			{
				move.y = 1;
			}
		}

	}
	void LateUpdate()
	{
		Vector3 pos = transform.position + camOffset;
		pos.z = Mathf.Lerp(cam.transform.position.z, pos.z, Time.deltaTime * camSpeed);
		cam.transform.position = pos;
	}
	void FixedUpdate()
	{
		Vector3 v = rb.velocity;
		grounded = Physics.Raycast(transform.position, -Vector3.up, 0.6f);
		if (stunTime <= 0)
		{
			v.x = move.x * speed;
			v.z = move.z * speed;
		}
		if (move.y > 0)
		{
			v.y += 3f;
			move.y = 0;
		}
		rb.velocity = v;
	}
}

public class Move
{
	public float x, y, z;
	public Vector3 raw;
	public Move()
	{
		x = 0;
		y = 0;
		z = 0;
		Debug.Log("Move created");
	}
	public void Update()
	{
		x = Input.GetAxis("Horizontal");
		z = Input.GetAxis("Vertical");
		raw.x = Input.GetAxisRaw("Horizontal");
		raw.z = Input.GetAxisRaw("Vertical");
	}
	public float magnitude
	{
		get { return new Vector2(x, z).magnitude; }
	}
}