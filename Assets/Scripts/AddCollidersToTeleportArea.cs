using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AddCollidersToTeleportArea : MonoBehaviour
{
    [SerializeField] private string _targetTag = "Floor";
    private TeleportationArea _teleportArea;

    private void Awake() => _teleportArea = GetComponent<TeleportationArea>();

    private void Start()
    {
        GameObject[] floorObjects = GameObject.FindGameObjectsWithTag(_targetTag);

        foreach (GameObject floor in floorObjects)
        {
            Collider collider = floor.GetComponent<Collider>();

            if (collider == null) collider = floor.AddComponent<BoxCollider>();

            _teleportArea.colliders.Add(collider);
        }
        UpdateTeleportationArea();
    }

    private void UpdateTeleportationArea()
    {
        _teleportArea.enabled = false;
        _teleportArea.enabled = true;
    }
}
