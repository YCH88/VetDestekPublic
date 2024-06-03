using ENtityFrameWork_Test.Extensions;
using ENtityFrameWork_Test.IServices;
using ENtityFrameWork_Test.Models.Home;
using Microsoft.EntityFrameworkCore;

namespace ENtityFrameWork_Test.Services
{
	public class SymptomService : ISymptomService
	{
		private readonly TestContext _dbContext;

		public SymptomService(TestContext testContext)
		{
			_dbContext = testContext;
		}

		public List<SymptomSearchDto> GetSymptoms()
		{
			var data = _dbContext.Symptoms.AsNoTracking().Select(x => new SymptomSearchDto()
			{
				Name = x.Name,
				Id = x.Id
			}).ToList();

			return data;
		}
	}
}
