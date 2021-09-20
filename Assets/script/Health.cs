using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider slider;

    public Gradient gradient;
    public Image fill;

    //initialisation des pv
    public void MaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);
    }
    //Ajouter des pv
    public void SetHealth(int health)
    {
        slider.value = health;
        //récupère la valeur initiale entre 0 & 1
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
