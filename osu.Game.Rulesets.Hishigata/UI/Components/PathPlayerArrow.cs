using System;
using System.Collections.Generic;
using System.Text;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics.Lines;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics;
using osuTK;
using osu.Game.Rulesets.Hishigata.LinearMath;
using SixLabors.Primitives;
using osuTK.Graphics;

namespace osu.Game.Rulesets.Hishigata.UI.Components
{
    public class PathPlayerArrow : SmoothPath
    {
        public PathPlayerArrow()
        {
            Anchor = Anchor.Centre;
            Origin = Anchor.TopLeft;
            PathRadius = 5;
        }

        private const float size = 30;
        private LineSegment[] segments = new[]{
            new LineSegment( new Vector2(size,0), new Vector2(0,size) ),
            new LineSegment( new Vector2(0,size), new Vector2(-size,0) ),
            new LineSegment( new Vector2(-size,0), new Vector2(0,-size) ),
            new LineSegment( new Vector2(0,-size), new Vector2(size,0) )
        };

        [BackgroundDependencyLoader]
        private void load(BindableFloat angleBindable)
        {
            angleBindable.BindValueChanged(a => redraw(a.NewValue), true);
        }

        private void redraw(float angle)
        {
            angle = angle / 180 * MathF.PI; // to radians
            ClearVertices();

            const int count = 30;
            const float radius = 100;
            for (int i = 0; i < count; i++)
            {
                float progress = i / (float)(count - 1);
                var vertexAngle = angle - (MathF.PI / 2) + progress * MathF.PI;
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
