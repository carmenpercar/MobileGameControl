using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float minVelocity = 0.1f;
    [SerializeField] private float addedVelocity;
    [SerializeField] private float jumpForce = 3.0f;
    [SerializeField] private float minVerticalJump = 0.9f;
    [SerializeField] private Joystick joystickControl;
    [SerializeField] private float timeToClick = 0.1f;
    [SerializeField] private float highLimit;
    private bool canJump;
    private float clickedMoment;   
    private Rigidbody playerRigidbody;
    private Vector3 startPosition;
    private void Start() {
        playerRigidbody = GetComponent<Rigidbody>();
        canJump = true;
        startPosition = transform.position;
    }
    private void Update() {
        MoveHorizontal(joystickControl.Horizontal);
        if(joystickControl.Vertical >= minVerticalJump && canJump) {
            Jump(joystickControl.Vertical);
            canJump = false;
        }
        if(joystickControl.Vertical <= 0) {
            canJump = true;
        }
        if(Input.GetButtonDown("Fire1")) {
            clickedMoment = Time.time;
        }
        if(Input.GetButtonUp("Fire1")) {
            if(Time.time-clickedMoment <= timeToClick) {
                ChangeColor();
            }
        }
        if(transform.position.y < highLimit) {
            Reposition();
        }
    }
    private void MoveHorizontal(float x) {
        if(Mathf.Abs(x) > minVelocity) {
            playerRigidbody.velocity = new Vector3(x * addedVelocity, playerRigidbody.velocity.y, playerRigidbody.velocity.z);
        }
    }
    private void Jump(float jumpAditionalForce) {
        playerRigidbody.AddForce(new Vector3(0, jumpAditionalForce*jumpForce, 0), ForceMode.Impulse);
    }
    
    private void ChangeColor() {
        GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
    }
    
    private void Reposition() {
        playerRigidbody.isKinematic = true;
        playerRigidbody.useGravity = false;
        transform.position = startPosition;

        playerRigidbody.isKinematic = false;
        playerRigidbody.useGravity = true;

    }
}
