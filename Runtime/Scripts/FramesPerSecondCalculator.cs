using UnityEngine;
using UnityEngine.UI;

namespace CodeLibrary24.PerformanceMeasurement
{
    public class FramesPerSecondCalculator : MonoBehaviour
    {
        [SerializeField]
        private float updateInterval = 1.0f;

        [SerializeField]
        private Text fpsText;
        private float _accum = 0.0f;
        private int _frames = 0;
        private float _timeLeft;

        private void Start()
        {
            _timeLeft = updateInterval;
        }

        private void Update()
        {
            _timeLeft -= Time.deltaTime;
            _accum += Time.timeScale / Time.deltaTime;
            ++_frames;

            if (_timeLeft <= 0.0f)
            {
                float fps = _accum / _frames;
                fpsText.text = "FPS: " + Mathf.RoundToInt(fps);

                _timeLeft = updateInterval;
                _accum = 0.0f;
                _frames = 0;
            }
        }
    }
}
