using NUnit.Framework;
using FluentAssertions;
using System.Drawing;
using TagsCloudVisualization;


namespace TagsCloudVisualizationTests;

public class TestsCloudVisualization
{
    private CircularCloudLayouter circularCloudLayouter;

    [SetUp]
    public void SetUp()
    {
        circularCloudLayouter = new CircularCloudLayouter(new Point(0, 0));
    }

    [Test]
    public void CircularCloudLayouter_SettingCenter()
    {
        CircularCloudLayouter circularLayouter = new CircularCloudLayouter(new Point(2, 4));
        circularLayouter.CenterCloud.X.Should().Be(2);
        circularLayouter.CenterCloud.Y.Should().Be(4);
    }

    [Test]
    public void CircularCloudLayouter_StartWithoutExceptions()
    {
        Action action = new Action(() => new CircularCloudLayouter(new Point(2, 6)));
        action.Should().NotThrow();
    }

    [Test]
    public void PutNextRectangle_ThrowingWhenLengthsNegative()
    {
        Action action = new Action(() => circularCloudLayouter.PutNextRectangle(new Size(-1, -1)));
        action.Should().Throw<ArgumentOutOfRangeException>().Which.Message.Should().Contain("side less or equal zero");
    }

    [Test]
    public void PutNextRectangle_ThrowingWhenRectangleEmpty()
    {
        Action action = new Action(() => circularCloudLayouter.PutNextRectangle(Size.Empty));
        action.Should().Throw<ArgumentNullException>().Which.Message.Should().Contain("rectangle is empty");
    }

    [Test]
    public void CircularCloudLayouter_RectanglesEmptyAfterInitialization()
    {
        circularCloudLayouter.GetRectangles.Should().BeEmpty();
    }

    [Test]
    public void PutNextRectangle_PutFirstRectangle()
    {
        Size rectangleSize = new Size(3, 7);
        Rectangle expectedRectangle = new Rectangle(new Point(0, 0), rectangleSize);
        circularCloudLayouter.PutNextRectangle(rectangleSize);

        circularCloudLayouter.GetRectangles.Should().ContainSingle(x => x == expectedRectangle);
    }

    [Test]
    public void PutNextRectangle_PutSeveralRectangles()
    {
        Size rectangleSize = new Size(3, 7);
        for (int i = 0; i < 20; i++)
        {
            circularCloudLayouter.PutNextRectangle(rectangleSize);
        }
        circularCloudLayouter.GetRectangles.Should().HaveCount(20);
        circularCloudLayouter.GetRectangles.Should().AllBeOfType(typeof(Rectangle));
    }

    [Test]
    public void PutNextRectangle_SeveralRectanglesDontIntersect()
    {
        var rectanglesSizes = new List<Size>
        {
            new Size(10, 5),
            new Size(8, 8),
            new Size(12, 3),
            new Size(6, 10)
        };

        foreach (var size in rectanglesSizes)
        {
            circularCloudLayouter.PutNextRectangle(size);
        }

        List<Rectangle> rectanglesTemp = circularCloudLayouter.GetRectangles;
        for (int i = 0; i < rectanglesTemp.Count; i++)
        {
            for (int j = i + 1; j < rectanglesTemp.Count; j++)
                rectanglesTemp[i].IntersectsWith(rectanglesTemp[j]).Should().BeFalse();
        }
    }
}