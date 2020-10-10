using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputCoroutine : MonoBehaviour
{
    private Collider _upgradeCollider;

    private float _chargeInterval = 1.0f;
    private int _chargeLoadAmount = 1;
    private int _percentageCharged;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _percentageCharged <= 100)
        {
            StartCoroutine(ChargeOnInput());
        }

        if (_upgradeCollider.isTrigger)
        {
            _chargeInterval -= 0.01f;
        }
    }

    IEnumerator ChargeOnInput()
    {
        do
        {
            _percentageCharged += _chargeLoadAmount;
            yield return new WaitForSeconds(_chargeInterval);
        } while (_percentageCharged > 100);
    }
}
