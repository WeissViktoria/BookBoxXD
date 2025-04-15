using Domain.Repo;
using Microsoft.EntityFrameworkCore;
using Model.Configurations;
using Model.Entities;

namespace Domain.Interfaces;

public class BeziehungRepository: ARepository<BuchBeziehung_JT>
{
    public BeziehungRepository(IDbContextFactory<BuchContext> context) : base(context)
    {
    }
}