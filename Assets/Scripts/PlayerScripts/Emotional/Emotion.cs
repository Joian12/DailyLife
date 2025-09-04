using UnityEngine;

[System.Serializable]
public class Emotion
{
    public string Name;
    [Range(0f, 1f)] public float Intensity;

    public Emotion(string name, float intensity = 0f)
    {
        Name = name;
        Intensity = intensity;
    }
}