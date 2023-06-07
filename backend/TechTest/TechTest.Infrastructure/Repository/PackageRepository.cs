using TechTest.Core.Entities;
using TechTest.Core.Interfaces;
using TechTest.Infrastructure.Persistence;
using TechTest.Infrastructure.Repository.Base;

namespace TechTest.Infrastructure.Repository
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository(TechTestContext context) : base(context)
        {

        }
    }
}
