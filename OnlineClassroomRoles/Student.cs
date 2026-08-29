using System;

namespace OnlineClassroomRoles;

/// <summary>
/// Represents a student role with the following permission(s):
///     - Viewing course materials.
/// </summary>
public sealed class Student : ICourseViewer
{
    /// <summary>
    /// Gets the unique identifier for the student.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the Student class.
    /// </summary>
    /// <param name="id">The unique student identifier.</param>
    /// <exception cref="ArgumentException">Thrown when id is null or whitespace.</exception>
    public Student(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentException("ID cannot be null or whitespace.", nameof(id));
        }

        Id = id;
    }

    /// <inheritdoc />
    public void ViewCourse(string courseId)
    {
        if (string.IsNullOrWhiteSpace(courseId))
        {
            throw new ArgumentException("Course ID cannot be null or whitespace.", nameof(courseId));
        }

        Console.WriteLine($"Student {Id} viewed course {courseId}.");
    }
}
