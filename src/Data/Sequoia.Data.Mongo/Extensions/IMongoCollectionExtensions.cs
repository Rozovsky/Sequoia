using MongoDB.Driver;
using Sequoia.Data.Models;

namespace Sequoia.Data.Mongo.Extensions;

public static class IMongoCollectionExtensions
{
    public static async Task<Paged<TDocument>> AsPagedResult<TDocument>(
        this IMongoCollection<TDocument> collection,
        FilterDefinition<TDocument> filterDefinition,
        SortDefinition<TDocument> sortDefinition,
        int page,
        int pageSize) where TDocument : class
    {
        var countFacet = AggregateFacet.Create("count", PipelineDefinition<TDocument, AggregateCountResult>.Create([
            PipelineStageDefinitionBuilder.Count<TDocument>()
        ]));

        var dataFacet = AggregateFacet.Create("data", PipelineDefinition<TDocument, TDocument>.Create([
            PipelineStageDefinitionBuilder.Sort(sortDefinition),
            PipelineStageDefinitionBuilder.Skip<TDocument>((page - 1) * pageSize),
            PipelineStageDefinitionBuilder.Limit<TDocument>(pageSize)
        ]));

        var aggregation = await collection.Aggregate()
            .Match(filterDefinition)
            .Facet(countFacet, dataFacet)
            .ToListAsync();

        var counter = aggregation.First().Facets
            .First(x => x.Name == "count")
            .Output<AggregateCountResult>()
            .FirstOrDefault();

        var count = (counter == null) ? 0 : counter.Count;
        var totalPages = (int)Math.Ceiling((double)count / pageSize);

        var data = aggregation.First().Facets
            .First(x => x.Name == "data")
            .Output<TDocument>()
            .ToList();

        var result = new Paged<TDocument>
        {
            Page = page,
            PageSize = pageSize,
            PagesTotal = totalPages,
            Items = data,
            ItemsTotal = count
        };

        return result;
    }
}