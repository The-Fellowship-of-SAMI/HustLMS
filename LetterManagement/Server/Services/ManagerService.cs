﻿using LetterManagement.Server.Repositories;
using LetterManagement.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace LetterManagement.Server.Services;

public class ManagerService : IManagerService
{
    private readonly DataContext _context;

    public ManagerService(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Manager>> getAll()
    {
        return null;
    }

    public async Task<Manager> create(Manager tDto)
    {
        return null;
    }

    public async Task<Manager> update(Guid id, Manager tNew)
    {
        return null;
    }

    public async Task<Manager> delete(Manager t)
    {
        return null;
    }

    public async Task<Manager?> GetByManagerId(Guid id)
    {
        var manager = await this._context.Manager.
            Include(x => x.Department).
            SingleOrDefaultAsync(x => x.Id == id);
        if (manager is null)
            return null;
        return manager;
    }
    
}