using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class HackingUIManager : MonoBehaviour
{
    public GameObject uiPanel; // The full UI panel to show/hide
    public Transform dropSlotParent; // Where drop slot layout will be instantiated
    public Transform blockSpawnArea; // Where draggable blocks will spawn
    public Button compileButton;

    private GameObject currentDropSlotLayout;
    private List<GameObject> spawnedBlocks = new List<GameObject>();
    private HackableObject currentTarget;

    void Awake()
    {
        // Hide the panel on start
        if (uiPanel != null)
            uiPanel.SetActive(false);
    }

    void OnEnable()
    {
        HackableObject.OnHackSelected += ShowHackUI;
    }

    void OnDisable()
    {
        HackableObject.OnHackSelected -= ShowHackUI;
    }

    void ShowHackUI(HackableObject target)
    {
        ClearUI();

        currentTarget = target;
        HackDefinition def = target.hackDefinition;

        if (def == null) return;

        uiPanel.SetActive(true); // Now show the panel

        // Instantiate the drop slot layout
        if (def.dropSlotLayoutPrefab != null)
        {
            currentDropSlotLayout = Instantiate(def.dropSlotLayoutPrefab, dropSlotParent);
        }

        // Instantiate each draggable block
        foreach (GameObject blockPrefab in def.draggablePrefabs)
        {
            GameObject block = Instantiate(blockPrefab, blockSpawnArea);
            spawnedBlocks.Add(block);
        }

        compileButton.onClick.RemoveAllListeners();
        compileButton.onClick.AddListener(CompileHack);

        Debug.Log($"Hacking '{def.hackName}': {def.description}");
    }

    public void HideUI()
    {
        uiPanel.SetActive(false);
        ClearUI();
    }

    void ClearUI()
    {
        if (currentDropSlotLayout)
        {
            Destroy(currentDropSlotLayout);
            currentDropSlotLayout = null;
        }

        foreach (var block in spawnedBlocks)
        {
            Destroy(block);
        }
        spawnedBlocks.Clear();
    }

    public void CompileHack()
    {
        if (currentTarget == null || currentDropSlotLayout == null) return;

        DropSlot[] dropSlots = currentDropSlotLayout.GetComponentsInChildren<DropSlot>();
        List<string> usedBlockNames = new List<string>();

        foreach (var slot in dropSlots)
        {
            if (slot.HasBlock())
            {
                usedBlockNames.Add(slot.currentBlock.name.Replace("(Clone)", "").Trim());
            }
        }

        foreach (var outcome in currentTarget.hackDefinition.outcomes)
        {
            if (CompareBlockSets(usedBlockNames, outcome.requiredBlockNames))
            {
                Debug.Log($"Hack successful: {outcome.description}");
                outcome.onSuccess?.Invoke();
                return;
            }
        }

        Debug.Log("Hack failed: Invalid block combination.");
    }

    bool CompareBlockSets(List<string> used, string[] required)
    {
        if (used.Count != required.Length) return false;

        foreach (string req in required)
        {
            if (!used.Contains(req)) return false;
        }

        return true;
    }
}
