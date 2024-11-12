using System.Drawing;

namespace Layouter;

class CircularCloudLayouter
{
    Spiral spiral;
    Point centercloud;

    public Point Center => centercloud;
    
    public CircularCloudLayouter(Point center){
        this.centercloud = center;
        this.spiral = new Spiral(center);
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