using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour {

	[SerializeField]
	private float speed;
	[SerializeField]
	private float gravity;
	[SerializeField]
	private float jumpPower;
	private Vector3 moveDirection;
	private CharacterController player;
[SerializeField]
	private float xMov;
	[SerializeField]
	private float zMov;
	[SerializeField]
	private Ray ray;
	private RaycastHit hit;
	[SerializeField]
	private float raydistance=2f;


	// Use this for initialization
	void Start () {
		player = GetComponent<CharacterController>();
		gravity=1f;
		speed=3f;
		jumpPower=0.8f;
	}
	
	// Update is called once per frame
	void Update () {
		Move();
	}

	private void Move()
	{
		xMov=Input.GetAxis("LeftRight");
		zMov=Input.GetAxis("ForwardBack");
		if(player.isGrounded)
		{
			gravity=0.1f;
			moveDirection = new Vector3(xMov, 0f,zMov);
			moveDirection=transform.TransformDirection(moveDirection)*speed;
			if(Input.GetAxis("Run")==1)
			{	speed=7f;	jumpPower=1f;}
			else
			{	speed=3f;	jumpPower=0.8f;}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				gravity=-(jumpPower);
			}

		}
		else if(!player.isGrounded)
		{
			gravity+=0.12f;
			
		}
		moveDirection.y-=gravity;
		
		
		player.Move(moveDirection*Time.fixedDeltaTime);			//Рух
	}
	private void Use()
	{
		//Запуск променя для відстежування об'єкту
		ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width/2, Screen.height/2));   
		if(Physics.Raycast(ray, out hit, raydistance))													//Якщо промінь відбився від колайдеру
		{
		
		}
	}

}
