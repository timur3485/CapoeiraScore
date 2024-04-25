using DefaultNamespace;
using TMPro;
using UnityEngine;

public sealed class PointsUI : MonoBehaviour
{
    [SerializeField, Range(-1,3)] private int _points;
    [SerializeField] private TMP_Text _yellowLabel;
    [SerializeField] private TMP_Text _greenLabel;
    [SerializeField] private TMP_Text _pointsLabel;

    private int _yellowTotal;
    private int _greenTotal;

    private void Awake()
    {
        _pointsLabel.text = _points.ToString();
        _yellowLabel.text = string.Empty;
        _greenLabel.text = string.Empty;
    }

    public void ResetPoints()
    {
        _yellowLabel.text = string.Empty;
        _greenLabel.text = string.Empty;
        _yellowTotal = 0;
        _greenTotal = 0;
    }

    public void YellowButtonPressed()
    {
        _yellowTotal+=_points;
        PointsModel.YellowPoints.Value += _points;
        _yellowLabel.text = _yellowTotal.ToString();
    }

    public void GreenButtonPressed()
    {
        _greenTotal+=_points;
        PointsModel.GreenPoints.Value += _points;
        _greenLabel.text = _greenTotal.ToString();
    }
}
