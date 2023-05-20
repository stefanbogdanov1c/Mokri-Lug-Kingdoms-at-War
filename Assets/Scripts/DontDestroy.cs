using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static AudioSource firstInstance;

    void Awake()
    {
        // Check if the first instance already exists
        if (firstInstance == null)
        {
            // Set the first instance if it doesn't exist
            firstInstance = GetComponent<AudioSource>();

            // Don't destroy this game object when the scene changes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // Destroy any additional instances that are created
            Destroy(gameObject);
        }
    }

}
