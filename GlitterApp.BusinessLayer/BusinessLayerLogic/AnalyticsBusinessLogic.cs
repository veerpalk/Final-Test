using GlitterApp.DAL.Repository;
using GlitterApp.SharedLayer.ViewModel;

namespace GlitterApp.BusinessLayer.BusinessLayerLogic
{
    /// <summary>
    /// calss database for action
    /// </summary>
    public class AnalyticsBusinessLogic
    {
        public AnalyticsViewModel getAnalytics()
        {
 
                AnalyticsRepoLayer obj = new AnalyticsRepoLayer();
            return (obj.GetAnalytics());
           
        }

    }
}
