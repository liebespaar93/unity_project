using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Script
{
    public class ScFloorBlock : MonoBehaviour
    {
        public float xPosition = 0;
        public float yPosition = 0;

        public float height = 1;
        public uint xSize = 1;
        public uint ySize = 1;

        // Start is called before the first frame update
        void Start()
        {
            // setting Block size && position point by object position
            this.gameObject.transform.localScale = new Vector3(xSize, height, ySize);
            this.gameObject.transform.position +=
                new Vector3((xSize * 0.5f) + xPosition, height * 0.5f, (ySize * 0.5f) + yPosition);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}