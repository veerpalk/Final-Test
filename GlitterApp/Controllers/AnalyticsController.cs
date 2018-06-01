using GlitterApp.BusinessLayer.BusinessLayerLogic;
using GlitterApp.SharedLayer.ViewModel;
using System.Web.Http;

namespace GlitterApp.Controllers
{
    /// <summary>
    /// Gets the Analytics data for website
    /// </summary>
    public class AnalyticsController : ApiController
    {
        
        // GET: api/Analytics/getAnalytics
        [HttpGet]
        public AnalyticsViewModel  getAnalytics()
        {
            //calls to the business layer to perform some logic
            AnalyticsBusinessLogic analyticsBL = new AnalyticsBusinessLogic();

            return (analyticsBL.getAnalytics());
           
        }

    }
}
