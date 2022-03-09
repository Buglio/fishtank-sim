using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace fishtank
{
    public class GraphManager : MonoBehaviour
    {
        [SerializeField] TankManager tankManager;

        // Graph Field PH
        [DebugGUIPrint, DebugGUIGraph(min: 0, max: 14, group: 0, r: 0, g: 0.8f, b: 0)]
        float pH;

        // Graph Field Co2
        [DebugGUIPrint, DebugGUIGraph(min: 0, max: 100, group: 1, r: 1, g: 0, b: 0)]
        float Co2;

        // Graph Field O2
        [DebugGUIPrint, DebugGUIGraph(min: 0, max: 100, group: 2, r: 0, g: 0, b: 1)]
        float O2;

        // Graph Field O2
        [DebugGUIPrint, DebugGUIGraph(min: 0, max: 1, group: 0, r: 1, g: 1, b: 1)]
        float DayCycle;

        void Start()
        {
            DebugGUI.Log("Hello! I will disappear in five seconds!");
            InvokeRepeating("UpdateGraph", 0.05f, 0.05f);
        }

        void UpdateGraph()
        {
            pH = tankManager.PH;
            Co2 = tankManager.Co2Ppm;
            O2 = tankManager.O2Ppm;
            DayCycle = Mathf.Sin(tankManager.DayCycle * Mathf.PI * 2);

            DebugGUI.Graph("Co2", Co2);
            DebugGUI.Graph("O2", O2);
            DebugGUI.Graph("pH", pH);
            DebugGUI.Graph("time", DayCycle);
        }

        void OnDestroy()
        {
            DebugGUI.RemovePersistent("pH");
        }
    }
}
