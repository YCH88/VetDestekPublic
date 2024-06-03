using ENtityFrameWork_Test.Extensions;
using ENtityFrameWork_Test.IServices;
using ENtityFrameWork_Test.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ENtityFrameWork_Test.Services
{
    public sealed class TestServices:ITestServices
    {
        private readonly TestContext _dbContext;

        public TestServices(TestContext dbContext)
        {
                _dbContext = dbContext;
        }

        public async Task<Result<List<TestTable>>> FindAll()
        {
            try
            {
                var data = await _dbContext.TestTable.ToListAsync();
                return new Result<List<TestTable>>(true,"",data);
            }
            catch (Exception e)
            {
                return new Result<List<TestTable>>(false, e.Message, null);
            }
        }

    }
}
