using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LotteryPanel : BasePanel
{
    private Transform UIClose;
    private Transform UICenter;
    private Transform UILottery10;
    private Transform UILottery1;
    private GameObject LotteryCellPrefab;

    protected override void Awake()
    {
        base.Awake();
        InitUI();
        InitPrefab();

    }

    private void Start()
    {
        // �򿪾�ִ����
        //OnLottery10Btn();
    }


    private void InitUI()
    {
        UIClose = transform.Find("TopRight/Close");
        UICenter = transform.Find("Center");
        UILottery10 = transform.Find("Bottom/Lottery10");
        UILottery1 = transform.Find("Bottom/Lottery1");
        UILottery10.GetComponent<Button>().onClick.AddListener(OnLottery10Btn);
        UILottery1.GetComponent<Button>().onClick.AddListener(OnLottery1Btn);

        UIClose.GetComponent<Button>().onClick.AddListener(OnClose);
    }

    private void InitPrefab()
    {
        LotteryCellPrefab = Resources.Load("Prefabs/Panel/Lottery/LotteryItem") as GameObject;
    }

    private void OnLottery1Btn()
    {
        print(">>>>>>>>>>>> OnLottery1Btn");
        // ����ԭ���Ŀ�Ƭ
        for (int i = 0; i < UICenter.childCount; i++)
        {
            Destroy(UICenter.GetChild(i).gameObject);
        }
        // �鿨���һ���µ���Ʒ
        PackageLocalItem item = GameManager.Instance.GetLotteryRandom1();

        Transform LotteryCellTran = Instantiate(LotteryCellPrefab.transform, UICenter) as Transform;
        // �Կ�Ƭ����Ϣչʾˢ��
        LotteryCell lotteryCell = LotteryCellTran.GetComponent<LotteryCell>();
        lotteryCell.Refresh(item, this);
    }

    private void OnLottery10Btn()
    {
        print(">>>>>>>>>> OnLottery10Btn");
        List<PackageLocalItem> packageLocalItems = GameManager.Instance.GetLotteryRandom10(sort: true);
        for (int i = 0; i < UICenter.childCount; i++)
        {
            Destroy(UICenter.GetChild(i).gameObject);
        }

        foreach (PackageLocalItem item in packageLocalItems)
        {
            Transform LotteryCellTran = Instantiate(LotteryCellPrefab.transform, UICenter) as Transform;
            // �Կ�Ƭ����Ϣչʾˢ��
            LotteryCell lotteryCell = LotteryCellTran.GetComponent<LotteryCell>();
            lotteryCell.Refresh(item, this);
        }
    }

    private void OnClose()
    {
        print(">>>>>>>>> OnClose");
        ClosePanel();
        UIManager.Instance.OpenPanel(UIConst.MainPanel);
    }
}