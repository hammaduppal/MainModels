
using MainModels.Models;

namespace MainModels.DTOModels
{
    public enum ProjectTaskPriority
    {
        Low,
        Normal,
        High
    }
    public class UserWorkloadReportVM
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public int BacklogCount { get; set; }    // Tasks in "To-Do / New" columns
        public int InProgressCount { get; set; } // Tasks in "In Development / Active" columns
        public int ReviewCount { get; set; }     // Tasks in "QA / Code Review"
        public int CompletedCount { get; set; }  // Tasks in "Done"
        public int TotalAssigned => BacklogCount + InProgressCount + ReviewCount + CompletedCount;

        public int QACount { get; set; }
    }
    public class ProjectReportVM
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int TotalTasks { get; set; }
        public int CompletedTasks { get; set; }
        public int OverdueTasks { get; set; }
        public double CompletionPercentage => TotalTasks > 0 ? ((double)CompletedTasks / TotalTasks) * 100 : 0;
        public string HealthStatus => OverdueTasks > 0 ? "At Risk" : (TotalTasks == 0 ? "Stale" : "On Track");
    }
    public partial class ProjectVM
    {
        public Guid ProjectId { get; set; }

        public Guid? BranchId { get; set; }

        public string ProjectName { get; set; }

        public string ProjectCode { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string ColorCode { get; set; }

        public string Icon { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsModified { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public virtual BranchVM Branch { get; set; }

        public virtual ICollection<ProjectColumnVM> ProjectColumns { get; set; } = new List<ProjectColumnVM>();

        public virtual ICollection<ProjectUserVM> ProjectUsers { get; set; } = new List<ProjectUserVM>();



    }
    public partial class ProjectColumnVM
    {
        public Guid ColumnId { get; set; }

        public Guid? ProjectId { get; set; }

        public string ColumnName { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsModified { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public virtual ProjectVM Project { get; set; }

        public virtual ICollection<ProjectTaskVM> ProjectTasks { get; set; } = new List<ProjectTaskVM>();
    }
    public class UpdateTaskDescriptionVM
    {
        public Guid TaskId { get; set; }
        public string? Description { get; set; }

    }
    public class AddUserByEmailModel
    {
        public Guid ProjectId { get; set; }
        public string Email { get; set; }
    }
    public class AssignUserModel
    {
        public Guid TaskId { get; set; }
        public int UserId { get; set; }
    }
    public class AssignProjectUserModel
    {
        public Guid ProjectId { get; set; }
        public int UserId { get; set; }
    }
    public partial class ProjectTaskVM
    {
        public Guid TaskId { get; set; }

        public Guid? ProjectId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public int? TaskNumber { get; set; }

        public string Priority { get; set; }

        public string Status { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal? EstimatedHours { get; set; }

        public decimal? ActualHours { get; set; }

        public int? SortOrder { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsModified { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public Guid? ColumnId { get; set; }

        public virtual ProjectColumnVM Column { get; set; }

        public virtual ICollection<TaskAssignedUserVM> TaskAssignedUsers { get; set; } = new List<TaskAssignedUserVM>();
        public virtual ICollection<TaskAttachmentVM> TaskAttachments { get; set; } = new List<TaskAttachmentVM>();
        public virtual ICollection<TaskCommentVM> TaskComments { get; set; } = new List<TaskCommentVM>();
        public string ColumnName { get; set; }
    }
    public partial class ProjectUserVM
    {
        public Guid ProjectUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? ProjectId { get; set; }

        public int? UserId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ProjectVM Project { get; set; }

        public virtual LoginUserVM User { get; set; }
        public string ImageUrl { get; set; }
    }
    public partial class TaskAttachmentVM
    {
        public Guid TaskAttachmentId { get; set; }

        public string AttachmentUrl { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public Guid? TaskId { get; set; }

        public int? UserId { get; set; }

        public virtual ProjectTaskVM Task { get; set; }
    }
    public partial class TaskCommentVM
    {
        public Guid TaskCommentId { get; set; }

        public string TaskComments { get; set; }

        public Guid? TaskId { get; set; }

        public int? UserId { get; set; }

        public DateTime? CreatedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public virtual ProjectTaskVM Task { get; set; }
    }
    public partial class TaskAssignedUserVM
    {
        public Guid TaskAssignedUserId { get; set; }

        public Guid? TaskId { get; set; }

        public DateTime? AssignedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsModified { get; set; }

        public bool? IsDeleted { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UserId { get; set; }

        public virtual ProjectTaskVM Task { get; set; }

        public virtual LoginUserVM User { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ImageUrl { get; set; }
        public string Email { get; set; }
    }
    public class DeleteColumnModel
    {
        public Guid ColumnId { get; set; }
    }
    public class RenameColumnModel
    {
        public Guid ColumnId { get; set; }
        public string ColumnName { get; set; }
    }
    public class CreateColumnModel { public Guid ProjectId { get; set; } public string ColumnName { get; set; } }
    public class CreateTaskModel { public Guid ColumnId { get; set; } public string Title { get; set; } }
    public class SortBoardModel { public Guid[] SortedColumnIds { get; set; } }
    public class SortTasksModel { public Guid TargetColumnId { get; set; } public Guid[] SortedTaskIds { get; set; } }
    //public class AssignUserModel { public Guid TaskId { get; set; } public int UserId { get; set; } }



}
