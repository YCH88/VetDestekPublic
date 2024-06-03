using ENtityFrameWork_Test.Models;
using ENtityFrameWork_Test.Models.Home;

namespace ENtityFrameWork_Test.IServices
{
    public interface IDiseaseService
    {
        Task<List<DiseaseListDto>> GetDiseaseList(int[] symptomIds, DataTablesResult dataTableDto);
    }
}
