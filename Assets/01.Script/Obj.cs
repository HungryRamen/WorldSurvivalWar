using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{

    protected enum EOBJ //오브젝트 종류
    {
        ePawn,
        eItem,
        eBuild,
        eGround,
    }

    private bool bDirection; //왼쪽FALSE 오른쪽 TRUE
    private EOBJ eObj;
    private Sprite[] sprites;


    protected bool IsDirection() { return bDirection; }

    protected EOBJ GetObj() { return eObj; }
    protected void SetObj(EOBJ eobj) { eObj = eobj; }

    protected void ImgLoad(string sRoute) { sprites = Resources.LoadAll<Sprite>(sRoute); }
    protected void ImgChange(int iarrcount) { this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[iarrcount]; }

    void Awake()
    {
        bDirection = true;
    }
	

    protected Vector3 Flip(Vector3 vScl) //좌우 반전 함수
    {
        bDirection = !bDirection;
        vScl.x *= -1;
        return vScl;
    }

    protected Vector2 Vector2Round(Vector2 vPos)   //반올림 처리
    {
        return new Vector2(Mathf.Round(vPos.x), Mathf.Round(vPos.y));
    }

}
