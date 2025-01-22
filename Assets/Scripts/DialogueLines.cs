using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogueText;

    int currentLine = 0;
    public void NextDialogueLine()
    {
        if (currentLine < timelineTextLines.Length - 1)
        {
            currentLine++;
            dialogueText.text = timelineTextLines[currentLine];
        }
        else
        {
            currentLine = 0;
        }
            
    }
}
