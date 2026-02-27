using UnityEngine;
using TMPro;

public class FeedbackUI : MonoBehaviour
{
    [SerializeField] private GameObject feedbackPanel;
    [SerializeField] private TMP_Text feedbackText;

    [SerializeField] private GameObject resultsPanel;
    [SerializeField] private TMP_Text requiredText;
    [SerializeField] private TMP_Text resultsText;

    private void Awake()
    {
        feedbackPanel.SetActive(false);
        resultsPanel.SetActive(false);

    }

    public void ShowText(string messageToShow)
    {
        feedbackText.text = messageToShow; 
        feedbackPanel.SetActive(true);
    }

    public void Hide()
    {
        feedbackPanel.SetActive(false);
        resultsPanel.SetActive(false);
    }

    public void ShowResults(int required, int placed)
    {
        requiredText.text = "Required: " + required.ToString();
        resultsText.text = "Placed: " + placed.ToString();
        resultsPanel.SetActive(true);
    }

    public void Goodbye()
    {
        CustomerFlow flow = FindFirstObjectByType<CustomerFlow>();
        if (flow != null)
        { 
            flow.OnGoodbyeClicked(); 
        }

        Hide();
    }
}
