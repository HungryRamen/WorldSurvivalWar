using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ESTATE
{
    eNormal,
    eWalk,
}

public class Test : MonoBehaviour
{

    public Sprite[] sprites;
    public float fSpeed;

    private SpriteRenderer spriteRenderer;
    private ESTATE eState;
    private float fLength;
    private bool bDirection;
    private Vector2 vTargetPos;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprites[0];
        vTargetPos = this.transform.position;
        bDirection = true;
        eState = ESTATE.eNormal;
    }

    // Update is called once per frame
    void Update()
    {
        MouseEvent();
        FSM();
    }

    void MouseEvent() //마우스 클릭 처리
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 MousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 WorldPos = Camera.main.ScreenToWorldPoint(MousePos);
            fLength = Vector2.Distance(this.transform.position, WorldPos);
            if (this.transform.position.x <= WorldPos.x && !bDirection)
                Flip();
            else if (this.transform.position.x > WorldPos.x && bDirection)
                Flip();
            vTargetPos = WorldPos;
            eState = ESTATE.eWalk;
            spriteRenderer.sprite = sprites[1];
        }
    }

    void FSM() //폰의 상태값에 따른 행동
    {
        switch (eState)
        {
            case ESTATE.eWalk:
                {
                    Vector2 CurPos = this.transform.position;
                    float step = fSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(CurPos, vTargetPos, step);
                    fLength -= fSpeed * Time.deltaTime;

                    if (fLength <= 0.0f)
                    {
                        eState = ESTATE.eNormal;
                        fLength = 0.0f;
                        spriteRenderer.sprite = sprites[0];
                        vTargetPos = this.transform.position;
                    }
                }
                break;
        }
    }

    void Flip() //좌우 반전 함수
    {
        bDirection = !bDirection;
        Vector3 vScl = transform.localScale;
        vScl.x *= -1;
        transform.localScale = vScl;
    }
}
