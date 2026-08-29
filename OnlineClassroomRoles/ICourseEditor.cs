namespace OnlineClassroomRoles;

/// <summary>
/// Defines capabilities for editing course content.
/// </summary>
public interface ICourseEditor
{
    /// <summary>
    /// Updates the course content for the specified course identifier.
    /// </summary>
    /// <param name="courseId">Unique identifier for the course.</param>
    /// <param name="content">New course content.</param>
    void UpdateCourse(string courseId, string content);
}
