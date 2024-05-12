using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class PlayerController : MonoBehaviour
    {
        public GameObject playerCamera;
        public float speed = 3.0f;
        public float jumpPower = 1.0f;
        private float _currTime;
        private bool _delayJump;
        private Rigidbody _rigidBody;

        // Start is called before the first frame update
        void Start()
        {
            _rigidBody = this.GetComponent<Rigidbody>();
            _delayJump = true;
        }

        // Update is called once per frame
        void Update()
        {
            _currTime += Time.deltaTime;
            if (Input.GetButton("Horizontal"))
            {
                // Vector3 move = this.transform.right * (speed * Time.deltaTime);
                Vector3 move = this.transform.right * (speed * Time.deltaTime);
                this.transform.position += move * Input.GetAxis("Horizontal");
            }

            if (Input.GetButton("Vertical"))
            {
                // Vector3 move = this.transform.forward * (speed * Time.deltaTime);
                Vector3 move = this.transform.forward * (speed * Time.deltaTime);
                this.transform.position += move * Input.GetAxis("Vertical");
            }

            if (Input.GetButtonDown("Jump") && _delayJump)
            {
                _rigidBody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
                _delayJump = false;
            }

            if (!_delayJump && _rigidBody && Math.Abs(_rigidBody.velocity.y) <= 0.01f)
            {
                _delayJump = true;
            }

            this.transform.forward = new Vector3(
                playerCamera.transform.forward.x,
                0,
                playerCamera.transform.forward.z
            );
        }
    }
}