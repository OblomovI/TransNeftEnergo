using TransNeftEnergo.Models;

namespace TransNeftEnergo
{
    public static class MockDb
    {
        public static void Initialize()
        {
            using (var context = new ApplicationDbContext())
            {
                var AllOrganization = context.Organizations;
                context.Organizations.RemoveRange(AllOrganization);
                context.SaveChanges();

                context.Organizations.Add(new Organization().Initialize() as Organization);
                context.SaveChanges();
            }
        }
    }
}
