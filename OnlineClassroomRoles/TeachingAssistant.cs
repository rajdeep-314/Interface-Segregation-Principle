using System;

namespace OnlineClassroomRoles;

/// <summary>
/// Represents a teaching assistant role with the following permission(s):
///     - Viewing course materials.
///     - Grading students.
/// </summary>
public sealed class TeachingAssistant : ICourseViewer, IGrader
{
    /// <summary>
    /// Gets the unique identifier for the teaching assistant.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the TeachingAssistant class.
    /// </summary>
    /// <param name="id">The unique teaching assistant identifier.</param>
    /// <exception cref="ArgumentException">Thrown when id is null or whitespace.</exception>
    public TeachingAssistant(string id)
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

        Console.WriteLine($"Teaching Assistant {Id} viewed course {courseId}.");
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

        Console.WriteLine($"Teaching Assistant {Id} graded student {studentId} with mark {mark}.");
    }
}
