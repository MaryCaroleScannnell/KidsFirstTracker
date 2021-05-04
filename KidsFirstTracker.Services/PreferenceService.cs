using KidsFirstTracker.Data;
using KidsFirstTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFirstTracker.Services
{
    public class PreferenceService
    {
        private readonly Guid _userId;
        public PreferenceService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePreferences(PreferencesCreate model)
        {
            var entity =
                new Preference()
                {
                    OwnerId = _userId,
                    GenderPreference = model.GenderPreference,
                    MinAge = model.MinAge,
                    MaxAge = model.MaxAge,
                    RacePreference = model.RacePreference,
                    AreTheyOkayWithOtherStates = model.AreTheyOkayWithOtherStates,
                    DomFamId = model.DomFamId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Preferences.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PreferencesListItem> GetPreferences()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Preferences
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PreferencesListItem
                                {
                                    DomFamId = e.DomFamId,
                                    GenderPreference = e.GenderPreference,
                                    MinAge = e.MinAge,
                                    MaxAge = e.MaxAge,
                                    RacePreference = e.RacePreference,
                                    AreTheyOkayWithOtherStates = e.AreTheyOkayWithOtherStates,
                                }
                        );

                return query.ToArray();
            }
        }

        public PreferencesDetail GetPreferenceById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Preferences
                        .Single(e => e.PreferenceId == id && e.OwnerId == _userId);
                return
                    new PreferencesDetail
                    {
                        PreferenceId = entity.PreferenceId,
                        DomFamId = entity.DomFamId,
                        GenderPreference = entity.GenderPreference,
                        MinAge = entity.MinAge,
                        MaxAge = entity.MaxAge,
                        RacePreference = entity.RacePreference,
                        AreTheyOkayWithOtherStates = entity.AreTheyOkayWithOtherStates,

                    };
            }


        }
        public bool DeletePreferences(int PreferencesId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Preferences
                        .Single(e => e.PreferenceId == PreferencesId && e.OwnerId == _userId);

                ctx.Preferences.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public bool UpdatePreferences(PreferencesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Preferences
                        .Single(e => e.PreferenceId == model.DomFamId && e.OwnerId == _userId);

                entity.GenderPreference = model.GenderPreference;
                entity.MinAge = model.MinAge;
                entity.MaxAge = model.MaxAge;
                entity.RacePreference = model.RacePreference;
                entity.AreTheyOkayWithOtherStates = model.AreTheyOkayWithOtherStates;
                entity.DomFamId = model.DomFamId;
                

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
