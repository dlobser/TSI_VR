using UnityEngine;
using UnityEditor;

public class AudioToneGenerator : MonoBehaviour
{
    // Generates a sine wave tone
    public static float[] GenerateToneData(float frequency, float duration, int sampleRate)
    {
        int sampleCount = (int)(duration * sampleRate);
        float[] data = new float[sampleCount];
        float increment = frequency * 2f * Mathf.PI / sampleRate;

        for (int i = 0; i < sampleCount; i++)
        {
            data[i] = Mathf.Sin(i * increment);
        }

        return data;
    }

    // Creates an AudioClip and saves it as an asset
    [MenuItem("Assets/Create/Tone AudioClip")]
    public static void CreateToneAudioClip()
    {
        float frequency = 440f; // Frequency in Hertz (A4 note)
        float duration = 2f; // Duration in seconds
        int sampleRate = 44100; // Sample rate in samples per second

        float[] toneData = GenerateToneData(frequency, duration, sampleRate);
        AudioClip toneClip = AudioClip.Create("Tone", toneData.Length, 1, sampleRate, false);
        toneClip.SetData(toneData, 0);

        // Save the AudioClip as an asset
        AssetDatabase.CreateAsset(toneClip, "Assets/ToneClip.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();
        Selection.activeObject = toneClip;
    }
}
