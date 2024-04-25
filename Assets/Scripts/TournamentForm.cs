using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class TournamentForm : MonoBehaviour
{
    [SerializeField] private Timer _timerUI;
    [SerializeField] private List<PointsUI> _points;
    [SerializeField] private TotalPointsUI _totalPointsUI;

    public void ResetForm()
    {
        _timerUI.ResetClicked();
        foreach (var points in _points)
        {
            points.ResetPoints();
        }
        _totalPointsUI.ResetPoints();

        PointsModel.YellowPoints.Value = 0;
        PointsModel.GreenPoints.Value = 0;
    }
}
