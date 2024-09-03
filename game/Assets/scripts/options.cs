using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterClickHandler : MonoBehaviour
{
    public TextMeshProUGUI[] emptySlots; 
    private Button button;
    private TextMeshProUGUI buttonText;

    void Start()
    {
        
        if (gameObject.name == "options")
        {
            button = GetComponent<Button>();
            if (button == null)
            {
                Debug.LogError("Button component is missing on " + gameObject.name);
                return;
            }

            buttonText = GetComponentInChildren<TextMeshProUGUI>();
            if (buttonText == null)
            {
                Debug.LogError("TextMeshProUGUI component is missing among the children of " + gameObject.name);
                return;
            }

            button.onClick.AddListener(OnButtonClick);
        }
    }

    public void OnButtonClick()
    {
        foreach (TextMeshProUGUI slot in emptySlots)
        {
            if (slot == null)
            {
                Debug.LogError("Empty slot reference is missing!");
                continue;
            }

            if (string.IsNullOrEmpty(slot.text))
            {
                slot.text = buttonText.text; 
                button.interactable = false; 
                break;
            }
        }
    }
}
