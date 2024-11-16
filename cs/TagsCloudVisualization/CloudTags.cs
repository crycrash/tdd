using System.Drawing;

namespace TagsCloudLayouter;

class CircularCloudLayouter
{
    private Spiral spiral;
    private Point centercloud;

    private List<Rectangle> rectangles;

    public Point GetCenter => centercloud;

    public List<Rectangle> GetRectangles => rectangles;

    public CircularCloudLayouter(Point center)
    {
        this.centercloud = center;
        this.spiral = new Spiral(center);
        this.rectangles = new List<Rectangle>();
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        if (rectangleSize.IsEmpty)
        {
            throw new ArgumentNullException("rectangle is empty");
        }
        if (rectangleSize.Height <= 0 || rectangleSize.Width <= 0)
        {
            throw new ArgumentOutOfRangeException("side less or equal zero");
        }
        Rectangle tempRectangle;
        do
        {
            Point nextPoint = spiral.GetNextPoint();
            tempRectangle = new Rectangle(new Point(nextPoint.X, nextPoint.Y), rectangleSize);
        }
        while (IsRectangleIntersect(tempRectangle));
        rectangles.Add(tempRectangle);
        return tempRectangle;
    }

    private bool IsRectangleIntersect(Rectangle rectangleChecked) =>
    rectangles.Any(rectangleChecked.IntersectsWith);
}