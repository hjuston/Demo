using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [Header("Panel informacji o wskazywanym przedmiocie")]
    public GameObject ItemInformationsPanel;

    public Text ItemName;
    public Text ItemDescription;
    public Text ItemWeight;
    public Text ItemValue;
    
    public void DisplayItemInformations(GameObject item)
    {
        if (item != null)
        {
            Item itemScript = item.GetComponent<Item>();
            if (itemScript != null)
            {
                ItemInformationsPanel.SetActive(true);

                ItemName.text = itemScript.Name;
                ItemDescription.text = itemScript.Description;
                ItemWeight.text = itemScript.Weight.ToString();
                ItemValue.text = (itemScript.Value < 0) ? "?" : itemScript.Value.ToString();
            }
        }
        else
        {
            ItemInformationsPanel.SetActive(false);
        }
    }

}
