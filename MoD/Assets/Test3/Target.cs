using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Transform finishTr;
    public float _speed;
    public void Initialize(Transform t, float speed, bool flip)
    {
        _speed = speed;
        finishTr = t;
        gameObject.GetComponent<SpriteRenderer>().flipX = flip;
    }

    private void Update()
    {
        if (finishTr != null)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, finishTr.position, Time.deltaTime * _speed);
            if (Mathf.Abs(this.transform.position.x - finishTr.position.x) <= 1)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
    }
}
