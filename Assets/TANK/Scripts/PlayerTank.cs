using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{

    public int ammo = 10;
    [SerializeField] float maxTorque = 90; 
    [SerializeField] float maxForce = 1;
    [SerializeField] float shootDelayMax = 2;
    [SerializeField] GameObject rocket;
    [SerializeField] GameObject playerModel;
    [SerializeField] Transform barrel;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] Slider healthSlider;

    float torque;
    float force;
    float timerDelay;

    Rigidbody rb;
    Destructable destructable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        destructable = GetComponent<Destructable>();
        healthSlider.maxValue = destructable.MaxHealth;
        timerDelay = shootDelayMax;
    }

    // Update is called once per frame
    void Update()
    {
        timerDelay -= Time.deltaTime;
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;

        if (Input.GetMouseButtonDown(0) && ammo > 0 && timerDelay <= 0)
        {
            ammo--;
            Instantiate(rocket, barrel.position, barrel.rotation);
            timerDelay = shootDelayMax;
        }
        ammoText.text = "Ammo: " + ammo.ToString();

        PlayerPrefs.SetFloat("PlayerHealth", destructable.Health);
        PlayerPrefs.Save();
        healthSlider.value = PlayerPrefs.GetFloat("PlayerHealth");

        if (destructable.Health <= 0)
        {
            Destroy(playerModel);
            GameManager.Instance.SetGameOver();
        }
        
    }
    private void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * force);
        rb.AddRelativeTorque(Vector3.up * torque);
    }
    public void OnHealthUpdate(float healthPoints)
    {
        destructable.HealHealth(healthPoints);
        PlayerPrefs.SetFloat("PlayerHealth", destructable.Health);
        PlayerPrefs.Save();
        healthSlider.value = PlayerPrefs.GetFloat("PlayerHealth");

    }

}
