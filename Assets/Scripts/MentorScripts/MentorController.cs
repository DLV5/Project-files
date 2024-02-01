using System.Collections.Generic;
using UnityEngine;

public class MentorController : MonoBehaviour
{
    [SerializeField] private List<string> _mentorSpeech = new List<string>();
    [SerializeField] private string _mentorName;
    [SerializeField] private Sprite _mentorSprite;
    private void Start()
    {
        VisualMentor.Instance.SetNewMentor(_mentorSprite, _mentorName);
        VisualMentor.Instance.GivePlayerInstructions(_mentorSpeech);
    }
}
