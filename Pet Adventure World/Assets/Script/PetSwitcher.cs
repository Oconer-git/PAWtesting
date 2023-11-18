using UnityEngine;
using UnityEngine.UI;

public class PetSwitcher : MonoBehaviour
{
    public GameObject[] petPrefabs;
    private int currentPetIndex = 0;

    public Transform petSpawner;

    private void Start()
    {
        UpdatePetPrefab();
    }

    public void OnRightButtonClick()
    {
        Debug.Log("clicked Right");
        currentPetIndex = (currentPetIndex + 1) % petPrefabs.Length;
        UpdatePetPrefab();
    }

    public void OnLeftButtonClick()
    {
        Debug.Log("clicked Left");
        currentPetIndex = (currentPetIndex - 1 + petPrefabs.Length) % petPrefabs.Length;
        UpdatePetPrefab();
    }

    private void UpdatePetPrefab()
    {
        // Destroy the current pet if it exists
        foreach (Transform child in petSpawner)
        {
            Destroy(child.gameObject);
        }

        // Instantiate the new pet prefab and set its rotation
        GameObject newPet = Instantiate(petPrefabs[currentPetIndex], petSpawner);
        newPet.transform.rotation = Quaternion.Euler(-90, 0, -200);
    }
}
