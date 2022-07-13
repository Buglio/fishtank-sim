using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace fishtank
{
    public class Graph : MonoBehaviour
    {
        [SerializeField] private TankManager tankManager;
        [SerializeField] private TankStat statToDisplay;
        //[SerializeField] private float yMaximum = 32f;
        //[SerializeField] private float yMinimum = 28f;
        [SerializeField] private int maxValues = 20;

        public float yMinDefault = 28f;
        public float yMaxDefault = 32f;

        private RectTransform _graphContainer;
        private List<float> _data = new List<float>();

        private void Start()
        {
            InvokeRepeating(nameof(UpdateGraph), 3f, .25f);
        }
        
        private void UpdateGraph()
        {
            Debug.Log("Update Graph!");
            
            switch (statToDisplay)
            {
                case TankStat.Co2Ppm:
                    _data.Add(tankManager.Co2Ppm);
                    break;
                case TankStat.O2Ppm:
                    _data.Add(tankManager.O2Ppm);
                    break;
                case TankStat.AmmoniaPpm:
                    _data.Add(tankManager.AmmoniaPpm);
                    break;
                case TankStat.PH:
                    _data.Add(tankManager.PH);
                    print(tankManager.PH);
                    break;
                case TankStat.TempK:
                    _data.Add(tankManager.TempK);
                    break;
                case TankStat.FoodMG:
                    _data.Add(tankManager.FoodMG);
                    break;
            }

            while (_data.Count > maxValues)
            {
                _data.RemoveAt(0);
            }
            _graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
            foreach(Transform child in _graphContainer.transform) GameObject.Destroy(child.gameObject);
            ShowGraph(_data);        
        }
        
        private void ShowGraph(List<float> valueList)
        {
            // Find the min and max values in the data list
            float yMin = Mathf.Min(_data.ToArray());
            float yMax = Mathf.Max(_data.ToArray());
            
            // Only use the new yMin and yMax if they are outside the default range.
            //if (yMin > yMinDefault) yMin = yMinDefault;
            //if (yMax < yMaxDefault) yMax = yMaxDefault;
            
            var yBuffer = (yMax - yMin) * .1f;
            yMin -= yBuffer;
            yMax += yBuffer;

            if (yMin == yMax)
            {
                var val = yMin;
                yMax = val + .01f;
                yMin = val - .01f;
            }
            
            float graphHeight = _graphContainer.sizeDelta.y;
            float graphWidth = _graphContainer.sizeDelta.x;
            Vector2 lastPoint = new Vector2(-1,-1);
            for (int i = 0; i < valueList.Count; i++)
            {
                // the graph should take up 90% of the total width
                var xWidth = graphWidth / maxValues * 0.9f;
                // The x offset should be 5% of the total width of the graph
                var xOffset = graphWidth * .05f;
                float xPosition = xOffset + i * xWidth;
                float adjValue = Remap(yMin, yMax, 0f, graphHeight, valueList[i]);
                float yPosition = adjValue;
                Vector2 currentPoint = new Vector2(xPosition,yPosition);
                // Create line
                if (lastPoint != new Vector2(-1,-1)) {
                    CreateLine(lastPoint, currentPoint);
                }
                lastPoint = currentPoint;
            }
        }

        private void CreateLine(Vector2 dotPositionA, Vector2 dotPositionB)
        {
            GameObject gameObject = new GameObject("dotConnection", typeof(Image));
            gameObject.transform.SetParent(_graphContainer, false);
            gameObject.GetComponent<Image>().color = new Color(1,1,1,1);
            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            Vector2 dir = (dotPositionB - dotPositionA).normalized;
            float distance = Vector2.Distance(dotPositionA,dotPositionB);
            rectTransform.anchorMin = new Vector2 (0,0);
            rectTransform.anchorMax = new Vector2 (0,0);
            rectTransform.sizeDelta = new Vector2 (distance, 3f);
            rectTransform.anchoredPosition = dotPositionA + dir * distance * 0.5f;
            rectTransform.localEulerAngles = new Vector3(0,0, GetAngleFromVectorFloat(dir));
        }

        public static float GetAngleFromVectorFloat(Vector3 dir) {
            dir = dir.normalized;
            float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }
        float Lerp( float a, float b, float t)
        {
            return (1.0f - t ) * a + b * t;
        }
        float InvLerp( float a, float b, float v)
        {
            return ( v - a ) / ( b - a );
        }
        float Remap( float iMin, float iMax, float oMin, float oMax, float v){
            float t = InvLerp(iMin, iMax, v);
            return Lerp( oMin, oMax, t );
        }

    }
}
