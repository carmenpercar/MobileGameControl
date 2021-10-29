using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private float forceValue;
    [SerializeField] private float rotation;

    private GameObject spawnedBall;

    private void Update() {
        RotateSpawner();
        if(Input.GetButtonDown("Fire1")) {
            SpawnBall();
        }
    }
    private void SpawnBall() {
        spawnedBall = Instantiate(ball, transform.position, transform.rotation);
        spawnedBall.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
        spawnedBall.GetComponent<Rigidbody>().AddForce(transform.forward * forceValue, ForceMode.Impulse);
    }
    private void RotateSpawner() {
        transform.Rotate(0, rotation, 0);
    }
}
