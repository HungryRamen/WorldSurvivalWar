using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obj : MonoBehaviour
{

    public enum EOBJ //오브젝트 종류 enum 부분도 마찬가지로 다른곳에 정리
    {
        ePawn,
        eItem,
        eBuild,
        eGround,
    }

    protected EOBJ eObj;
    protected Sprite[] sprites;

    public EOBJ GetObj() { return eObj; }
    public void SetObj(EOBJ eobj) { eObj = eobj; }

    public void ImgLoad(string sRoute) { sprites = Resources.LoadAll<Sprite>(sRoute); }
    public void ImgChange(int iarrcount) { this.gameObject.GetComponent<SpriteRenderer>().sprite = sprites[iarrcount]; }

    static public Vector2 Vector2Round(Vector2 vPos)   //반올림 처리
    {
        //이부분은 따로 나중에 정리하자
        return new Vector2(Mathf.Round(vPos.x), Mathf.Round(vPos.y));
    }

}
