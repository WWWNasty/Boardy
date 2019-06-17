using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogicLayer.Objects.Dtos.Adverts.Search;
using DataAccessLayer.Abstraction.RepositoryInterfaces;
using DataAccessLayer.Data.EntityFramework;
using DataAccessLayer.Implementation.Repositories.Base;
using DataAccessLayer.Models.Entities;
using DataAccessLayer.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Implementation.Repositories
{
    public class AdvertRepository : RepositoryBase<Advert>, IAdvertRepository
    {
        public AdvertRepository(BoardyDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<Advert> GetAsync(int id)
        {
            Task<Advert> result = AdvertsQueryWithEverything()
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<ICollection<Advert>> GetAllAsync(SearchQuery filterQuery)
        {
            IQueryable<Advert> advertsQueryWithEverything = AdvertsQueryWithEverything();

            advertsQueryWithEverything = Filter(advertsQueryWithEverything, filterQuery);

            advertsQueryWithEverything = Sort(advertsQueryWithEverything, (SortingType)filterQuery.SortType);

            advertsQueryWithEverything = GetPage(advertsQueryWithEverything, filterQuery.CurrentPage, filterQuery.AdvertsPerPage);

            ICollection<Advert> result = await advertsQueryWithEverything.ToListAsync();

            return result;
        }

        public async Task<int> GetAdvertsAmountAsync(SearchQuery filterQuery)
        {
            IQueryable<Advert> advertsQueryWithEverything = AdvertsQueryWithEverything();

            advertsQueryWithEverything = Filter(advertsQueryWithEverything, filterQuery);

            return await advertsQueryWithEverything.CountAsync();
        }

        private IQueryable<Advert> Filter(IQueryable<Advert> dbQuery, SearchQuery filterQuery)
        {
            if (filterQuery.UserInfo != null)
            {
                switch ((AdvertsType)filterQuery.UserInfo.AdvertsType)
                {
                    case AdvertsType.Own:
                        dbQuery = dbQuery.Where(adv => adv.UserId == filterQuery.UserInfo.Id);
                        break;
                    case AdvertsType.Liked:
                        var likedAdverts = DbContext.Likes
                            .Where(like => like.UserId == filterQuery.UserInfo.Id)
                            .Select(like => like.Advert.Id);
                        dbQuery = dbQuery.Where(adv => likedAdverts.Contains(adv.Id));
                        break;
                    default:
                        break;
                }
            }

            if (!string.IsNullOrEmpty(filterQuery.AdvertSearchString))
            {
                dbQuery = dbQuery.Where(advert =>
                    advert.Name.Contains(filterQuery.AdvertSearchString)
                    || advert.Description.Contains(filterQuery.AdvertSearchString));
            }

            if (filterQuery.AdvertCategoryId.HasValue)
            {
                dbQuery = dbQuery.Where(advert => advert.SubCategoryId == filterQuery.AdvertCategoryId);
            }

            if (!string.IsNullOrEmpty(filterQuery.AdvertRegion))
            {
                dbQuery = dbQuery.Where(advert =>
                    advert.Address.City.Contains(filterQuery.AdvertRegion)
                    || advert.Address.Region.Contains(filterQuery.AdvertRegion));
            }

            if (filterQuery.PriceFilterMax.HasValue)
            {
                dbQuery = dbQuery.Where(advert => advert.Price <= filterQuery.PriceFilterMax);
            }

            if (filterQuery.PriceFilterMin.HasValue)
            {
                dbQuery = dbQuery.Where(advert => advert.Price >= filterQuery.PriceFilterMin);
            }

            return dbQuery;
        }

        private IQueryable<Advert> AdvertsQueryWithEverything()
        {
            var query = DbContext.Adverts.Include(advert => advert.AdvertComments)
                .Include(advert => advert.Address)
                .Include(advert => advert.AdvertImages)
                .Include(advert => advert.Likes)
                .Include(advert => advert.SubCategory)
                .ThenInclude(subcategory => subcategory.Parent);
            return query;
        }

        private IQueryable<Advert> Sort(IQueryable<Advert> query, SortingType sortingType)
        {
            switch (sortingType)
            {
                case SortingType.ByPriceAsc:
                    query = query.OrderBy(ad => ad.Price);
                    break;
                case SortingType.ByPriceDesc:
                    query = query.OrderByDescending(ad => ad.Price);
                    break;
                case SortingType.ByPublishDateAsc:
                    query = query.OrderBy(ad => ad.CreatedDate);
                    break;
                case SortingType.ByPublishDateDesc:
                    query = query.OrderByDescending(ad => ad.CreatedDate);
                    break;
                default:
                    break;
            }
            return query;
        }

        private IQueryable<Advert> GetPage(IQueryable<Advert> query, int PageNumber, int AdvertsPerPage)
        {
            if (query.Count() > AdvertsPerPage)
            {
                query = query
                .Skip(PageNumber * AdvertsPerPage)
                .Take(AdvertsPerPage);
            }
            return query;
        }
    }
}