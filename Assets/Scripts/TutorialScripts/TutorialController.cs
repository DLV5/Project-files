using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    [SerializeField] private GameObject _tutorial;
    private bool _isTutorialActivated = false;
    public void ActivateTutorial()
    {
        if(_isTutorialActivated) 
            return;
        _tutorial.SetActive(true);
        _isTutorialActivated = true;
    }
    private void Update()
    {
        if (!_isTutorialActivated)
            return;
        if (Input.anyKeyDown)
        {
            _isTutorialActivated = false;
            _tutorial.SetActive(false);
        }
    }
}
