using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Obj
{

    public enum ESTATE //폰의 FSM 상태
    {
        eNormal,
        eWalk,
    }

    protected bool bDirection; //왼쪽FALSE 오른쪽 TRUE
    protected ESTATE eState;
    protected float fSpeed;
    protected float fLength;
    protected Vector2 vTargetPos;

    public bool IsDirection() { return bDirection; }

    public float GetSpeed() { return fSpeed; }
    public void SetSpeed(float fspeed) { fSpeed = fspeed; }

    public ESTATE GetState() { return eState; }
    public void SetState(ESTATE estate) { eState = estate; }

    public float GetLength() { return fLength; }
    public void SetLength(float flength) { fLength = flength; }

    public Vector2 GetTargetPos() { return vTargetPos; }
    public void SetTargetPos(Vector2 vPos) { vTargetPos = vPos; }

    void Awake()
    {
        bDirection = true;
        fLength = 0.0f;
        eState = ESTATE.eNormal;
    }

    protected Vector3 Flip(Vector3 vScl) //좌우 반전 함수
    {
        bDirection = !bDirection;
        vScl.x *= -1;
        return vScl;
    }

    protected void FSM()
    {
        switch (eState)
        {
            case ESTATE.eNormal:

                break;
            case ESTATE.eWalk:
                {
                    Vector2 CurPos = this.transform.position;
                    float step = fSpeed * Time.deltaTime;
                    transform.position = Vector2.MoveTowards(CurPos, vTargetPos, step);
                    fLength -= fSpeed * Time.deltaTime;

                    if (fLength <= 0.0f)
                    {
                        eState = ESTATE.eNormal;
                        ImgChange((int)eState);
                        fLength = 0.0f;
                        vTargetPos = this.transform.position;
                    }
                }
                break;
        }
    }
}
