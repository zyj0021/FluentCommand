﻿using System;
using Microsoft.Data.SqlClient;
using Xunit;
using Xunit.Abstractions;

namespace FluentCommand.SqlServer.Tests
{
    [Collection(DatabaseCollection.CollectionName)]
    public abstract class DatabaseTestBase : IDisposable
    {
        protected DatabaseTestBase(ITestOutputHelper output, DatabaseFixture databaseFixture)
        {
            Output = output;
            Fixture = databaseFixture;
        }


        public ITestOutputHelper Output { get; }

        public DatabaseFixture Fixture { get; }


        protected IDataConfiguration GetConfiguration()
        {
            IDataConfiguration dataConfiguration  = new DataConfiguration(
                SqlClientFactory.Instance, 
                Fixture.ConnectionString,
                DataCache.Default, 
                Output.WriteLine);

            return dataConfiguration;
        }

        public void Dispose()
        {
            Fixture?.Report(Output);
        }
    }
}