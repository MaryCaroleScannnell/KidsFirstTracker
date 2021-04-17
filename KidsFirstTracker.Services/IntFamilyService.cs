using KidsFirstTracker.Data;
using KidsFirstTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Services
{
    public class IntFamilyService
    {
        private readonly Guid _userId;
        public IntFamilyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateIntFamily(IntFamilyCreate model)
        {
            var entity =
                new IntFamily()
                {
                    OwnerId = _userId,
                    Parent1Name = model.Parent1Name,
                    Parent2Name = model.Parent2Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Country = model.Country,
                    USCISExpiration = model.USCISExpiration
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IntFamilies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<IntFamilyListItem> GetIntFamily()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .IntFamilies
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new IntFamilyListItem
                                {
                                    IntFamId = e.IntFamId,
                                    Parent1Name = e.Parent1Name,
                                    Parent2Name = e.Parent2Name,
                                    Country = e.Country,
                                    USCISExpiration = e.USCISExpiration
                                }
                        );

                return query.ToArray();
            }
        }

        public IntFamilyDetail GetIntFamilyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .IntFamilies
                        .Single(e => e.IntFamId == id && e.OwnerId == _userId);
                return
                    new IntFamilyDetail
                    {
                        IntFamId = entity.IntFamId,
                        Parent1Name = entity.Parent1Name,
                        Parent2Name = entity.Parent2Name,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email,
                        Country = entity.Country,
                        USCISExpiration = entity.USCISExpiration
                    };
            }
        }

    }
}
