using Synthic.Native.Buffers;
using Synthic.Native.Data;
using Unity.Burst;
using Unity.Mathematics;
using UnityEngine;
using TMPro;

namespace Synthic
{
    [BurstCompile]
    public class SquareModulated : SynthProvider
    {
        [SerializeField, Range(0, 1)] private float amplitude = 0.5f;
        [SerializeField, Range(16.35f, 7902.13f)]private float fundamental = 50.0f;
        private float frequency = 50.0f;
        private float offset = 0.0f;
        private float amplitude_ = 0.0f;
        Vector3 pos = Vector3.zero;
        Vector3 lastPos = Vector3.zero;
        Vector3 lastPartialPos = Vector3.zero;
        private int state = 0;
        public TMP_Text display;
        private float ratio = 0.0f;


        private static BurstSineDelegate _burstSine;

        private double _phase;
        private int _sampleRate;

        private void Awake()
        {
            _sampleRate = AudioSettings.outputSampleRate;
            _burstSine ??= BurstCompiler.CompileFunctionPointer<BurstSineDelegate>(BurstSine).Invoke;
        }

        protected override void ProcessBuffer(ref SynthBuffer buffer)
        {
            _phase = _burstSine(ref buffer, _phase, _sampleRate, amplitude_, (frequency + offset));
        }

        private delegate double BurstSineDelegate(ref SynthBuffer buffer,
            double phase, int sampleRate, float amplitude_, float frequency);

        [BurstCompile]
        private static double BurstSine(ref SynthBuffer buffer,
            double phase, int sampleRate, float amplitude_, float frequency)
        {
            // calculate how much the phase should change after each sample
            double phaseIncrement = frequency / sampleRate;

            for (int sample = 0; sample < buffer.Length; sample++)
            {
                // calculate and set buffer sample
                buffer[sample] = new StereoData(Mathf.Sign((float) (math.sin(phase * 2 * math.PI))) * amplitude_);

                // increment _phase value for next iteration
                phase = (phase + phaseIncrement) % 1;
            }

            // return the updated phase
            return phase;
        }


        void Update()
        {
            pos = this.transform.position;
            offset = Vector3.Distance(pos, Vector3.zero);
            offset /= 50.0f;
            offset = Mathf.Pow(offset, 3);
            if (offset < 0.01f) offset = 0.0f;
            ratio = 1.0f + offset;
            frequency = fundamental + fundamental * (ratio);
            Debug.Log("Frequency: " + frequency.ToString());
            if(pos != lastPos) {
                display.text = "";
                amplitude_ = Mathf.Lerp(amplitude_, 0.0f, 0.01f);
            } else {
                amplitude_ = Mathf.Lerp(amplitude_, amplitude, 0.001f);
                string text = getRatio().ToString();
                text = text.Substring(0, Mathf.Min(5, text.Length));
                display.text = text;
                display.color = Color.Lerp(Color.white, Color.black, amplitude_);
            }
            lastPos = pos;
        }

        public float getRatio() {
            return ratio;
        }

        public void updateState(int state_) {
            state = state_;
            Debug.Log("State changed to " + state);
            lastPartialPos = pos;
            Debug.Log("New partial at: " + lastPartialPos.ToString());
        }
    }
}