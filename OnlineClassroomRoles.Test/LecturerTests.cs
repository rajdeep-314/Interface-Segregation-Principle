using System;
using System.IO;
using Xunit;

namespace OnlineClassroomRoles.Test;

[Collection("Console Tests")]
public class LecturerTests
{
    [Fact]
    public void TypeSafety_ImplementsAllInterfaces()
    {
        var lecturer = new Lecturer("L01");

        Assert.IsAssignableFrom<ICourseViewer>(lecturer);
        Assert.IsAssignableFrom<IGrader>(lecturer);
        Assert.IsAssignableFrom<ICourseEditor>(lecturer);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidId_ThrowsArgumentException(string? invalidId)
    {
        Assert.Throws<ArgumentException>(() => new Lecturer(invalidId!));
    }

    [Fact]
    public void ViewCourse_ValidCourseId_PrintsToConsole()
    {
        ICourseViewer viewer = new Lecturer("L01");
        TextWriter originalOut = Console.Out;
        using var stringWriter = new StringWriter();

        try
        {
            Console.SetOut(stringWriter);
            viewer.ViewCourse("CS101");

            string output = stringWriter.ToString().Trim();
            Assert.Equal("Lecturer L01 viewed course CS101.", output);
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
        ICourseViewer viewer = new Lecturer("L01");

        Assert.Throws<ArgumentException>(() => viewer.ViewCourse(invalidCourseId!));
    }

    [Fact]
    public void Grade_ValidMark_PrintsToConsole()
    {
        IGrader grader = new Lecturer("L01");
        TextWriter originalOut = Console.Out;
        using var stringWriter = new StringWriter();

        try
        {
            Console.SetOut(stringWriter);
            grader.Grade("S101", 95m);

            string output = stringWriter.ToString().Trim();
            Assert.Equal("Lecturer L01 graded student S101 with mark 95.", output);
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
        IGrader grader = new Lecturer("L01");

        Assert.Throws<ArgumentOutOfRangeException>(() => grader.Grade("S101", invalidMark));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Grade_InvalidStudentId_ThrowsArgumentException(string? invalidStudentId)
    {
        IGrader grader = new Lecturer("L01");

        Assert.Throws<ArgumentException>(() => grader.Grade(invalidStudentId!, 85m));
    }

    [Fact]
    public void UpdateCourse_ValidInput_PrintsToConsole()
    {
        ICourseEditor editor = new Lecturer("L01");
        TextWriter originalOut = Console.Out;
        using var stringWriter = new StringWriter();

        try
        {
            Console.SetOut(stringWriter);
            editor.UpdateCourse("CS101", "Updated Syllabus Content");

            string output = stringWriter.ToString().Trim();
            Assert.Equal("Lecturer L01 updated course CS101 with content Updated Syllabus Content.", output);
        }
        finally
        {
            Console.SetOut(originalOut);
        }
    }

    [Fact]
    public void UpdateCourse_NullContent_ThrowsArgumentNullException()
    {
        ICourseEditor editor = new Lecturer("L01");

        Assert.Throws<ArgumentNullException>(() => editor.UpdateCourse("CS101", null!));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void UpdateCourse_InvalidCourseId_ThrowsArgumentException(string? invalidCourseId)
    {
        ICourseEditor editor = new Lecturer("L01");

        Assert.Throws<ArgumentException>(() => editor.UpdateCourse(invalidCourseId!, "Updated Syllabus Content"));
    }
}
