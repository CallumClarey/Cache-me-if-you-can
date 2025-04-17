using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

[System.Serializable]
public class HackOutcome
{
    public string[] requiredBlockNames; // Names of the blocks that trigger this outcome
    [TextArea] public string description; // Description of what the outcome does
    public UnityEvent onSuccess; // What happens if this outcome is triggered
}

[CreateAssetMenu(fileName = "NewHackDefinition", menuName = "Hacking/Hack Definition")]
public class HackDefinition : ScriptableObject
{
    public string hackName;
    [TextArea] public string description;

    public GameObject[] draggablePrefabs; // Blocks like Overheat, TurnOff
    public GameObject dropSlotLayoutPrefab; // Prefab of drop slot layout (horizontal, grid, etc.)

    public List<HackOutcome> outcomes; // List of possible valid block combinations
}
