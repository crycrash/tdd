using System.Drawing;

namespace Layouter;

class CircularCloudLayouter
{
    Point centerPoint;
    public Point Center => centerPoint;
    
    public CircularCloudLayouter(Point center){
        centerPoint = center;
    }
    public Rectangle PutNextRectangle(Size rectangleSize){
        if (rectangleSize.IsEmpty){
            throw new ArgumentNullException("rectangle is empty");
        }
        if (rectangleSize.Height <= 0 || rectangleSize.Width <= 0){
            throw new ArgumentOutOfRangeException("side less or equal zero");
        }
        return Rectangle.Empty;
    }
}