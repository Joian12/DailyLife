using System.Collections.Generic;
using UnityEngine;


public class EmotionDecisionTree 
{
    private List<EmotionNode> nodes = new List<EmotionNode>();
    private List<Emotion> _emotions;
    private float _emotionalThreshold = 0.5f; 

    public EmotionDecisionTree(List<Emotion> emotions) {
        _emotions = emotions;
    }

    public void Initialize()
    {
        //Can be scriptables hehe and we dont need this. 
        var emotionRules = new (EmotionType type, float threshold, System.Action<float> action)[]
        {
            (EmotionType.Anger,   _emotionalThreshold, w => Debug.Log($"NPC attacks with strength {w}!")),
            (EmotionType.Fear,    _emotionalThreshold, w => Debug.Log($"NPC avoids with caution {w}!")),
            (EmotionType.Joy,     _emotionalThreshold, w => Debug.Log($"NPC helps with enthusiasm {w}!")),
            (EmotionType.Sadness, _emotionalThreshold, w => Debug.Log($"NPC ignores with gloom {w}!")),
            (EmotionType.Disgust, _emotionalThreshold, w => Debug.Log($"NPC is disgusted {w}!"))
        };

        // Build nodes from rules
        foreach (var (type, threshold, action) in emotionRules)
        {
            var emotion = _emotions.Find(e => e.EmotionType == type);
            if (emotion != null)
                nodes.Add(new EmotionNode(emotion, threshold, action));
        }
    }

    public void EvaluateDecision()
    {
        bool reacted = false;

        foreach (var node in nodes)
        {
            float weight = node.Evaluate();
            if (weight > 0f)
            {
                node.Invoke(weight);
                reacted = true;
            }
        }

        if (reacted == false)
            Debug.Log("NPC has no strong emotional reaction.");
    }
}