﻿using System;
using System.Data.Entity;
using DAL.Interfaces;
using DAL.Interfaces.Users;
using Domain;
using Domain.People;
using NLog;

namespace DAL
{
    public class UOW : IUOW, IDisposable
    {
        private readonly NLog.ILogger _logger;
        private readonly string _instanceId = Guid.NewGuid().ToString();

        private IDbContext DbContext { get; set; }
        protected IEFRepositoryProvider RepositoryProvider { get; set; }

        public UOW(IEFRepositoryProvider repositoryProvider, IDbContext dbContext, ILogger logger)
        {
            _logger = logger;
            _logger.Debug("InstanceId: " + _instanceId);

            DbContext = dbContext;

            repositoryProvider.DbContext = dbContext;
            RepositoryProvider = repositoryProvider;
        }

        // UoW main feature - atomic commit at the end of work
        public void Commit()
        {
            ((DbContext)DbContext).SaveChanges();
        }

        public void RefreshAllEntities()
        {
            foreach (var entity in ((DbContext)DbContext).ChangeTracker.Entries())
            {
                entity.Reload();
            }
        }

        //standard repos
        public IEFRepository<ContactType> ContactTypes => GetStandardRepo<ContactType>();
        public IEFRepository<MultiLangString> MultiLangStrings => GetStandardRepo<MultiLangString>();
        public IEFRepository<Translation> Translations => GetStandardRepo<Translation>();

        // repo with custom methods
        // add it also in EFRepositoryFactories.cs, in method GetCustomFactories

        //public IUserRepository Users => GetRepo<IUserRepository>();
        //public IUserRoleRepository UserRoles => GetRepo<IUserRoleRepository>();
        //public IRoleRepository Roles => GetRepo<IRoleRepository>();
        //public IUserClaimRepository UserClaims => GetRepo<IUserClaimRepository>();
        //public IUserLoginRepository UserLogins => GetRepo<IUserLoginRepository>();
        public IPersonRepository People => GetRepo<IPersonRepository>();
        public IContactRepository Contacts => GetRepo<IContactRepository>();

        public IUserRepository Users => GetRepo<IUserRepository>();
        public IUserRoleRepository UserRoles => GetRepo<IUserRoleRepository>();
        public IRoleRepository Roles => GetRepo<IRoleRepository>();
        public IUserClaimRepository UserClaims => GetRepo<IUserClaimRepository>();
        public IUserLoginRepository UserLogins => GetRepo<IUserLoginRepository>();

        // calling standard EF repo provider
        private IEFRepository<T> GetStandardRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepositoryForEntityType<T>();
        }

        // calling custom repo provier
        private T GetRepo<T>() where T : class
        {
            return RepositoryProvider.GetRepository<T>();
        }

        // try to find repository
        public T GetRepository<T>() where T : class
        {
            var res = GetRepo<T>() ?? GetStandardRepo<T>() as T;
            if (res == null)
            {
                throw new NotImplementedException("No repository for type, " + typeof(T).FullName);
            }
            return res;
        }

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            _logger.Debug("InstanceId: " + _instanceId + " Disposing:" + disposing);
        }

        #endregion
    }
}