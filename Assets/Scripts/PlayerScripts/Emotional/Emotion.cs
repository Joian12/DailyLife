using UnityEngine;

[System.Serializable]
public class Emotion
{
    public EmotionType EmotionType;
    [Range(0f, 1f)] public float Intensity;

    public Emotion(EmotionType emotionType, float intensity = 0f)
    {
        EmotionType = emotionType;
        Intensity = intensity;
    }
}

public enum EmotionType
{
    Default,
    Anger,
    Fear, 
    Sadness,
    Joy,
    Disgust,
}