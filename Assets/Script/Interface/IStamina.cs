using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStamina 
{
    public float stamina { get; set; }

    public float maxStamina { get; set; }

    public float staminaDrain { get; set; }

    public float staminaRegen { get; set; }

    void RegenStamina();
}
