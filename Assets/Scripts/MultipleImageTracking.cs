using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;



[RequireComponent(typeof(ARTrackedImageManager))]
[RequireComponent(typeof(AudioSource))]
public class MultipleImageTracking : MonoBehaviour
{
    [SerializeField] private GameObject[] placeablePrefabs; //our Prefabs, that will be created at runtime
     public GameObject pantherView;
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();  //will call sporned prefabs out of Prefab Array (string = used for finding a prefab from the placeable Prefab array with the same name
    public AudioSource geschichte;
    private ARTrackedImageManager trackedImageManager; //contains the reference image library, detects the images in it
public bool showUICamera = false; //true = show UI camera, hide AR camera
//public Camera ARcamera;
private void Start(){
geschichte = GetComponent<AudioSource>();
}
    private void Awake()
    {

      //  ARcamera.enabled = false;
        trackedImageManager = FindObjectOfType<ARTrackedImageManager>(); //getting and storing a reference to the trackedImageManager
           Debug.Log("Panther");
        //presporn one of the placeable Prefabs in our Array
        foreach (GameObject prefab in placeablePrefabs)
        {
            Debug.Log("Geschichte  " + geschichte);
            GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newPrefab.name = prefab.name; //searching for the right prefab
            spawnedPrefabs.Add(prefab.name, newPrefab); //add this to the spawnedPrefab Dictionary, newPrefab=Reference
           // geschichte.Play();


        }
    }

    private void OnEnable() //bind events to the TrackedImageChanged in the trackedImageManager
    {
        trackedImageManager.trackedImagesChanged += ImageChanged; //trackedImagesChanged: Invoked once per frame with information about the ARTrackedImages that have changed, i.e., been added, updated, or removed.
    }

    private void OnDisable() //unbind events to the TrackedImageChanged in the trackedImageManager
    {
        trackedImageManager.trackedImagesChanged -= ImageChanged;
    }

    private void ImageChanged(ARTrackedImagesChangedEventArgs eventArgs) //allows to call functionalities based on which image is being tracked/removed/updated
    {
        foreach (ARTrackedImage trackedImage in eventArgs.added) //each time an image is added
        {
            UpdateImage(trackedImage);
        }
        
        foreach (ARTrackedImage trackedImage in eventArgs.updated) //each time an image is updated
        {
            UpdateImage(trackedImage);
        }
        
        foreach (ARTrackedImage trackedImage in eventArgs.removed) //each time an image is removed
        {
            spawnedPrefabs[trackedImage.name].SetActive(false); //finding the current tracked image name, searching for the item in our dictionary, disabling the object of the same name
        }
    }

    private void UpdateImage(ARTrackedImage trackedImage)
    {

        string name = trackedImage.referenceImage.name; //temporarily store the name of the tracked image
        Vector3 position = trackedImage.transform.localPosition;

        GameObject prefab = spawnedPrefabs[name]; //GameObject will be from our spawnedPrefabs Dictionary selected by the name
        prefab.transform.localPosition = position;
        prefab.SetActive(true); //see the prefab linked to the current image
pantherView.gameObject.SetActive(true);
        foreach (GameObject go in spawnedPrefabs.Values)
        {
            if (go.name != name)
            {
                go.SetActive(false); //ensure that all of the other prefabs we have activated go back to be hidden if we look at a new image
            }
        }

    }

    
}
