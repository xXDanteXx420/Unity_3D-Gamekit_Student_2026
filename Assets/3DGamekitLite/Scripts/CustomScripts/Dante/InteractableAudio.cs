using UnityEngine;
using FMOD.Studio;
using FMODUnity;

[CreateAssetMenu(fileName = "InteractableAudio", menuName = "Scriptable Objects/InteractableAudio")]
public class InteractableAudio : ScriptableObject
{
    //Declares an EventReference that hold a reference to our specific event
    [SerializeField] private EventReference pickupHealthAudio, boxDestroyAudio, switchAudio, doorAudio, pressurePadAudio;

    //Declares a method that should play the pickupHealth sound without any 3D-positioning.
    public void PickupHealthPlay()
    {
        RuntimeManager .PlayOneShot(pickupHealthAudio);
    }
    //Declares a method that should play the boxDestroyAudio with 3D-Positioning by referencing a Transform position.
    public void BoxDestroyPlay(Transform objectTransform)
    {
        RuntimeManager.PlayOneShot(boxDestroyAudio, objectTransform.position);
    }

    public void PressurePadPlay(Transform objectTransform)
    {
        RuntimeManager.PlayOneShot(pressurePadAudio, objectTransform.position);
    }
}
