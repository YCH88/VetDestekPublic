using ENtityFrameWork_Test.Extensions;
using ENtityFrameWork_Test.IServices;
using ENtityFrameWork_Test.Models;
using ENtityFrameWork_Test.Models.Home;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Linq;
using System.Net.WebSockets;

namespace ENtityFrameWork_Test.Services
{
	public class DiseaseService : IDiseaseService
	{
		private readonly TestContext _dbContext;

		public DiseaseService(TestContext testContext)
		{
			_dbContext = testContext;
		}

		public async Task<List<DiseaseListDto>> GetDiseaseList(int[] symptomIds, DataTablesResult dataTableDto)
		{
			var data = _dbContext.Diseases.AsNoTracking()
						 .Include(x => x.DiseaseSymptoms)
						 .Include(x => x.AnimalDisease)
						 .Select(x => new DiseaseListDto()
						 {
							 Animals = ConcatStringItemsWithComma(x.AnimalDisease.Select(x => x.Animal.Name).ToList()),
							 Name = x.Name,
							 Desc = x.Description,
							 Symptoms = ConcatStringItemsWithComma(x.DiseaseSymptoms.Select(x => x.Symptoms.Name).ToList()),
							 Treatment = x.Treatment,
						     SymptomId = x.DiseaseSymptoms.Select(x => x.Symptoms.Id).ToList()
						 })
						.AsQueryable();

			if (symptomIds.Length > 0 && symptomIds is not null)
				data = FilterSymptomIds(symptomIds, data.ToList());

			var totalCount = data.Count();

			data = data.Skip(dataTableDto.start * dataTableDto.length).Take(dataTableDto.length);

			if (dataTableDto.order is not null && dataTableDto.order.Count > 0)
			{
				var order = dataTableDto.order.First();
				if (order.dir is "asc")
					switch (order.column)
					{
						case 0:
							data = data.OrderBy(x => x.Name);
							break;
						case 1:
							data = data.OrderBy(x => x.Desc);
							break;
						case 4:
							data = data.OrderBy(x => x.Treatment);
							break;

						default:
							break;
					}

				if (order.dir is "desc")
					switch (order.column)
					{
						case 0:
							data = data.OrderByDescending(x => x.Name);
							break;
						case 1:
							data = data.OrderByDescending(x => x.Desc);
							break;
						case 4:
							data = data.OrderByDescending(x => x.Treatment);
							break;
						default:
							break;
					}
			}
			data.ToList().ForEach(x => x.TotalRecord = totalCount);

			return data.ToList();
		}

		private static string ConcatStringItemsWithComma(List<string> strings)
		{
			return string.Join(",", strings);
		}

		private IQueryable<DiseaseListDto> FilterSymptomIds(int[] symptoms,List<DiseaseListDto> diseaseListDtos)
		{
			var tempList = new List<DiseaseListDto>();
			
			for (int i = 0; i < diseaseListDtos.Count; i++)
			{
				var symptomIdList = diseaseListDtos[i].SymptomId;
				for (int j = 0; j < symptoms.Length; j++)
				{
					if(symptomIdList.Contains(symptoms[j]))
					{
						tempList.Add(diseaseListDtos[i]);
						break;
					}
				}
			}

			return tempList.AsQueryable();
		}
	}
}
