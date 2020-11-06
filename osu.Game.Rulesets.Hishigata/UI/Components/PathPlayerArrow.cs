using System;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Lines;
using osu.Framework.Graphics;
using osuTK;
using osu.Game.Rulesets.Hishigata.LinearMath;
using System.Diagnostics;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public class PathPlayerArrow : SmoothPath
    {
        public PathPlayerArrow()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.TopLeft;
            PathRadius = 5;

            AutoSizeAxes = Axes.None;
            Size = new Vector2((PathRadius + size) * 2);

            angle.BindValueChanged(x => redraw());
            arc.BindValueChanged(x => redraw());

            redraw();
        }

        private const float size = 30;
        private LineSegment[] segments = new[]{
            new LineSegment( new Vector2(size,0), new Vector2(0,size) ),
            new LineSegment( new Vector2(0,size), new Vector2(-size,0) ),
            new LineSegment( new Vector2(-size,0), new Vector2(0,-size) ),
            new LineSegment( new Vector2(0,-size), new Vector2(size,0) )
        };

        private const float deg_to_rad = MathF.PI / 180;
        private BindableFloat arc = new BindableFloat(180);
        private BindableFloat angle = new BindableFloat(0);

        public void ChangeRotation(float angle, Easing easing = Easing.None)
        {
            FinishTransforms();

            if (Math.Abs(angle - this.angle.Value) % 360 == 180)
            {
                this.TransformBindableTo(arc, 360, 25, easing)
                    .Then()
                    .TransformBindableTo(arc, 180, 25, easing)
                    .TransformBindableTo(this.angle, angle);
            }
            else
            {
                this.TransformBindableTo(this.angle, angle, 50, easing);
            }
        }

        private void redraw()
        {
            ClearVertices();

            const int count = 60;
            const float radius = 100;
            for (int i = 0; i < count; i++)
            {
                float progress = i / (float)(count - 1);
                var vertexAngle = (angle.Value - (arc.Value / 2) + (progress * arc.Value)) * deg_to_rad;
                LineSegment ray = new LineSegment(Vector2.Zero, new Vector2(MathF.Sin(vertexAngle) * radius, -MathF.Cos(vertexAngle) * radius));

                foreach (var segment in segments)
                {
                    if (ray.TryIntersect(segment, out var point))
                    {
                        AddVertex(point);
                        continue; // dont intersect 2 at once
                    }
                }
            }

            Position = -PositionInBoundingBox(Vector2.Zero);
        }
    }
}
