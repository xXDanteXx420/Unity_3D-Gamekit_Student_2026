using UnityEngine;

public class SurvivalMod : MonoBehaviour
{
    [SerializeField] private float thirstLevel = 100f;
    [SerializeField] private float thirstSpeed;
    
    [SerializeField] private bool thirsty;
    [SerializeField] private bool parched; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Subtracting the current level of thirstLevel with thirstSpeed. thirstSpeed is normalized
        //by using  Time.deltaTime, so that it's frame rate independent. Math.Clamp restricts the thirstLevel between it's current value and 0.
        
        thirstLevel -= Mathf.Clamp(thirstSpeed*Time.deltaTime, min:0, max:thirstLevel);

        if (thirstLevel <= 50f && !thirsty)
        {
            Debug.Log(message: "Getting Thirsty....");
            thirsty = true; 
        }
    }
}
