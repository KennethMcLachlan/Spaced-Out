using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    
    [SerializeField]
    private float _laserSpeed = 8.0f;
    
    private bool _isEnemyLaser = false;
   
    void Start()
    {
       
    }

    void Update()
    {
        if (_isEnemyLaser == false)
        {
            MoveUp();
        }

        else
        {
            MoveDown();
        }
    }

    void MoveUp()
    {

        transform.Translate(Vector3.up * _laserSpeed * Time.deltaTime);

        if (transform.position.y >= 8f)
        {

            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }

            Destroy(gameObject);
        }
    }

    void MoveDown()
    {
        transform.Translate(Vector3.down * _laserSpeed * Time.deltaTime);

        
        if (transform.position.y <= -8f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            
            Destroy(gameObject);
        }
        
    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _isEnemyLaser == true)
        {
            Player player = other.GetComponent<Player>();

            if (player != null)
            {
                player.Damage();
                Destroy(gameObject);
            }
        }
    }
    
}
