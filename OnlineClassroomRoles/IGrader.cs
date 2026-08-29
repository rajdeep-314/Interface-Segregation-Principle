namespace OnlineClassroomRoles;

/// <summary>
/// Defines capabilities for grading students.
/// </summary>
public interface IGrader
{
    /// <summary>
    /// Assigns to the student with the argument student identifier a grade equal to the argument grade.
    /// </summary>
    /// <param name="studentId">Unique identifier for the student.</param>
    /// <param name="mark">Marks being assigned to the student.</param>
    void Grade(string studentId, decimal mark);
}
