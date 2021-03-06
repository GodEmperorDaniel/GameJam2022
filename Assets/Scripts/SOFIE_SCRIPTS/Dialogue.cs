using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float textSpeed;
    public List<TextAndCharacter> dialogueForBoth = new List<TextAndCharacter>();
    public Vector3 MortBubblePosition;
    public Vector3 TildaBubblePosition;
    public GameObject dialogueText;
    public Image characterPortraitObject;
    public Sprite tilda;
    public Sprite mort;

    private int index;

    private void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeDialogue());
    }

    IEnumerator TypeDialogue()
    {
        if (dialogueForBoth[index].character is CharacterENUM.MORT)
        {
            characterPortraitObject.sprite = mort;
            characterPortraitObject.transform.eulerAngles = Vector3.zero;
            GetComponent<RectTransform>().anchoredPosition = MortBubblePosition;
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 0, 0);
            dialogueText.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            characterPortraitObject.sprite = tilda;
            if (characterPortraitObject.transform.eulerAngles != new Vector3(0, 180, 0))
            {
                characterPortraitObject.transform.eulerAngles = new Vector3(0, 180, 0);
            }
            GetComponent<RectTransform>().anchoredPosition = TildaBubblePosition;
            GetComponent<RectTransform>().eulerAngles = new Vector3(0, 180, 0);
            dialogueText.transform.localScale = new Vector3(-1, 1, 1);
        }
        foreach (char c in dialogueForBoth[index].text)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

    }

    void nextLine()
    {
        if (index < dialogueForBoth.Count - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeDialogue());
        }
        else
        {
            //UIManager.UI.ChangeActionMapCharacterInput();
            UIManager.UI.HealthbarObj.SetActive(true);
            UIManager.UI.TimerScreen.SetActive(true);
            transform.parent.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    public void ButtonForDialoguePressed()
    {
        if (textComponent.text == dialogueForBoth[index].text)
        {
            nextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = dialogueForBoth[index].text;
        }
    }

    public void OnSkipDialogue()
    {
        //players can move again here
        if (UIManager.UI.HealthbarObj)
        {
            UIManager.UI.HealthbarObj.SetActive(true);
            UIManager.UI.TimerScreen.SetActive(true);
        }
        else
        {
            UIManager.UI.ChangeActionMapCharacterInput();
        }
        transform.parent.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }


    [System.Serializable]
    public class TextAndCharacter
    {
        public CharacterENUM character;
        [TextArea]
        public string text;
    }
}
