using System;
using System.IO;
using Xunit;

namespace OnlineClassroomRoles.Test;

[Collection("Console Tests")]
public class StudentTests
{
    [Fact]
    public void TypeSafety_ImplementsCourseViewerOnly()
    {
        var student = new Student("S101");

        Assert.IsAssignableFrom<ICourseViewer>(student);
        Assert.IsNotAssignableFrom<IGrader>(student);
        Assert.IsNotAssignableFrom<ICourseEditor>(student);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Constructor_InvalidId_ThrowsArgumentException(string? invalidId)
    {
        Assert.Throws<ArgumentException>(() => new Student(invalidId!));
    }

    [Fact]
    public void ViewCourse_ValidCourseId_PrintsToConsole()
    {
        ICourseViewer viewer = new Student("S101");
        TextWriter originalOut = Console.Out;
        using var stringWriter = new StringWriter();

        try
        {
            Console.SetOut(stringWriter);
            viewer.ViewCourse("CS101");

            string output = stringWriter.ToString().Trim();
            Assert.Equal("Student S101 viewed course CS101.", output);
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
        ICourseViewer viewer = new Student("S101");

        Assert.Throws<ArgumentException>(() => viewer.ViewCourse(invalidCourseId!));
    }
}
