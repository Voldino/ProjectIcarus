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

    [SerializeField] List<SoundClass> soundsList;
    private Dictionary<string, List<AudioSource> > sounds = new Dictionary<string, List<AudioSource>>() ; 

   // Singleton instance.
   public static SoundManager Instance = null;

   // Initialize the singleton instance.
    private void Awake()
    {
        // If there is not already an instance of SoundManager, set it to this.
        if (Instance == null)
        {

            for (int i = 0; i < soundsList.Count; i++)
            {
                for (int j = 0; j < 10 ; j++)
                {
                    AudioSource audioS = Instantiate(soundsList[i].audioSource);
                    //sounds.Add(soundsList[i].tag,audioS);
                }
            }
            Instance = this;
        }
        //If an instance already exists, destroy whatever this object is to enforce the singleton.
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    // Play a single clip through the sound effects source.
    public void Play(string tag)
    {
        
        /*Instantiate(sounds[tag], sounds[tag].transform);
        AudioSource audio = sounds[tag];
        audio.Play();*/
    }

 



}