using System.Threading.Tasks;
using AB.TwitterAPI.Helpers;
using AB.TwitterAPI.Interfaces;
namespace AB.TwitterAPI.Managers
{
    public class TwitterManager : IManager
    {        
        private HttpClientHelper _httpHelper;
        public TwitterManager(IHttpClient httpHelper) 
        {
            _httpHelper = (HttpClientHelper)httpHelper;
        }

        public TwitterManager()
        {
        }

        public async Task<object> Search()
        {
            var test = await _httpHelper.Get(new System.Uri("test"), "test", null);
            return new { test.StatusCode };
        }

        bool IManager.TryParse<T, T2>(ref T model, out T2 outModel)
        {
            throw new System.NotImplementedException();
        }
    }
}