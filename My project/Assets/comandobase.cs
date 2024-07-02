using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comandobase : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    public float movimentoHorizontal;
    public float forca;
    public bool isSensor;
    public Transform posicaoSensor;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sensorChao();
        movimentoHorizontal = Input.GetAxisRaw("Horizontal");
        rigidbody2.velocity = new Vector2(movimentoHorizontal *10, rigidbody2.velocity.y);
        if (Input.GetButtonDown("Jump")&& isSensor==true)
        {
            rigidbody2.AddForce(new Vector2(0, forca));
        }
    }

    public void sensorChao()
    {
        isSensor = Physics2D.OverlapCircle(posicaoSensor.position,0.2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("coletavel"))
        Destroy(collision.gameObject);
    }
}
  