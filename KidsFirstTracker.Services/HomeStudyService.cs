using KidsFirstTracker.Data;
using KidsFirstTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Services
{
    public class HomeStudyService
    {
        private readonly Guid _userId;
        public HomeStudyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateHomeStudy(HomeStudyCreate model)
        {
            var entity =
                new HomeStudy()
                {
                    OwnerId =_userId,
                    Parent1Name = model.Parent1Name,
                    Parent2Name = model.Parent2Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    TypeOfHomeStudy = model.TypeOfHomeStudy,
                    Agency = model.Agency
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.HomeStudies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<HomeStudyListItem> GetHomeStudy()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .HomeStudies
                        .Where(e => e.OwnerId ==_userId)
                        .Select(
                            e =>
                                new HomeStudyListItem
                                {
                                    HomeStudyId = e.HomeStudyId,
                                    Parent1Name = e.Parent1Name,
                                    Parent2Name = e.Parent2Name,
                                    TypeOfHomeStudy = e.TypeOfHomeStudy,
                                    Agency = e.Agency
                                }
                        );

                return query.ToArray();
            }
        }

        public HomeStudyDetail GetHomeStudyById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HomeStudies
                        .Single(e => e.HomeStudyId == id && e.OwnerId == _userId);
                return
                    new HomeStudyDetail
                    {
                        HomeStudyId = entity.HomeStudyId,
                        Parent1Name = entity.Parent1Name,
                        Parent2Name = entity.Parent2Name,
                        PhoneNumber = entity.PhoneNumber,
                        Email = entity.Email,
                        TypeOfHomeStudy = entity.TypeOfHomeStudy,
                        Agency = entity.Agency
                    };
            }
        
        }

        public bool UpdateHomeStudy(HomeStudyEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .HomeStudies
                        .Single(e => e.HomeStudyId == model.HomeStudyId && e.OwnerId == _userId);

                entity.Parent1Name = model.Parent1Name;
                entity.Parent2Name = model.Parent2Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Email = model.Email;
                entity.TypeOfHomeStudy = model.TypeOfHomeStudy;
                entity.Agency = model.Agency;
                    

                return ctx.SaveChanges() == 1;
            }
        
        }

    }
}
