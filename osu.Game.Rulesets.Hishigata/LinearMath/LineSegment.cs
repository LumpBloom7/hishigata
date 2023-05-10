using System;
using osuTK;

namespace osu.Game.Rulesets.Hishigata.LinearMath
{
    public struct LineSegment
    {
        public float Dx => PointA.X - PointB.X;
        public float Dy => PointA.Y - PointB.Y;

        public readonly Vector2 PointA;
        public readonly Vector2 PointB;

        public LineSegment(Vector2 a, Vector2 b)
        {
            PointA = a;
            PointB = b;
        }

        public bool TryIntersect(LineSegment other, out Vector2 point)
        {
            if (Dx == 0 || other.Dx == 0)
            {
                float m1 = Dx / Dy;
                float m2 = other.Dx / other.Dy;

                float b1 = PointA.X - (m1 * PointA.Y);
                float b2 = other.PointA.X - (m2 * other.PointA.Y);

                float y = (b2 - b1) / (m1 - m2);
                point = new Vector2((m1 * y) + b1, y);
            }
            else
            {
                float m1 = Dy / Dx;
                float m2 = other.Dy / other.Dx;

                float b1 = PointA.Y - (m1 * PointA.X);
                float b2 = other.PointA.Y - (m2 * other.PointA.X);

                float x = (b2 - b1) / (m1 - m2);
                point = new Vector2(x, (m1 * x) + b1);
            }

            return isInBounds(point) && other.isInBounds(point);
        }

        private readonly bool isInBounds(Vector2 point)
            => point.X > Math.Min(PointA.X, PointB.X)
            && point.X < Math.Max(PointA.X, PointB.X)
            && point.Y > Math.Min(PointA.Y, PointB.Y)
            && point.Y < Math.Max(PointA.Y, PointB.Y);
    }
}
