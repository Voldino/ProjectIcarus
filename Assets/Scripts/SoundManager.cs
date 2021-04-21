using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    // Audio players components.
    [System.Serializable]
    class SoundClass
    {
        public string tag;
        public AudioSource audioSource; 
    }

    [SerializeField] List<SoundClass> soundsList = new List<SoundClass>() ;
    private Dictionary<string, AudioSource> sounds =  new Dictionary<string, AudioSource>() ; 

   // Singleton instance.
   public static SoundManager Instance = null;

   // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            for (int i = 0; i < soundsList.Count; i++)
            {
                print(soundsList[i].tag); 
                sounds.Add(soundsList[i].tag,soundsList[i].audioSource);
                
            }
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else  
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.

    }

    // Play a single clip through the sound effects source.
    public void Play(string tag)
    {
        AudioSource audio = sounds[tag];
        audio.Play();
    }

    public void Stop(string tag)
    {
        sounds[tag].Stop(); 
    }

 



}