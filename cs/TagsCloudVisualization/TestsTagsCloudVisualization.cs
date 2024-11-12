using NUnit.Framework;
using FluentAssertions;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Layouter;

public class Tests
{

    CircularCloudLayouter circularCloudLayouter;
    [SetUp]
    public void SetUp(){
        circularCloudLayouter = new CircularCloudLayouter(new Point(0, 0));
    }

    [Test]
    public void CheckForSettingCenter()
    {
        CircularCloudLayouter circularLayouter = new CircularCloudLayouter(new Point(2, 4));
        circularLayouter.Center.X.Should().Be(2);
        circularLayouter.Center.Y.Should().Be(4);
    }

    [Test]
    public void CheckForStartWithoutExceptions(){
        Action action = new Action(() => new CircularCloudLayouter(new Point(2, 6)));
        action.Should().NotThrow();
    }

    [Test]
    public void CheckForThrowingWhenLengthsNegative(){
        Action action = new Action(() => circularCloudLayouter.PutNextRectangle(new Size(-1, -1)));
        action.Should().Throw<ArgumentOutOfRangeException>().Which.Message.Should().Contain("side less or equal zero");
    }

    [Test]
    public void CheckForThrowingWhenRectangleEmpty(){
        Action action = new Action(() => circularCloudLayouter.PutNextRectangle(Size.Empty));
        action.Should().Throw<ArgumentNullException>().Which.Message.Should().Contain("rectangle is empty");
    }
}