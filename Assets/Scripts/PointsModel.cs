using UniRx;

namespace DefaultNamespace
{
    public static class PointsModel
    {
        public static ReactiveProperty<int> YellowPoints = new();
        public static ReactiveProperty<int> GreenPoints = new();
    }
}