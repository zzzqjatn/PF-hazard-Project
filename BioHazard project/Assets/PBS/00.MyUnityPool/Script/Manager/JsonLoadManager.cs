using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JsonLoadManager : Singleton<JsonLoadManager>
{
    List<float> JDamageList;    // 게임 내에 모든 초기 데미지 값
    List<SaveAndLoadData> JSaveLoad;    // 게임 내에 플레이어 SaveLoad 데이터 슬롯이 5개이니
    List<GameObject> JActiveArea;   // 게임 내에 액션 키를 눌렀을 때 활성화되는 월드 위치와 각도 값 그리고 다음 행동? 도착 위치?
    public List<CameraData> JCameraData;   // 게임 내에 카메라 데이터

    protected override void Init()
    {
        JDamageList = new List<float>();
        JSaveLoad = new List<SaveAndLoadData>();
        JCameraData = new List<CameraData>();
        //여기에 데이터들 불러오기
    }

    // Json 형식 데이터 저장 & 로드

    public void GetLoadData(int num)
    {
        string Save_data_Dir = Application.dataPath + "/Resources/PBS/JsonData/";
        string Save_File_Name = "CameraData" + num + ".json";

        string stringListJson = File.ReadAllText(Save_data_Dir + Save_File_Name);
        List<CameraData> stringListFromJson = JsonUtility.FromJson<jsonableListWrapper<CameraData>>(stringListJson).list;
    }
    public void SetSaveData(int num)
    {
        Vector3 vtemp = new Vector3(1, 1, 1);
        Vector3 rtemp = new Vector3(2, 2, 2);
        float[] ftemp = new float[8] { 31, 26, 12, 231, 1231, 2, 23, 111 };
        CameraData temp = new CameraData(vtemp, rtemp, ftemp);
        JCameraData.Add(temp);

        vtemp = new Vector3(23, 11, 1451);
        rtemp = new Vector3(77, 89, 3544);
        ftemp = new float[8] { 31, 26, 12, 231, 1231, 2, 23, 111 };
        temp = new CameraData(vtemp, rtemp, ftemp);
        JCameraData.Add(temp);

        string Save_data_Dir = Application.dataPath + "/Resources/PBS/JsonData/";
        string Save_File_Name = "CameraData" + num + ".json";

        if (JCameraData.Count > 0)
        {
            string stringListJson = JsonUtility.ToJson(new jsonableListWrapper<CameraData>(JCameraData));
            File.WriteAllText(Save_data_Dir + Save_File_Name, stringListJson);
        }
    }
}

[System.Serializable]
public class jsonableListWrapper<T>
{
    public List<T> list;
    public jsonableListWrapper(List<T> list) => this.list = list;
}

public class SaveAndLoadData
{
    private int SaveNum;
    private SavePoint SaveWhere;

    // 인벤토리 (아이템)
    // 캐릭터 현재 스텟 (체력, 맵? , 위치, 방향)
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