﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRoomUICtrl : MonoBehaviour
{
    private GameObject buttonsection;
    private GameObject removebutton;
    private GameObject flist;
    private GameObject selectcircle;
    private GameObject saveimage;
    private GameObject savecomplete;

    // 현재 레이캐스트한 타겟을 받기 위한 변수
    public GameObject getTarget = null;

    // 가구제거 버튼 위치 설정을 위한 변수
    public Vector3 add;

    // 모델스 연결
    private GameObject Models;
    // 소파2 가구 연결
    public GameObject Sofa2;
    // 한번만 생성하기 위한 변수
    public bool isInstantiate = false;

    public int setcamera = 0;

    // 싱글톤
    public static MyRoomUICtrl _instance = null;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(this.gameObject);

        // 로드일때 안 사라짐
        //DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        Initialize();
    }

    private void Update()
    {
        CheckCameraNum();
        UpdateRemoveButton();
    }

    private void Initialize()
    {
        buttonsection = GameObject.Find("ButtonSection");
        removebutton = GameObject.Find("RemoveButton");
        flist = GameObject.Find("FList");
        selectcircle = GameObject.Find("MyRoomUI").transform.Find("SelectCircle").gameObject;
        saveimage = GameObject.Find("MyRoomUI").transform.Find("ButtonSection").transform.Find("SaveButton").transform.Find("SaveImage").gameObject;
        savecomplete = GameObject.Find("MyRoomUI").transform.Find("ButtonSection").transform.Find("SaveButton").transform.Find("SaveComplete").gameObject;
        Models = GameObject.Find("Models");
        removebutton.SetActive(false);
        flist.SetActive(false);

        Vector3 removebtnadd = new Vector3(114.58f, 70.82f, 0.0f);
        add = removebtnadd;
    }

    // 카메라 번호로 버튼 온오프
    void CheckCameraNum()
    {
        if (setcamera == 0)
        {
            buttonsection.SetActive(false);
            flist.SetActive(false);
            saveimage.SetActive(false);
            savecomplete.SetActive(false);
            selectcircle.SetActive(false);
        }
        else if (setcamera == 1)
        {
            buttonsection.SetActive(true);
        }
    }

    // 가구 제거 버튼 위치 설정, 활성화 여부 설정
    void UpdateRemoveButton()
    {
        removebutton.transform.position = new Vector3(selectcircle.transform.position.x, selectcircle.transform.position.y, removebutton.transform.position.z) + add;

        if (selectcircle.activeSelf == true)
            removebutton.SetActive(true);
        else
            removebutton.SetActive(false);
    }

    // 가구 추가 버튼 클릭
    public void OnTouchAddFButton()
    {
        if (saveimage.activeSelf || savecomplete.activeSelf)
            return;

        if (!flist.activeSelf)
            flist.SetActive(true);
        else
            flist.SetActive(false);
    }

    // 가구 저장 버튼 클릭
    public void OnTouchSaveButton()
    {
        if (!savecomplete.activeSelf)
        {
            selectcircle.SetActive(false);
            removebutton.SetActive(false);
            flist.SetActive(false);
            saveimage.SetActive(true);
        }
    }

    // 가구 제거 버튼 클릭
    public void OnTouchRemoveButton()
    {
        Destroy(getTarget);
        selectcircle.SetActive(false);
    }

    // 가구 저장 수락 버튼 클릭
    public void OnTouchYesButton()
    {
        saveimage.SetActive(false);
        savecomplete.SetActive(true);

        int objectctrlslength = GameObject.Find("MyRoomMgr").GetComponent<MyRoomMgrCtrl>().objectctrlsLength;

        for (int i = 0; i < objectctrlslength; i++)
        {
            GameObject.Find("MyRoomMgr").GetComponent<MyRoomMgrCtrl>().objectCtrls[i].objectPos = GameObject.Find("MyRoomMgr").GetComponent<MyRoomMgrCtrl>().objectCtrls[i].transform.position;
        }
    }

    // 가구 저장 취소 버튼 클릭
    public void OnTouchNoButton()
    {
        saveimage.SetActive(false);

        int objectctrlslength = GameObject.Find("MyRoomMgr").GetComponent<MyRoomMgrCtrl>().objectctrlsLength;

        for (int i = 0; i < objectctrlslength; i++)
        {
            GameObject.Find("MyRoomMgr").GetComponent<MyRoomMgrCtrl>().objectCtrls[i].transform.position = GameObject.Find("MyRoomMgr").GetComponent<MyRoomMgrCtrl>().objectCtrls[i].objectPos;
        }
    }

    // 가구 저장 확인 버튼 클릭
    public void OnTouchConfirmButton()
    {
        savecomplete.SetActive(false);
    }

    // 가구 클릭시 특정 위치에 생성
    public void OnTouchF1()
    {
        if (!isInstantiate)
        {
            GameObject instance = Instantiate(Sofa2, Sofa2.transform.position, Sofa2.transform.rotation);
            instance.transform.parent = Models.transform;
            isInstantiate = true;
        }

        flist.SetActive(false);
    }

    public void OnTouchF2()
    {
        flist.SetActive(false);
    }

    public void OnTouchF3()
    {
        flist.SetActive(false);
    }

    public void OnTouchF4()
    {
        flist.SetActive(false);
    }

}