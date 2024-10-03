using DA_Management_Endpoint.Data;
using DA_Management_Endpoint.Models;
using DA_Management_Endpoint.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DA_Management_Endpoint.Repositories
{
    public class CatechistProfileRepository : Repository<CatechistProfile>, ICatechistProfileRepository
    {
        public CatechistProfileRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Profile> GetProfileByCatechistId(int catechistId)
        {
            try
            {
                Profile aggregatedProfile = new Profile();
                var profiles = await _context.CatechistProfiles
                                            .AsNoTracking()
                                            .Include(x => x.Profile)
                                            .Where(x => x.CatechistId == catechistId).ToListAsync();

                foreach (CatechistProfile catechistProfile in profiles)
                {
                    if (catechistProfile.Profile != null)
                    {
                        var profile = catechistProfile.Profile;
                        aggregatedProfile.P1 |= profile.P1;
                        aggregatedProfile.P2 |= profile.P2;
                        aggregatedProfile.P3 |= profile.P3;
                        aggregatedProfile.P4 |= profile.P4;
                        aggregatedProfile.P5 |= profile.P5;
                        aggregatedProfile.P6 |= profile.P6;
                        aggregatedProfile.P7 |= profile.P7;
                        aggregatedProfile.P8 |= profile.P8;
                        aggregatedProfile.P9 |= profile.P9;
                        aggregatedProfile.P10 |= profile.P10;
                        aggregatedProfile.P11 |= profile.P11;
                        aggregatedProfile.P12 |= profile.P12;
                        aggregatedProfile.P13 |= profile.P13;
                        aggregatedProfile.P14 |= profile.P14;
                        aggregatedProfile.P15 |= profile.P15;
                        aggregatedProfile.P16 |= profile.P16;
                        aggregatedProfile.P17 |= profile.P17;
                        aggregatedProfile.P18 |= profile.P18;
                        aggregatedProfile.P19 |= profile.P19;
                        aggregatedProfile.P20 |= profile.P20;
                        aggregatedProfile.P21 |= profile.P21;
                        aggregatedProfile.P22 |= profile.P22;
                        aggregatedProfile.P23 |= profile.P23;
                        aggregatedProfile.P24 |= profile.P24;
                    }
                }
                return aggregatedProfile;
            } catch (Exception ex) {
                throw ex;
            }
            
        }

        public async Task<bool> IsAllow(int userId, string role)
        {
            var profile = await GetProfileByCatechistId(userId);
            switch (role)
            {
                case "VIEW_ALL_STUDENTS":
                    return profile.P1;
                case "VIEW_STUDENTS_BY_BLOCK":
                    return profile.P2;
                case "VIEW_STUDENTS_BY_CLASS":
                    return profile.P3;
                case "EDIT_All_STUDENTS":
                    return profile.P4;
                case "EDIT_STUDENTS_BY_BLOCK":
                    return profile.P5;
                case "EDIT_STUDENTS_BY_CLASS":
                    return profile.P6;
                case "STUDENT_MANAGEMENT_ADD":
                    return profile.P7;
                case "STUDENT_MANAGEMENT_DELETE":
                    return profile.P8;
                case "STUDENT_MANAGEMENT_CLASS_ASSIGN":
                    return profile.P9;
                case "CATECHIST_MANAGEMENT_VIEW":
                    return profile.P10;
                case "CATECHIST_MANAGEMENT_ADD":
                    return profile.P11;
                case "CATECHIST_MANAGEMENT_DELETE":
                    return profile.P12;
                case "CATECHIST_MANAGEMENT_EDIT":
                    return profile.P13;
                case "CATECHIST_MANAGEMENT_CLASS_ASSIGN_ALL":
                    return profile.P14;
                case "CATECHIST_MANAGEMENT_CLASS_ASSIGN_BY_BLOCK":
                    return profile.P15;
                case "PROFILE_MANAGEMENT":
                    return profile.P16;
                case "PROFILE_ASSIGN":
                    return profile.P17;
                case "CLASS_MANAGEMENT_VIEW":
                    return profile.P18;
                case "CLASS_MANAGEMENT_ADD":
                    return profile.P19;
                case "CLASS_MANAGEMENT_DELETE":
                    return profile.P20;
                case "CLASS_MANAGEMENT_EDIT":
                    return profile.P21;
                case "REGISTRATION_SECTION_VIEW":
                    return profile.P22;
                case "REGISTRATION_SECTION_CREATE":
                    return profile.P23;
                case "DASKBOARD":
                    return profile.P24;
                default:
                    return false;
            }
        }
    }

}

