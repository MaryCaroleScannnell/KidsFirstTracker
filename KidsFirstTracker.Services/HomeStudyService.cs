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
        public HomeStudyService()
        {

        }

        public bool CreateHomeStudy(HomeStudyCreate model)
        {
            var entity =
                new HomeStudy()
                {
                    
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

                        .Select(
                            e =>
                                new HomeStudyListItem
                                {
                                    HomeStudyId = e.HomeStudyId,
                                    Parent1Name = e.Parent1Name,
                                    Parent2Name = e.Parent2Name,
                                    PhoneNumber = e.PhoneNumber,
                                    Email = e.Email,
                                    TypeOfHomeStudy = e.TypeOfHomeStudy,
                                    Agency = e.Agency
                                }
                        );

                return query.ToArray();
            }
        }



    }
}
