using UnityEngine;
using UnityEngine.UI;

public class HackingInteraction : MonoBehaviour
{
    public GameObject hackingUIPanel; // Assign in Inspector

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Hackable"))
            {
                OpenHackingUI();
            }
        }
    }

    void OpenHackingUI()
    {
        hackingUIPanel.SetActive(true); // Show UI
    }

    public void CloseHackingUI()
    {
        hackingUIPanel.SetActive(false); // Hide UI
    }
}
