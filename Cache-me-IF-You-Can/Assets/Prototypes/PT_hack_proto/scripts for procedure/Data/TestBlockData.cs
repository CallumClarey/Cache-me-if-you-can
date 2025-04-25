using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewHackableObject", menuName = "Hacking/HackableObject")]
public class TestBlockData : ScriptableObject
{
    public string hackPrompt;
    public List<Vector2> slotPositions; // Positions for UI slots
    public List<string> blockNames;     // Names of blocks shown for this object
}
