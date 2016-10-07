using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InteractionsController : MonoBehaviour
{

    public Text InteractionText;

    private GameObject _focusedItem;
    private GameObject FocusedItem { get { return _focusedItem; } set { _focusedItem = value; Helper.GetGUIManager().DisplayItemInformations(value); } }

    void Update()
    {
        Raycast();
        HighlightItem();
        CheckForPickUp();
    }

    void CheckForPickUp()
    {
        if (FocusedItem != null && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.Destroy(FocusedItem);
            FocusedItem = null;
        }
    }

    void Raycast()
    {
        // Raycasting in the direction of hud indicator
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 2.5f))
        {
            if (hitInfo.collider.tag == "Interactable")
            {
                InteractionText.gameObject.SetActive(true);
                FocusedItem = hitInfo.collider.gameObject;
            }
            else
            {
                InteractionText.gameObject.SetActive(false);
                if (FocusedItem != null)
                {
                    FocusedItem.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
                    FocusedItem = null;
                }

            }
        }
        else
        {
            InteractionText.gameObject.SetActive(false);
            if (FocusedItem != null)
            {
                FocusedItem.GetComponent<Renderer>().material.shader = Shader.Find("Standard");
                FocusedItem = null;
            }
        }
    }

    void HighlightItem()
    {
        if (FocusedItem != null)
        {
            FocusedItem.GetComponent<Renderer>().material.shader = Shader.Find("Self-Illumin/Outlined Diffuse");
        }
    }
}
