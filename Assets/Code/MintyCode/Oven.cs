using UnityEngine;

public class Oven : MonoBehaviour
{
    public Plate plate;
    public MenuRecipe menuRecipe;
    public ScoreManager scoreManager;
    public Transform plateSpawnPoint1;
    public Transform plateSpawnPoint2;
    public GameObject platePrefab;

    private Transform currentSpawnPoint; // Store the current spawn point

    private void Start()
    {
        // Store the initial spawn point
        currentSpawnPoint = plateSpawnPoint1;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKey(KeyCode.F))
            {
                if (plate.IsEmpty() || plate.ItemCount(null) < 3)
                {
                    // Create a mystery dumpling that earns 0 points
                    scoreManager.AddScore(0);
                }
                else
                {
                    // Get the combination of items on the plate
                    Item[] items = plate.GetItems();
                    bool isRecipeMatched = menuRecipe.IsMatch(items);

                    if (isRecipeMatched)
                    {
                        // Get the corresponding dumpling score
                        int dumplingScore = menuRecipe.GetDumplingScore(items);

                        // Add the dumpling score to the total score
                        scoreManager.AddScore(dumplingScore);
                    }
                    else
                    {
                        // Create a mystery dumpling that earns 0 points
                        scoreManager.AddScore(0);
                    }
                }

                // Clear the plate after processing
                plate.Clear();

                // Spawn a new plate on the current spawn point if it's empty
                if (!IsSpawnPointOccupied())
                {
                    Instantiate(platePrefab, currentSpawnPoint.position, currentSpawnPoint.rotation);
                }
            }
        }
    }

    private bool IsSpawnPointOccupied()
    {
        // Check if the current spawn point has a plate
        Collider[] colliders = Physics.OverlapSphere(currentSpawnPoint.position, 0.1f);
        foreach (Collider collider in colliders)
        {
            Plate spawnedPlate = collider.GetComponent<Plate>();
            if (spawnedPlate != null)
            {
                return true;
            }
        }
        return false;
    }
}
