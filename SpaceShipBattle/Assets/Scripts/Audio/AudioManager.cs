using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;
using FMOD.Studio;

public class AudioManager : MonoBehaviour
{
    [Header("Volume")]
    [Range(0, 1)]
    public float masterVolume = 1;
    [Range(0, 1)]
    public float musicVolume = 1;
    [Range(0, 1)]
    public float ambienceVolume = 1;
    [Range(0, 1)]
    public float SFXVolume = 1;

    private Bus masterBus;
    private Bus musicBus;
    private Bus sfxBus;

    private Dictionary<EventReference, EventInstance> eventInstances;

    private EventInstance musicEventInstance;

    public static AudioManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one audio manager");
        }
        else
        {
            instance = this;
        }

        eventInstances = new Dictionary<EventReference, EventInstance>();

        masterBus = RuntimeManager.GetBus("bus:/");
        musicBus = RuntimeManager.GetBus("bus:/Music");
        sfxBus = RuntimeManager.GetBus("bus:/SFX");
    }

    public void InitializeMusic(EventReference musicEventReference)
    {
        musicEventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        musicEventInstance = CreateInstance(musicEventReference);
        musicEventInstance.start();
    }

    public EventInstance CreateInstance(EventReference eventReference)
    {
        EventInstance eventInstance = RuntimeManager.CreateInstance(eventReference);
        eventInstances.TryAdd(eventReference, eventInstance);
        return eventInstance;
    }

    public void PlayOneShot(EventReference sound, Vector3 pos)
    {
        RuntimeManager.PlayOneShot(sound, pos);
    }

    public void PlayOneShot(EventReference sound)
    {
        CreateInstance(sound);
        RuntimeManager.PlayOneShot(sound);
    }

    public int GetLength(EventReference eventReference)
    {
        if (!eventInstances.ContainsKey(eventReference))
        {
            EventInstance instance = CreateInstance(eventReference);
            eventInstances.Add(eventReference, instance);
        }

        EventInstance eventInstance = eventInstances[eventReference];

        if (eventInstance.isValid())
        {
            eventInstance.getDescription(out EventDescription eventDescription);

            if (eventDescription.isValid())
            {
                eventDescription.getLength(out int length);
                Debug.Log($"[FMOD] Event '{eventReference.Path}' length: {length} ms");
                return length;
            }
            else
            {
                Debug.LogWarning($"[FMOD] EventDescription not valid for: {eventReference.Path}");
            }
        }
        else
        {
            Debug.LogWarning($"[FMOD] EventInstance not valid for: {eventReference.Path}");
        }
        
        return 0;
    }

    public void SetMasterVolume(float volume)
    {
        masterBus.setVolume(volume); // 0.0 = mute, 1.0 = full volume
    }

    public void SetMusicVolume(float volume)
    {
        musicBus.setVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        sfxBus.setVolume(volume);
    }

    private void CleanUp()
    {
        // stop and release any created instances
        foreach (EventInstance eventInstance in eventInstances.Values)
        {
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.release();
        }
    }

    private void OnDestroy()
    {
        CleanUp();
    }
}
