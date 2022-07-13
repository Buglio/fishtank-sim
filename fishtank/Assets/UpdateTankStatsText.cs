using TMPro;
using UnityEngine;

namespace fishtank
{
    public class UpdateTankStatsText : MonoBehaviour
    {
        private TankManager _tankManager;

        [SerializeField] private TMP_Text tankStatsTextBody;

        private void OnEnable()
        {
            _tankManager = TankManager.Instance;
        }

        private void FixedUpdate()
        {
            var hours = Mathf.FloorToInt(24 * _tankManager.DayCycle);
            var minutes = (Mathf.FloorToInt(1440 * _tankManager.DayCycle) - hours * 60).ToString();
            if (minutes.Length == 1) minutes = $"0{minutes}";
            
            var data = "";
            data += $"Day {_tankManager.Days + 1}, {hours}:{minutes}\n";
            data += $"pH: {_tankManager.PH}\n";
            data += $"Co2 ppm: {_tankManager.Co2Ppm}\n";
            data += $"o2 ppm: {_tankManager.O2Ppm}\n";
            data += $"ammonia: {_tankManager.AmmoniaPpm}\n";

            tankStatsTextBody.text = data;
        }
    }
}
