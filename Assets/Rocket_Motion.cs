using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Motion : MonoBehaviour
{

    [SerializeField] float rocketThrust = 400f;
    [SerializeField] float tiltSpeed = 5f;
    new Rigidbody rigidbody;
    AudioSource rocketSound;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rocketSound = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust() {
        if (Input.GetKey(KeyCode.W)) {
            rigidbody.AddRelativeForce(Vector3.up * Time.deltaTime * rocketThrust);
            if(!rocketSound.isPlaying) {
                rocketSound.Play();
            }
        }
        else {
            rocketSound.Stop();
        }
    }

    void ProcessRotation() {
        if (Input.GetKey(KeyCode.J)) {
            transform.Rotate(Vector3.left * Time.deltaTime * tiltSpeed);
        }
        else if (Input.GetKey(KeyCode.L)) {
            transform.Rotate(Vector3.right * Time.deltaTime * tiltSpeed);
        }
    }
}
