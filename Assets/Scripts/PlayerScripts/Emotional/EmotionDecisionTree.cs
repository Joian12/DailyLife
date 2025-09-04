using System.Collections.Generic;
using UnityEngine;

public class EmotionDecisionTree 
{
    private List<EmotionNode> nodes = new List<EmotionNode>();
    private List<Emotion> _emotions;
    private float _emotionalThreshold = 0.3f; 

    public EmotionDecisionTree(List<Emotion> emotions) {
        _emotions = emotions;
    }

    public void Initialize()
    {
        //Can be scriptables hehe and we dont need this. 
        var emotionRules = new (string name, float threshold, System.Action<float> action)[]
        {
            ("Anger",   _emotionalThreshold, w => Debug.Log($"NPC attacks with strength {w}!")),
            ("Fear",    _emotionalThreshold, w => Debug.Log($"NPC avoids with caution {w}!")),
            ("Joy",     _emotionalThreshold, w => Debug.Log($"NPC helps with enthusiasm {w}!")),
            ("Sadness", _emotionalThreshold, w => Debug.Log($"NPC ignores with gloom {w}!")),
            ("Disgust", _emotionalThreshold, w => Debug.Log($"NPC is disgusted {w}!"))
        };

        // Build nodes from rules
        foreach (var (name, threshold, action) in emotionRules)
        {
            var emotion = _emotions.Find(e => e.Name == name);
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

        if (!reacted)
            Debug.Log("NPC has no strong emotional reaction.");
    }
}