using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    private float secondsToDestroy = 10f;
    private float elapsedSecondsToDestroy;

    private void Update() {
        elapsedSecondsToDestroy += Time.deltaTime;
        if(elapsedSecondsToDestroy >= secondsToDestroy) {
            DestroyBall();
        }
    }
    private void DestroyBall() {
        Destroy(gameObject);
    }
}
