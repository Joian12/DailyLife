using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Emotion_Test : MonoBehaviour
{
    [SerializeField] private CharacterEmotion _characterEmotion;
    [SerializeField] private TextMeshProUGUI _textUI;
    
    public void TriggerAnger()
    {
        _characterEmotion.ModifyEmotion(EmotionType.Anger, 0.1f);
        UpdateEmotionUI();
    }
    
    public void TriggerFear()
    {
        _characterEmotion.ModifyEmotion(EmotionType.Fear, 0.1f);
        UpdateEmotionUI();
    }
    
    public void TriggerJoy()
    {
        _characterEmotion.ModifyEmotion(EmotionType.Joy, 0.1f);
        UpdateEmotionUI();
    }
    
    private void UpdateEmotionUI()
    {
        var strongestEmotion = _characterEmotion.GetStrongestEmotion();
        
        _textUI.text = strongestEmotion.EmotionType.ToString();
    }
}
