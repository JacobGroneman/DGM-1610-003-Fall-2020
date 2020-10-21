using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PracticeGetComponents : MonoBehaviour
{
    private Transform _trans;
    private Collider _col;
    private Rigidbody _rb;
    private Animator _anim;
    private MeshRenderer _meshR;
    private SpriteRenderer _spriteR;

    void Start()
    {
        _trans = GetComponent<Transform>();
        _col = GetComponent<Collider>();
        _rb = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();
        _meshR = GetComponent<MeshRenderer>();
        _spriteR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        _trans = new RectTransform();
        _col.isTrigger = true;
        _rb.constraints = RigidbodyConstraints.FreezeRotation;
        _anim.speed = 29.97f;
        _meshR.additionalVertexStreams = new Mesh();
        _spriteR.color = Color.HSVToRGB(50, 6, 23);
    }
}
