﻿namespace InnoGotchi.Core.Entities.DataTransferObject;

public class CollaborationForCreationDto
{
    public required Guid FarmId { get; set; }

    public Guid? UserId { get; set; }
}
