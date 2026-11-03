using Gamekit3D;
using UnityEngine;

public class SurvivalMod : MonoBehaviour
{
    [SerializeField] private float thirstLevel = 100f;
    [SerializeField] private float thirstSpeed;
    
    [SerializeField] private bool thirsty;
    [SerializeField] private bool parched;

    [SerializeField] private GameObject playerObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
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
        if (thirstLevel <= 0 && thirsty)
        {
            Damageable.DamageMessage msg = new Damageable.DamageMessage()
            {
                amount = 1,
                damager = this,
                damageSource = new Vector3(0, 0, 0),
                direction = new Vector3(0, 0, 0),
                throwing = false,
                stopCamera = false
            };
            playerObject.GetComponent<Damageable>().ApplyDamage();
            Debug.Log(message:"Damage by thirst");
        }
    }
}
