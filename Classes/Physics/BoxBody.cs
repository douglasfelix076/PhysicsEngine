using System;
using System.Drawing;
using System.Numerics;

namespace Physics
{
    class BoxBody : PhysicsBody
    {
        public float Width;
        public float Height;
        public override RectangleF bounds => new RectangleF(position.X - Width / 2, position.Y - Height / 2, Width, Height);

        public BoxBody(Vector2 position, float size) : base(position, size * size)
        {
            Width = Height = size;
        }

        public BoxBody(float size) : base(size * size)
        {
            Width = Height = size;
        }

        public override void HandleCollision(PhysicsBody body)
        {
            if (body is CircleBody circleTarget)
            {
                // a ser adicionado

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
                // a ser adicionado
                return false;
            }
            else if (body is BoxBody boxTarget)
            {
                // teste temporario enquanto nao há um algoritmo
                // melhor para checar colisões de caixas
                return !(position.X + Width < boxTarget.position.X ||
                         position.X > boxTarget.position.X + boxTarget.Width ||
                         position.Y + Height < boxTarget.position.Y ||
                         position.Y > boxTarget.position.Y + boxTarget.Height);
            }
            return false;
        }

        public override void DrawSelf(Graphics g)
        {
            Color color = GetColor();
            g.FillRectangle(new SolidBrush(color), bounds);
        }
    }
}
