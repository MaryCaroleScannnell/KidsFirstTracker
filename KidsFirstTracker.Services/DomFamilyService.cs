using KidsFirstTracker.Data;
using KidsFirstTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Services
{
    public class DomFamilyService  
    {
        public DomFamilyService()
        {
            
        }

        public bool CreateDomFamily(DomFamilyCreate model)
        {
            var entity =
                new DomFamily()
                {
                    
                    Parent1Name = model.Parent1Name,
                    Parent2Name = model.Parent2Name,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    IsHomeStudyDone = model.IsHomeStudyDone,
                    HomeStudyDate = model.HomeStudyDate
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.DomFamilies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<DomFamilyListItem> GetDomFamily()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .DomFamilies
                        
                        .Select(
                            e =>
                                new DomFamilyListItem
                                {
                                    DomFamId = e.DomFamId,
                                    Parent1Name = e.Parent1Name,
                                    Parent2Name = e.Parent2Name,
                                    PhoneNumber = e.PhoneNumber,
                                    Email = e.Email,
                                    IsHomeStudyDone = e.IsHomeStudyDone,
                                    HomeStudyDate = e.HomeStudyDate
                                }
                        );

                return query.ToArray();
            }
        }



    }
}
