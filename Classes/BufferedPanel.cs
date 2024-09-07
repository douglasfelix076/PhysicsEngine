using System.Windows.Forms;

class BufferedPanel : Panel
{
    // esse BufferedPanel é usado para impedir alguns problemas visuais do painel padrão
    public BufferedPanel() : base()
    {
        DoubleBuffered = true;
        ResizeRedraw = true;
    }
}