namespace Worker
{
    using ZenAchitecture.Domain.Common;
    using ZenAchitecture.Domain.Interfaces;

    public class CurrentUserPuppeteerService : ICurrentUserService
    {
        public string UserId => Constants.ServiceWorkerUser.Id;

        public string UserName => Constants.ServiceWorkerUser.Name;

        public string FacilitatorId => Constants.ServiceWorkerUser.FacilitatorId;

        public string UserMerchants => Constants.ServiceWorkerUser.Merchants;
    }
}
