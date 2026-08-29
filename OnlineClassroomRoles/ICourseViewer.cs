namespace OnlineClassroomRoles;

/// <summary>
/// Defines capabilities for viewing course materials.
/// </summary>
public interface ICourseViewer
{
    /// <summary>
    /// Views the course content for the specified course identifier.
    /// </summary>
    /// <param name="courseId">Unique identifier for the course.</param>
    void ViewCourse(string courseId);
}
