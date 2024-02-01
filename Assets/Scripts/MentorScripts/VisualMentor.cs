using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualMentor: MonoBehaviour
{
    public static VisualMentor Instance { get; private set; } 
    [SerializeField] private Image _mentorImage;
    [SerializeField] private TMP_Text _speechTextField;
    [SerializeField] private TMP_Text _nameTextField;

    private string _mentorName;

    private WaitForSeconds _waitUntilNextChar = new WaitForSeconds(0.05f);
    private WaitForSeconds _waitAfterEnd = new WaitForSeconds(4f);

    bool _isTexting = false;  //Prevents multiple GivePlayerInstructions methods from being called simultaneously

    private void Awake()
    {
        Debug.Log("VisualMentor awaked");
        if(Instance != null && Instance != this)
        {
            Destroy(Instance);
        } else
        {
            Instance = this;
        }
    }
    public void SetNewMentor(Sprite skin, string name)
    {
        _mentorImage.sprite = skin;
        _mentorName = name;
        _nameTextField.text = _mentorName;
    }

    /// <summary>
    /// Shows the mentor then types the instructions received as a parameter
    /// </summary>
    /// <param name="instruction"></param>
    public void GivePlayerInstructions(string instruction)
    {
        ShowMentor();
        StartCoroutine(TypeText(instruction));
    }
    /// <summary>
    /// Shows the mentor and types the instructions received as a parameter
    /// </summary>
    /// <param name="allInstructions"></param>
    public void GivePlayerInstructions(List<string> allInstructions)
    {
        ShowMentor();
        StartCoroutine(TypeText(allInstructions));
    }

    /// <summary>
    /// Typing text of the instruction by simbols
    /// </summary>
    /// <param name="instruction"></param>
    /// <returns></returns>
    private IEnumerator TypeText(string instruction)
    {
        if (_isTexting)
            yield break;

        _isTexting = true;
        _speechTextField.text = "";
        for (int i = 0; i < instruction.Length; i++)
        {
            _speechTextField.text += instruction[i];
            yield return _waitUntilNextChar;
        }
        yield return _waitAfterEnd;
        HideMentor();
        _isTexting = false;
    }
    /// <summary>
    /// Typing text of the instructions by simbols
    /// </summary>
    /// <param name="allInstructions"></param>
    /// <returns></returns>
    private IEnumerator TypeText(List<string> allInstructions)
    {
        if (_isTexting)
            yield break;

        for (int i = 0; i < allInstructions.Count; i++)
        {
            _isTexting = true;
            _speechTextField.text = "";
            for (int b = 0; b < allInstructions[i].Length; b++)
            {
                _speechTextField.text += allInstructions[i][b];
                yield return _waitUntilNextChar;
            }
            yield return _waitAfterEnd;
            _isTexting = false;
        }
        HideMentor();
    }
    private void ShowMentor()
    {
        gameObject.SetActive(true);
    }
    private void HideMentor()
    {
        gameObject.SetActive(false);
    }
}
