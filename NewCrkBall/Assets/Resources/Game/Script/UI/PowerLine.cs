using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLine : MonoBehaviour
{
    public GameObject ten, digits;
    private int ten_count = 0, digits_count = 0;

    public void addAttack_UI()
    {
        digits_count++;
        
        if (digits_count >= 10)
        {
            ten_count++;
            digits_count = 0;
        
            

        }
        else
        {
            GameObject digits_gameobject = Instantiate(digits);
            digits_gameobject.transform.parent = gameObject.transform;

            
            float width = (digits_count-1) * 0.2f;
            digits_gameobject.transform.localPosition += new Vector3(width,0);
        }
    }

    private void Start()
    {
        addAttack_UI();
        addAttack_UI();
    }
}