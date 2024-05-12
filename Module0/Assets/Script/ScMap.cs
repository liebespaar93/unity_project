using UnityEngine;

namespace Script
{
    [System.Serializable]
    public class MapArray
    {
        public float xPosition;
        public float yPosition;

        public uint xSize;
        public uint ySize;
        public float height;
    }

    public class ScMap : MonoBehaviour
    {
        public ScFloorBlock floorBlockOrigin;

        public GameObject floorLavaOrigin;

        // Map control
        public MapArray[] mapInfo;
        private Vector2 _minSize = new Vector2(0, 0);
        private Vector2 _maxSize = new Vector2(0, 0);


        // Start is called before the first frame update
        void Start()
        {
            if (!floorBlockOrigin)
                return;
            if (mapInfo.Length > 0)
            {
                _minSize.x = mapInfo[0].xSize;
                _maxSize.x = mapInfo[0].xSize;
                _minSize.y = mapInfo[0].ySize;
                _maxSize.y = mapInfo[0].ySize;
            }

            foreach (MapArray mapObj in mapInfo)
            {
                ScFloorBlock clone = Instantiate(
                    floorBlockOrigin,
                    new Vector3(mapObj.xPosition, 0, mapObj.yPosition),
                    floorBlockOrigin.transform.rotation
                );
                clone.height = mapObj.height;
                if (mapObj.height < 1)
                    clone.height = 1;
                clone.xSize = mapObj.xSize;
                clone.ySize = mapObj.ySize;

                // Update map size
                MapSizeUpdate(mapObj.xPosition, mapObj.yPosition,
                    mapObj.xPosition + mapObj.xSize,
                    mapObj.yPosition + mapObj.ySize
                );
            }

            print("minSize : " + _minSize.y + ", " + _minSize.x + "\n maxSize : " + _maxSize.x + ", " + _maxSize.y);
            MapFloat();
        }

        void MapSizeUpdate(float minX, float minY, float maxX, float maxY)
        {
            if (minX < _minSize.x)
                _minSize.x = minX;
            if (minY < _minSize.y)
                _minSize.y = minY;
            if (maxX > _maxSize.x)
                _maxSize.x = maxX;
            if (maxY > _maxSize.y)
                _maxSize.y = maxY;
        }

        void MapFloat()
        {
            if (!floorLavaOrigin)
                return;
            float margin = 2;
            float xSize = _maxSize.x - _minSize.x + (margin * 2);
            float ySize = _maxSize.y - _minSize.y + (margin * 2);

            GameObject floorLava = Instantiate(floorLavaOrigin,
                new Vector3((xSize * 0.5f) + _minSize.x - margin, -0.5f, (ySize * 0.5f) + _minSize.y - margin),
                floorLavaOrigin.transform.rotation);
            
            floorLava.transform.localScale = new Vector3(xSize, 1.0f, ySize);
            // Material lavaMaterial = floorLava.GetComponent<Material>();
            // lavaMaterial.SetTextureScale(xSize,ySize); = new Vector2(0.1f, 0.1f);
        }

        // Update is called once per frame
        // void Update()
        // {
        // }
    }
}