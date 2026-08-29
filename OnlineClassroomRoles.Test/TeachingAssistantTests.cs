using System;
using System.IO;
using Xunit;

namespace OnlineClassroomRoles.Test;

[Collection("Console Tests")]
public class TeachingAssistantTests
{
    [Fact]
    public void TypeSafety_ImplementsViewerAndGraderOnly()
    {
        var ta = new TeachingAssistant("TA01");

        Assert.IsAssignableFrom<ICourseViewer>(ta);
        Assert.IsAssignableFrom<IGrader>(ta);
        Assert.IsNotAssignableFrom<ICourseEditor>(ta);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidId_ThrowsArgumentException(string? invalidId)
    {
        Assert.Throws<ArgumentException>(() => new TeachingAssistant(invalidId!));
    }

    [Fact]
    public void ViewCourse_ValidCourseId_PrintsToConsole()
    {
        ICourseViewer viewer = new TeachingAssistant("TA01");
        TextWriter originalOut = Console.Out;
        using var stringWriter = new StringWriter();

        try
        {
            Console.SetOut(stringWriter);
            viewer.ViewCourse("CS101");

            string output = stringWriter.ToString().Trim();
            Assert.Equal("Teaching Assistant TA01 viewed course CS101.", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void ViewCourse_InvalidCourseId_ThrowsArgumentException(string? invalidCourseId)
    {
        ICourseViewer viewer = new TeachingAssistant("TA01");

        Assert.Throws<ArgumentException>(() => viewer.ViewCourse(invalidCourseId!));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(50.5)]
    [InlineData(100)]
    public void Grade_ValidMark_PrintsToConsole(decimal mark)
    {
        IGrader grader = new TeachingAssistant("TA01");
        TextWriter originalOut = Console.Out;
        using var stringWriter = new StringWriter();

        try
        {
            Console.SetOut(stringWriter);
            grader.Grade("S101", mark);

            string output = stringWriter.ToString().Trim();
            Assert.Equal($"Teaching Assistant TA01 graded student S101 with mark {mark}.", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Theory]
    [InlineData(-0.1)]
    [InlineData(100.1)]
    public void Grade_MarkOutOfRange_ThrowsArgumentOutOfRangeException(decimal invalidMark)
    {
        IGrader grader = new TeachingAssistant("TA01");

        Assert.Throws<ArgumentOutOfRangeException>(() => grader.Grade("S101", invalidMark));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Grade_InvalidStudentId_ThrowsArgumentException(string? invalidStudentId)
    {
        IGrader grader = new TeachingAssistant("TA01");

        Assert.Throws<ArgumentException>(() => grader.Grade(invalidStudentId!, 85m));
    }
}
