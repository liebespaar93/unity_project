using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class ScCamera : MonoBehaviour
    {
        public GameObject player;
        public bool cameralock;

        private float _lockDelay = 0.1f;
        private float _currTime = 0.0f;
        public float cameraFar = 3.0f;
        public float rotSpeed = 500.0f;

        private Vector3 _prevPlayerPosion;
        
        // Start is called before the first frame update
        void Start()
        {
            _prevPlayerPosion = new Vector3(0, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            if (player)
            {
                _prevPlayerPosion = player.transform.position;
            }
            if (Input.GetMouseButton(0))
            {
                MouseRotation();
                cameralock = false;
            }
            if (cameralock)
            {
                CameraAutoFollow();
                return;
            }
            AutoLockCamera();
        }

        void MouseRotation()
        {
            // get mouse movemnet
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            
            this.transform.localEulerAngles += new Vector3(
                -(my * Time.deltaTime * rotSpeed), 
                (mx * Time.deltaTime * rotSpeed), 
                0);
            
            Vector3 cameraTargetPoint = _prevPlayerPosion + (this.transform.forward * -cameraFar);
            
            this.transform.position += cameraTargetPoint - this.transform.position;
        }
        
        void CameraAutoFollow()
        {
            Vector3 dir = _prevPlayerPosion - this.transform.position;
            dir.Normalize();
            // camera position
            // Vector3 cameraTargetPoint = player.transform.position + (player.transform.forward * -5);
            
            Vector3 cameraTargetPoint = _prevPlayerPosion + (dir * -cameraFar);
            if (this.transform.position.y < _prevPlayerPosion.y + 1.0f)
            {
                cameraTargetPoint.y = _prevPlayerPosion.y + 1.0f;
            }

            // cameraTargetPoint.Normalize();
            Vector3 move = (cameraTargetPoint - this.transform.position) * 0.05f;
            this.transform.position += move;

            // camera rotation
            Vector3 dirRotate = _prevPlayerPosion - this.transform.position;
            dirRotate.Normalize();
            this.transform.forward = dir;
        }

        void AutoLockCamera()
        {
            _currTime += Time.deltaTime;
            if (_currTime > _lockDelay)
            {
                _currTime = 0.0f;
                cameralock = true;
            }
        }
    }
}