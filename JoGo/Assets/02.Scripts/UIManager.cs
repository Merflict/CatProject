using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject storeBtn;
    public GameObject walkBtn;
    public GameObject setRoomBtn;
    public GameObject inventoryBtn;
    public GameObject backBtn;

    public GameObject moreFuncEnterBtn;
    public GameObject settingBtn;
    public GameObject missionBtn;
    private int moreFuncClickCount = 0;
    private int moreFuncEnterCount = 0;

    //Setting�˾�â
    public GameObject settingPopUp;

    //Mission�˾�â
    public GameObject missionPopUp;

    public int setcamera = 0;
    private int originalcamera = 0;

    private int clickCount = 0;

    private void Update()
    {
        CheckCameraNum();
    }

    private void CheckCameraNum()
    {
        if (originalcamera != setcamera)
        {
            clickCount = 2;
            moreFuncClickCount = 2;
            SetActiveMoreFuncFalse();
            SetActiveFalse();
            moreFuncEnterBtn.SetActive(false);


        }

        if (originalcamera == setcamera)
        {
            moreFuncEnterBtn.SetActive(true);
        }
               
         
    }

    public void SetActiveTrue()
    {
        storeBtn.SetActive(true);
        walkBtn.SetActive(true);
        setRoomBtn.SetActive(true);
        inventoryBtn.SetActive(true);
        backBtn.SetActive(true);

        clickCount++;
    }

    public void SetActiveFalse()
    {
        if (clickCount == 2)
        {
            storeBtn.SetActive(false);
            walkBtn.SetActive(false);
            setRoomBtn.SetActive(false);
            inventoryBtn.SetActive(false);
            backBtn.SetActive(false);
            clickCount = 0;
        }
    }

    public void SetActiveMoreFuncTrue()
    {
        settingBtn.SetActive(true);
        missionBtn.SetActive(true);
        moreFuncClickCount++;
    }

    public void SetActiveMoreFuncFalse()
    {
        if (moreFuncClickCount == 2)
        {
            settingBtn.SetActive(false);
            missionBtn.SetActive(false);
            moreFuncClickCount = 0;
        }
    }

    //Setting �˾�â Ȱ��ȭ
    public void SetActiveSettingPopUpTrue()
    {
        settingPopUp.SetActive(true);
    }

    //Setting �˾�â ��Ȱ��ȭ
    public void SetActiveSettingPopUpFalse()
    {
        settingPopUp.SetActive(false);
    }

    //Mission �˾�â Ȱ��ȭ
    public void SetActiveMissionPopUpTrue()
    {
        missionPopUp.SetActive(true);
    }

    //Mission �˾�â ��Ȱ��ȭ
    public void SetActiveMissionPopUpFalse()
    {
        missionPopUp.SetActive(false);
    }

}
