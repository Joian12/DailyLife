public class EmotionNode
{
    private Emotion emotion;
    private float threshold;
    private System.Action<float> action;

    public EmotionNode(Emotion emotion, float threshold, System.Action<float> action)
    {
        this.emotion = emotion;
        this.threshold = threshold;
        this.action = action;
    }

    public float Evaluate()
    {
        return emotion.Intensity >= threshold ? emotion.Intensity : 0f;
    }

    public void Invoke(float weight)
    {
        action?.Invoke(weight);
    }
}