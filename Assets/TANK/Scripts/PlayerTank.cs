using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTank : MonoBehaviour
{

    public int ammo = 10;
    [SerializeField] float maxTorque = 90; 
    [SerializeField] float maxForce = 1;
    [SerializeField] GameObject rocket;
    [SerializeField] Transform barrel;
    [SerializeField] TMP_Text ammoText;
    [SerializeField] Slider healthSlider;

    float torque;
    float force;

    Rigidbody rb;
    Destructable destructable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        rb = GetComponent<Rigidbody>();
        destructable = GetComponent<Destructable>();
        healthSlider.maxValue = destructable.MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        torque = Input.GetAxis("Horizontal") * maxTorque;
        force = Input.GetAxis("Vertical") * maxForce;

        if (Input.GetMouseButtonDown(0) && ammo > 0)
        {
            ammo--;
            Instantiate(rocket, barrel.position, barrel.rotation);
        }
        ammoText.text = "Ammo: " + ammo.ToString() + " Health Temp: " + destructable.Health.ToString();

        PlayerPrefs.SetFloat("PlayerHealth", destructable.Health);
        PlayerPrefs.Save();
        healthSlider.value = PlayerPrefs.GetFloat("PlayerHealth");

        if (destructable.Health <= 0)
        {
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
