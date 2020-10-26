using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit3MoveLeft : MonoBehaviour
{
    private float _velocity = 5f;
    private float _leftBound = -15f;
    private Unit3PlayerController _playerController;
    
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<Unit3PlayerController>();
    }

    void Update()
    {
        if (_playerController.gameOver == false)
        {
            transform.Translate(Vector3.left * _velocity * Time.deltaTime);
        }
        else if (_playerController.gameOver == true)
        {
            _velocity = 0;
            transform.Translate(Vector3.left * _velocity * Time.deltaTime);
        }
        
        
        if (transform.position.x < _leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(this.gameObject);
        }
    }
}
