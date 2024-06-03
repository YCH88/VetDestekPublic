using ENtityFrameWork_Test.Extensions;
using ENtityFrameWork_Test.Models;
using ENtityFrameWork_Test.Services;

namespace ENtityFrameWork_Test.IServices
{
    public interface ITestServices
    {
        public Task<Result<List<TestTable>>> FindAll();
    }
}
