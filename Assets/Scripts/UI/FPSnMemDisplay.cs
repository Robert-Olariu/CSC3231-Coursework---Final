using System.Text;
using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;

public class FPSnMemDisplay : MonoBehaviour
{
    string statsText;
    ProfilerRecorder systemUsedMemory;
    public Text averageFPS;
    int framesPassed = 0;
    float fpsTotal = 0f;

    void OnEnable()
    {
        systemUsedMemory = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "System Used Memory");
    }

    void OnDisable()
    {
        systemUsedMemory.Dispose();
    }


    void Update()
    {
        float fps = (int)1 / Time.unscaledDeltaTime;
        fpsTotal += fps;
        framesPassed++;

        var sb = new StringBuilder(500);
            if (systemUsedMemory.Valid)
            {
                sb.AppendLine($"System Used Memory:{systemUsedMemory.LastValue / 1024 / 1024}MB");
            }
                sb.AppendLine($"FPS Average:{ Mathf.RoundToInt(fpsTotal / framesPassed)}");

        statsText = sb.ToString();
    }

    void OnGUI()
    {
        GUI.TextArea(new Rect(10, 10, 200, 40), statsText);
    }
}