using UnityEngine;

[CreateAssetMenu(fileName = "New Special", menuName = "Today's Special")]
public class TodaysSpecials : ScriptableObject
{
    public Dumpling[] dumplings;
    public int points;
}

[System.Serializable]
public class Dumpling
{
    public ScriptableObject dumplingObject;
    public int requiredQuantity;
}