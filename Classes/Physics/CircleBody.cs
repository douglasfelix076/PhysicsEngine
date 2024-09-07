using System;
using System.Drawing;
using System.Numerics;

namespace Physics
{
    class CircleBody : PhysicsBody
    {
        public float Radius;
        public override RectangleF bounds => new RectangleF(position.X - Radius, position.Y - Radius, Radius * 2, Radius * 2);
        
        public CircleBody(Vector2 position, float radius) : base(position, (float)Math.PI * (radius * radius))
        {
            Radius = radius;
        }

        public CircleBody(float radius) : base((float)Math.PI * (radius * radius))
        {
            Radius = radius;
        }

        public override void HandleCollision(PhysicsBody body)
        {
            if (body is CircleBody circleTarget)
            {
                Vector2 diff = position - circleTarget.position;
                float dist = diff.Length();
                float massDifference = Mass / (Mass + circleTarget.Mass);
                float delta = (Radius + circleTarget.Radius - (float)dist) / 2;
                Move(diff / dist * delta * (1 - massDifference));
                circleTarget.Move(-diff / dist * delta * massDifference);
            }
            else if (body is BoxBody boxTarget)
            {
                // a ser adicionado
            }
        }

        public override bool IsColliding(PhysicsBody body)
        {
            if (body == this)
                return false;

            if (body is CircleBody circleTarget)
            {
                float minDistance = Radius + circleTarget.Radius;
                return (position - circleTarget.position).LengthSquared() < minDistance * minDistance && this != circleTarget;
            }
            else if (body is BoxBody boxTarget)
            {
                // a ser adicionado
            }
            return false;
        }

        public override void DrawSelf(Graphics g)
        {
            Color color = GetColor();
            g.FillEllipse(new SolidBrush(color), bounds);
            //g.DrawString(Math.Round(vel.Length(),2).ToString(), new Font("Arial", 16), new SolidBrush(Color.Black), Position.X, Position.Y, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }
    }
}
