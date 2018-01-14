using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour 
{
	public Vector3 move;
	public bool isRunning, jumped;

	public Camera mainCamera;

	private float horizontal, vertical;
	private Vector3 cameraForward;

	private void Start () 
	{
		if(mainCamera == null)
		{
			mainCamera = Camera.main;
		}
	}
	
	// Update is called once per frame
	private void Update () 
	{
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");

		isRunning = Input.GetKey(KeyCode.LeftShift);
		jumped = Input.GetKey(KeyCode.Space);

		cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
		move = vertical * cameraForward + horizontal * mainCamera.transform.right;
	}

	public bool StopWalking ()
	{
		return Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0;
	}
}