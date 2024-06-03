using ENtityFrameWork_Test.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ENtityFrameWork_Test.Extensions
{
    public static class ServiceExtension
	{
		public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<TestContext>(option =>
			{
				string connectionString = "CONNECTION_STRING";
				option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
			});
		}

		public static void AddIdentityAndEFStore(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

			services.AddIdentity<User, IdentityRole>(
				opt =>
				{
					opt.SignIn.RequireConfirmedEmail = false;
					opt.SignIn.RequireConfirmedPhoneNumber = false;
					opt.SignIn.RequireConfirmedAccount = false;
				}
				)
					.AddEntityFrameworkStores<TestContext>()
					.AddDefaultTokenProviders();

			services.Configure<IdentityOptions>(options =>
			{
				// Password settings.
				options.Password.RequireDigit = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequiredLength = 6;
				options.Password.RequiredUniqueChars = 1;

				// User settings.
				options.User.AllowedUserNameCharacters =
				"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
				options.User.RequireUniqueEmail = false;

			});

			services.ConfigureApplicationCookie(options =>
			{
				options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

				options.Cookie = new CookieBuilder
				{
					Name = "IdentityCookie", 
					HttpOnly = false,
					SameSite = SameSiteMode.Strict, 
					IsEssential = true,
					Domain = "vetdestek.online",
					SecurePolicy = CookieSecurePolicy.None					
				};

				options.LoginPath = "/Account/Login";
				options.AccessDeniedPath = "/Account/AccessDenied";
				options.SlidingExpiration = true;
			});

		}

		public static async Task Seed(this IServiceCollection services, IConfiguration configuration, TestContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
		{
			if (!roleManager.Roles.Any())
			{
				await roleManager.CreateAsync(new IdentityRole("Admin"));
				await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
				await roleManager.CreateAsync(new IdentityRole("User"));

			}

			if (!context.Users.Any())
			{
				/*
				 User Seed Logic
			     Commented due Public Repo
				 */
			}

			if (!context.Animals.Any())
			{
				context.Animals.AddRange(new List<Animal>() { 
					new Animal() { Name = "Animal1"}, 
					new Animal() { Name = "Animal2"},
					new Animal() { Name = "Animal3"},
					new Animal() { Name = "Animal4"}
				});

				context.SaveChanges();
			}

			if(!context.Symptoms.Any())
			{
                context.Symptoms.AddRange(new List<Symptoms>() {
                    new Symptoms() { Name = "Symptom1" ,Description = "Desc1"},
                    new Symptoms() { Name = "Symptom2" ,Description = "Desc2"},
                    new Symptoms() { Name = "Symptom3", Description = "Desc3"},
                    new Symptoms() { Name = "Symptom4", Description = "Desc4"}
                });

                context.SaveChanges();
            }

            if (!context.Diseases.Any())
			{
                context.Diseases.AddRange(new List<Disease>() {
                    new Disease() { Name = "Diease1", Description = "Desc1", IsForSpesificBreeds=  false, Treatment="Treatment1"},
                    new Disease() { Name = "Diease2", Description = "Desc2", IsForSpesificBreeds=  false, Treatment="Treatment2"},
                    new Disease() { Name = "Diease3", Description = "Desc3", IsForSpesificBreeds = false, Treatment="Treatment3"},
                    new Disease() { Name = "Diease4", Description = "Desc4", IsForSpesificBreeds = false, Treatment="Treatment4"}
                });

                context.SaveChanges();
            }

            if (!context.DiseaseSymptoms.Any())
            {
				var diseases = context.Diseases.AsNoTracking().ToList();
				
				var symptoms = context.Symptoms.AsNoTracking().ToList();
				
				List<DiseaseSymptom> ds = new List<DiseaseSymptom>();

				for (int i = 0; i < diseases.Count; i++)
				{
					ds.Add(new DiseaseSymptom() { DiseaseId = diseases[i].Id, SymptomId = symptoms[i].Id });
				}

				ds.Add(new DiseaseSymptom() { DiseaseId = diseases[0].Id, SymptomId = symptoms[1].Id });
				ds.Add(new DiseaseSymptom() { DiseaseId = diseases[0].Id, SymptomId = symptoms[2].Id });

                context.DiseaseSymptoms.AddRange(ds);

                context.SaveChanges();
            }

			if (!context.AnimalDiseases.Any())
			{
                var diseases = context.Diseases.AsNoTracking().ToList();

                var animals = context.Animals.AsNoTracking().ToList();

                List<AnimalDisease> ad = new List<AnimalDisease>();

                for (int i = 0; i < diseases.Count; i++)
                {
                    ad.Add(new AnimalDisease() { DiseaseId = diseases[i].Id, AnimalId= animals[i].Id });
                }

                ad.Add(new AnimalDisease() { AnimalId = animals[0].Id, DiseaseId = diseases[1].Id });
                ad.Add(new AnimalDisease() { AnimalId = animals[0].Id, DiseaseId = diseases[2].Id });

                context.AnimalDiseases.AddRange(ad);

                context.SaveChanges();
            }
        }
	}
}
