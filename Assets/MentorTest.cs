using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MentorTest : MonoBehaviour
{
    [SerializeField] public Sprite sprite;
    [SerializeField] public string _name;
    [SerializeField] public Sprite sprite2;
    [SerializeField] public string _2name;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            VisualMentor.Instance.SetNewMentor(sprite,_name);
            VisualMentor.Instance.GivePlayerInstructions("Hello boys and girls! Welcome!");
        }
        if (Input.GetKeyUp(KeyCode.O))
        {
            VisualMentor.Instance.SetNewMentor(sprite2, _2name);
            List<string> miafrases = new List<string> { "Are you rrready kids!" , "Cause I am ready!", "Let's go!", "One more frase" };
            VisualMentor.Instance.GivePlayerInstructions(miafrases);
        }
    }
}
