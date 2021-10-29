using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float smoothValue = 0.5f;

    private void Update() {
        FollowPlayer();
    }
    private void FollowPlayer() {
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, player.transform.position.x, smoothValue), transform.position.y, transform.position.z);
    }
}
