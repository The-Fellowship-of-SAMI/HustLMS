﻿using LetterManagement.Shared.Models;

namespace LetterManagement.Server.Services;

public interface IManagerService : ICrud<Manager>
{
    public Task<Manager?> GetByManagerId(Guid id);

    public Task<List<Manager>> GetManagersByDepartmentId(Guid departmentId);
}