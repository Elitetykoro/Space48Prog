using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Text : MonoBehaviour
{
    [SerializeField] private TMP_Text introductionField;
    [SerializeField] private TMP_Text messageField;

    void Start()
    {
        StartCoroutine(Introduction());
    }
    IEnumerator Introduction()
    {
        StartCoroutine(ShowMessage("Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.", 5f));
        yield break;
    }
    public IEnumerator ShowMessage(string message , float time)
    {
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(time);
        messageField.enabled = false;
    }
}
