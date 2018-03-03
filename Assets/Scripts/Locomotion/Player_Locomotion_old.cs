using UnityEngine;

public class Player_Locomotion : MonoBehaviour 
{
	public Transform moveHelper, player;
	bool forward, backward, left, right, slow_walk, sprint;

	public int angle_to_rotate;

	float vdest, hdest;
	public float horizAxis, vertAxis;
	public float turnSpeed = 20f;
	Input_Manager im;
	public float rotationSpeed = 1f;
	Animator anim;



	void Awake ()
	{
		anim = GetComponent <Animator> ();
		im = GameObject.Find ("GameManager").GetComponent <Input_Manager> ();
	}

	void Update ()
	{


		CalculateVertAxis ();
		CalculateHorizAxis ();
		Calculate_Angle ();

		forward = im.PressedDown("Forward");
		backward = im.PressedDown("Backward");
		left = im.PressedDown("Left");
		right = im.Pressed("Right");

		if (im.PressedDown("Walk"))
			slow_walk = !slow_walk;
		if (im.Pressed ("Sprint"))
			sprint = true;
		else
			sprint = false;
		
		anim.SetBool ("sprint", sprint);
		anim.SetBool ("slow_walk", slow_walk);
		anim.SetFloat ("movement", Mathf.Max (vertAxis, horizAxis));
		anim.SetFloat ("angle", (angle_to_rotate));
	}
	void Calculate_Angle ()
	{	
		if (forward && !backward) 
		{
			if (left && !right) 
			{
				moveHelper.position = player.position + player.forward * 1 + player.right * -1;
				angle_to_rotate = -45;
			} 
			else if (!left && right) {
				moveHelper.position = player.position + player.forward * 1 + player.right * 1;
				angle_to_rotate = 45;
			} 
			else 
			{
				moveHelper.position = player.position + player.forward * 1.5f;
				angle_to_rotate = 0;
			}

		}

		else if (!forward && backward) 
		{
			if (left && !right) 
			{
				moveHelper.position = player.position + player.forward * -1 + player.right * -1;
				angle_to_rotate = -135;
				storeMoveHelper ();
			} 
			else if (!left && right) {
				moveHelper.position = player.position + player.forward * -1 + player.right * 1;
				angle_to_rotate = 135;
				storeMoveHelper ();

			} 
			else 
			{
				moveHelper.position = player.position + player.forward * -1.5f;
				angle_to_rotate = 180;
				storeMoveHelper ();

			}

		} 
		else 
		{
			if (left && !right) 
			{
				moveHelper.position = player.position + player.right * -1.5f;
				angle_to_rotate = -90;
				storeMoveHelper ();

			} 
			else if (right && !left)
 			{				
				moveHelper.position = player.position + player.right * 1.5f;
				angle_to_rotate = 90;
				storeMoveHelper ();

			}
			else
			{
				moveHelper.position = player.position + player.forward * 1.5f;
				angle_to_rotate = 0;
				storeMoveHelper ();

			}
		}
	}
	void CalculateVertAxis ()
	{
		if (im.Pressed ("Forward") ^ im.Pressed ("Backward"))
			vdest = 1;
		else
			vdest = 0;
		if (vdest == 1 && Mathf.Abs (vertAxis - 1 )<= 0.01f)
			vertAxis = 1;
		else if (vdest == 0 && Mathf.Abs (vertAxis )<= 0.01f)
			vertAxis = 0;
		else
			vertAxis = Mathf.Lerp (vertAxis, vdest, Time.deltaTime * 3);	
	}
	void CalculateHorizAxis ()
	{
		if (im.Pressed ("Left") ^ im.Pressed ("Right"))
			hdest = 1;
		else
			hdest = 0;
		if (hdest == 1 && Mathf.Abs (horizAxis - 1 )<= 0.01f)
			vertAxis = 1;
		else if (hdest == 0 && Mathf.Abs (horizAxis )<= 0.01f)
			horizAxis = 0;
		else
			horizAxis = Mathf.Lerp (horizAxis, hdest, Time.deltaTime * 3);
	}
	void storeMoveHelper ()
	{
		if (anim.GetFloat("movement") < .3f)
			{
				moveHelper.position = player.position + player.forward * 1.5f;
			}
	}
}
