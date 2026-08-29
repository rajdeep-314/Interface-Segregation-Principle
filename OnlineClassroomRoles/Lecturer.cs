using System;

namespace OnlineClassroomRoles;

/// <summary>
/// Represents a lecturer role with the following permission(s):
///     - Viewing course materials.
///     - Grading students.
///     - Editing course content.
/// </summary>
public sealed class Lecturer : ICourseViewer, IGrader, ICourseEditor
{
    /// <summary>
    /// Gets the unique identifier for the lecturer.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the Lecturer class.
    /// </summary>
    /// <param name="id">The unique lecturer identifier.</param>
    /// <exception cref="ArgumentException">Thrown when id is null or whitespace.</exception>
    public Lecturer(string id)
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

        Console.WriteLine($"Lecturer {Id} viewed course {courseId}.");
    }

    /// <inheritdoc />
    public void Grade(string studentId, decimal mark)
    {
        if (string.IsNullOrWhiteSpace(studentId))
        {
            throw new ArgumentException("Student ID cannot be null or whitespace.", nameof(studentId));
        }

        if (mark < 0m || mark > 100m)
        {
            throw new ArgumentOutOfRangeException(nameof(mark), "Mark must be between 0 and 100.");
        }

        Console.WriteLine($"Lecturer {Id} graded student {studentId} with mark {mark}.");
    }

    /// <inheritdoc />
    public void UpdateCourse(string courseId, string content)
    {
        if (string.IsNullOrWhiteSpace(courseId))
        {
            throw new ArgumentException("Course ID cannot be null or whitespace.", nameof(courseId));
        }

        if (content == null)
        {
            throw new ArgumentNullException(nameof(content));
        }

        Console.WriteLine($"Lecturer {Id} updated course {courseId} with content {content}.");
    }
}
