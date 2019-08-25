﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MTFrame;
using UnityEngine.UI;
using Es.InkPainter.Sample;


public class GamePanel : BasePanel
{
    public static Transform CurrentModel = null;

    public ChooseUIPanel chooseuipanel;
    public GameUIPanel gameuiPanel;

    public override void InitFind()
    {
        base.InitFind();
        chooseuipanel = FindTool.FindChildComponent<ChooseUIPanel>(transform, "ChooseUIPanel");
        gameuiPanel = FindTool.FindChildComponent<GameUIPanel>(transform, "GameUIPanel");

    }

    public override void Open()
    {
        base.Open();
        gameuiPanel.Hide();
        gameuiPanel.completePanel.Hide();
        InitModel();
    }

    //public void rotation_left()
    //{
    //    CurrentModel.transform.eulerAngles += new Vector3(0, 0, 5);
    //}

    //public void ratation_right()
    //{
  
    //    CurrentModel.transform.eulerAngles -= new Vector3(0, 0, 5);
    //}


    public void InitModel()
    {
        ImageAddListen(chooseuipanel.ImageButtonGroup, 0);
        //ModelViewControls.Instance.Reset();
        ModelControl.Instance.CloseModel();
        ModelControl.Instance.ModelGroup[0].gameObject.SetActive(true);
        CurrentModel = ModelControl.Instance.ModelGroup[0];
        chooseuipanel.ChooseIngImage.localPosition = new Vector3(-260.4f, 324,0);
    }


    void InitButtons(Button btn,int i,int index)
    {
        btn.onClick.AddListener(delegate () {
            foreach (Transform item in ModelControl.Instance.ModelGroup)
            {
                item.gameObject.SetActive(false);
            }
            //Debug.LogFormat("i=={0},index=={1},i+index=={2}", i, index, i + index);
            ModelControl.Instance.ModelGroup[i + index].gameObject.SetActive(true);
            CurrentModel = ModelControl.Instance.ModelGroup[i + index];
            chooseuipanel.ChooseIngImage.DOLocalMoveX(chooseuipanel.ChooseIngImageX[i], 0.5f);
        });
    }

    public  void ImageAddListen(Button[] buttons,int index)
    {
        foreach (Button item in buttons)
        {
            item.onClick.RemoveAllListeners();
        }
        for (int i = 0; i < buttons.Length; i++)
        {
            InitButtons(buttons[i], i, index);
        }
    }


}
