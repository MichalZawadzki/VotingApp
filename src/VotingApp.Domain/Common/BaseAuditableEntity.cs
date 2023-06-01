using System;

namespace VotingApp.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; protected set; }

    public string? CreatedBy { get; protected set; }

    public DateTime? LastModified { get; protected set; }

    public string? LastModifiedBy { get; protected set; }

    public void SetCreationAuditableData(string? createdBy, DateTime createdAt)
    {
        this.CreatedBy = createdBy;
        this.Created = createdAt;
    }

    public void SetUpdatingAuditableData(string? updatedBy, DateTime updatedAt)
    {
        this.CreatedBy = updatedBy;
        this.Created = updatedAt;
    }
}
