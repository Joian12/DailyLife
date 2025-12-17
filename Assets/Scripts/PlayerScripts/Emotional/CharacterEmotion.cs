using System.Collections.Generic;
using UnityEngine;

public class CharacterEmotion : MonoBehaviour
{
    private EmotionDecisionTree _characterEmotionTree;
    
    public List<Emotion> emotions = new()
    {
        new Emotion(EmotionType.Joy),
        new Emotion(EmotionType.Anger),
        new Emotion(EmotionType.Fear),
        new Emotion(EmotionType.Sadness),
        new Emotion(EmotionType.Disgust)
    };

    public void Awake()
    {
        _characterEmotionTree = new EmotionDecisionTree(emotions); // No action decision tree base on emotion yet
        _characterEmotionTree.Initialize();
    }
    
    public float GetIntensity(EmotionType emotionType)
    {
        Emotion emotion = emotions.Find(em => em.EmotionType == emotionType);
        return emotion ?.Intensity ?? 0f;
    }

    public void ModifyEmotion(EmotionType emotionType, float amount)
    {
        Emotion emotion = emotions.Find(em => em.EmotionType == emotionType);
        if (emotion != null)
        {
            emotion.Intensity = Mathf.Clamp01(emotion.Intensity + amount);
        }
    } 

    public Emotion GetStrongestEmotion()
    {
        Emotion strongest = emotions[0];
        
        foreach (var emotion in emotions)
        {
            if (emotion.Intensity > strongest.Intensity)
                strongest = emotion;
        }
        return strongest;
    }
}