﻿using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace VirtualStore.Identity.Core.Repositories;

public class BaseRepository
{
    private readonly IConfiguration _configuration;

    public BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection GetConnection()
    {
        string connectionString = _configuration["IdentityConnectionString"];
        NpgsqlConnection connection = new(connectionString);
        connection.Open();
        return connection;
    }
}