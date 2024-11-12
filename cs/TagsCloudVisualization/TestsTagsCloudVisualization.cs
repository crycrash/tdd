using NUnit.Framework;
using FluentAssertions;
using System.Drawing;

namespace Layouter;

public class TestsCloudVisualization
{

    CircularCloudLayouter circularCloudLayouter;
    [SetUp]
    public void SetUp(){
        circularCloudLayouter = new CircularCloudLayouter(new Point(0, 0));
    }

    [Test]
    public void CircularCloudLayouter_SettingCenter()
    {
        CircularCloudLayouter circularLayouter = new CircularCloudLayouter(new Point(2, 4));
        circularLayouter.Center.X.Should().Be(2);
        circularLayouter.Center.Y.Should().Be(4);
    }

    [Test]
    public void CircularCloudLayouter_StartWithoutExceptions(){
        Action action = new Action(() => new CircularCloudLayouter(new Point(2, 6)));
        action.Should().NotThrow();
    }

    [Test]
    public void PutNextRectangle_ThrowingWhenLengthsNegative(){
        Action action = new Action(() => circularCloudLayouter.PutNextRectangle(new Size(-1, -1)));
        action.Should().Throw<ArgumentOutOfRangeException>().Which.Message.Should().Contain("side less or equal zero");
    }

    [Test]
    public void PutNextRectangle_ThrowingWhenRectangleEmpty(){
        Action action = new Action(() => circularCloudLayouter.PutNextRectangle(Size.Empty));
        action.Should().Throw<ArgumentNullException>().Which.Message.Should().Contain("rectangle is empty");
    }

}