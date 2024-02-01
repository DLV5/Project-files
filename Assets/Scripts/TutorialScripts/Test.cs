using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private TutorialController controller;
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            controller.ActivateTutorial();
        }
    }
}
