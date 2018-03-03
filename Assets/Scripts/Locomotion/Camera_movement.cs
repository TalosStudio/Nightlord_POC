using UnityEngine;

public class Camera_movement : MonoBehaviour

/* Controls the Position and Rotation of the Player 
	- the x value rotates around the player, while the y axis actually increases and decreases on the y axis and does not rotate
	- either add rotation to the y axis, or adjust center point appropriately when the camera raises
	- add the angle to center_point to keep camera on track.
*/
{
	public Transform player_cam, center_point;
	public float distance, max_height, min_height, orbiting_speed, vertical_speed;
	float height;
	Vector3 dest;
	RaycastHit hit;
	Input_Manager im;

	void Awake ()
	{
		im = GameObject.Find ("GameManager").GetComponent <Input_Manager> ();
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.lockState = CursorLockMode.Locked;
	}
	void Update () {
		center_point.position = gameObject.transform.position + new Vector3 (0, 1.5f, 0);
		center_point.eulerAngles += new Vector3 (0, im.mouseX * Time.deltaTime * orbiting_speed, 0);
		height += im.mouseY * Time.deltaTime * -vertical_speed;
		height = Mathf.Clamp (height, min_height, max_height);
	}


	void LateUpdate () {
		dest = center_point.position + center_point.forward * -1 * distance + Vector3.up * height;
		if (Physics.Linecast (center_point.position, dest, out hit)) {
			if (hit.collider.CompareTag ("Terrain")) {
				player_cam.position = hit.point + hit.normal * 0.3f;
			}
		}
		
		player_cam.position = Vector3.Lerp (player_cam.position, dest, Time.deltaTime * 3f);
		player_cam.LookAt (center_point);
	}


}

