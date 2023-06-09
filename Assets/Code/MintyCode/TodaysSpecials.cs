using UnityEngine;

[CreateAssetMenu(fileName = "New Special", menuName = "Today's Special")]
public class TodaysSpecials : ScriptableObject
{
    public Dumpling[] dumplings;
}

[System.Serializable]
public class Dumpling
{
    public ScriptableObject dumplingObject;
    public int requiredQuantity;
}