using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace fishtank
{
    public class Graph : MonoBehaviour
    {
        public TankManager tankManager;
        public float yMaximum = 32f;
        public float yMinimum = 28f;
        public float xOffset = 7f;
        public int maxValues = 20;

        private RectTransform graphContainer;
        private List<float> data = new List<float>();

        private void Start()
        {
            InvokeRepeating(nameof(UpdateGraph), 3f, 1f);
        }
        private void UpdateGraph() 
        {
            Debug.Log("Update Graph!");
            data.Add(tankManager.Co2Ppm);
            while (data.Count > maxValues)
            {
                data.RemoveAt(0);
            }
            graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
            foreach(Transform child in graphContainer.transform) GameObject.Destroy(child.gameObject);
            ShowGraph(data);        
        }
        
        private void ShowGraph(List<float> ValueList)
        {
            float graphHeight = graphContainer.sizeDelta.y;
            float graphWidth = graphContainer.sizeDelta.x;
            Vector2 LastPoint = new Vector2(-1,-1);
            for (int i = 0; i < ValueList.Count; i++)
            {
                float xPosition = xOffset + i * graphWidth / maxValues;
                float adjValue = Remap(yMinimum, yMaximum, 0f, graphHeight, ValueList[i]);
                float yPosition = adjValue;
                Vector2 CurrentPoint = new Vector2(xPosition,yPosition);
                // Create line
                if (LastPoint != new Vector2(-1,-1)) {
                    CreateLine(LastPoint, CurrentPoint);
                }
                LastPoint = CurrentPoint;
            }
        }

        private void CreateLine(Vector2 dotPositionA, Vector2 dotPositionB)
        {
            GameObject gameObject = new GameObject("dotConnection", typeof(Image));
            gameObject.transform.SetParent(graphContainer, false);
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
