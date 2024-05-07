
using UnityEngine;

public class SpriteOrient : MonoBehaviour
{
    public Transform player; // Assign this in the inspector with your player's transform

    void Update()
    {
        if (player != null)
        {
            // Look at the player
            transform.LookAt(player);

            Vector3 rotation = transform.eulerAngles;
            rotation.y += 180;
            transform.eulerAngles = rotation;
        }
    }
}
