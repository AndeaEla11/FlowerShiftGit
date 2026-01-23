using UnityEngine;
using UnityEngine.SceneManagement;

public class OrderUI : MonoBehaviour
{
    [SerializeField] private GameObject orderPanel;

    private void Awake()
    {
        orderPanel.SetActive(false);
    }

    public void ShowOrder()
    {
        orderPanel.SetActive(true);
    }

    public void HideOrder()
    {
        orderPanel.SetActive(false);
    }

    public void StartBuilding()
    {
        HideOrder();
        SceneManager.LoadScene("BouquetArrangementScene");
    }
}
