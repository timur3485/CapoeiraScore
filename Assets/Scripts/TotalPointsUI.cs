using System;
using DefaultNamespace;
using TMPro;
using UniRx;
using UnityEngine;

public class TotalPointsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _yellowTotalText;
    [SerializeField] private TMP_Text _greenTotalText;

    private void Awake()
    {
        PointsModel.YellowPoints.Subscribe(SetYellowPoints).AddTo(this);
        PointsModel.GreenPoints.Subscribe(SetGreenPoints).AddTo(this);
    }

    public void ResetPoints()
    {
        _yellowTotalText.text = string.Empty;
        _greenTotalText.text = string.Empty;
    }

    private void SetYellowPoints(int points) => _yellowTotalText.text = points.ToString();

    private void SetGreenPoints(int points) => _greenTotalText.text = points.ToString();
}
