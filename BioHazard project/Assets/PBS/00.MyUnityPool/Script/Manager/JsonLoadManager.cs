using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonLoadManager : Singleton<JsonLoadManager>    //싱글톤화 해야함
{
    List<float> JDamageList;    // 게임 내에 모든 초기 데미지 값
    List<SaveAndLoadData> JSaveLoad;    // 게임 내에 플레이어 SaveLoad 데이터 슬롯이 5개이니
    List<GameObject> JActiveArea;   // 게임 내에 액션 키를 눌렀을 때 활성화되는 월드 위치와 각도 값 그리고 다음 행동? 도착 위치?

    private void Awake()
    {
        JDamageList = new List<float>();
        JSaveLoad = new List<SaveAndLoadData>();

        //여기에 데이터들 불러오기
    }

    public void GetLoadData(int num)
    {

    }
    public void SetSaveData(int num)
    {

    }
}

public class SaveAndLoadData
{
    private int SaveNum;
    private SavePoint SaveWhere;

    // 인벤토리 (아이템)
    // 캐릭터 현재 스텟 (체력, 맵?)
    // 맵 내 (한 에어리어) 에 주변 좀비 수? (오브젝트 풀링과는 별개 여긴 체크만)
    // 퍼즐의 클리어 유무
}

public enum SavePoint
{
    None = 0, Shop, PoliceCenter, StarsOffice
}

public enum SavePuzzle
{

}