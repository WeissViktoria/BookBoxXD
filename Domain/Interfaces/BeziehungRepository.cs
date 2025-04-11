using Domain.Repo;
using Model.Configurations;
using Model.Entities;

namespace Domain.Interfaces;

public class BeziehungRepository: ARepository<BuchBeziehung_JT>
{
    public BeziehungRepository(BuchContext context) : base(context)
    {
    }
}