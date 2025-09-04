using System.Collections.Generic;
using UnityEngine;

public class EmotionManager : MonoBehaviour
{
    public List<Emotion> emotions = new List<Emotion>
    {
        new Emotion("Joy"),
        new Emotion("Anger"),
        new Emotion("Fear"),
        new Emotion("Sadness"),
        new Emotion("Disgust")
    };

    public float GetIntensity(string emotionName)
    {
        var e = emotions.Find(em => em.Name == emotionName);
        return e != null ? e.Intensity : 0f;
    }

    public void ModifyEmotion(string emotionName, float amount)
    {
        var e = emotions.Find(em => em.Name == emotionName);
        if (e != null)
        {
            e.Intensity = Mathf.Clamp01(e.Intensity + amount);
        }
    }

    public Emotion GetStrongestEmotion()
    {
        Emotion strongest = emotions[0];
        foreach (var e in emotions)
        {
            if (e.Intensity > strongest.Intensity)
                strongest = e;
        }
        return strongest;
    }
}