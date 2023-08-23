﻿using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace VirtualStore.Catalog.Core.Repositories;

public class BaseRepository
{
    private readonly IConfiguration _configuration;

    public BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IDbConnection GetConnection()
    {
        string connectionString = _configuration["CatalogConnectionString"];
        NpgsqlConnection connection = new NpgsqlConnection(connectionString);
        connection.Open();
        return connection;
    }
}