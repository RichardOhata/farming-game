using UnityEngine;

public class SoilTile : MonoBehaviour
{
    public bool isTilled = false;
    public bool isPlanted = false;
    //public Plant plantedPlant;

    public void Till()
    {
        isTilled = true;
    }

    public void PlantSeed()
    {
        isPlanted = true;
    }
}
