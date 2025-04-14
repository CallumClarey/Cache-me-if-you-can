using UnityEngine;

public class HackingInteraction : MonoBehaviour
{
    public GameObject hackingUIPanel;

    void OnEnable()
    {
        HackEvents.OnTargetSelected += OpenHackingUI;
    }

    void OnDisable()
    {
        HackEvents.OnTargetSelected -= OpenHackingUI;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Hackable"))
            {
                HackEvents.TriggerTargetSelected(hit.collider.gameObject);
            }
        }
    }

    void OpenHackingUI(GameObject target)
    {
        hackingUIPanel.SetActive(true);
        Debug.Log($"Selected target: {target.name}");
    }

    public void CloseHackingUI()
    {
        hackingUIPanel.SetActive(false);
    }
}

